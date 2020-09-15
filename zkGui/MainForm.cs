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
                await m_zooKeeperClient.closeAsync();
                m_zooKeeperClient = null;
                buttonConnect.BackColor = SystemColors.Control;
                buttonConnect.Text = "Connect";
            }
        }

        private async void M_stateWatcher_OnEvent(WatchedEvent obj)
        {
            Color color = Color.Gray;

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
            try
            {
                var childAbsolutePath = $"{parentPath.TrimEnd('/')}/{childPath.TrimStart('/')}";
                if (parentTreeNode == null)
                {
                    treeViewNodes.Invoke(new Action(() => parentTreeNode = treeViewNodes.Nodes.Add(childPath)));
                }
                var children = await m_zooKeeperClient.getChildrenAsync(childAbsolutePath);
                foreach (var child in children.Children)
                {
                    var childTreeNode = parentTreeNode.Nodes.Add(child);
                    await LoadTree(childTreeNode, childAbsolutePath, child);
                }
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
                    treeViewNodes.Nodes.Clear();
                    await LoadTree(null, "/", "/");
                    break;
            }
        }
    }
}
