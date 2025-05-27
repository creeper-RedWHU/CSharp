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
        public Question(int courseId, int studentId)
        {
            InitializeComponent();
            _courseId = courseId;
            _studentId = studentId;
        }

        //加载所有问题
        private void LoadQuestions()
        {
            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT QID, Content FROM Question ORDER BY QID DESC";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        listBoxQuestions.DataSource = dt;
                        listBoxQuestions.DisplayMember = "Content";
                        listBoxQuestions.ValueMember = "QID";
                    }
                }
            }
        }

        //选中问题时显示内容和回复
        private void listBoxQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxQuestions.SelectedValue == null) return;
                var drv = listBoxQuestions.SelectedItem as DataRowView;
            if (drv == null) return;
                int qid = Convert.ToInt32(drv["QID"]);

            // 显示问题内容
            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Content FROM Question WHERE QID=@qid";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@qid", qid);
                    object content = cmd.ExecuteScalar();
                    labelQuestionContent.Text = content?.ToString() ?? "";
                }

                // 加载所有回复
                sql = @"SELECT Content FROM Answer WHERE QID=@qid ORDER BY AID";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@qid", qid);
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        listBoxAnswers.DataSource = dt;
                        listBoxAnswers.DisplayMember = "Content";
                    }
                }
            }
        }

        //回复按钮点击事件
        private void btnReply_Click(object sender, EventArgs e)
        {
                if (listBoxQuestions.SelectedItem == null) return;
                    var drv = listBoxQuestions.SelectedItem as DataRowView;
                if (drv == null) return;
                    int qid = Convert.ToInt32(drv["QID"]);
            string reply = textBoxReply.Text.Trim();
            if (string.IsNullOrEmpty(reply))
            {
                MessageBox.Show("回复内容不能为空！");
                return;
            }
            int studentId = _studentId; // 需从父窗体传递

            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO Answer (QID, ResponderID, Content) VALUES (@qid, @sid, @content)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@qid", qid);
                    cmd.Parameters.AddWithValue("@sid", studentId);
                    cmd.Parameters.AddWithValue("@content", reply);
                    cmd.ExecuteNonQuery();
                }
            }
            textBoxReply.Clear();
            listBoxQuestions_SelectedIndexChanged(null, null); // 刷新回复
        }

        //我要提问按钮点击事件
        private void btnAsk_Click(object sender, EventArgs e)
        {
            using (var inputForm = new InputBoxForm("我要提问", "请输入你的问题："))
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string question = inputForm.InputText.Trim();
                    if (string.IsNullOrWhiteSpace(question)) return;
                    int studentId = _studentId; // 你的实际学生ID

                    string connStr = "Data Source=StudentSystem.db;Version=3;";
                    using (SQLiteConnection conn = new SQLiteConnection(connStr))
                    {
                        conn.Open();
                        string sql = "INSERT INTO Question (AskerID, Content) VALUES (@sid, @content)";
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@sid", studentId);
                            cmd.Parameters.AddWithValue("@content", question);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadQuestions(); // 刷新问题列表
                }
            }
        }

    }
}
