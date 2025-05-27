using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using EduAdminApp.DAL;
using EduAdminApp;

namespace WindowsFormsApp1
{
    public partial class UserInfo : UserControl
    {
        private int _userId;
        private Student currentStudent;

        public UserInfo(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT ID, Username, Password, Role, Name, Gender, Major, Email, Phone FROM Users WHERE ID=@id AND Role='学生'";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _userId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 创建并存储学生对象
                            currentStudent = new Student
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Username = reader["Username"].ToString(),
                                Password=reader["Password"].ToString(),
                                Role = reader["Role"].ToString(),
                                Name = reader["Name"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                Major = reader["Major"].ToString(),
                                Email = reader["Email"].ToString(),
                                Phone = reader["Phone"].ToString()
                            };

                            // 显示信息
                            labelId.Text = "ID号：" + currentStudent.Id;
                            labelUsername.Text = "用户名：" + currentStudent.Username;
                            labelRole.Text = "角色：" + currentStudent.Role;
                            labelName.Text = "姓名：" + currentStudent.Name;
                            labelGender.Text = "性别：" + currentStudent.Gender;
                            labelMajor.Text = "专业：" + currentStudent.Major;
                            labelEmail.Text = "邮箱：" + currentStudent.Email;
                            labelPhone.Text = "电话：" + currentStudent.Phone;
                        }
                        else
                        {
                            MessageBox.Show("未找到该学生或该用户不是学生。");
                        }
                    }
                }
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (currentStudent == null)
            {
                MessageBox.Show("无法编辑：未加载学生信息。");
                return;
            }

            StudentForm form = new StudentForm(currentStudent); // 弹出编辑窗口
            if (form.ShowDialog() == DialogResult.OK)
            {
                // 更新数据库
                StudentDAL dal = new StudentDAL();
                dal.Update(form.Student);

                // 重新加载更新后的数据
                LoadUserInfo();

                MessageBox.Show("学生信息更新成功！");
            }
        }
    }
}