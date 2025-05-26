using System;
using System.Windows.Forms;
using EduAdminApp.Models;

namespace EduAdminApp
{
    public partial class StudentForm : Form
    {
        public Student Student { get; set; }

        public StudentForm()
        {
            InitializeComponent();
            Student = new Student();
            cboGender.SelectedIndex = 0;
        }

        public StudentForm(Student s) : this()
        {
            Student = s;
            txtName.Text = s.Name;
            cboGender.SelectedItem = s.Gender;
            txtMajor.Text = s.Major;
            txtEmail.Text = s.Email;
            txtPhone.Text = s.Phone;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Student.Name = txtName.Text.Trim();
            Student.Gender = cboGender.SelectedItem?.ToString() ?? "男";
            Student.Major = txtMajor.Text.Trim();
            Student.Email = txtEmail.Text.Trim();
            Student.Phone = txtPhone.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}