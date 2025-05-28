namespace WindowsFormsApp1
{
    partial class UserInfo
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelMajor;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Panel cardPanel; // 新增卡片Panel

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cardPanel = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelMajor = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.cardPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardPanel
            // 
            this.cardPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardPanel.BackColor = System.Drawing.Color.White;
            this.cardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPanel.Controls.Add(this.labelTitle);
            this.cardPanel.Controls.Add(this.labelId);
            this.cardPanel.Controls.Add(this.labelUsername);
            this.cardPanel.Controls.Add(this.labelRole);
            this.cardPanel.Controls.Add(this.labelName);
            this.cardPanel.Controls.Add(this.labelGender);
            this.cardPanel.Controls.Add(this.labelMajor);
            this.cardPanel.Controls.Add(this.labelEmail);
            this.cardPanel.Controls.Add(this.labelPhone);
            this.cardPanel.Controls.Add(this.uiButton1);
            this.cardPanel.Location = new System.Drawing.Point(197, 90);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Padding = new System.Windows.Forms.Padding(60, 40, 60, 40);
            this.cardPanel.Size = new System.Drawing.Size(900, 750);
            this.cardPanel.TabIndex = 100;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelTitle.Location = new System.Drawing.Point(0, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(780, 60);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "学生信息";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelId
            // 
            this.labelId.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.labelId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelId.Location = new System.Drawing.Point(302, 111);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(780, 40);
            this.labelId.TabIndex = 1;
            this.labelId.Text = "ID号：";
            // 
            // labelUsername
            // 
            this.labelUsername.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.labelUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelUsername.Location = new System.Drawing.Point(302, 171);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(780, 40);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "用户名：";
            // 
            // labelRole
            // 
            this.labelRole.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.labelRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelRole.Location = new System.Drawing.Point(302, 231);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(780, 40);
            this.labelRole.TabIndex = 3;
            this.labelRole.Text = "角色：";
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelName.Location = new System.Drawing.Point(302, 291);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(780, 40);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "姓名：";
            // 
            // labelGender
            // 
            this.labelGender.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.labelGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelGender.Location = new System.Drawing.Point(302, 351);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(780, 40);
            this.labelGender.TabIndex = 5;
            this.labelGender.Text = "性别：";
            // 
            // labelMajor
            // 
            this.labelMajor.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.labelMajor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelMajor.Location = new System.Drawing.Point(302, 411);
            this.labelMajor.Name = "labelMajor";
            this.labelMajor.Size = new System.Drawing.Size(780, 40);
            this.labelMajor.TabIndex = 6;
            this.labelMajor.Text = "专业：";
            // 
            // labelEmail
            // 
            this.labelEmail.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEmail.Location = new System.Drawing.Point(302, 471);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(780, 40);
            this.labelEmail.TabIndex = 7;
            this.labelEmail.Text = "邮箱：";
            // 
            // labelPhone
            // 
            this.labelPhone.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPhone.Location = new System.Drawing.Point(302, 531);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(780, 40);
            this.labelPhone.TabIndex = 8;
            this.labelPhone.Text = "电话：";
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.DodgerBlue;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.uiButton1.Location = new System.Drawing.Point(350, 630);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 18;
            this.uiButton1.RectColor = System.Drawing.Color.DodgerBlue;
            this.uiButton1.Size = new System.Drawing.Size(200, 60);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.TabIndex = 9;
            this.uiButton1.Text = "✏️ 修改信息";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 6F);
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // UserInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.cardPanel);
            this.Name = "UserInfo";
            this.Size = new System.Drawing.Size(1294, 975);
            this.cardPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Sunny.UI.UIButton uiButton1;
    }
}