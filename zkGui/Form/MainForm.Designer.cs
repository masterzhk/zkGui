namespace zkGui
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelConnectstring = new System.Windows.Forms.Label();
            this.textBoxConnectstring = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelSessionTimeout = new System.Windows.Forms.Label();
            this.textBoxSessionTimeout = new System.Windows.Forms.TextBox();
            this.treeViewNodes = new System.Windows.Forms.TreeView();
            this.buttonAddAuth = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.contextMenuStripLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.groupBoxNodes = new System.Windows.Forms.GroupBox();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.contextMenuStripLog.SuspendLayout();
            this.groupBoxConnection.SuspendLayout();
            this.groupBoxNodes.SuspendLayout();
            this.groupBoxLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelConnectstring
            // 
            this.labelConnectstring.AutoSize = true;
            this.labelConnectstring.Location = new System.Drawing.Point(6, 17);
            this.labelConnectstring.Name = "labelConnectstring";
            this.labelConnectstring.Size = new System.Drawing.Size(83, 12);
            this.labelConnectstring.TabIndex = 0;
            this.labelConnectstring.Text = "Connectstring";
            // 
            // textBoxConnectstring
            // 
            this.textBoxConnectstring.Location = new System.Drawing.Point(101, 14);
            this.textBoxConnectstring.Name = "textBoxConnectstring";
            this.textBoxConnectstring.Size = new System.Drawing.Size(669, 21);
            this.textBoxConnectstring.TabIndex = 1;
            this.textBoxConnectstring.Text = "localhost:2181";
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.SystemColors.Control;
            this.buttonConnect.Location = new System.Drawing.Point(695, 39);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelSessionTimeout
            // 
            this.labelSessionTimeout.AutoSize = true;
            this.labelSessionTimeout.Location = new System.Drawing.Point(6, 44);
            this.labelSessionTimeout.Name = "labelSessionTimeout";
            this.labelSessionTimeout.Size = new System.Drawing.Size(89, 12);
            this.labelSessionTimeout.TabIndex = 3;
            this.labelSessionTimeout.Text = "SessionTimeout";
            // 
            // textBoxSessionTimeout
            // 
            this.textBoxSessionTimeout.Location = new System.Drawing.Point(101, 41);
            this.textBoxSessionTimeout.Name = "textBoxSessionTimeout";
            this.textBoxSessionTimeout.Size = new System.Drawing.Size(507, 21);
            this.textBoxSessionTimeout.TabIndex = 4;
            this.textBoxSessionTimeout.Text = "40000";
            // 
            // treeViewNodes
            // 
            this.treeViewNodes.HideSelection = false;
            this.treeViewNodes.Location = new System.Drawing.Point(6, 49);
            this.treeViewNodes.Name = "treeViewNodes";
            this.treeViewNodes.Size = new System.Drawing.Size(764, 148);
            this.treeViewNodes.TabIndex = 5;
            this.treeViewNodes.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewNodes_BeforeCollapse);
            this.treeViewNodes.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewNodes_BeforeExpand);
            this.treeViewNodes.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewNodes_NodeMouseDoubleClick);
            this.treeViewNodes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeViewNodes_KeyUp);
            // 
            // buttonAddAuth
            // 
            this.buttonAddAuth.Location = new System.Drawing.Point(614, 39);
            this.buttonAddAuth.Name = "buttonAddAuth";
            this.buttonAddAuth.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAuth.TabIndex = 6;
            this.buttonAddAuth.Text = "AddAuth";
            this.buttonAddAuth.UseVisualStyleBackColor = true;
            this.buttonAddAuth.Click += new System.EventHandler(this.buttonAddAuth_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.ContextMenuStrip = this.contextMenuStripLog;
            this.textBoxLog.Location = new System.Drawing.Point(8, 20);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(762, 114);
            this.textBoxLog.TabIndex = 7;
            // 
            // contextMenuStripLog
            // 
            this.contextMenuStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.contextMenuStripLog.Name = "contextMenuStripLog";
            this.contextMenuStripLog.Size = new System.Drawing.Size(129, 92);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.labelConnectstring);
            this.groupBoxConnection.Controls.Add(this.textBoxConnectstring);
            this.groupBoxConnection.Controls.Add(this.buttonAddAuth);
            this.groupBoxConnection.Controls.Add(this.labelSessionTimeout);
            this.groupBoxConnection.Controls.Add(this.textBoxSessionTimeout);
            this.groupBoxConnection.Controls.Add(this.buttonConnect);
            this.groupBoxConnection.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(776, 72);
            this.groupBoxConnection.TabIndex = 8;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "连接管理";
            // 
            // groupBoxNodes
            // 
            this.groupBoxNodes.Controls.Add(this.buttonInfo);
            this.groupBoxNodes.Controls.Add(this.buttonCreate);
            this.groupBoxNodes.Controls.Add(this.buttonDelete);
            this.groupBoxNodes.Controls.Add(this.treeViewNodes);
            this.groupBoxNodes.Location = new System.Drawing.Point(12, 90);
            this.groupBoxNodes.Name = "groupBoxNodes";
            this.groupBoxNodes.Size = new System.Drawing.Size(776, 202);
            this.groupBoxNodes.TabIndex = 9;
            this.groupBoxNodes.TabStop = false;
            this.groupBoxNodes.Text = "节点管理";
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(168, 20);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonInfo.TabIndex = 8;
            this.buttonInfo.Text = "Info";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(6, 20);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(87, 20);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.textBoxLog);
            this.groupBoxLog.Location = new System.Drawing.Point(12, 298);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(776, 140);
            this.groupBoxLog.TabIndex = 10;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "日志输出";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.groupBoxNodes);
            this.Controls.Add(this.groupBoxConnection);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainForm";
            this.Text = "zkGui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStripLog.ResumeLayout(false);
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.groupBoxNodes.ResumeLayout(false);
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelConnectstring;
        private System.Windows.Forms.TextBox textBoxConnectstring;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelSessionTimeout;
        private System.Windows.Forms.TextBox textBoxSessionTimeout;
        private System.Windows.Forms.TreeView treeViewNodes;
        private System.Windows.Forms.Button buttonAddAuth;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.GroupBox groupBoxNodes;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLog;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}

