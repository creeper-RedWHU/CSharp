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
    public partial class passed_work : UserControl
    {
        private int _courseId;
        private int _studentId;
        private List<WorkInfo> _passedWorks = new List<WorkInfo>();

        private class WorkInfo
        {
            public int HID { get; set; }
            public string HName { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
        }

        public passed_work(int courseId, int studentId)
        {
            InitializeComponent();
            _courseId = courseId;
            _studentId = studentId;
        }

        private void passed_work_Load(object sender, EventArgs e)
        {
            LoadPassedWorks();
        }

        private void passed_work_Resize(object sender, EventArgs e)
        {
            if (flpPassedWorks != null)
            {
                flpPassedWorks.Width = this.Width - 30;
                flpPassedWorks.Height = this.Height - 80;
            }
        }

        private void LoadPassedWorks()
        {
            _passedWorks.Clear();
            flpPassedWorks.Controls.Clear();

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
                      AND date('now') > h.EndTime
                      AND h.IsTest = 0
                    ORDER BY h.EndTime DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", _courseId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var work = new WorkInfo
                            {
                                HID = reader.GetInt32("HID"),
                                HName = reader.GetString("HName"),
                                StartTime = reader.GetString("StartTime"),
                                EndTime = reader.GetString("EndTime")
                            };

                            _passedWorks.Add(work);
                            CreateWorkCard(work);
                        }
                    }
                }
            }

            if (_passedWorks.Count == 0)
            {
                CreateNoWorkCard("😊 暂无过期作业！");
            }
        }

        private void CreateWorkCard(WorkInfo work)
        {
            Panel workCard = new Panel
            {
                Width = flpPassedWorks.Width - 40,
                Height = 140,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5, 5, 5, 10),
                Cursor = Cursors.Hand
            };

            // 作业状态标识（红色表示已过期）
            Panel statusPanel = new Panel
            {
                Width = 8,
                Height = 140,
                BackColor = Color.Red,
                Dock = DockStyle.Left
            };

            // 过期标签
            Label lblExpired = new Label
            {
                Text = "已过期",
                Font = new Font("微软雅黑", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(workCard.Width - 80, 10),
                Size = new Size(60, 25)
            };

            // 作业名称
            Label lblName = new Label
            {
                Text = $"📝 {work.HName}",
                Font = new Font("微软雅黑", 14F, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(20, 15),
                Size = new Size(workCard.Width - 150, 30),
                AutoEllipsis = true
            };

            // 开始时间
            Label lblStartTime = new Label
            {
                Text = $"🕐 开始时间: {work.StartTime}",
                Font = new Font("微软雅黑", 10F),
                ForeColor = Color.Gray,
                Location = new Point(20, 55),
                Size = new Size(300, 25)
            };

            // 结束时间
            Label lblEndTime = new Label
            {
                Text = $"⏰ 截止时间: {work.EndTime}",
                Font = new Font("微软雅黑", 10F),
                ForeColor = Color.Red,
                Location = new Point(20, 80),
                Size = new Size(300, 25)
            };

            // 查看按钮
            Button btnView = new Button
            {
                Text = "👁️ 查看作业",
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(workCard.Width - 130, 45),
                Size = new Size(110, 50),
                Cursor = Cursors.Hand
            };

            btnView.FlatAppearance.BorderSize = 0;
            btnView.Click += (s, e) => ViewWork(work.HID);

            // 鼠标悬停效果
            workCard.MouseEnter += (s, e) => {
                workCard.BackColor = Color.Gainsboro;
            };
            workCard.MouseLeave += (s, e) => {
                workCard.BackColor = Color.White;
            };

            // 整个卡片点击事件
            workCard.Click += (s, e) => ViewWork(work.HID);
            lblName.Click += (s, e) => ViewWork(work.HID);
            lblStartTime.Click += (s, e) => ViewWork(work.HID);
            lblEndTime.Click += (s, e) => ViewWork(work.HID);

            workCard.Controls.Add(statusPanel);
            workCard.Controls.Add(lblExpired);
            workCard.Controls.Add(lblName);
            workCard.Controls.Add(lblStartTime);
            workCard.Controls.Add(lblEndTime);
            workCard.Controls.Add(btnView);

            flpPassedWorks.Controls.Add(workCard);
        }

        private void CreateNoWorkCard(string message)
        {
            Panel noWorkCard = new Panel
            {
                Width = flpPassedWorks.Width - 40,
                Height = 200,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblNoWork = new Label
            {
                Text = message,
                Font = new Font("微软雅黑", 16F, FontStyle.Bold),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            noWorkCard.Controls.Add(lblNoWork);
            flpPassedWorks.Controls.Add(noWorkCard);
        }

        private void ViewWork(int hid)
        {
            FormProblems form = new FormProblems(hid, _studentId, false); // 不允许提交
            form.ShowDialog();
        }
    }
}