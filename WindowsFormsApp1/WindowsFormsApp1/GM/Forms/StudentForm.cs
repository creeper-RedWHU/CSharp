using System;
using System.Windows.Forms;
using EduAdminApp.Models;
using MaterialSkin;
using MaterialSkin.Controls;

namespace EduAdminApp
{
    public partial class StudentForm : MaterialForm
    {
        public Student Student { get; set; }

        public StudentForm()
        {
            InitializeComponent();

            // 初始化 Material 主题
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE);

            Student = new Student();
            cboGender.SelectedIndex = 0;
        }

        public StudentForm(Student s) : this()
        {
            Student = s;
            txtUsername.Text = s.Username;
            txtPassword.Text = s.Password;
            txtName.Text = s.Name;
            cboGender.SelectedItem = s.Gender;
            txtMajor.Text = s.Major;
            txtEmail.Text = s.Email;
            txtPhone.Text = s.Phone;
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

            Student.Username = txtUsername.Text.Trim();
            Student.Password = txtPassword.Text.Trim();
            Student.Role = "学生"; // 强制设定为“学生”
            Student.Name = txtName.Text.Trim();
            Student.Gender = cboGender.SelectedItem?.ToString() ?? "男";
            Student.Major = txtMajor.Text.Trim();
            Student.Email = txtEmail.Text.Trim();
            Student.Phone = txtPhone.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void bnt_close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}