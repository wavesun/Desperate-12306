namespace YA12306
{
    partial class LoginForm
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
            this.captchaBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.accountBox = new System.Windows.Forms.TextBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.captchaPicture = new CaptchaPictureBox();
            this.SuspendLayout();
            // 
            // captchaBox
            // 
            this.captchaBox.Location = new System.Drawing.Point(101, 72);
            this.captchaBox.Name = "captchaBox";
            this.captchaBox.Size = new System.Drawing.Size(123, 20);
            this.captchaBox.TabIndex = 2;
            this.captchaBox.Enter += new System.EventHandler(this.TextBoxEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Account";
            // 
            // loginButton
            // 
            this.loginButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loginButton.Location = new System.Drawing.Point(15, 110);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(76, 23);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButtonClick);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(101, 37);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(123, 20);
            this.passwordBox.TabIndex = 1;
            this.passwordBox.Enter += new System.EventHandler(this.TextBoxEnter);
            // 
            // accountBox
            // 
            this.accountBox.Location = new System.Drawing.Point(101, 14);
            this.accountBox.Name = "accountBox";
            this.accountBox.Size = new System.Drawing.Size(123, 20);
            this.accountBox.TabIndex = 0;
            this.accountBox.Enter += new System.EventHandler(this.TextBoxEnter);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(101, 110);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(123, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh Captcha";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButtonClick);
            // 
            // messageLabel
            // 
            this.messageLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.messageLabel.ForeColor = System.Drawing.Color.Red;
            this.messageLabel.Location = new System.Drawing.Point(0, 142);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(238, 13);
            this.messageLabel.TabIndex = 101;
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // captchaPicture
            // 
            this.captchaPicture.Client = null;
            this.captchaPicture.Location = new System.Drawing.Point(15, 66);
            this.captchaPicture.Name = "captchaPicture";
            this.captchaPicture.Size = new System.Drawing.Size(78, 26);
            this.captchaPicture.TabIndex = 100;
            this.captchaPicture.Url = null;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 155);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.captchaPicture);
            this.Controls.Add(this.captchaBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.accountBox);
            this.Controls.Add(this.refreshButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox captchaBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox accountBox;
        private System.Windows.Forms.Button refreshButton;
        private CaptchaPictureBox captchaPicture;
        private System.Windows.Forms.Label messageLabel;
    }
}