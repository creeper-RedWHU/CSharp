

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
using MaterialSkin;
using MaterialSkin.Controls;
using EduAdminApp.Forms;
namespace WindowsFormsApp1
{
    public partial class Form_login : MaterialForm
    {

        public Form_login()
        {
            InitializeComponent();

            // 创建圆角窗体
            this.FormBorderStyle = FormBorderStyle.None;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; 
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );

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

            cboRole.UseTallSize = true;
            txtPassword.UseTallSize = true;
            txtUsername.UseTallSize = true;
            cboRole.Font = new Font("微软雅黑", 10F);
            label1.Font = new System.Drawing.Font("宋体", 10F);
            label2.Font = new System.Drawing.Font("宋体", 10F);
            btnLogin.Font = new System.Drawing.Font("微软雅黑", 10F);
        }


        #region 窗口移动
        private Point mPoint;
        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }
        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
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

                int userId = GetUserIdByUsername(username);

                Form nextForm = null;
                if (role == "学生")
                {
                    nextForm = new Form_student(userId);
                }
                else if (role == "老师")
                {
                    //nextForm = new Form1(userId); // 你需要有Form_teacher窗体，并支持传入userId
                    Params.TeacherID = userId;
                    Params.TeacherName = username;
                    nextForm = new Form1();
                }
                else if (role == "管理员")
                {
                    nextForm = new MainForm(); // 你需要有Form_admin窗体，并支持传入userId
                }

                if (nextForm != null)
                {
                    this.Hide();
                    nextForm.Show();
                    nextForm.FormClosed += (s, args) => this.Close();
                }
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
