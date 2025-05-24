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

namespace WindowsFormsApp1.Form1Tea.zy
{
    public partial class zyinput : UserControl
    {
        public zyinput()
        {
            InitializeComponent();
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
                cmd.Parameters.AddWithValue("@PID", getID.GetNextProID());
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
            pro.ProName=textBox1.Text;
            pro.ProText=textBox2.Text;
            pro.ProCategory=textBox3.Text;
            pro.Ans=textBox4.Text;
            pro.Analysis=textBox5.Text;
            if (radioButton1.Checked)
            {
                pro.IsTest = "考试题";
            }
            else { pro.IsTest = "作业题"; }
            pro.InputInformation = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"); ;
            pro.ChangeInformation = pro.InputInformation;
            if(pro.ProName.Length == 0 || pro.Ans.Length == 0 || pro.ProText.Length == 0)
                { MessageBox.Show("缺少重要元素！");return; }
            string emp = " ";
            textBox1.Text = 
                textBox2.Text =
                textBox3.Text =
                textBox4.Text =
                textBox5.Text = emp;
            radioButton2.Checked = true;
            radioButton1.Checked = false;
            MessageBox.Show("提交成功！");
            addPro(pro);
        }
    }
}
