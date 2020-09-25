using Newtonsoft.Json;
using org.apache.zookeeper;
using org.apache.zookeeper.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static org.apache.zookeeper.ZooDefs;

namespace zkGui
{
    public partial class NodeInfoForm : Form
    {
        public string NodeName
        {
            get
            {
                return textBoxNodeName.Text;
            }
            set
            {
                textBoxNodeName.Text = value;
            }
        }

        private byte[] m_Data;
        public byte[] Data
        {
            get
            {
                switch (comboBoxFormat.Text)
                {
                    case "Base64":
                        return Convert.FromBase64String(textBoxData.Text);
                    default:
                        return Encoding.GetEncoding(comboBoxEncoding.Text).GetBytes(textBoxData.Text);
                }
            }
            set
            {
                m_Data = value;

                switch (comboBoxFormat.Text)
                {
                    case "Base64":
                        textBoxData.Text = Convert.ToBase64String(value);
                        break;
                    default:
                        textBoxData.Text = Encoding.GetEncoding(comboBoxEncoding.Text).GetString(value);
                        break;
                }
            }
        }

        public List<ACL> ACLs
        {
            get
            {
                List<ACL> result = new List<ACL>();

                foreach (DataGridViewRow row in dataGridViewAcls.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        result.Add(
                            new ACL(Convert.ToInt32(row.Cells[2].Value) * (int)Perms.READ
                            + Convert.ToInt32(row.Cells[3].Value) * (int)Perms.WRITE
                            + Convert.ToInt32(row.Cells[4].Value) * (int)Perms.CREATE
                            + Convert.ToInt32(row.Cells[5].Value) * (int)Perms.DELETE
                            + Convert.ToInt32(row.Cells[6].Value) * (int)Perms.ADMIN,
                            new Id(row.Cells[0].Value?.ToString(), row.Cells[1].Value?.ToString())));
                    }
                }

                return result;
            }
            set
            {
                foreach (var acl in value)
                {
                    dataGridViewAcls.Rows.Add(
                        acl.getId().getScheme(),
                        acl.getId().getId(),
                        (acl.getPerms() & (int)Perms.READ) == (int)Perms.READ,
                        (acl.getPerms() & (int)Perms.WRITE) == (int)Perms.WRITE,
                        (acl.getPerms() & (int)Perms.CREATE) == (int)Perms.CREATE,
                        (acl.getPerms() & (int)Perms.DELETE) == (int)Perms.DELETE,
                        (acl.getPerms() & (int)Perms.ADMIN) == (int)Perms.ADMIN);
                }
            }
        }

        private Stat m_Stat;
        public Stat Stat
        {
            set
            {
                m_Stat = value;
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "czxid", value.getCzxid().ToString() }.ToArray()));
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "mzxid", value.getMzxid().ToString() }.ToArray()));
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "pzxid", value.getPzxid().ToString() }.ToArray()));
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "ctime", (this.checkBoxLocaltime.Checked ? new DateTime(1970, 1, 1).AddMilliseconds(value.getCtime()).ToLocalTime() : new DateTime(1970, 1, 1).AddMilliseconds(value.getCtime())).ToString() }.ToArray()));
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "mtime", (this.checkBoxLocaltime.Checked ? new DateTime(1970, 1, 1).AddMilliseconds(value.getMtime()).ToLocalTime() : new DateTime(1970, 1, 1).AddMilliseconds(value.getMtime())).ToString() }.ToArray()));
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "version", value.getVersion().ToString() }.ToArray()));
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "cversion", value.getCversion().ToString() }.ToArray()));
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "aversion", value.getAversion().ToString() }.ToArray()));
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "ephemeralOwner", value.getEphemeralOwner().ToString() }.ToArray()));
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "dataLength", value.getDataLength().ToString() }.ToArray()));
                listViewStat.Items.Add(new ListViewItem(new List<string>() { "numChildren", value.getNumChildren().ToString() }.ToArray()));
                comboBoxCreateMode.Text = value.getEphemeralOwner() == 0 ? "PERSISTENT" : "EPHEMERAL";
            }
        }

        public CreateMode CreateMode
        {
            get
            {
                switch (comboBoxCreateMode.Text)
                {
                    case "PERSISTENT_SEQUENTIAL":
                        return CreateMode.PERSISTENT_SEQUENTIAL;

                    case "EPHEMERAL":
                        return CreateMode.EPHEMERAL;

                    case "EPHEMERAL_SEQUENTIAL":
                        return CreateMode.EPHEMERAL_SEQUENTIAL;

                    default:
                        return CreateMode.PERSISTENT;
                }
            }
        }

        public NodeInfoForm()
        {
            InitializeComponent();
        }

        private void checkBoxLocaltime_CheckedChanged(object sender, EventArgs e)
        {
            var listViewItemCtime = listViewStat.FindItemWithText("ctime");
            if (listViewItemCtime != null)
            {
                listViewItemCtime.SubItems[1].Text = (this.checkBoxLocaltime.Checked ? new DateTime(1970, 1, 1).AddMilliseconds(m_Stat.getCtime()).ToLocalTime() : new DateTime(1970, 1, 1).AddMilliseconds(m_Stat.getCtime())).ToString();
            }
            var listViewItemMtime = listViewStat.FindItemWithText("mtime");
            if (listViewItemMtime != null)
            {
                listViewItemMtime.SubItems[1].Text = (this.checkBoxLocaltime.Checked ? new DateTime(1970, 1, 1).AddMilliseconds(m_Stat.getMtime()).ToLocalTime() : new DateTime(1970, 1, 1).AddMilliseconds(m_Stat.getMtime())).ToString();
            }
        }

        private void textBoxData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    textBoxData.Text = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(textBoxData.Text), Formatting.Indented);
                }
                catch
                {
                    // 美化失败
                }
            }
        }

        private void comboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data = m_Data;
        }

        private void comboBoxEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data = m_Data;
        }

        private void textBoxData_Leave(object sender, EventArgs e)
        {
            try
            {
                m_Data = Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ToolStripMenuItemDigestHelper_Click(object sender, EventArgs e)
        {
            DigestHelperForm digestHelperForm = new DigestHelperForm();
            digestHelperForm.Show();
        }
    }
}
