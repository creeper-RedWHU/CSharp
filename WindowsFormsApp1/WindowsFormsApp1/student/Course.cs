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
    public partial class Course : UserControl
    {
        private int _courseId;

        public Course(int courseId)
        {
            InitializeComponent();
            _courseId = courseId;
            LoadCourseInfo();
        }

        private void LoadCourseInfo()
        {
            string dbPath = "StudentSystem.db";
            string connStr = $"Data Source={dbPath};Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"SELECT c.CourseName, u.Username AS TeacherName, c.StartTime
                               FROM Course c
                               JOIN Users u ON c.TeacherID = u.ID
                               WHERE c.CourseID = @courseId";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", _courseId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var dt = new DataTable();
                            dt.Columns.Add("Field");
                            dt.Columns.Add("Value");

                            dt.Rows.Add("课程名称", reader["CourseName"].ToString());
                            dt.Rows.Add("课程老师", reader["TeacherName"].ToString());
                            dt.Rows.Add("开课时间", reader["StartTime"].ToString());

                            dgvcourses.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // 可以留空，或写你需要的逻辑
        }

        private void dgvcourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 可以留空，或写你需要的逻辑
        }
    }
}
