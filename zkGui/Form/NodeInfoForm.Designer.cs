namespace zkGui
{
    partial class NodeInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.labelNodeName = new System.Windows.Forms.Label();
            this.textBoxNodeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.labelFormat = new System.Windows.Forms.Label();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.tabPageAcl = new System.Windows.Forms.TabPage();
            this.dataGridViewAcls = new System.Windows.Forms.DataGridView();
            this.ColumnScheme = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPermRead = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPermWrite = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPermCreate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPermDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPermAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPageStat = new System.Windows.Forms.TabPage();
            this.checkBoxLocaltime = new System.Windows.Forms.CheckBox();
            this.listViewStat = new System.Windows.Forms.ListView();
            this.columnHeaderField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageOther = new System.Windows.Forms.TabPage();
            this.labelCreateMode = new System.Windows.Forms.Label();
            this.comboBoxCreateMode = new System.Windows.Forms.ComboBox();
            this.contextMenuStripAcl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemDigestHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.tabPageAcl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAcls)).BeginInit();
            this.tabPageStat.SuspendLayout();
            this.tabPageOther.SuspendLayout();
            this.contextMenuStripAcl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageData);
            this.tabControl.Controls.Add(this.tabPageAcl);
            this.tabControl.Controls.Add(this.tabPageStat);
            this.tabControl.Controls.Add(this.tabPageOther);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(560, 337);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.labelNodeName);
            this.tabPageData.Controls.Add(this.textBoxNodeName);
            this.tabPageData.Controls.Add(this.label1);
            this.tabPageData.Controls.Add(this.comboBoxEncoding);
            this.tabPageData.Controls.Add(this.labelFormat);
            this.tabPageData.Controls.Add(this.comboBoxFormat);
            this.tabPageData.Controls.Add(this.textBoxData);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(552, 311);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // labelNodeName
            // 
            this.labelNodeName.AutoSize = true;
            this.labelNodeName.Location = new System.Drawing.Point(6, 9);
            this.labelNodeName.Name = "labelNodeName";
            this.labelNodeName.Size = new System.Drawing.Size(53, 12);
            this.labelNodeName.TabIndex = 6;
            this.labelNodeName.Text = "NodeName";
            // 
            // textBoxNodeName
            // 
            this.textBoxNodeName.Location = new System.Drawing.Point(65, 6);
            this.textBoxNodeName.Name = "textBoxNodeName";
            this.textBoxNodeName.Size = new System.Drawing.Size(100, 21);
            this.textBoxNodeName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Encoding";
            // 
            // comboBoxEncoding
            // 
            this.comboBoxEncoding.FormattingEnabled = true;
            this.comboBoxEncoding.Items.AddRange(new object[] {
            "UTF-8",
            "GB18030"});
            this.comboBoxEncoding.Location = new System.Drawing.Point(413, 6);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(121, 20);
            this.comboBoxEncoding.TabIndex = 3;
            this.comboBoxEncoding.Text = "UTF-8";
            this.comboBoxEncoding.SelectedIndexChanged += new System.EventHandler(this.comboBoxEncoding_SelectedIndexChanged);
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Location = new System.Drawing.Point(171, 9);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(41, 12);
            this.labelFormat.TabIndex = 2;
            this.labelFormat.Text = "Format";
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "Plain Text",
            "Base64"});
            this.comboBoxFormat.Location = new System.Drawing.Point(218, 6);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFormat.TabIndex = 1;
            this.comboBoxFormat.Text = "Plain Text";
            this.comboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormat_SelectedIndexChanged);
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(6, 32);
            this.textBoxData.Multiline = true;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxData.Size = new System.Drawing.Size(540, 273);
            this.textBoxData.TabIndex = 0;
            this.textBoxData.Leave += new System.EventHandler(this.textBoxData_Leave);
            this.textBoxData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxData_MouseDoubleClick);
            // 
            // tabPageAcl
            // 
            this.tabPageAcl.Controls.Add(this.dataGridViewAcls);
            this.tabPageAcl.Location = new System.Drawing.Point(4, 22);
            this.tabPageAcl.Name = "tabPageAcl";
            this.tabPageAcl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAcl.Size = new System.Drawing.Size(552, 311);
            this.tabPageAcl.TabIndex = 1;
            this.tabPageAcl.Text = "Acl";
            this.tabPageAcl.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAcls
            // 
            this.dataGridViewAcls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAcls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnScheme,
            this.ColumnId,
            this.ColumnPermRead,
            this.ColumnPermWrite,
            this.ColumnPermCreate,
            this.ColumnPermDelete,
            this.ColumnPermAdmin});
            this.dataGridViewAcls.ContextMenuStrip = this.contextMenuStripAcl;
            this.dataGridViewAcls.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewAcls.Name = "dataGridViewAcls";
            this.dataGridViewAcls.RowTemplate.Height = 23;
            this.dataGridViewAcls.Size = new System.Drawing.Size(540, 299);
            this.dataGridViewAcls.TabIndex = 0;
            // 
            // ColumnScheme
            // 
            this.ColumnScheme.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColumnScheme.HeaderText = "Scheme";
            this.ColumnScheme.Items.AddRange(new object[] {
            "world",
            "auth",
            "digest",
            "ip",
            "x509"});
            this.ColumnScheme.Name = "ColumnScheme";
            this.ColumnScheme.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnScheme.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnScheme.Width = 60;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Width = 180;
            // 
            // ColumnPermRead
            // 
            this.ColumnPermRead.HeaderText = "Read";
            this.ColumnPermRead.Name = "ColumnPermRead";
            this.ColumnPermRead.Width = 50;
            // 
            // ColumnPermWrite
            // 
            this.ColumnPermWrite.HeaderText = "Write";
            this.ColumnPermWrite.Name = "ColumnPermWrite";
            this.ColumnPermWrite.Width = 50;
            // 
            // ColumnPermCreate
            // 
            this.ColumnPermCreate.HeaderText = "Create";
            this.ColumnPermCreate.Name = "ColumnPermCreate";
            this.ColumnPermCreate.Width = 50;
            // 
            // ColumnPermDelete
            // 
            this.ColumnPermDelete.HeaderText = "Delete";
            this.ColumnPermDelete.Name = "ColumnPermDelete";
            this.ColumnPermDelete.Width = 50;
            // 
            // ColumnPermAdmin
            // 
            this.ColumnPermAdmin.HeaderText = "Admin";
            this.ColumnPermAdmin.Name = "ColumnPermAdmin";
            this.ColumnPermAdmin.Width = 50;
            // 
            // tabPageStat
            // 
            this.tabPageStat.Controls.Add(this.checkBoxLocaltime);
            this.tabPageStat.Controls.Add(this.listViewStat);
            this.tabPageStat.Location = new System.Drawing.Point(4, 22);
            this.tabPageStat.Name = "tabPageStat";
            this.tabPageStat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStat.Size = new System.Drawing.Size(552, 311);
            this.tabPageStat.TabIndex = 2;
            this.tabPageStat.Text = "Stat";
            this.tabPageStat.UseVisualStyleBackColor = true;
            // 
            // checkBoxLocaltime
            // 
            this.checkBoxLocaltime.AutoSize = true;
            this.checkBoxLocaltime.Checked = true;
            this.checkBoxLocaltime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLocaltime.Location = new System.Drawing.Point(6, 6);
            this.checkBoxLocaltime.Name = "checkBoxLocaltime";
            this.checkBoxLocaltime.Size = new System.Drawing.Size(78, 16);
            this.checkBoxLocaltime.TabIndex = 2;
            this.checkBoxLocaltime.Text = "LocalTime";
            this.checkBoxLocaltime.UseVisualStyleBackColor = true;
            this.checkBoxLocaltime.CheckedChanged += new System.EventHandler(this.checkBoxLocaltime_CheckedChanged);
            // 
            // listViewStat
            // 
            this.listViewStat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderField,
            this.columnHeaderValue});
            this.listViewStat.GridLines = true;
            this.listViewStat.HideSelection = false;
            this.listViewStat.Location = new System.Drawing.Point(6, 28);
            this.listViewStat.Name = "listViewStat";
            this.listViewStat.Size = new System.Drawing.Size(540, 277);
            this.listViewStat.TabIndex = 1;
            this.listViewStat.UseCompatibleStateImageBehavior = false;
            this.listViewStat.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderField
            // 
            this.columnHeaderField.Text = "Field";
            this.columnHeaderField.Width = 150;
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            this.columnHeaderValue.Width = 200;
            // 
            // tabPageOther
            // 
            this.tabPageOther.Controls.Add(this.labelCreateMode);
            this.tabPageOther.Controls.Add(this.comboBoxCreateMode);
            this.tabPageOther.Location = new System.Drawing.Point(4, 22);
            this.tabPageOther.Name = "tabPageOther";
            this.tabPageOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOther.Size = new System.Drawing.Size(552, 311);
            this.tabPageOther.TabIndex = 3;
            this.tabPageOther.Text = "Other";
            this.tabPageOther.UseVisualStyleBackColor = true;
            // 
            // labelCreateMode
            // 
            this.labelCreateMode.AutoSize = true;
            this.labelCreateMode.Location = new System.Drawing.Point(6, 9);
            this.labelCreateMode.Name = "labelCreateMode";
            this.labelCreateMode.Size = new System.Drawing.Size(65, 12);
            this.labelCreateMode.TabIndex = 1;
            this.labelCreateMode.Text = "CreateMode";
            // 
            // comboBoxCreateMode
            // 
            this.comboBoxCreateMode.FormattingEnabled = true;
            this.comboBoxCreateMode.Items.AddRange(new object[] {
            "PERSISTENT",
            "PERSISTENT_SEQUENTIAL",
            "EPHEMERAL",
            "EPHEMERAL_SEQUENTIAL"});
            this.comboBoxCreateMode.Location = new System.Drawing.Point(77, 6);
            this.comboBoxCreateMode.Name = "comboBoxCreateMode";
            this.comboBoxCreateMode.Size = new System.Drawing.Size(469, 20);
            this.comboBoxCreateMode.TabIndex = 0;
            this.comboBoxCreateMode.Text = "PERSISTENT";
            // 
            // contextMenuStripAcl
            // 
            this.contextMenuStripAcl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDigestHelper});
            this.contextMenuStripAcl.Name = "contextMenuStripAcl";
            this.contextMenuStripAcl.Size = new System.Drawing.Size(157, 26);
            // 
            // ToolStripMenuItemDigestHelper
            // 
            this.ToolStripMenuItemDigestHelper.Name = "ToolStripMenuItemDigestHelper";
            this.ToolStripMenuItemDigestHelper.Size = new System.Drawing.Size(156, 22);
            this.ToolStripMenuItemDigestHelper.Text = "Digest Helper";
            this.ToolStripMenuItemDigestHelper.Click += new System.EventHandler(this.ToolStripMenuItemDigestHelper_Click);
            // 
            // NodeInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "NodeInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NodeInfoForm";
            this.tabControl.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            this.tabPageAcl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAcls)).EndInit();
            this.tabPageStat.ResumeLayout(false);
            this.tabPageStat.PerformLayout();
            this.tabPageOther.ResumeLayout(false);
            this.tabPageOther.PerformLayout();
            this.contextMenuStripAcl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.TabPage tabPageAcl;
        private System.Windows.Forms.TabPage tabPageStat;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.TabPage tabPageOther;
        private System.Windows.Forms.Label labelCreateMode;
        private System.Windows.Forms.ComboBox comboBoxCreateMode;
        private System.Windows.Forms.ListView listViewStat;
        private System.Windows.Forms.ColumnHeader columnHeaderField;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxEncoding;
        private System.Windows.Forms.Label labelNodeName;
        private System.Windows.Forms.TextBox textBoxNodeName;
        private System.Windows.Forms.CheckBox checkBoxLocaltime;
        private System.Windows.Forms.DataGridView dataGridViewAcls;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnScheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPermRead;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPermWrite;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPermCreate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPermDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPermAdmin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAcl;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDigestHelper;
    }
}