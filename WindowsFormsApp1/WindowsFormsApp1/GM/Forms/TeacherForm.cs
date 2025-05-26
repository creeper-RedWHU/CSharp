using System;
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