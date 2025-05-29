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
    public partial class due_work : UserControl
    {
        private int _courseId;
        private int _studentId;
        private List<WorkInfo> _dueWorks = new List<WorkInfo>();

        private class WorkInfo
        {
            public int HID { get; set; }
            public string HName { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
        }

        public due_work(int courseId, int studentId)
        {
            InitializeComponent();
            _courseId = courseId;
            _studentId = studentId;
        }

        private void due_work_Load(object sender, EventArgs e)
        {
            LoadDueWorks();
        }

        private void due_work_Resize(object sender, EventArgs e)
        {
            if (flpDueWorks != null)
            {
                flpDueWorks.Width = this.Width - 30;
                flpDueWorks.Height = this.Height - 80;
            }
        }

        private void LoadDueWorks()
        {
            _dueWorks.Clear();
            flpDueWorks.Controls.Clear();

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
                AND h.IsTest = 0
            ORDER BY h.EndTime ASC";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", _courseId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var work = new WorkInfo
                            {
                                HID = reader.GetInt32(0),
                                HName = reader.GetString(1),
                                StartTime = reader.GetString(2),
                                EndTime = reader.GetString(3)
                            };

                            // 只显示当前时间在开始和结束之间的作业
                            DateTime now = DateTime.Now;
                            DateTime start = DateTime.Parse(work.StartTime);
                            DateTime end = DateTime.Parse(work.EndTime);
                            if (now >= start && now <= end)
                            {
                                _dueWorks.Add(work);
                                CreateWorkCard(work);
                            }
                        }
                    }
                }
            }

            if (_dueWorks.Count == 0)
            {
                CreateNoWorkCard("🎉 暂无正在进行的作业！");
            }
        }

        private void CreateWorkCard(WorkInfo work)
        {
            Panel workCard = new Panel
            {
                Width = flpDueWorks.Width - 40,
                Height = 140,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5, 5, 5, 10),
                Cursor = Cursors.Hand
            };

            // 作业状态标识（绿色表示可提交）
            Panel statusPanel = new Panel
            {
                Width = 8,
                Height = 140,
                BackColor = Color.Green,
                Dock = DockStyle.Left
            };

            // 作业名称
            Label lblName = new Label
            {
                Text = $"📝 {work.HName}",
                Font = new Font("微软雅黑", 14F, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
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

            // 进入按钮
            Button btnEnter = new Button
            {
                Text = "📖 进入作业",
                Font = new Font("微软雅黑", 11F, FontStyle.Bold),
                BackColor = Color.Green,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(workCard.Width - 130, 45),
                Size = new Size(110, 50),
                Cursor = Cursors.Hand
            };

            btnEnter.FlatAppearance.BorderSize = 0;
            btnEnter.Click += (s, e) => OpenWork(work.HID);

            // 鼠标悬停效果
            workCard.MouseEnter += (s, e) => {
                workCard.BackColor = Color.AliceBlue;
            };
            workCard.MouseLeave += (s, e) => {
                workCard.BackColor = Color.White;
            };

            // 整个卡片点击事件
            workCard.Click += (s, e) => OpenWork(work.HID);
            lblName.Click += (s, e) => OpenWork(work.HID);
            lblStartTime.Click += (s, e) => OpenWork(work.HID);
            lblEndTime.Click += (s, e) => OpenWork(work.HID);

            workCard.Controls.Add(statusPanel);
            workCard.Controls.Add(lblName);
            workCard.Controls.Add(lblStartTime);
            workCard.Controls.Add(lblEndTime);
            workCard.Controls.Add(btnEnter);

            flpDueWorks.Controls.Add(workCard);
        }

        private void CreateNoWorkCard(string message)
        {
            Panel noWorkCard = new Panel
            {
                Width = flpDueWorks.Width - 40,
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
            flpDueWorks.Controls.Add(noWorkCard);
        }

        private void OpenWork(int hid)
        {
            FormProblems form = new FormProblems(hid, _studentId, true); // 允许提交
            form.ShowDialog();
        }
    }
}