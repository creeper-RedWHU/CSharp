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

        public due_work(int courseId, int studentId)
        {
            InitializeComponent();
            _courseId = courseId;
            _studentId = studentId;
            LoadDueWorks();
        }

private void LoadDueWorks()
{
    string dbPath = "StudentSystem.db";
    string connStr = $"Data Source={dbPath};Version=3;";
    using (SQLiteConnection conn = new SQLiteConnection(connStr))
    {
        conn.Open();
        string sql = @"
            SELECT h.HID, h.HName AS 作业名称, h.StartTime AS 开始日期, h.EndTime AS 结束日期
            FROM HMK h
            JOIN CourseHMK ch ON h.HID = ch.HID
            WHERE ch.CourseID = @courseId
              AND date('now') BETWEEN h.StartTime AND h.EndTime
              AND h.IsTest = 0
        ";
        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@courseId", _courseId);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // 先清空列，防止重复添加
            dgvDueWork.Columns.Clear();
            dgvDueWork.AutoGenerateColumns = false;

            // 添加三列并设置均分
            dgvDueWork.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colName",
                HeaderText = "作业名称",
                DataPropertyName = "作业名称",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDueWork.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colStart",
                HeaderText = "开始日期",
                DataPropertyName = "开始日期",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvDueWork.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colEnd",
                HeaderText = "结束日期",
                DataPropertyName = "结束日期",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // 添加隐藏的 HID 列
            DataGridViewColumn hidColumn = new DataGridViewTextBoxColumn()
            {
                Name = "HID",
                HeaderText = "HID",
                DataPropertyName = "HID",
                Visible = false // 隐藏
            };
            dgvDueWork.Columns.Add(hidColumn);

            dgvDueWork.DataSource = dt;
        }
    }
}

       private void dgvDueWork_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 获取当前作业的 HID
                int hid = Convert.ToInt32(dgvDueWork.Rows[e.RowIndex].Cells["HID"].Value);

                FormProblems form = new FormProblems(hid, _studentId, true); // 允许提交
                form.ShowDialog();
            }
        }


    }
}
