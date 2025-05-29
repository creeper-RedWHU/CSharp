using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Course : UserControl
    {
        public Course()
        {
            InitializeComponent();
            // 你可以在这里绑定数据源，假设有CourseModel列表
            // this.dgvcourses.DataSource = GetCourseList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvcourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // 示例：课程数据模型
        public class CourseModel
        {
            public string CourseName { get; set; }
            public string Endtim { get; set; }
            public int NUM { get; set; }
        }

        // 示例：获取课程列表（实际应从数据库获取）
        private List<CourseModel> GetCourseList()
        {
            return new List<CourseModel>
            {
                new CourseModel { CourseName = "高等数学", Endtim = "2024-12-31", NUM = 50 },
                new CourseModel { CourseName = "大学英语", Endtim = "2024-11-30", NUM = 40 }
            };
        }
    }
}
