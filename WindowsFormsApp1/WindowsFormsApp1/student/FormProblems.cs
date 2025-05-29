using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace WindowsFormsApp1
{
    public partial class FormProblems : MaterialForm
    {
        private int _hid;
        private int _studentId;
        private bool _canCommit;
        private bool _isExam;
        private bool _hasSubmitted = false;
        private List<ProblemInfo> _problems = new List<ProblemInfo>();
        private int _currentProblemId = 0;
        private int _currentProblemIndex = -1;
        private Dictionary<int, string> _currentAnswers = new Dictionary<int, string>();

        private class ProblemInfo
        {
            public int PID { get; set; }
            public string ProName { get; set; }
            public string ProText { get; set; }
        }

        public FormProblems(int hid, int studentId, bool canCommit, bool isExam = false)
        {
            InitializeComponent();
            _hid = hid;
            _studentId = studentId;
            _canCommit = canCommit;
            _isExam = isExam;

            InitializeForm();
            LoadProblems();

            if (_canCommit)
                txtAnswer.TextChanged += TxtAnswer_TextChanged;
        }

        private void TxtAnswer_TextChanged(object sender, EventArgs e)
        {
            // 实时保存当前输入到内存
            if (_currentProblemId > 0)
                _currentAnswers[_currentProblemId] = txtAnswer.Text;
        }

        private void InitializeForm()
        {
            if (_isExam)
            {
                this.Text = "在线考试";
                btnCommit.Text = "提交考试";
                lblAnswerArea.Text = "考试答题";
                this.FormClosing += FormProblems_FormClosing;
                this.ControlBox = false;
            }
            else
            {
                this.Text = "作业练习";
                btnCommit.Text = "提交作业";
                lblAnswerArea.Text = "作业答题";
            }

            if (_canCommit)
            {
                pnlAnswerContent.Visible = true;
                pnlSubmissionHistory.Visible = false;
                btnCommit.Visible = true;
                btnSubmitSingle.Visible = true;
            }
            else
            {
                pnlAnswerContent.Visible = false;
                pnlSubmissionHistory.Visible = true;
                btnCommit.Visible = false;
                btnSubmitSingle.Visible = false;
                lblAnswerArea.Text = "提交历史";
            }
        }

        private void LoadProblems()
        {
            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"SELECT p.PID, p.ProName, p.ProText
                               FROM Problem p
                               JOIN ProH ph ON p.PID = ph.PID
                               WHERE ph.HID = @hid
                               ORDER BY p.PID";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hid", _hid);
                    using (var reader = cmd.ExecuteReader())
                    {
                        _problems.Clear();
                        lstProblems.Items.Clear();
                        int count = 0; // 调试用
                        while (reader.Read())
                        {
                            var problem = new ProblemInfo
                            {
                                PID = reader.GetInt32(0),
                                ProName = reader.GetString(1),
                                ProText = reader.GetString(2)
                            };
                            _problems.Add(problem);
                            lstProblems.Items.Add($"{problem.PID}. {problem.ProName}");
                            count++;
                        }
                        // 这里加调试输出
                        Console.WriteLine($"[调试] 当前HID={_hid}，查到题目数量={count}");
                    }
                }
            }
            LoadAllExistingAnswers();
            if (_problems.Count > 0)
            {
                lstProblems.SelectedIndex = 0;
            }
        }

        private void LoadAllExistingAnswers()
        {
            if (!_canCommit) return;
            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"SELECT PID, Answer FROM [Commit] WHERE StudentID = @sid AND HID = @hid";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", _studentId);
                    cmd.Parameters.AddWithValue("@hid", _hid);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int pid = reader.GetInt32(0);
                            string answer = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            _currentAnswers[pid] = answer;
                        }
                    }
                }
            }
        }

        private void lstProblems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newIndex = lstProblems.SelectedIndex;
            if (newIndex < 0 || newIndex >= _problems.Count) return;

            // 切换前保存当前题目输入到内存
            if (_canCommit && _currentProblemIndex >= 0 && _currentProblemIndex < _problems.Count)
            {
                int prevPid = _problems[_currentProblemIndex].PID;
                _currentAnswers[prevPid] = txtAnswer.Text;
            }

            _currentProblemIndex = newIndex;
            ShowProblemDetails(newIndex);
        }

        private void ShowProblemDetails(int index)
        {
            if (index < 0 || index >= _problems.Count) return;
            var selectedProblem = _problems[index];
            _currentProblemId = selectedProblem.PID;

            rtbProblemContent.Text = $"题目名称：{selectedProblem.ProName}\n\n题目内容：\n{selectedProblem.ProText}";

            if (_canCommit)
            {
                txtAnswer.TextChanged -= TxtAnswer_TextChanged;
                txtAnswer.Text = _currentAnswers.ContainsKey(_currentProblemId) ? _currentAnswers[_currentProblemId] : "";
                txtAnswer.TextChanged += TxtAnswer_TextChanged;
            }
            else
            {
                LoadSubmissionHistory(selectedProblem.PID);
            }
        }

        private void LoadSubmissionHistory(int pid)
        {
            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"SELECT CommitTime AS '提交时间', Answer AS '提交答案',
                              CASE WHEN Score IS NULL THEN '未评分' ELSE CAST(Score AS TEXT) END AS '得分'
                              FROM [Commit]
                              WHERE StudentID = @sid AND HID = @hid AND PID = @pid
                              ORDER BY CommitTime DESC";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", _studentId);
                    cmd.Parameters.AddWithValue("@hid", _hid);
                    cmd.Parameters.AddWithValue("@pid", pid);
                    var adapter = new SQLiteDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    dgvSubmissionHistory.DataSource = dt;
                }
            }
        }

        private void btnSubmitSingle_Click(object sender, EventArgs e)
        {
            if (_currentProblemId == 0)
            {
                MessageBox.Show("请先选择要提交的题目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string answer = txtAnswer.Text.Trim();
            if (string.IsNullOrEmpty(answer))
            {
                MessageBox.Show("请输入答案后再提交！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var currentProblem = _problems.FirstOrDefault(p => p.PID == _currentProblemId);
            string problemName = currentProblem?.ProName ?? "";
            DialogResult result = MessageBox.Show($"确定要提交题目 \"{problemName}\" 的答案吗？",
                "确认提交", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (SaveAnswer(_currentProblemId, answer))
                {
                    MessageBox.Show("提交成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _currentAnswers[_currentProblemId] = answer;
                    UpdateProblemListDisplay();
                }
                else
                {
                    MessageBox.Show("提交失败，请重试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateProblemListDisplay()
        {
            int selectedIndex = lstProblems.SelectedIndex;
            lstProblems.SelectedIndexChanged -= lstProblems_SelectedIndexChanged;
            lstProblems.Items.Clear();
            for (int i = 0; i < _problems.Count; i++)
            {
                var problem = _problems[i];
                string displayText = $"{problem.PID}. {problem.ProName}";
                if (HasAnswerInMemory(problem.PID))
                    displayText += " ✓";
                lstProblems.Items.Add(displayText);
            }
            if (selectedIndex >= 0 && selectedIndex < lstProblems.Items.Count)
                lstProblems.SelectedIndex = selectedIndex;
            lstProblems.SelectedIndexChanged += lstProblems_SelectedIndexChanged;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            // 提交前保存当前题目输入
            if (_canCommit && _currentProblemIndex >= 0 && _currentProblemIndex < _problems.Count)
            {
                int prevPid = _problems[_currentProblemIndex].PID;
                _currentAnswers[prevPid] = txtAnswer.Text;
            }

            // 检查未作答题目
            var unansweredProblems = _problems.Where(p => !HasAnswerInMemory(p.PID)).Select(p => p.ProName).ToList();
            if (unansweredProblems.Count > 0)
            {
                string message = $"以下题目尚未作答：\n{string.Join("\n", unansweredProblems)}\n\n确定要提交吗？";
                DialogResult result = MessageBox.Show(message, "确认提交", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }
            else
            {
                DialogResult result = MessageBox.Show(_isExam ? "确定要提交考试答案吗？提交后将无法修改。" : "确定要提交作业吗？",
                    "确认提交", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }

            // 批量保存所有答案
            foreach (var kv in _currentAnswers)
            {
                SaveAnswer(kv.Key, kv.Value);
            }

            _hasSubmitted = true;
            MessageBox.Show(_isExam ? "考试提交成功！" : "作业提交成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private bool HasAnswerInMemory(int pid)
        {
            return _currentAnswers.ContainsKey(pid) && !string.IsNullOrEmpty(_currentAnswers[pid]?.Trim());
        }

        private bool SaveAnswer(int pid, string answer)
        {
            try
            {
                string commitTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string connStr = "Data Source=StudentSystem.db;Version=3;";
                using (var conn = new SQLiteConnection(connStr))
                {
                    conn.Open();
                    string deleteSql = @"DELETE FROM [Commit] WHERE StudentID=@sid AND HID=@hid AND PID=@pid";
                    using (var delCmd = new SQLiteCommand(deleteSql, conn))
                    {
                        delCmd.Parameters.AddWithValue("@sid", _studentId);
                        delCmd.Parameters.AddWithValue("@hid", _hid);
                        delCmd.Parameters.AddWithValue("@pid", pid);
                        delCmd.ExecuteNonQuery();
                    }
                    string sql = @"INSERT INTO [Commit] (StudentID, HID, PID, Answer, CommitTime, Score, Feedback) 
                                   VALUES (@sid, @hid, @pid, @ans, @ctime, NULL, NULL)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", _studentId);
                        cmd.Parameters.AddWithValue("@hid", _hid);
                        cmd.Parameters.AddWithValue("@pid", pid);
                        cmd.Parameters.AddWithValue("@ans", answer);
                        cmd.Parameters.AddWithValue("@ctime", commitTime);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存答案时发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void FormProblems_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isExam && e.CloseReason == CloseReason.UserClosing && !_hasSubmitted)
            {
                e.Cancel = true;
                MessageBox.Show("考试进行中，请先提交答案再关闭窗口。", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}