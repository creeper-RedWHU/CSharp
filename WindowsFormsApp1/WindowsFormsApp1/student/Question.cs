using Sunny.UI;
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
using WindowsFormsApp1.student;

namespace WindowsFormsApp1
{
    public partial class Question : UserControl
    {
        private int _courseId;
        private int _studentId;
        private List<QuestionInfo> _questions = new List<QuestionInfo>();
        private int _selectedQuestionId = 0;

        private class QuestionInfo
        {
            public int QID { get; set; }
            public int AskerID { get; set; }
            public string Content { get; set; }
            public string AskerName { get; set; }
        }

        private class AnswerInfo
        {
            public int AID { get; set; }
            public int QID { get; set; }
            public int ResponderID { get; set; }
            public string Content { get; set; }
            public string ResponderName { get; set; }
        }

        public Question(int courseId, int studentId)
        {
            InitializeComponent();
            _courseId = courseId;
            _studentId = studentId;

            InitializeStyles();
        }

        private void InitializeStyles()
        {
            // 设置 ListBox 为自绘模式
            lstQuestions.DrawMode = DrawMode.OwnerDrawFixed;
            lstQuestions.ItemHeight = 80;

            // 设置控件自适应
            this.Resize += Question_Resize;

            // 美化按钮样式
            SetButtonStyle(btnAsk, Color.DodgerBlue);
            SetButtonStyle(btnReply, Color.Green);
            SetButtonStyle(btnRefresh, Color.Orange);
        }

        private void SetButtonStyle(Button btn, Color backColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            // 添加鼠标悬停效果
            btn.MouseEnter += (s, e) => {
                btn.BackColor = ControlPaint.Light(backColor);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = backColor;
            };
        }

        private void Question_Resize(object sender, EventArgs e)
        {
            // 调整控件大小以适应窗体
            if (lstQuestions != null)
            {
                lstQuestions.Width = leftPanel.Width - 30;
                lstQuestions.Height = leftPanel.Height - 120;
            }

            if (rtbQuestionContent != null)
            {
                rtbQuestionContent.Width = topRightPanel.Width - 30;
                rtbQuestionContent.Height = topRightPanel.Height - 75;
            }

            if (pnlAnswersList != null)
            {
                pnlAnswersList.Width = bottomRightPanel.Width - 30;
                pnlAnswersList.Height = bottomRightPanel.Height - 135;
            }

            if (pnlAnswerButtons != null)
            {
                pnlAnswerButtons.Width = bottomRightPanel.Width - 30;
            }

            if (btnAsk != null)
            {
                btnAsk.Width = leftPanel.Width - 30;
            }
        }

        private void Question_Load(object sender, EventArgs e)
        {
            LoadQuestions();
        }

        // 自定义绘制问题列表项
        private void lstQuestions_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= _questions.Count) return;

            var question = _questions[e.Index];

            // 设置背景色
            Color backColor = e.State.HasFlag(DrawItemState.Selected) ?
                Color.LightBlue : Color.White;

            using (Brush backBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            // 绘制边框
            using (Pen borderPen = new Pen(Color.LightGray))
            {
                e.Graphics.DrawRectangle(borderPen, e.Bounds.X, e.Bounds.Y,
                    e.Bounds.Width - 1, e.Bounds.Height - 1);
            }

            // 绘制问题内容（截断显示）
            string displayContent = question.Content.Length > 50 ?
                question.Content.Substring(0, 50) + "..." : question.Content;

            using (Brush textBrush = new SolidBrush(Color.Black))
            {
                Font titleFont = new Font("微软雅黑", 10F, FontStyle.Bold);
                Font contentFont = new Font("微软雅黑", 9F);
                Font timeFont = new Font("微软雅黑", 8F);

                // 绘制提问者信息（不显示时间，因为没有CreateTime字段）
                string header = $"👤 {question.AskerName} 提问 • Q{question.QID}";
                e.Graphics.DrawString(header, timeFont, Brushes.Gray,
                    e.Bounds.X + 8, e.Bounds.Y + 5);

                // 绘制问题内容
                Rectangle contentRect = new Rectangle(e.Bounds.X + 8, e.Bounds.Y + 25,
                    e.Bounds.Width - 16, e.Bounds.Height - 35);
                e.Graphics.DrawString(displayContent, contentFont, textBrush, contentRect);
            }

            e.DrawFocusRectangle();
        }

