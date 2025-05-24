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

        // 构造函数，传入课程ID和学生ID
        public exam(int courseId, int studentId)
        {
            InitializeComponent();
            _courseId = courseId;
            _studentId = studentId;
            LoadExamList();

            // 绑定双击事件
            this.dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        // 加载考试列表
        private void LoadExamList()
        {
            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT h.HID, h.HName AS 考试名称, h.StartTime AS 开始时间, h.EndTime AS 结束时间
                    FROM HMK h
                    JOIN CourseHMK ch ON h.HID = ch.HID
                    WHERE ch.CourseID = @courseId
                      AND h.IsTest = 1
                ";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", _courseId);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        // 双击考试行，弹出题目详情窗体
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int hid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["HID"].Value);
                // 允许提交考试答案
                FormProblems form = new FormProblems(hid, _studentId, true);
                form.ShowDialog();
            }
        }
    }
}
