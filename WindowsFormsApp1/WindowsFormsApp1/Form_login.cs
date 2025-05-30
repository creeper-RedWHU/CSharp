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
// 移除 MaterialSkin 引用
using EduAdminApp.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_login : Form  // 改为普通 Form
    {
        public Form_login()
        {
            InitializeComponent();

            // 启动时自动将所有明文密码转换为哈希（只需调用一次）
            DbHelper.ConvertAllPasswordsToHash();

            // 设置无边框窗体
            this.FormBorderStyle = FormBorderStyle.None;

            // 初始化样式
            InitializeStyles();
        }

        // ...existing code...

        private void InitializeStyles()
        {
            // 设置窗体的清晰度和渲染质量
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // 设置登录按钮样式
            //SetButtonStyle(btnLogin, Color.DodgerBlue);
            //SetButtonStyle(btnExit, Color.FromArgb(231, 76, 60));

            // 设置输入框样式
            SetTextBoxStyle(txtUsername);
            SetTextBoxStyle(txtPassword);

            // 设置下拉框样式
            SetComboBoxStyle(cboRole);

            // 设置登录卡片圆角效果
            SetCardShadow();
        }

        private void SetCardShadow()
        {
            // 给登录卡片添加阴影效果
            loginCard.Paint += (s, e) => {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddRectangle(new Rectangle(0, 0, loginCard.Width - 1, loginCard.Height - 1));
                    using (var pen = new Pen(Color.FromArgb(200, 200, 200), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }

        private void SetTextBoxStyle(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
            txt.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point);

            // 添加焦点效果
            txt.Enter += (s, e) => {
                txt.BackColor = Color.FromArgb(240, 248, 255);
                txt.BorderStyle = BorderStyle.FixedSingle;
            };
            txt.Leave += (s, e) => {
                txt.BackColor = Color.White;
            };
        }

        private void SetComboBoxStyle(ComboBox cbo)
        {
            cbo.FlatStyle = FlatStyle.Standard;
            cbo.BackColor = Color.White;
            cbo.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point);
        }

        // 绘制更清晰的边框
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 启用抗锯齿
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (Pen borderPen = new Pen(Color.DodgerBlue, 2))
            {
                e.Graphics.DrawRectangle(borderPen, 1, 1, this.Width - 3, this.Height - 3);
            }
        }

        // ...existing code...

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