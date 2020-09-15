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
            this.labelConnectstring = new System.Windows.Forms.Label();
            this.textBoxConnectstring = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelSessionTimeout = new System.Windows.Forms.Label();
            this.textBoxSessionTimeout = new System.Windows.Forms.TextBox();
            this.treeViewNodes = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // labelConnectstring
            // 
            this.labelConnectstring.AutoSize = true;
            this.labelConnectstring.Location = new System.Drawing.Point(12, 9);
            this.labelConnectstring.Name = "labelConnectstring";
            this.labelConnectstring.Size = new System.Drawing.Size(83, 12);
            this.labelConnectstring.TabIndex = 0;
            this.labelConnectstring.Text = "Connectstring";
            // 
            // textBoxConnectstring
            // 
            this.textBoxConnectstring.Location = new System.Drawing.Point(150, 6);
            this.textBoxConnectstring.Name = "textBoxConnectstring";
            this.textBoxConnectstring.Size = new System.Drawing.Size(641, 21);
            this.textBoxConnectstring.TabIndex = 1;
            this.textBoxConnectstring.Text = "localhost:2181";
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.SystemColors.Control;
            this.buttonConnect.Location = new System.Drawing.Point(716, 32);
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
            this.labelSessionTimeout.Location = new System.Drawing.Point(12, 36);
            this.labelSessionTimeout.Name = "labelSessionTimeout";
            this.labelSessionTimeout.Size = new System.Drawing.Size(89, 12);
            this.labelSessionTimeout.TabIndex = 3;
            this.labelSessionTimeout.Text = "SessionTimeout";
            // 
            // textBoxSessionTimeout
            // 
            this.textBoxSessionTimeout.Location = new System.Drawing.Point(150, 33);
            this.textBoxSessionTimeout.Name = "textBoxSessionTimeout";
            this.textBoxSessionTimeout.Size = new System.Drawing.Size(560, 21);
            this.textBoxSessionTimeout.TabIndex = 4;
            this.textBoxSessionTimeout.Text = "40000";
            // 
            // treeViewNodes
            // 
            this.treeViewNodes.Location = new System.Drawing.Point(12, 61);
            this.treeViewNodes.Name = "treeViewNodes";
            this.treeViewNodes.Size = new System.Drawing.Size(776, 377);
            this.treeViewNodes.TabIndex = 5;
            this.treeViewNodes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeViewNodes_KeyUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeViewNodes);
            this.Controls.Add(this.textBoxSessionTimeout);
            this.Controls.Add(this.labelSessionTimeout);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxConnectstring);
            this.Controls.Add(this.labelConnectstring);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MainForm";
            this.Text = "zkGui";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConnectstring;
        private System.Windows.Forms.TextBox textBoxConnectstring;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelSessionTimeout;
        private System.Windows.Forms.TextBox textBoxSessionTimeout;
        private System.Windows.Forms.TreeView treeViewNodes;
    }
}