        // 加载所有问题 - 根据你的实际表结构修改
        private void LoadQuestions()
        {
            _questions.Clear();
            lstQuestions.Items.Clear();

            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                // 修改SQL查询，移除CreateTime字段，使用你的实际表结构
                string sql = @"SELECT q.QID, q.AskerID, q.Content,
                              COALESCE(u.Username, '未知用户') as AskerName
                              FROM Question q
                              LEFT JOIN Users u ON q.AskerID = u.ID
                              ORDER BY q.QID DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            {
                                var question = new QuestionInfo
                                {
                                    QID = reader.GetInt32(0), // 0是QID的索引
                                    AskerID = reader.GetInt32(1),
                                    Content = reader.GetString(2),
                                    AskerName = reader.GetString(3)
                                };

                                _questions.Add(question);
                                lstQuestions.Items.Add($"Q{question.QID}");
                            }
                    }
                }
            }

            // 如果有问题，默认选中第一个
            if (_questions.Count > 0)
            {
                lstQuestions.SelectedIndex = 0;
            }
            else
            {
                rtbQuestionContent.Text = "暂无问题，点击‘我要提问’发起第一个讨论吧！ 🎉";
                flpAnswers.Controls.Clear();
            }
        }

        // 选中问题时显示内容和回复
        private void lstQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedIndex < 0 || lstQuestions.SelectedIndex >= _questions.Count)
                return;

            var selectedQuestion = _questions[lstQuestions.SelectedIndex];
            _selectedQuestionId = selectedQuestion.QID;

            // 显示问题详细内容（不显示时间）
            rtbQuestionContent.Text = $"🗣️ {selectedQuestion.AskerName} 提问（Q{selectedQuestion.QID}）：\n\n{selectedQuestion.Content}";

            // 加载并显示回复
            LoadAnswers(selectedQuestion.QID);
        }

        private void LoadAnswers(int questionId)
        {
            flpAnswers.Controls.Clear();

            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                // 修改SQL查询，确保正确过滤对应问题的回答
                string sql = @"SELECT a.AID, a.QID, a.ResponderID, a.Content,
                            COALESCE(u.Username, '未知用户') as ResponderName
                            FROM Answer a
                            LEFT JOIN Users u ON a.ResponderID = u.ID
                            WHERE a.QID = @qid 
                            ORDER BY a.AID ASC";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@qid", questionId);  // 确保这行存在
                    
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        int answerCount = 0;
                        while (reader.Read())
                        {
                            var answer = new AnswerInfo
                            {
                                AID = reader.GetInt32("AID"),
                                QID = reader.GetInt32("QID"),
                                ResponderID = reader.GetInt32("ResponderID"),
                                Content = reader.GetString("Content"),
                                ResponderName = reader.GetString("ResponderName")
                            };

                            CreateAnswerCard(answer, ++answerCount);
                        }

                        if (answerCount == 0)
                        {
                            CreateNoAnswerCard();
                        }
                    }
                }
            }
        }

        private void CreateAnswerCard(AnswerInfo answer, int index)
        {
            Panel answerCard = new Panel
            {
                Width = flpAnswers.Width - 40,
                Height = 120,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5, 5, 5, 10)
            };

            // 回复标题（不显示时间，因为没有CreateTime字段）
            Label lblHeader = new Label
            {
                Text = $"💬 #{index} {answer.ResponderName} 的回复 (A{answer.AID})",
                Font = new Font("微软雅黑", 9F, FontStyle.Bold),
                ForeColor = Color.DodgerBlue,
                Location = new Point(10, 8),
                Size = new Size(answerCard.Width - 20, 20)
            };

            // 回复内容
            TextBox txtContent = new TextBox
            {
                Text = answer.Content,
                Font = new Font("微软雅黑", 10F),
                Multiline = true,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Location = new Point(10, 35),
                Size = new Size(answerCard.Width - 20, 75),
                ScrollBars = ScrollBars.Vertical
            };

            answerCard.Controls.Add(lblHeader);
            answerCard.Controls.Add(txtContent);
            flpAnswers.Controls.Add(answerCard);
        }

        private void CreateNoAnswerCard()
        {
            Panel noAnswerCard = new Panel
            {
                Width = flpAnswers.Width - 40,
                Height = 80,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblNoAnswer = new Label
            {
                Text = "🤔 暂无回复，快来抢沙发吧！",
                Font = new Font("微软雅黑", 12F, FontStyle.Bold),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            noAnswerCard.Controls.Add(lblNoAnswer);
            flpAnswers.Controls.Add(noAnswerCard);
        }

        // 回复按钮点击事件
        private void btnReply_Click(object sender, EventArgs e)
        {
            // 直接用当前选中的问题索引判断
            int idx = lstQuestions.SelectedIndex;
            if (idx < 0 || idx >= _questions.Count)
            {
                MessageBox.Show("请先选择要回复的问题！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedQuestion = _questions[idx];
            int questionId = selectedQuestion.QID;

            using (var inputForm = new InputBoxForm("回复问题", "请输入你的回复内容："))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string reply = inputForm.InputText.Trim();
                    if (string.IsNullOrWhiteSpace(reply))
                    {
                        MessageBox.Show("回复内容不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 保存回复到数据库
                    string connStr = "Data Source=StudentSystem.db;Version=3;";
                    using (SQLiteConnection conn = new SQLiteConnection(connStr))
                    {
                        conn.Open();
                        string sql = "INSERT INTO Answer (QID, ResponderID, Content) VALUES (@qid, @sid, @content)";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@qid", questionId);
                            cmd.Parameters.AddWithValue("@sid", _studentId);
                            cmd.Parameters.AddWithValue("@content", reply);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("回复发表成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 刷新回复列表
                    LoadAnswers(questionId);
                }
            }
        }

        // 我要提问按钮点击事件
        private void btnAsk_Click(object sender, EventArgs e)
        {
            using (var inputForm = new InputBoxForm("发起新问题", "请输入你的问题："))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string question = inputForm.InputText.Trim();
                    if (string.IsNullOrWhiteSpace(question))
                    {
                        MessageBox.Show("问题内容不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 保存问题到数据库（移除CreateTime字段）
                    string connStr = "Data Source=StudentSystem.db;Version=3;";
                    using (SQLiteConnection conn = new SQLiteConnection(connStr))
                    {
                        conn.Open();
                        string sql = "INSERT INTO Question (AskerID, Content) VALUES (@sid, @content)";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@sid", _studentId);
                            cmd.Parameters.AddWithValue("@content", question);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("问题发表成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 刷新问题列表
                    LoadQuestions();
                }
            }
        }

        // 刷新按钮点击事件
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadQuestions();
            MessageBox.Show("刷新完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}