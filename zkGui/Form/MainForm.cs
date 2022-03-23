using org.apache.zookeeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zkGui
{
    public partial class MainForm : Form
    {
        private object m_zooKeeperClientLocker = new object();
        private bool m_closing = false;
        private ZooKeeper m_zooKeeperClient;
        private StateWatcher m_stateWatcher;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var filePath = GetConfigFilePath();
                if (File.Exists(filePath))
                {
                    var appConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<AppConfig>(File.ReadAllText(filePath));
                    if (appConfig != null)
                    {
                        textBoxConnectstring.Text = appConfig.Connectstring;
                        textBoxSessionTimeout.Text = appConfig.SessionTimeout.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var filePath = GetConfigFilePath();
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                Int32.TryParse(textBoxSessionTimeout.Text, out int sessionTimeOut);

                File.WriteAllText(filePath, Newtonsoft.Json.JsonConvert.SerializeObject(new AppConfig()
                {
                    Connectstring = textBoxConnectstring.Text,
                    SessionTimeout = sessionTimeOut,
                }));
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }

            if (m_zooKeeperClient != null)
            {
                try
                {
                    await m_zooKeeperClient.closeAsync();
                }
                catch (Exception ex)
                {
                    Log(ex.Message); // 这里记录了也没用^_^
                }
            }
        }

        private string GetConfigFilePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create), Text, "appconfig.json");
        }

        private void Log(string message)
        {
            textBoxLog.Invoke(new Action(() =>
            {
                textBoxLog.AppendText($"{DateTime.Now.ToString()} : {message}\r\n");
            }));
        }

        private string Combine(string parentPath, string childPath)
        {
            return $"{parentPath.TrimEnd('/')}/{childPath.TrimStart('/')}";
        }

        private string GetNodeName(string path)
        {
            return path.Split('/').LastOrDefault();
        }

        private void SelecteNode(string name)
        {
            treeViewNodes.SelectedNode = treeViewNodes.Nodes.Find(name, true).FirstOrDefault();
        }

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            lock (m_zooKeeperClientLocker)
            {
                try
                {
                    if (m_zooKeeperClient == null)
                    {
                        string connectstring = textBoxConnectstring.Text;
                        Int32.TryParse(textBoxSessionTimeout.Text, out int sessionTimeout);
                        m_stateWatcher = new StateWatcher();
                        m_stateWatcher.OnEvent += M_stateWatcher_OnEvent;
                        m_zooKeeperClient = new ZooKeeper(connectstring, sessionTimeout, m_stateWatcher);
                        Log("Connecting...");
                        buttonConnect.Text = "Disconnect";
                        m_closing = false;
                    }
                    else
                    {
                        if (m_closing)
                        {
                            MessageBox.Show("Disconnecting...", "Info");
                            return;
                        }
                        else
                        {
                            m_closing = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

            if (m_closing)
            {
                m_stateWatcher.OnEvent -= M_stateWatcher_OnEvent;
                try
                {
                    Log("Disconnecting...");
                    await m_zooKeeperClient.closeAsync();
                }
                catch (KeeperException ex)
                {
                    Log(ex.Message);
                }
                Log("Disconnected.");
                m_zooKeeperClient = null;
                buttonConnect.BackColor = SystemColors.Control;
                buttonConnect.Text = "Connect";
                treeViewNodes.Nodes.Clear();
            }
        }

        private void M_stateWatcher_OnEvent(WatchedEvent obj)
        {
            try
            {
                Color color = Color.Gray;
                Log(obj.getState().ToString());
                switch (obj.getState())
                {
                    case Watcher.Event.KeeperState.ConnectedReadOnly:
                    case Watcher.Event.KeeperState.SyncConnected:
                        color = Color.Green;
                        treeViewNodes.Invoke(new Action(async () =>
                        {
                            treeViewNodes.Nodes.Clear();
                            Log("Loading tree.");
                            await LoadTree(treeViewNodes.Nodes.Add("/", "/"));
                            Log("Tree loaded.");
                        }));
                        break;

                    case Watcher.Event.KeeperState.Disconnected:
                        color = Color.Gray;
                        break;

                    case Watcher.Event.KeeperState.Expired:
                        color = Color.Red;
                        break;

                    case Watcher.Event.KeeperState.AuthFailed:
                        color = Color.Yellow;
                        break;
                }

                buttonConnect.Invoke(new Action(() => { buttonConnect.BackColor = color; }));
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private async Task LoadTree(TreeNode parentTreeNode, bool recursive = false)
        {
            try
            {
                var children = await m_zooKeeperClient.getChildrenAsync(parentTreeNode.Name);
                foreach (var child in children.Children)
                {
                    var childTreeNode = new TreeNode() { Name = Combine(parentTreeNode.Name, child), Text = child, };
                    await LoadTree(childTreeNode, true);
                    parentTreeNode.Nodes.Add(childTreeNode);
                }
            }
            catch (BreakException ex)
            {
                if (recursive)
                {
                    throw ex;
                }
                else
                {
                    Log(ex.Message);
                }
            }
            catch (KeeperException.SessionExpiredException ex)
            {
                throw new BreakException("Break due to session expired.", ex);
            }
            catch (KeeperException ex)
            {
                Log($"{ex.Message} {parentTreeNode.Name}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private async void treeViewNodes_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyData)
                {
                    case Keys.F5:
                        if (m_zooKeeperClient == null)
                        {
                            MessageBox.Show("No Connection.", "Info");
                            break;
                        }
                        var selectedNode = treeViewNodes.SelectedNode;
                        if (selectedNode == null)
                        {
                            treeViewNodes.Nodes.Clear();
                            Log("Loading tree.");
                            await LoadTree(treeViewNodes.Nodes.Add("/", "/"));
                            Log("Tree loaded.");
                        }
                        else
                        {
                            selectedNode.Nodes.Clear();
                            await LoadTree(selectedNode);
                        }
                        Log("Refreshed.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void buttonAddAuth_Click(object sender, EventArgs e)
        {
            lock (m_zooKeeperClientLocker)
            {
                if (m_zooKeeperClient == null)
                {
                    MessageBox.Show("No Connection.", "Info");
                }
                else
                {
                    AuthInfoForm authInfoForm = new AuthInfoForm();
                    var dialogResult = authInfoForm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        try
                        {
                            m_zooKeeperClient.addAuthInfo(authInfoForm.Scheme, authInfoForm.Auth);
                            Log("Auth added.");
                        }
                        catch (KeeperException ex)
                        {
                            Log(ex.Message);
                        }
                    }
                }
            }
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            if (m_zooKeeperClient == null)
            {
                MessageBox.Show("No Connection.", "Info");
                return;
            }

            var selectedNode = treeViewNodes.SelectedNode;
            if (selectedNode != null)
            {
                NodeInfoForm nodeInfoForm = new NodeInfoForm();
                nodeInfoForm.NodeName = "NewNode";
                nodeInfoForm.Text = "NewNode";
                nodeInfoForm.ACLs = new List<org.apache.zookeeper.data.ACL>() { new org.apache.zookeeper.data.ACL(31, new org.apache.zookeeper.data.Id("world", "anyone")) };
                nodeInfoForm.ShowDialog();
                if (MessageBox.Show($"Are You Sure To Add {nodeInfoForm.NodeName}？", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        var data = nodeInfoForm.Data;
                        var acls = nodeInfoForm.ACLs;
                        string path = await m_zooKeeperClient.createAsync(Combine(selectedNode.Name, nodeInfoForm.NodeName), data, acls, nodeInfoForm.CreateMode);
                        selectedNode.Nodes.Add(path, GetNodeName(path));
                        Log($"Added {path}.");
                    }
                    catch (KeeperException ex)
                    {
                        Log($"{ex.Message} {Combine(selectedNode.Name, nodeInfoForm.NodeName)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("No Node Selected.", "Info");
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewNodes.SelectedNode;
            if (selectedNode != null)
            {
                if (MessageBox.Show($"Are You Sure To Delete {selectedNode.Text}？", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        await m_zooKeeperClient.deleteAsync(selectedNode.Name);
                        SelecteNode(selectedNode.Parent.Name);
                        selectedNode.Parent?.Nodes.Remove(selectedNode);
                        Log($"Deleted {selectedNode.Name}.");
                    }
                    catch (KeeperException ex)
                    {
                        Log($"{ex.Message} {selectedNode.Name}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("No Node Selected.", "Info");
            }
        }

        private async void buttonInfo_Click(object sender, EventArgs e)
        {
            await ShowNodeInfo();
        }

        private async Task ShowNodeInfo()
        {
            var selectedNode = treeViewNodes.SelectedNode;
            if (selectedNode != null)
            {
                try
                {
                    var dataResult = await m_zooKeeperClient.getDataAsync(selectedNode.Name);
                    var aCLResult = await m_zooKeeperClient.getACLAsync(selectedNode.Name);
                    NodeInfoForm nodeInfoForm = new NodeInfoForm();
                    nodeInfoForm.NodeName = selectedNode.Text;
                    nodeInfoForm.Text = selectedNode.Name;
                    nodeInfoForm.Data = dataResult.Data ?? (new byte[0]);
                    nodeInfoForm.ACLs = aCLResult.Acls;
                    nodeInfoForm.Stat = aCLResult.Stat;
                    nodeInfoForm.ShowDialog();

                    bool dataChanged = true;
                    bool aclsChanged = true;
                    var data = nodeInfoForm.Data;
                    if (Convert.ToBase64String(dataResult.Data ?? (new byte[0])) == Convert.ToBase64String(data))
                    {
                        dataChanged = false;
                    }

                    var acls = nodeInfoForm.ACLs;
                    if (aCLResult.Acls.Count == acls.Count && aCLResult.Acls.All(acl => acls.Exists(i => i.getPerms() == acl.getPerms() && i.getId().getScheme() == acl.getId().getScheme() && i.getId().getId() == acl.getId().getId())))
                    {
                        aclsChanged = false;
                    }

                    if (dataChanged || aclsChanged)
                    {
                        if (MessageBox.Show("Do You Want To Update The Modification", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            if (dataChanged)
                            {
                                await m_zooKeeperClient.setDataAsync(selectedNode.Name, data);
                                Log($"Data seted {selectedNode.Name}.");
                            }

                            if (aclsChanged)
                            {
                                await m_zooKeeperClient.setACLAsync(selectedNode.Name, acls);
                                Log($"ACL seted {selectedNode.Name}.");
                            }
                        }
                    }
                }
                catch (KeeperException ex)
                {
                    Log($"{ex.Message} {selectedNode.Name}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("No Node Selected.", "Info");
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxLog.Focus();
            textBoxLog.SelectAll();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxLog.Copy();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "zkGui.log";
            openFileDialog.CheckFileExists = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.AppendAllText(openFileDialog.FileName, textBoxLog.Text);
                Process.Start(openFileDialog.FileName);
            }
        }

        private async void treeViewNodes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var selectedNode = treeViewNodes.SelectedNode;
            if (selectedNode != null)
            {
                if (selectedNode.Nodes == null || selectedNode.Nodes.Count == 0)
                {
                    await ShowNodeInfo();
                }
                else if (Control.ModifierKeys == Keys.Control)
                {
                    await ShowNodeInfo();
                }
            }
        }

        private void treeViewNodes_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                e.Cancel = true;
            }
        }

        private void treeViewNodes_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                e.Cancel = true;
            }
        }
    }
}
