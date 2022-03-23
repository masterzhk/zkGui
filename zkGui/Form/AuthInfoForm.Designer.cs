namespace zkGui
{
    partial class AuthInfoForm
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
            this.labelScheme = new System.Windows.Forms.Label();
            this.textBoxScheme = new System.Windows.Forms.TextBox();
            this.labelAuth = new System.Windows.Forms.Label();
            this.textBoxAuth = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelScheme
            // 
            this.labelScheme.AutoSize = true;
            this.labelScheme.Location = new System.Drawing.Point(12, 9);
            this.labelScheme.Name = "labelScheme";
            this.labelScheme.Size = new System.Drawing.Size(41, 12);
            this.labelScheme.TabIndex = 0;
            this.labelScheme.Text = "Scheme";
            // 
            // textBoxScheme
            // 
            this.textBoxScheme.Location = new System.Drawing.Point(59, 6);
            this.textBoxScheme.Name = "textBoxScheme";
            this.textBoxScheme.Size = new System.Drawing.Size(163, 21);
            this.textBoxScheme.TabIndex = 1;
            this.textBoxScheme.Text = "digest";
            // 
            // labelAuth
            // 
            this.labelAuth.AutoSize = true;
            this.labelAuth.Location = new System.Drawing.Point(12, 40);
            this.labelAuth.Name = "labelAuth";
            this.labelAuth.Size = new System.Drawing.Size(29, 12);
            this.labelAuth.TabIndex = 2;
            this.labelAuth.Text = "Auth";
            // 
            // textBoxAuth
            // 
            this.textBoxAuth.Location = new System.Drawing.Point(59, 37);
            this.textBoxAuth.Name = "textBoxAuth";
            this.textBoxAuth.Size = new System.Drawing.Size(163, 21);
            this.textBoxAuth.TabIndex = 3;
            this.textBoxAuth.Text = "user:pwd";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(14, 69);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(101, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(121, 69);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(101, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // AuthInfoForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(234, 101);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxAuth);
            this.Controls.Add(this.labelAuth);
            this.Controls.Add(this.textBoxScheme);
            this.Controls.Add(this.labelScheme);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 140);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 140);
            this.Name = "AuthInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AuthInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelScheme;
        private System.Windows.Forms.TextBox textBoxScheme;
        private System.Windows.Forms.Label labelAuth;
        private System.Windows.Forms.TextBox textBoxAuth;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}