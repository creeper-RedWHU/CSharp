using Sunny.UI;
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

namespace WindowsFormsApp1
{
    public partial class exam : UserControl
    {
        private int _courseId;
        private int _studentId;
        private List<ExamInfo> _exams = new List<ExamInfo>();

        private class ExamInfo
        {
            public int HID { get; set; }
            public string ExamName { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool IsAvailable { get; set; }
            public bool IsExpired { get; set; }
        }

        public exam(int courseId, int studentId)
        {
            InitializeComponent();
            _courseId = courseId;
            _studentId = studentId;

            InitializeStyles();
        }

        private void InitializeStyles()
        {
            // 设置刷新按钮样式
            SetButtonStyle(btnRefresh, Color.Orange);

            // 设置控件自适应
            this.Resize += exam_Resize;
        }

        private void SetButtonStyle(Button btn, Color backColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            // 添加鼠标悬停效果
            btn.MouseEnter += (s, e) => {
                btn.BackColor = ControlPaint.Light(backColor);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = backColor;
            };
        }

        private void exam_Load(object sender, EventArgs e)
        {
            LoadExamList();
        }

        private void exam_Resize(object sender, EventArgs e)
        {
            if (btnRefresh != null)
            {
                btnRefresh.Left = headerPanel.Width - btnRefresh.Width - 20;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadExamList();
            MessageBox.Show("考试列表已刷新！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadExamList()
        {
            _exams.Clear();
            flpExams.Controls.Clear();

            string dbPath = "StudentSystem.db";
            string connStr = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT h.HID, h.HName, h.StartTime, h.EndTime
                    FROM HMK h
                    JOIN CourseHMK ch ON h.HID = ch.HID
                    WHERE ch.CourseID = @courseId
                      AND h.IsTest = 1
                    ORDER BY h.StartTime DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", _courseId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var exam = new ExamInfo
                            {
                                HID = reader.GetInt32(0), // 0是HID
                                ExamName = reader.GetString(1),
                                StartTime = DateTime.Parse(reader.GetString(2)),
                                EndTime = DateTime.Parse(reader.GetString(3))
                            };

                            // 判断考试状态
                            DateTime now = DateTime.Now;
                            exam.IsAvailable = now >= exam.StartTime && now <= exam.EndTime;
                            exam.IsExpired = now > exam.EndTime;

                            _exams.Add(exam);
                            CreateExamCard(exam);
                        }
                    }
                }
            }

            if (_exams.Count == 0)
            {
                CreateNoExamCard();
            }
        }

        private void CreateExamCard(ExamInfo exam)
        {
            Panel examCard = new Panel
            {
                Width = flpExams.Width - 40,
                Height = 160,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5, 5, 5, 15),
                Cursor = Cursors.Hand
            };

            // 状态指示条
            Panel statusBar = new Panel
            {
                Width = 8,
                Height = 160,
                BackColor = GetStatusColor(exam),
                Dock = DockStyle.Left
            };

