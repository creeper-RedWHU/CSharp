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
using Sunny.UI;

namespace WindowsFormsApp1
{
    public partial class FormProblems : Form
    {
        private int _hid;
        private int _studentId;
        private bool _canCommit;

        public FormProblems(int hid, int studentId, bool canCommit)
        {
            InitializeComponent();
            _hid = hid;
            _studentId = studentId;
            _canCommit = canCommit;
            LoadProblems();
            btnCommit.Visible = _canCommit;
        }

            private void LoadProblems()
            {
                string connStr = "Data Source=StudentSystem.db;Version=3;";
                using (SQLiteConnection conn = new SQLiteConnection(connStr))
                {
                    conn.Open();
                    string sql = @"
                        SELECT p.PID, p.ProName AS 题目名称, p.ProText AS 题目内容
                        FROM Problem p
                        JOIN ProH ph ON p.PID = ph.PID
                        WHERE ph.HID = @hid";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@hid", _hid);
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // 先清空列，防止重复添加
                        dgvProblems.Columns.Clear();
                        dgvProblems.AutoGenerateColumns = false;

                        // 添加三列并设置均分
                        dgvProblems.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            Name = "colProName",
                            HeaderText = "题目名称",
                            DataPropertyName = "题目名称",
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        });

                        DataGridViewTextBoxColumn colProText = new DataGridViewTextBoxColumn()
                        {
                            Name = "colProText",
                            HeaderText = "题目内容",
                            DataPropertyName = "题目内容",
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                        };
                        colProText.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // 设置自动换行
                        dgvProblems.Columns.Add(colProText);

                        // 设置表格样式
                        dgvProblems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvProblems.RowTemplate.Height = 32;
                        dgvProblems.Font = new Font("微软雅黑", 12F);
                        dgvProblems.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
                        dgvProblems.EnableHeadersVisualStyles = false;
                        dgvProblems.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        dgvProblems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgvProblems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvProblems.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;

                        dgvProblems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // 设置行高自适应

                        dgvProblems.DataSource = dt; // 设置数据源

                        // 如果允许提交，动态生成答题框
                        if (_canCommit)
                        {
                            panelAnswers.Controls.Clear();
                            foreach (DataRow row in dt.Rows)
                            {
                                UILabel lbl = new UILabel { Text = row["题目名称"].ToString(), AutoSize = true };
                                UITextBox txt = new UITextBox { Name = "txtAnswer_" + row["PID"], Width = 400 };
                                panelAnswers.Controls.Add(lbl);
                                panelAnswers.Controls.Add(txt);
                            }
                        }
                    }
                }
            }
        private void btnCommit_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panelAnswers.Controls)
            {
                if (ctrl is UITextBox txt)
                {
                    string pidStr = txt.Name.Replace("txtAnswer_", "");
                    int pid = int.Parse(pidStr);
                    string answer = txt.Text.Trim();
                    string commitTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    using (SQLiteConnection conn = new SQLiteConnection("Data Source=StudentSystem.db;Version=3;"))
                    {
                        conn.Open();

                        // 可选：先删除已提交的记录，防止重复提交
                        string deleteSql = @"DELETE FROM Commit WHERE StudentID=@sid AND HID=@hid AND PID=@pid";
                        using (SQLiteCommand delCmd = new SQLiteCommand(deleteSql, conn))
                        {
                            delCmd.Parameters.AddWithValue("@sid", _studentId);
                            delCmd.Parameters.AddWithValue("@hid", _hid);
                            delCmd.Parameters.AddWithValue("@pid", pid);
                            delCmd.ExecuteNonQuery();
                        }

                        // 插入新提交
                        string sql = @"INSERT INTO Commit (StudentID, HID, PID, Answer, CommitTime) VALUES (@sid, @hid, @pid, @ans, @ctime)";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@sid", _studentId);
                            cmd.Parameters.AddWithValue("@hid", _hid);
                            cmd.Parameters.AddWithValue("@pid", pid);
                            cmd.Parameters.AddWithValue("@ans", answer);
                            cmd.Parameters.AddWithValue("@ctime", commitTime);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            MessageBox.Show("提交成功！");
            this.Close();
        }
    }
}