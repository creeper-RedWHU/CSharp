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
        private const int RESIZE_BORDER = 5;

        private int _studentId;
        private Button _activeNavButton;

        public Form_student(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;

            // 设置无边框
            this.FormBorderStyle = FormBorderStyle.None;

            // 关闭 MaterialForm 标题栏边距
            this.Padding = new Padding(0);

            // 初始化样式
            InitializeStyles();

            // 加载课程
            LoadCoursesForStudent(_studentId);

            // 绑定下拉框事件
            comboBoxCourse.SelectedIndexChanged += comboBoxCourse_SelectedIndexChanged;
        }

        private void InitializeStyles()
        {

            // 设置导航按钮样式
            SetNavigationButtonStyle(button4, Color.FromArgb(52, 152, 219));
            SetNavigationButtonStyle(button5, Color.FromArgb(39, 174, 96));
            SetNavigationButtonStyle(button8, Color.FromArgb(231, 76, 60));
            SetNavigationButtonStyle(button9, Color.FromArgb(230, 126, 34));
            SetNavigationButtonStyle(button6, Color.FromArgb(155, 89, 182));

            // 设置顶部按钮样式
            SetTopButtonStyle(button1, Color.Green);

            SetTopButtonStyle(button3, Color.Orange);

            // 默认激活课程信息按钮
            SetActiveNavigationButton(button4);
        }

        private void SetWindowControlStyle(Button btn, Color baseColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = baseColor;
            btn.Cursor = Cursors.Hand;
        }

        private void SetNavigationButtonStyle(Button btn, Color baseColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = baseColor;
            btn.Cursor = Cursors.Hand;

            // 添加悬停效果
            btn.MouseEnter += (s, e) => {
                if (btn != _activeNavButton)
                {
                    btn.BackColor = ControlPaint.Light(baseColor);
                }
            };
            btn.MouseLeave += (s, e) => {
                if (btn != _activeNavButton)
                {
                    btn.BackColor = baseColor;
                }
            };
        }

        private void SetTopButtonStyle(Button btn, Color baseColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = baseColor;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => {
                btn.BackColor = ControlPaint.Light(baseColor);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = baseColor;
            };
        }

        private void SetActiveNavigationButton(Button activeButton)
        {
            // 重置所有按钮为非激活状态
            if (_activeNavButton != null)
            {
                Color originalColor = GetOriginalButtonColor(_activeNavButton);
                _activeNavButton.BackColor = originalColor;
            }

            // 设置新的激活按钮
            _activeNavButton = activeButton;
            if (activeButton != null)
            {
                Color originalColor = GetOriginalButtonColor(activeButton);
                activeButton.BackColor = ControlPaint.Dark(originalColor);
            }
        }

        private Color GetOriginalButtonColor(Button btn)
        {
            if (btn == button4) return Color.FromArgb(52, 152, 219);
            if (btn == button5) return Color.FromArgb(39, 174, 96);
            if (btn == button8) return Color.FromArgb(231, 76, 60);
            if (btn == button9) return Color.FromArgb(230, 126, 34);
            if (btn == button6) return Color.FromArgb(155, 89, 182);
            return Color.Gray;
        }

        #region 窗口移动和缩放
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

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (isMaximized) return;

            if (m.Msg == WM_NCHITTEST && m.Result.ToInt32() == HTCLIENT)
            {
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

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
        #endregion

        #region 窗口控制按钮事件
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
                normalSize = this.Size;
                normalLocation = this.Location;
                Rectangle workingArea = Screen.GetWorkingArea(this);
                this.Size = new Size(workingArea.Width, workingArea.Height);
                this.Location = new Point(workingArea.X, workingArea.Y);
                ((Button)sender).Text = "⧉";
                isMaximized = true;
            }
            else
            {
                this.Size = normalSize;
                this.Location = normalLocation;
                ((Button)sender).Text = "□";
                isMaximized = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimize_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = ControlPaint.Light(Color.FromArgb(52, 152, 219));
        }

        private void BtnMinimize_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(52, 152, 219);
        }

        private void BtnMaximize_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = ControlPaint.Light(Color.FromArgb(52, 152, 219));
        }

        private void BtnMaximize_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(52, 152, 219);
        }

        private void BtnExit_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = ControlPaint.Dark(Color.FromArgb(231, 76, 60));
        }

        private void BtnExit_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(231, 76, 60);
        }
        #endregion

        #region 导航按钮事件 - 保持原有逻辑
        private void button4_Click(object sender, EventArgs e)
        {
            SetActiveNavigationButton(button4);
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
            Course courseControl = new Course(courseId);
            courseControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(courseControl);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetActiveNavigationButton(button5);
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
            online_work workControl = new online_work(courseId, _studentId);
            workControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(workControl);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SetActiveNavigationButton(button8);
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
            SetActiveNavigationButton(button9);
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
            Question questionControl = new Question(courseId, _studentId);
            questionControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(questionControl);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetActiveNavigationButton(button6);
            panel3.Controls.Clear();
            UserInfo InfoControl = new UserInfo(_studentId);
            InfoControl.Dock = DockStyle.Fill;
            panel3.Controls.Add(InfoControl);
        }
        #endregion

        #region 数据加载 - 保持原有逻辑
        private void Form_student_Load(object sender, EventArgs e)
        {
            LoadCoursesForStudent(_studentId);
        }

        private void LoadCoursesForStudent(int studentId)
        {
            string dbPath = "StudentSystem.db";
            string connStr = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
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
                        comboBoxCourse.DisplayMember = "CourseName";
                        comboBoxCourse.ValueMember = "CourseID";
                    }
                }
            }
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCourse.SelectedValue != null)
            {
                int courseId = Convert.ToInt32(comboBoxCourse.SelectedValue);
                panel3.Controls.Clear();
                Course courseControl = new Course(courseId);
                courseControl.Dock = DockStyle.Fill;
                panel3.Controls.Add(courseControl);
                SetActiveNavigationButton(button4);
            }
        }
        #endregion

        #region 保持原有事件处理器
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
