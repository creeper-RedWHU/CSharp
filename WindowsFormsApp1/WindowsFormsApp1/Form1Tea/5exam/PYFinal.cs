using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Form1Tea._5exam
{
    public partial class PYFinal : UserControl
    {
        private readonly int HID;
        HT ht;
        private List<CommitMent> list = new List<CommitMent>();
        private List<Button> sidebarButtons = new List<Button>();
        private List<Problem> problems = new List<Problem>();
        private List<int>score = new List<int>();
        public PYFinal(int HID)
        {
            InitializeComponent();
            this.HID = HID;
            ht = GetHTByHID();
            GetCommitMentsByHIDAndStudentID(HID);
            InitialPainter();
            CreateButtons(createID());
            panel3.Hide();
            getProblems();
            getScore();
            
        }
        private void InitialPainter()
        {
            this.label1.Text = "您正在批阅学生" + Params.PYFinalStuID.ToString() + "的";
            if(ht.IsTest == 1) { label1.Text += "考试，试卷编号为" + HID;labelTitle.Text = "考试批阅中"; }
            else { label1.Text += "作业，作业编号为" + HID;labelTitle.Text = "作业批阅中"; }
        }

        private void getScore()
        {
            score.Clear();
            using (var conn = new SQLiteConnection(Params.connstr))
            {
                conn.Open();
                foreach (var p in problems)
                {
                    int s = 0;
                    string sql = "SELECT Score FROM ProH WHERE HID=@hid AND PID=@pid LIMIT 1";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@hid", HID);
                        cmd.Parameters.AddWithValue("@pid", p.PID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && reader["Score"] != DBNull.Value)
                                s = Convert.ToInt32(reader["Score"]);
                        }
                    }
                    score.Add(s);
                }
            }
        }

        private void getProblems()
        {
            HashSet<int> pidSet = new HashSet<int>();
            foreach (var cm in list)
            {
                if (!pidSet.Contains(cm.PID))
                    pidSet.Add(cm.PID);
            }
            if (pidSet.Count == 0) return ;

            using (var conn = new SQLiteConnection(Params.connstr))
            {
                conn.Open();
                foreach (int pid in pidSet)
                {
                    string sql = "SELECT PID, ProName, ProText, ProCategory, Ans, Analysis, InputInformation, ChangeInformation, IsTest FROM Problem WHERE PID=@pid";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", pid);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Problem p = new Problem
                                {
                                    PID = reader.GetInt32(reader.GetOrdinal("PID")),
                                    ProName = reader["ProName"]?.ToString(),
                                    ProText = reader["ProText"]?.ToString(),
                                    ProCategory = reader["ProCategory"]?.ToString(),
                                    Ans = reader["Ans"]?.ToString(),
                                    Analysis = reader["Analysis"]?.ToString(),
                                    InputInformation = reader["InputInformation"]?.ToString(),
                                    ChangeInformation = reader["ChangeInformation"]?.ToString(),
                                    IsTest = reader["IsTest"]?.ToString()
                                };
                                problems.Add(p);
                            }
                        }
                    }
                }
            }
        }

        public ArrayList createID()
        {
            ArrayList arlist = new ArrayList();
            
            foreach(CommitMent x in list)
            {
                arlist.Add(x.PID);
            }
            return arlist;
        }

        public void CreateButtons(ArrayList arrayList)
        {
            flowLayoutPanel2.Controls.Clear(); // 先清空原有控件
            if(sidebarButtons!=null)sidebarButtons.Clear();  // 清空按钮集合
            for (int i = 0; i < arrayList.Count; i++)
            {
                Button btn = new Button();
                btn.Name = "button" + arrayList[i].ToString();
                btn.Text = (i+1).ToString();
                btn.Width = 32;
                btn.Height = 32;
                btn.Margin = new Padding(3, 2, 3, 2);
                btn.Tag = arrayList[i]; // 可用于后续识别
                btn.Click += Btn_Click;
                
                btn.Cursor = Cursors.Hand;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
                btn.UseVisualStyleBackColor = false;
                btn.Show();
                flowLayoutPanel2.Controls.Add(btn);
                sidebarButtons.Add(btn); // 正确添加到集合
                
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Btn_Clicker(sender as Button);
            Button temp = sender as Button;
            int index = int.Parse(temp.Text) - 1;

            label9.Text = problems[index].ProName;
            textBox4.Text = problems[index].ProText;
            textBox2.Text = problems[index].Ans;
            textBox1.Text = list[index].Answer;
            textBox3.Text = list[index].Score.ToString();
            label8.Text = "（满分：" + score[index] + "分）";
            textBox5.Text = list[index].FeedBack;
            panel3.Show();
        }

        public void Btn_Clicker(Button selectedButton)
        {
            foreach (var btn in sidebarButtons)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
            }
            selectedButton.BackColor = Color.FromArgb(40, 167, 69); // 绿色
            selectedButton.ForeColor = Color.White;
            selectedButton.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        }

        public void GetCommitMentsByHIDAndStudentID(int hid)
        {
            
            using (var conn = new SQLiteConnection(Params.connstr))
            {
                conn.Open();
                string sql = "SELECT StudentID, HID, PID, Answer, Score, CommitTime, FeedBack FROM [Commit] WHERE HID=@hid AND StudentID=@sid";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hid", hid);
                    cmd.Parameters.AddWithValue("@sid", Params.PYFinalStuID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CommitMent cm = new CommitMent
                            {
                                StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                                HID = reader.GetInt32(reader.GetOrdinal("HID")),
                                PID = reader.GetInt32(reader.GetOrdinal("PID")),
                                Answer = reader["Answer"]?.ToString(),
                                Score = reader.GetInt32(reader.GetOrdinal("Score")),
                                CommitTime = reader["CommitTime"]?.ToString(),
                                FeedBack = reader["FeedBack"]?.ToString()
                            };
                            list.Add(cm);
                        }
                    }
                }
            }
            list.Sort();
        }

        public HT GetHTByHID()
        {
            HT result = null;
            using (var conn = new SQLiteConnection(Params.connstr))
            {
                conn.Open();
                string sql = "SELECT HID, HName, HText, StartTime, EndTime, InputInformation, ChangeInformation, IsTest, isValid FROM HMK WHERE HID = @hid";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hid", HID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = new HT
                            {
                                HID = reader.GetInt32(reader.GetOrdinal("HID")),
                                HName = reader["HName"].ToString(),
                                HText = reader["HText"].ToString(),
                                StartTime = reader["StartTime"].ToString(),
                                EndTime = reader["EndTime"].ToString(),
                                InputInformation = reader["InputInformation"].ToString(),
                                ChangeInformation = reader["ChangeInformation"].ToString(),
                                IsTest = Convert.ToInt32(reader["IsTest"]),
                                isValid = Convert.ToInt32(reader["isValid"])
                            };
                        }
                    }
                }
            }
            return result;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // 获取当前题目索引
            int index = GetCurrentProblemIndex();
            if (index < 0 || index >= list.Count) return;

            // 提交分数
            int newScore = 0;
            if (int.TryParse(textBox3.Text.Trim(), out newScore))
            {
                if (newScore < 0 || newScore > score[index]) { MessageBox.Show("请输入正确的分数！");return; }
                list[index].Score = newScore;
                using (var conn = new SQLiteConnection(Params.connstr))
                {
                    conn.Open();
                    string sql = "UPDATE [Commit] SET Score=@score WHERE HID=@hid AND StudentID=@sid AND PID=@pid";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@score", newScore);
                        cmd.Parameters.AddWithValue("@hid", HID);
                        cmd.Parameters.AddWithValue("@sid", Params.PYFinalStuID);
                        cmd.Parameters.AddWithValue("@pid", list[index].PID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // 提交评语
            string newFeedback = textBox5.Text.Trim();
            if (string.IsNullOrEmpty(newFeedback)) { newFeedback = "无"; }
            list[index].FeedBack = newFeedback;
            using (var conn = new SQLiteConnection(Params.connstr))
            {
                conn.Open();
                string sql = "UPDATE [Commit] SET FeedBack=@fb WHERE HID=@hid AND StudentID=@sid AND PID=@pid";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fb", newFeedback);
                    cmd.Parameters.AddWithValue("@hid", HID);
                    cmd.Parameters.AddWithValue("@sid", Params.PYFinalStuID);
                    cmd.Parameters.AddWithValue("@pid", list[index].PID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("批阅结果已提交！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int GetCurrentProblemIndex()
        {
            string currentProName = label9.Text;
            for (int i = 0; i < problems.Count; i++)
            {
                if (problems[i].ProName == currentProName)
                    return i;
            }
            return -1;
        }

        // ...existing code...

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
