using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Form1Tea._5exam
{
    public partial class PGNext : UserControl
    {
        private int HID;

        public PGNext(int x)
        {
            InitializeComponent();
            HID = x;
        }

        public void UpdateData()
        {
            dataGridView1.Rows.Clear();
            foreach (int stuId in Params.array)
            {
                // 1. 查找学生姓名
                string stuName = "";
                using (var conn = new SQLiteConnection(Params.connstr))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand("SELECT Name FROM Users WHERE ID=@uid", conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", stuId);
                        var obj = cmd.ExecuteScalar();
                        stuName = obj == null ? "" : obj.ToString();
                    }

                    // 2. 查找提交情况
                    string isCommit = "未提交";
                    string commitTime = "无";
                    string score = "-";
                    string chooseText = "无法批阅";

                    using (var cmd = new SQLiteCommand("SELECT CommitTime, Score FROM [Commit] WHERE StudentID=@sid AND HID=@hid", conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", stuId);
                        cmd.Parameters.AddWithValue("@hid", HID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            int totalScore = 0;
                            string firstCommitTime = null;
                            bool hasCommit = false;
                            while (reader.Read())
                            {
                                hasCommit = true;
                                if (firstCommitTime == null)
                                    firstCommitTime = reader["CommitTime"]?.ToString();
                                int s;
                                if (int.TryParse(reader["Score"]?.ToString(), out s))
                                    totalScore += s;
                            }
                            if (hasCommit)
                            {
                                isCommit = "已提交";
                                commitTime = firstCommitTime ?? "无";
                                score = totalScore.ToString();
                                chooseText = "批阅";
                            }
                        }
                    }

                    // 添加到DataGridView
                    int idx = dataGridView1.Rows.Add();
                    var row = dataGridView1.Rows[idx];
                    row.Cells["StuID"].Value = stuId;
                    row.Cells["StuName"].Value = stuName;
                    row.Cells["isCommit"].Value = isCommit;
                    row.Cells["Time"].Value = commitTime;
                    row.Cells["Score"].Value = score;
                    row.Cells["Choose"].Value = chooseText;
                    // 如果无法批阅则禁用按钮
                    DataGridViewButtonCell btnCell = row.Cells["Choose"] as DataGridViewButtonCell;
                    if (chooseText == "无法批阅")
                    {
                        btnCell.Style.ForeColor = System.Drawing.Color.Gray;
                        btnCell.Style.SelectionForeColor = System.Drawing.Color.Gray;
                        btnCell.FlatStyle = FlatStyle.Flat;
                        btnCell.ReadOnly = true;
                    }
                    else
                    {
                        btnCell.Style.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
                        btnCell.Style.SelectionForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
                        btnCell.FlatStyle = FlatStyle.Standard;
                        btnCell.ReadOnly = false;
                    }
                }
            }
        }

        public event Action<int> GoToFinal;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Choose" && dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()!="无法批阅")
            {
                string x = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                MessageBox.Show("您将要批阅" + x + "的作业");
                //GoToEditPage?.Invoke(x);
                Params.PYFinalStuID=int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                GoToFinal?.Invoke(HID);
            }
            else if(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "无法批阅")
            {
                MessageBox.Show("该同学尚未完成作业！");
            }
        }
    }
}
