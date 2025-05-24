using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Form1Tea._1zy
{
    public partial class zyedit : UserControl
    {
        public zyedit()
        {
            InitializeComponent();
        }
        // 修改后的查询方法 
        public event Action GoToViewPage;
        private void delPro(int PID)
        {
            const string sql = @"DELETE FROM Problem WHERE PID = @PID";

            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var cmd = new SQLiteCommand(sql, conn);
                // 严格类型校验防止SQL注入
                cmd.Parameters.Add(new SQLiteParameter("@PID", DbType.Int32) { Value = PID });

                int affectedRows = cmd.ExecuteNonQuery();
            });
        }

        private Problem FindPro(int PID)
        {
            const string sql = @"
        SELECT PID, ProName, ProText, ProCategory, 
               Ans, Analysis, InputInformation, 
               ChangeInformation, IsTest 
        FROM Problem 
        WHERE PID = @PID 
        LIMIT 1";

            Problem result = null;

            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@PID", PID);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return;

                result = new Problem
                {
                    // 直接处理空值 
                    PID = reader.GetInt32(0),
                    ProName = reader["ProName"] is DBNull ? "" : (string)reader["ProName"],
                    ProText = reader["ProText"] is DBNull ? "" : (string)reader["ProText"],
                    ProCategory = reader["ProCategory"] is DBNull ? "" : (string)reader["ProCategory"],
                    Ans = reader["Ans"] is DBNull ? "" : (string)reader["Ans"],
                    Analysis = reader["Analysis"] is DBNull ? "" : (string)reader["Analysis"],
                    InputInformation = reader["InputInformation"] is DBNull ? "" : (string)reader["InputInformation"],
                    ChangeInformation = reader["ChangeInformation"] is DBNull ? "" : (string)reader["ChangeInformation"],
                    IsTest = reader["IsTest"] is DBNull ? "N" : (string)reader["IsTest"]
                };
            });
            delPro(PID);
            return result;
        }
        private string receivedIDGlobal;
        private string receivedTimeGlobal;
        public zyedit(string receivedID)
        { 
            InitializeComponent();
            label9.Text = "当前编辑的题目ID：" + receivedID;
            receivedIDGlobal= receivedID;
            Problem now = FindPro(int.Parse(receivedID));
            textBox1.Text = now.ProName;
            textBox2.Text = now.ProText;
            textBox3.Text = now.ProCategory;
            textBox4.Text = now.Ans;
            textBox5.Text = now.Analysis;
            receivedTimeGlobal=now.InputInformation;
            if(now.IsTest == "考试题")
            {
                radioButton1.Checked= true;
            }
            else radioButton2.Checked = true;
        }
        private void addPro(Problem pro)
        {
            const string sql = @"
                    INSERT INTO Problem (
                        PID, ProName, ProText, ProCategory, 
                        Ans, Analysis, InputInformation, 
                        ChangeInformation, IsTest 
                    ) VALUES (
                        @PID, @ProName, @ProText, @ProCategory, 
                        @Ans, @Analysis, @InputInformation, 
                        @ChangeInformation, @IsTest 
                    )";

            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var cmd = new SQLiteCommand(sql, conn);


                // 参数化绑定（类型安全校验）
                cmd.Parameters.AddWithValue("@PID", int.Parse(receivedIDGlobal));
                cmd.Parameters.AddWithValue("@ProName", pro.ProName.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ProText", pro.ProText.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ProCategory", pro.ProCategory.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Ans", pro.Ans.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Analysis", pro.Analysis.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@InputInformation", pro.InputInformation.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ChangeInformation", pro.ChangeInformation.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsTest", pro.IsTest.Trim());

                // 执行并验证影响行数 
                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new ApplicationException("插入操作未影响任何行");
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Problem pro = new Problem();
            pro.ProName = textBox1.Text;
            pro.ProText = textBox2.Text;
            pro.ProCategory = textBox3.Text;
            pro.Ans = textBox4.Text;
            pro.Analysis = textBox5.Text;
            if (radioButton1.Checked)
            {
                pro.IsTest = "考试题";
            }
            else { pro.IsTest = "作业题"; }
            pro.InputInformation = receivedTimeGlobal;
            pro.ChangeInformation = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff");
            if (pro.ProName.Length == 0 || pro.Ans.Length == 0 || pro.ProText.Length == 0)
            { MessageBox.Show("缺少重要元素！"); return; }
            MessageBox.Show("提交成功！");
            addPro(pro);
        }
    }
}
