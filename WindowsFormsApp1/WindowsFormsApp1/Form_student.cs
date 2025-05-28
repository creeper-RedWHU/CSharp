using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EduAdminApp;
using MaterialSkin;
using MaterialSkin.Controls;


namespace WindowsFormsApp1
{
    public partial class Form_student : MaterialForm
    {

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int HTLEFT = 0x0A;
        private const int HTRIGHT = 0x0B;
        private const int HTTOP = 0x0C;
        private const int HTTOPLEFT = 0x0D;
        private const int HTTOPRIGHT = 0x0E;
        private const int HTBOTTOM = 0x0F;
        private const int HTBOTTOMLEFT = 0x10;
        private const int HTBOTTOMRIGHT = 0x11;
        private const int RESIZE_BORDER = 5; // 调整大小的边框宽度

        private int _studentId;

        public Form_student(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
            //设置无边框的
            this.FormBorderStyle = FormBorderStyle.None;

            // 加载课程
            LoadCoursesForStudent(_studentId);

            // 绑定下拉框事件
            comboBoxCourse.SelectedIndexChanged += comboBoxCourse_SelectedIndexChanged;
        }
        #region 窗口移动
        private Point mPoint;
        private void Form_student_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Form_student_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion

        // 添加窗体消息处理
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // 如果当前已最大化，不处理缩放
            if (isMaximized)
                return;

            if (m.Msg == WM_NCHITTEST && m.Result.ToInt32() == HTCLIENT)
            {
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                // 判断鼠标位置，返回相应的光标
                if (clientPoint.X <= RESIZE_BORDER && clientPoint.Y <= RESIZE_BORDER)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (clientPoint.X >= this.ClientSize.Width - RESIZE_BORDER && clientPoint.Y <= RESIZE_BORDER)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (clientPoint.X <= RESIZE_BORDER && clientPoint.Y >= this.ClientSize.Height - RESIZE_BORDER)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (clientPoint.X >= this.ClientSize.Width - RESIZE_BORDER && clientPoint.Y >= this.ClientSize.Height - RESIZE_BORDER)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (clientPoint.X <= RESIZE_BORDER)
                    m.Result = (IntPtr)HTLEFT;
                else if (clientPoint.Y <= RESIZE_BORDER)
                    m.Result = (IntPtr)HTTOP;
                else if (clientPoint.X >= this.ClientSize.Width - RESIZE_BORDER)
                    m.Result = (IntPtr)HTRIGHT;
                else if (clientPoint.Y >= this.ClientSize.Height - RESIZE_BORDER)
                    m.Result = (IntPtr)HTBOTTOM;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form_student_Load(object sender, EventArgs e)
        {
            LoadCoursesForStudent(_studentId);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            int courseId = 0;
            if (comboBoxCourse.SelectedValue != null)
            {
                courseId = Convert.ToInt32(comboBoxCourse.SelectedValue);
            }
            else
            {
                MessageBox.Show("请先选择课程！");
                return;
            }
            online_work workControl = new online_work(courseId, _studentId); // 传递 studentId
            workControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(workControl);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear(); // 清空原有内容

            // 假设你有一个当前选中的课程ID，比如通过 comboBoxCourse.SelectedValue 获取
            int courseId = 0;
            if (comboBoxCourse.SelectedValue != null)
            {
                courseId = Convert.ToInt32(comboBoxCourse.SelectedValue);
            }
            else
            {
                MessageBox.Show("请先选择课程！");
                return;
            }

            Course courseControl = new Course(courseId);
            courseControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(courseControl);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            int courseId = 0;
            if (comboBoxCourse.SelectedValue != null)
            {
                courseId = Convert.ToInt32(comboBoxCourse.SelectedValue);
            }
            else
            {
                MessageBox.Show("请先选择课程！");
                return;
            }
            exam examControl = new exam(courseId, _studentId);

            examControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(examControl);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear(); // 清空原有内容
            int courseId = 0;
            if (comboBoxCourse.SelectedValue != null)
            {
                courseId = Convert.ToInt32(comboBoxCourse.SelectedValue);
            }
            else
            {
                MessageBox.Show("请先选择课程！");
                return;
            }
            Question questionControl = new Question(courseId, _studentId); // 传递参数
            questionControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(questionControl);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear(); // 清空原有内容
            UserInfo InfoControl = new UserInfo(_studentId);
            InfoControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(InfoControl);
        }

        private bool isMaximized = false;
        private Size normalSize;
        private Point normalLocation;

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (!isMaximized)
            {
                // 保存当前窗体的大小和位置
                normalSize = this.Size;
                normalLocation = this.Location;

                // 最大化窗体
                Rectangle workingArea = Screen.GetWorkingArea(this);
                this.Size = new Size(workingArea.Width, workingArea.Height);
                this.Location = new Point(workingArea.X, workingArea.Y);

                // 更新按钮文本
                ((Button)sender).Text = "⧉";

                isMaximized = true;
            }
            else
            {
                // 恢复窗体
                this.Size = normalSize;
                this.Location = normalLocation;

                // 更新按钮文本
                ((Button)sender).Text = "□";

                isMaximized = false;
            }
        }

        private void BtnMinimize_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightBlue;
            ((Button)sender).ForeColor = Color.White;
        }

        private void BtnMinimize_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
            ((Button)sender).ForeColor = Color.Black;
        }

        private void BtnMaximize_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightBlue;
            ((Button)sender).ForeColor = Color.White;
        }

        private void BtnMaximize_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
            ((Button)sender).ForeColor = Color.Black;
        }

        private void LoadCoursesForStudent(int studentId)
        {
            string dbPath = "StudentSystem.db";
            string connStr = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                // 查询当前学生选修的所有课程，显示课程名称
                string sql = @"SELECT c.CourseID, c.CourseName
                       FROM Course c
                       JOIN CourseStudent cs ON c.CourseID = cs.CourseID
                       WHERE cs.StudentID = @studentId";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        comboBoxCourse.DataSource = dt;
                        comboBoxCourse.DisplayMember = "CourseName"; // 显示课程名称
                        comboBoxCourse.ValueMember = "CourseID";     // 选中项的值为课程ID
                    }
                }
            }
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCourse.SelectedValue != null)
            {
                int courseId = Convert.ToInt32(comboBoxCourse.SelectedValue);
                // 传递 courseId 给 Course 控件
                panel3.Controls.Clear();
                Course courseControl = new Course(courseId);
                courseControl.Dock = DockStyle.Fill;
                panel3.Controls.Add(courseControl);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
