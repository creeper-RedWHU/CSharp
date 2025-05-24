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

        public passed_work(int courseId, int studentId)
        {
            InitializeComponent();
            _courseId = courseId;
            _studentId = studentId;
            LoadPassedWorks();
        }

private void LoadPassedWorks()
{
    string dbPath = "StudentSystem.db";
    string connStr = $"Data Source={dbPath};Version=3;";
    using (SQLiteConnection conn = new SQLiteConnection(connStr))
    {
        conn.Open();
        string sql = @"
            SELECT h.HID, h.HName AS 作业名称, h.StartTime AS 开始时间, h.EndTime AS 结束时间
            FROM HMK h
            JOIN CourseHMK ch ON h.HID = ch.HID
            WHERE ch.CourseID = @courseId
              AND date('now') > h.EndTime
              AND h.IsTest = 0
        ";
        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@courseId", _courseId);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvPassedWork.DataSource = dt;
        }
    }
}

        private void dgvDueWork_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 获取当前作业的 HID
                int hid = Convert.ToInt32(dgvPassedWork.Rows[e.RowIndex].Cells["HID"].Value);

                FormProblems form = new FormProblems(hid, _studentId, false); // 不允许提交
                form.ShowDialog();
            }
        }

    }
}
