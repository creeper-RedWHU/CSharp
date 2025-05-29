using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace EduAdminApp
{
    public partial class Course : UserControl
    {
        private int _courseId;

        public Course(int courseId)
        {
            InitializeComponent();
            _courseId = courseId;
            LoadCourseInfo();
        }

        public Course()
        {
            InitializeComponent();
      
        }

        private void LoadCourseInfo()
        {
            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT c.CourseID, c.CourseName, c.TeacherID, c.StartTime,
                           c.Endtime, c.NUM, c.CourseDescription, c.Credit, c.Classroom, c.Schedule,
                           u.Name AS TeacherName
                    FROM Course c
                    LEFT JOIN Users u ON c.TeacherID = u.ID
                    WHERE c.CourseID = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _courseId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelCourseID.Text = "📘 课程编号：" + reader["CourseID"].ToString();
                            labelCourseName.Text = "📖 课程名称：" + reader["CourseName"].ToString();
                            labelTeacher.Text = "👨‍🏫 授课教师：" + reader["TeacherName"].ToString();
                            labelStartTime.Text = "🕒 开课时间：" + Convert.ToDateTime(reader["StartTime"]).ToString("yyyy-MM-dd");
                            labelCredits.Text = "🎓 学分：" + reader["Credit"].ToString();
                            labelEndTime.Text = "⏰ 结束时间：" + Convert.ToDateTime(reader["Endtime"]).ToString("yyyy-MM-dd"); // 新增
                            labelNum.Text = "👥 上课人数：" + reader["NUM"].ToString(); // 新增
                            labelClassroom.Text = "🏫 上课地点：" + reader["Classroom"].ToString();
                            labelSchedule.Text = "📅 上课时间：" + reader["Schedule"].ToString();

                            string desc = reader["CourseDescription"]?.ToString();
                            labelDescription.Text = string.IsNullOrWhiteSpace(desc) ? "暂无课程简介" : desc;
                        }
                        else
                        {
                            MessageBox.Show("未找到课程信息。");
                        }
                    }
                }
            }
        }
    }
}