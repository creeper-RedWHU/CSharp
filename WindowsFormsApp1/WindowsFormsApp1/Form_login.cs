using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_login : Form
    {

        public Form_login()
        {
            InitializeComponent();

            // 创建圆角窗体
            this.FormBorderStyle = FormBorderStyle.None;
           
        }

        // 重写窗体大小改变事件，保持圆角效果
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 设置窗体标题
            this.Text = "用户登录";


            // 添加角色选项
            cboRole.Items.Add("学生");
            cboRole.Items.Add("老师");
            cboRole.Items.Add("管理员");

            // 默认选择第一个选项
            cboRole.SelectedIndex = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #region 窗口移动
        private Point mPoint;
        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }
        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Location=new Point(this.Location.X + e.X -mPoint.X,this.Location.Y+e.Y-mPoint.Y);
            }
        }

        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cboRole.SelectedItem.ToString();

            // 简单验证输入是否为空
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("账号和密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 使用数据库验证用户
            bool isAuthenticated = DbHelper.ValidateUser(username, password, role);

            // 根据验证结果执行相应操作
            if (isAuthenticated)
            {
                MessageBox.Show($"欢迎 {role} {username} 登录系统！", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int studentId = GetUserIdByUsername(username);

                // 创建学生表单实例
                Form_student studentForm = new Form_student(studentId);

                // 隐藏登录表单
                this.Hide();

                // 显示学生表单
                studentForm.Show();

                // 设置关闭学生窗口时，关闭整个应用程序
                studentForm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("账号、密码或角色选择错误，请重试！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 新增：根据用户名查找ID
        private int GetUserIdByUsername(string username)
        {
            string dbPath = "StudentSystem.db";
            string connStr = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT ID FROM Users WHERE Username = @username";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        return Convert.ToInt32(result);
                    else
                        throw new Exception("未找到用户ID");
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
