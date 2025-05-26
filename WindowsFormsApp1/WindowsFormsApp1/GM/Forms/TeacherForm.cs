using System;
using System.Windows.Forms;
using System.Xml.Linq;
using EduAdminApp.Models;

namespace EduAdminApp
{
    public partial class TeacherForm : Form
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
            txtName.Text = t.Name;
            cboGender.SelectedItem = t.Gender;
            txtDepartment.Text = t.Department;
            txtEmail.Text = t.Email;
            txtPhone.Text = t.Phone;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Teacher.Name = txtName.Text.Trim();
            Teacher.Gender = cboGender.SelectedItem?.ToString() ?? "男";
            Teacher.Department = txtDepartment.Text.Trim();
            Teacher.Email = txtEmail.Text.Trim();
            Teacher.Phone = txtPhone.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}