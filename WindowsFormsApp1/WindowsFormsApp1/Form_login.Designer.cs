namespace WindowsFormsApp1
{
    partial class Form_login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.loginCard = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.rolePanel = new System.Windows.Forms.Panel();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.usernamePanel = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.loginCard.SuspendLayout();
            this.rolePanel.SuspendLayout();
            this.passwordPanel.SuspendLayout();
            this.usernamePanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.mainPanel.Controls.Add(this.loginCard);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(2, 50);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(936, 604);
            this.mainPanel.TabIndex = 2;
            // 
            // loginCard
            // 
            this.loginCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginCard.BackColor = System.Drawing.Color.White;
            this.loginCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginCard.Controls.Add(this.btnLogin);
            this.loginCard.Controls.Add(this.rolePanel);
            this.loginCard.Controls.Add(this.passwordPanel);
            this.loginCard.Controls.Add(this.usernamePanel);
            this.loginCard.Controls.Add(this.titlePanel);
            this.loginCard.Location = new System.Drawing.Point(268, 62);
            this.loginCard.Name = "loginCard";
            this.loginCard.Padding = new System.Windows.Forms.Padding(32);
            this.loginCard.Size = new System.Drawing.Size(400, 480);
            this.loginCard.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(32, 370);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(336, 48);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "🚀 立即登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // rolePanel
            // 
            this.rolePanel.Controls.Add(this.cboRole);
            this.rolePanel.Controls.Add(this.lblRole);
            this.rolePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rolePanel.Location = new System.Drawing.Point(32, 246);
            this.rolePanel.Name = "rolePanel";
            this.rolePanel.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.rolePanel.Size = new System.Drawing.Size(334, 62);
            this.rolePanel.TabIndex = 3;
            // 
            // cboRole
            // 
            this.cboRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(0, 52);
            this.cboRole.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(334, 43);
            this.cboRole.TabIndex = 1;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRole.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRole.Location = new System.Drawing.Point(0, 12);
            this.lblRole.Name = "lblRole";
            this.lblRole.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblRole.Size = new System.Drawing.Size(169, 40);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "👥 登录角色";
            // 
            // passwordPanel
            // 
            this.passwordPanel.Controls.Add(this.txtPassword);
            this.passwordPanel.Controls.Add(this.lblPassword);
            this.passwordPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordPanel.Location = new System.Drawing.Point(32, 184);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.passwordPanel.Size = new System.Drawing.Size(334, 62);
            this.passwordPanel.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtPassword.Location = new System.Drawing.Point(0, 52);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(334, 46);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPassword.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPassword.Location = new System.Drawing.Point(0, 12);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblPassword.Size = new System.Drawing.Size(169, 40);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "🔒 登录密码";
            // 
            // usernamePanel
            // 
            this.usernamePanel.Controls.Add(this.txtUsername);
            this.usernamePanel.Controls.Add(this.lblUsername);
            this.usernamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.usernamePanel.Location = new System.Drawing.Point(32, 122);
            this.usernamePanel.Name = "usernamePanel";
            this.usernamePanel.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.usernamePanel.Size = new System.Drawing.Size(334, 62);
            this.usernamePanel.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUsername.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtUsername.Location = new System.Drawing.Point(0, 52);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(334, 46);
            this.txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUsername.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsername.Location = new System.Drawing.Point(0, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblUsername.Size = new System.Drawing.Size(169, 40);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "👤 用户账号";
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.lblSubtitle);
            this.titlePanel.Controls.Add(this.lblTitle);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(32, 32);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(334, 90);
            this.titlePanel.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitle.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(0, 48);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(334, 32);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(334, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🎓 系统登录";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.headerPanel.Controls.Add(this.btnExit);
            this.headerPanel.Controls.Add(this.lblHeader);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(2, 2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(936, 48);
            this.headerPanel.TabIndex = 1;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            this.headerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Title_MouseMove);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(896, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 48);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "✕";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(20, 13);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(434, 42);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "教学作业考试一体化在线平台";
            this.lblHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            this.lblHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Title_MouseMove);
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(940, 656);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_login";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainPanel.ResumeLayout(false);
            this.loginCard.ResumeLayout(false);
            this.rolePanel.ResumeLayout(false);
            this.rolePanel.PerformLayout();
            this.passwordPanel.ResumeLayout(false);
            this.passwordPanel.PerformLayout();
            this.usernamePanel.ResumeLayout(false);
            this.usernamePanel.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel loginCard;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel usernamePanel;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel rolePanel;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Button btnLogin;
    }
}