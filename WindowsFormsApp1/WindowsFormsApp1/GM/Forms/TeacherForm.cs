using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EduAdminApp.Models;
using MaterialSkin;
using MaterialSkin.Controls;

namespace EduAdminApp
{
    public partial class TeacherForm : MaterialForm
    {
        public Teacher Teacher { get; set; }

        public TeacherForm()
        {
            InitializeComponent();
            Teacher = new Teacher();
            cboGender.SelectedIndex = 0;
        }

        public TeacherForm(Teacher t) : this()
        {
            Teacher = t;
            txtUsername.Text = t.Username;
            txtPassword.Text = t.Password;
            txtName.Text = t.Name;
            cboGender.SelectedItem = t.Gender;
            txtMajor.Text = t.Major;
            txtEmail.Text = t.Email;
            txtPhone.Text = t.Phone;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("用户名、密码和姓名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 正则表达式校验
            Regex nameRegex = new Regex(@"^[\u4e00-\u9fa5A-Za-z]{2,20}$");
            Regex phoneRegex = new Regex(@"^\d{11}$");
            Regex emailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");

            if (!nameRegex.IsMatch(txtName.Text.Trim()))
            {
                MessageBox.Show("姓名格式不正确，应为2-20位中英文字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtPhone.Text) && !phoneRegex.IsMatch(txtPhone.Text.Trim()))
            {
                MessageBox.Show("手机号格式不正确，应为11位数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !emailRegex.IsMatch(txtEmail.Text.Trim()))
            {
                MessageBox.Show("邮箱格式不正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Teacher.Username = txtUsername.Text.Trim();
            Teacher.Password = txtPassword.Text.Trim();
            Teacher.Name = txtName.Text.Trim();
            Teacher.Gender = cboGender.SelectedItem?.ToString() ?? "男";
            Teacher.Major = txtMajor.Text.Trim();
            Teacher.Email = txtEmail.Text.Trim();
            Teacher.Phone = txtPhone.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

     
    }
}