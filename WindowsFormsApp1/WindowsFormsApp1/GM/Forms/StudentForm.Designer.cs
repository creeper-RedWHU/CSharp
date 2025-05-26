using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Windows.Forms;

namespace EduAdminApp
{
    partial class StudentForm : MaterialForm
    {
        private MaterialTextBox2 txtUsername;
        private MaterialTextBox2 txtPassword;
        private MaterialTextBox2 txtName;
        private MaterialComboBox cboGender;
        private MaterialTextBox2 txtMajor;
        private MaterialTextBox2 txtEmail;
        private MaterialTextBox2 txtPhone;
        private MaterialButton btnOK;
        private MaterialButton btnCancel;

        private void InitializeComponent()
        {
            this.txtUsername = new MaterialTextBox2();
            this.txtPassword = new MaterialTextBox2();
            this.txtName = new MaterialTextBox2();
            this.cboGender = new MaterialComboBox();
            this.txtMajor = new MaterialTextBox2();
            this.txtEmail = new MaterialTextBox2();
            this.txtPhone = new MaterialTextBox2();
            this.btnOK = new MaterialButton();
            this.btnCancel = new MaterialButton();

      

            // Form 基础设置
            this.Text = "学生信息";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(600, 650);

            // txtUsername
            this.txtUsername.Hint = "账号";
            this.txtUsername.Location = new System.Drawing.Point(50, 80);
            this.txtUsername.Size = new System.Drawing.Size(500, 48);

            // txtPassword
            this.txtPassword.Hint = "密码";
            this.txtPassword.UseSystemPasswordChar = true;  // 改为这个属性
            this.txtPassword.Location = new System.Drawing.Point(50, 140);
            this.txtPassword.Size = new System.Drawing.Size(500, 48);

            // txtName
            this.txtName.Hint = "姓名";
            this.txtName.Location = new System.Drawing.Point(50, 200);
            this.txtName.Size = new System.Drawing.Size(500, 48);

            // cboGender
            this.cboGender.Hint = "性别";
            this.cboGender.Items.AddRange(new object[] { "男", "女" });
            this.cboGender.Location = new System.Drawing.Point(50, 260);
            this.cboGender.Size = new System.Drawing.Size(500, 48);

            // txtMajor
            this.txtMajor.Hint = "专业";
            this.txtMajor.Location = new System.Drawing.Point(50, 320);
            this.txtMajor.Size = new System.Drawing.Size(500, 48);

            // txtEmail
            this.txtEmail.Hint = "邮箱";
            this.txtEmail.Location = new System.Drawing.Point(50, 380);
            this.txtEmail.Size = new System.Drawing.Size(500, 48);

            // txtPhone
            this.txtPhone.Hint = "电话";
            this.txtPhone.Location = new System.Drawing.Point(50, 440);
            this.txtPhone.Size = new System.Drawing.Size(500, 48);

            // btnOK
            this.btnOK.Text = "确认";
            this.btnOK.Type = MaterialButton.MaterialButtonType.Contained;
            this.btnOK.Location = new System.Drawing.Point(100, 520);
            this.btnOK.Size = new System.Drawing.Size(120, 40);
            this.btnOK.Click += new EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Text = "取消";
            this.btnCancel.Type = MaterialButton.MaterialButtonType.Text;
            this.btnCancel.Location = new System.Drawing.Point(350, 520);
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.Click += new EventHandler(this.bnt_close);


            // 添加控件到窗体
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.txtMajor);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
        }
    }
}