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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
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
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.labelTitle.Location = new System.Drawing.Point(429, 36);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(400, 79);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "学生信息";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelId
            // 
            this.labelId.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.labelId.Location = new System.Drawing.Point(420, 163);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(400, 40);
            this.labelId.TabIndex = 1;
            this.labelId.Text = "ID号：";
            // 
            // labelUsername
            // 
            this.labelUsername.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.labelUsername.Location = new System.Drawing.Point(420, 253);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(400, 40);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "用户名：";
            // 
            // labelRole
            // 
            this.labelRole.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.labelRole.Location = new System.Drawing.Point(420, 343);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(400, 40);
            this.labelRole.TabIndex = 3;
            this.labelRole.Text = "身份：";
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.labelName.Location = new System.Drawing.Point(420, 433);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(400, 40);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "姓名：";
            // 
            // labelGender
            // 
            this.labelGender.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.labelGender.Location = new System.Drawing.Point(420, 523);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(400, 40);
            this.labelGender.TabIndex = 5;
            this.labelGender.Text = "性别：";
            // 
            // labelMajor
            // 
            this.labelMajor.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelMajor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.labelMajor.Location = new System.Drawing.Point(420, 613);
            this.labelMajor.Name = "labelMajor";
            this.labelMajor.Size = new System.Drawing.Size(400, 40);
            this.labelMajor.TabIndex = 6;
            this.labelMajor.Text = "专业：";
            // 
            // labelEmail
            // 
            this.labelEmail.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.labelEmail.Location = new System.Drawing.Point(420, 703);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(400, 40);
            this.labelEmail.TabIndex = 7;
            this.labelEmail.Text = "邮箱：";
            // 
            // labelPhone
            // 
            this.labelPhone.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.labelPhone.Location = new System.Drawing.Point(420, 793);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(400, 40);
            this.labelPhone.TabIndex = 8;
            this.labelPhone.Text = "电话：";
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(529, 914);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 10;
            this.uiButton1.Size = new System.Drawing.Size(169, 60);
            this.uiButton1.TabIndex = 9;
            this.uiButton1.Text = "修改信息";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 6F);
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // UserInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelMajor);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelPhone);
            this.Name = "UserInfo";
            this.Size = new System.Drawing.Size(1287, 1048);
            this.ResumeLayout(false);

        }

        private Sunny.UI.UIButton uiButton1;
    }
}