using org.apache.zookeeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                        buttonConnect.Text = "Disconnect";
                        m_closing = false;
                    }
                    else
                    {
                        if (m_closing)
                        {
                            MessageBox.Show("正在关闭", "提示");
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
                    MessageBox.Show(ex.Message, "异常");
                }
            }

            if (m_closing)
            {
                m_stateWatcher.OnEvent -= M_stateWatcher_OnEvent;
                try
                {
                    await m_zooKeeperClient.closeAsync();
                }
                catch (KeeperException ex)
                {
                    Log(ex.Message);
                }
                m_zooKeeperClient = null;
                buttonConnect.BackColor = SystemColors.Control;
                buttonConnect.Text = "Connect";
                treeViewNodes.Nodes.Clear();
            }
        }

        private void M_stateWatcher_OnEvent(WatchedEvent obj)
        {
            Color color = Color.Gray;
            Log(obj.getState().ToString());
            switch (obj.getState())
            {
                case Watcher.Event.KeeperState.ConnectedReadOnly:
                case Watcher.Event.KeeperState.SyncConnected:
                    color = Color.Green;
                    treeViewNodes.Invoke(new Action(async () => await LoadTree(null, "/", "/")));
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

        private async Task LoadTree(TreeNode parentTreeNode, string parentPath, string childPath)
        {
            string childAbsolutePath = String.Empty;

            try
            {
                childAbsolutePath = Combine(parentPath, childPath);
                if (parentTreeNode == null)
                {

                    treeViewNodes.Invoke(new Action(() =>
                    {
                        treeViewNodes.Nodes.Clear();
                        parentTreeNode = treeViewNodes.Nodes.Add(childAbsolutePath, childPath);
                    }));
                }
                var children = await m_zooKeeperClient.getChildrenAsync(childAbsolutePath);
                foreach (var child in children.Children)
                {
                    var childTreeNode = parentTreeNode.Nodes.Add(Combine(childAbsolutePath, child), child);
                    await LoadTree(childTreeNode, childAbsolutePath, child);
                }
            }
            catch (KeeperException ex)
            {
                Log($"{ex.Message} {childAbsolutePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "树加载异常");
            }
        }

        private async void treeViewNodes_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F5:
                    var selectedNode = treeViewNodes.SelectedNode;
                    await LoadTree(null, "/", "/");
                    SelecteNode(selectedNode.Name);
                    break;
            }
        }

        private void buttonAddAuth_Click(object sender, EventArgs e)
        {
            lock (m_zooKeeperClientLocker)
            {
                if (m_zooKeeperClient == null)
                {
                    MessageBox.Show("未连接", "提示");
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
                        }
                        catch (KeeperException ex)
                        {
                            Log(ex.Message);
                        }
                    }
                }
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_zooKeeperClient != null)
            {
                try
                {
                    await m_zooKeeperClient.closeAsync();
                }
                catch (KeeperException ex)
                {
                    Log(ex.Message);
                }
            }
        }

        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewNodes.SelectedNode;
            if (selectedNode != null)
            {
                NodeInfoForm nodeInfoForm = new NodeInfoForm();
                nodeInfoForm.NodeName = "NewNode";
                nodeInfoForm.Text = "NewNode";
                nodeInfoForm.ACLs = new List<org.apache.zookeeper.data.ACL>() { new org.apache.zookeeper.data.ACL(31, new org.apache.zookeeper.data.Id("world", "anyone")) };
                nodeInfoForm.ShowDialog();
                if (MessageBox.Show($"确认添加节点{nodeInfoForm.NodeName}？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        var data = nodeInfoForm.Data;
                        var acls = nodeInfoForm.ACLs;
                        string path = await m_zooKeeperClient.createAsync(Combine(selectedNode.Name, nodeInfoForm.NodeName), data, acls, nodeInfoForm.CreateMode);
                        selectedNode.Nodes.Add(path, GetNodeName(path));
                        Log($"添加成功 {path}");
                    }
                    catch (KeeperException ex)
                    {
                        Log($"{ex.Message} {Combine(selectedNode.Name, nodeInfoForm.NodeName)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "添加节点异常");
                    }
                }
            }
            else
            {
                MessageBox.Show("未选择节点", "提示");
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewNodes.SelectedNode;
            if (selectedNode != null)
            {
                if (MessageBox.Show($"确认删除节点{selectedNode.Text}？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        await m_zooKeeperClient.deleteAsync(selectedNode.Name);
                        SelecteNode(selectedNode.Parent.Name);
                        selectedNode.Parent?.Nodes.Remove(selectedNode);
                        Log($"删除成功 {selectedNode.Name}");
                    }
                    catch (KeeperException ex)
                    {
                        Log($"{ex.Message} {selectedNode.Name}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "删除节点异常");
                    }
                }
            }
            else
            {
                MessageBox.Show("未选择节点", "提示");
            }
        }

        private async void buttonInfo_Click(object sender, EventArgs e)
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
                    nodeInfoForm.Data = dataResult.Data;
                    nodeInfoForm.ACLs = aCLResult.Acls;
                    nodeInfoForm.Stat = aCLResult.Stat;
                    nodeInfoForm.ShowDialog();

                    bool dataChanged = true;
                    bool aclsChanged = true;
                    var data = nodeInfoForm.Data;
                    if (Convert.ToBase64String(dataResult.Data) == Convert.ToBase64String(data))
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
                        if (MessageBox.Show("是否要更新修改到zookeeper服务", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (dataChanged)
                            {
                                await m_zooKeeperClient.setDataAsync(selectedNode.Name, data);
                                Log($"Data更新成功 {selectedNode.Name}");
                            }

                            if (aclsChanged)
                            {
                                await m_zooKeeperClient.setACLAsync(selectedNode.Name, acls);
                                Log($"Acls更新成功 {selectedNode.Name}");
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
                    MessageBox.Show(ex.Message, "显示节点信息异常");
                }
            }
            else
            {
                MessageBox.Show("未选择节点", "提示");
            }
        }
    }
}