            // 状态标签
            Label lblStatus = new Label
            {
                Text = GetStatusText(exam),
                Font = new Font("微软雅黑", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = GetStatusColor(exam),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(examCard.Width - 90, 10),
                Size = new Size(75, 30)
            };

            // 考试名称
            Label lblExamName = new Label
            {
                Text = $"📊 {exam.ExamName}",
                Font = new Font("微软雅黑", 16F, FontStyle.Bold),
                ForeColor = exam.IsExpired ? Color.Gray : Color.DarkBlue,
                Location = new Point(25, 20),
                Size = new Size(examCard.Width - 150, 35),
                AutoEllipsis = true
            };

            // 开始时间
            Label lblStartTime = new Label
            {
                Text = $"🕐 开始时间: {exam.StartTime:yyyy-MM-dd HH:mm}",
                Font = new Font("微软雅黑", 11F),
                ForeColor = Color.Gray,
                Location = new Point(25, 65),
                Size = new Size(300, 25)
            };

            // 结束时间
            Label lblEndTime = new Label
            {
                Text = $"⏰ 结束时间: {exam.EndTime:yyyy-MM-dd HH:mm}",
                Font = new Font("微软雅黑", 11F),
                ForeColor = exam.IsExpired ? Color.Red : Color.OrangeRed,
                Location = new Point(25, 95),
                Size = new Size(300, 25)
            };

            // 考试时长
            TimeSpan duration = exam.EndTime - exam.StartTime;
            Label lblDuration = new Label
            {
                Text = $"⏳ 考试时长: {duration.TotalHours:F1} 小时",
                Font = new Font("微软雅黑", 11F),
                ForeColor = Color.Gray,
                Location = new Point(350, 65),
                Size = new Size(200, 25)
            };

            // 剩余时间或状态信息
            Label lblTimeInfo = new Label
            {
                Font = new Font("微软雅黑", 11F),
                ForeColor = GetStatusColor(exam),
                Location = new Point(350, 95),
                Size = new Size(200, 25)
            };

            if (exam.IsExpired)
            {
                lblTimeInfo.Text = "❌ 考试已结束";
            }
            else if (exam.IsAvailable)
            {
                TimeSpan remaining = exam.EndTime - DateTime.Now;
                lblTimeInfo.Text = $"⏰ 剩余: {remaining.Hours}h {remaining.Minutes}m";
            }
            else
            {
                lblTimeInfo.Text = "⏳ 考试未开始";
            }

            // 操作按钮
            Button btnAction = new Button
            {
                Font = new Font("微软雅黑", 12F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(examCard.Width - 140, 115),
                Size = new Size(120, 35),
                Cursor = Cursors.Hand
            };

            if (exam.IsAvailable)
            {
                btnAction.Text = "🚀 开始考试";
                btnAction.BackColor = Color.Green;
                btnAction.ForeColor = Color.White;
                btnAction.Click += (s, e) => StartExam(exam);
            }
            else if (exam.IsExpired)
            {
                btnAction.Text = "👁️ 查看详情";
                btnAction.BackColor = Color.Gray;
                btnAction.ForeColor = Color.White;
                btnAction.Click += (s, e) => ViewExam(exam);
            }
            else
            {
                btnAction.Text = "⏳ 未开始";
                btnAction.BackColor = Color.LightGray;
                btnAction.ForeColor = Color.Gray;
                btnAction.Enabled = false;
            }

            btnAction.FlatAppearance.BorderSize = 0;

            // 鼠标悬停效果
            examCard.MouseEnter += (s, e) => {
                if (!exam.IsExpired)
                {
                    examCard.BackColor = Color.AliceBlue;
                }
            };
            examCard.MouseLeave += (s, e) => {
                examCard.BackColor = Color.White;
            };

            // 双击事件 - 保持原有逻辑
            examCard.DoubleClick += (s, e) => HandleExamDoubleClick(exam);
            lblExamName.DoubleClick += (s, e) => HandleExamDoubleClick(exam);
            lblStartTime.DoubleClick += (s, e) => HandleExamDoubleClick(exam);
            lblEndTime.DoubleClick += (s, e) => HandleExamDoubleClick(exam);

            // 添加控件到卡片
            examCard.Controls.Add(statusBar);
            examCard.Controls.Add(lblStatus);
            examCard.Controls.Add(lblExamName);
            examCard.Controls.Add(lblStartTime);
            examCard.Controls.Add(lblEndTime);
            examCard.Controls.Add(lblDuration);
            examCard.Controls.Add(lblTimeInfo);
            examCard.Controls.Add(btnAction);

            flpExams.Controls.Add(examCard);
        }

        private void CreateNoExamCard()
        {
            Panel noExamCard = new Panel
            {
                Width = flpExams.Width - 40,
                Height = 200,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblNoExam = new Label
            {
                Text = "📝 暂无考试安排",
                Font = new Font("微软雅黑", 18F, FontStyle.Bold),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            noExamCard.Controls.Add(lblNoExam);
            flpExams.Controls.Add(noExamCard);
        }

        private Color GetStatusColor(ExamInfo exam)
        {
            if (exam.IsExpired) return Color.Red;
            if (exam.IsAvailable) return Color.Green;
            return Color.Orange;
        }

        private string GetStatusText(ExamInfo exam)
        {
            if (exam.IsExpired) return "已结束";
            if (exam.IsAvailable) return "进行中";
            return "未开始";
        }

        private void StartExam(ExamInfo exam)
        {
            HandleExamDoubleClick(exam);
        }

        private void ViewExam(ExamInfo exam)
        {
            // 查看已结束的考试
            FormProblems form = new FormProblems(exam.HID, _studentId, false, true);
            form.Text = $"考试详情: {exam.ExamName}";
            form.ShowDialog();
        }

        // 保持原有的双击逻辑不变
        private void HandleExamDoubleClick(ExamInfo exam)
        {
            try
            {
                // 检查考试是否已结束
                if (exam.IsExpired)
                {
                    MessageBox.Show("该考试已结束，无法参加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 检查考试是否未开始
                if (!exam.IsAvailable)
                {
                    MessageBox.Show($"该考试尚未开始，开始时间为 {exam.StartTime:yyyy-MM-dd HH:mm}！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 创建考试窗口
                FormProblems form = new FormProblems(exam.HID, _studentId, true, true);

                // 设置窗口标题
                form.Text = $"考试: {exam.ExamName}";

                // 设置为模态对话框，这会阻止用户与父窗口交互
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.StartPosition = FormStartPosition.CenterScreen;

                // 可以添加确认提示
                DialogResult result = MessageBox.Show(
                    $"您即将开始 \"{exam.ExamName}\" 考试，考试结束时间为 {exam.EndTime:yyyy-MM-dd HH:mm}。\n\n" +
                    "开始后将无法退出，直到提交答案。确定开始考试吗？",
                    "考试确认",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    form.ControlBox = false; // 禁用关闭按钮
                    form.ShowDialog(); // 使用模态对话框显示
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"打开考试失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}