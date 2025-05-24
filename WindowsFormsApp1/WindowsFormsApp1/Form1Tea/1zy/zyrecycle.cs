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
using WindowsFormsApp1.Form1Tea._1zy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1.Form1Tea.zy
{
    public partial class zyrecycle : UserControl
    {
        public zyrecycle()
        {
            InitializeComponent();
        }
        public void UpdateData(int x = 2)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            if (x == 2) { radioButton1.Checked = true; }
            getID.BindToTable(this.dataGridView1, "Problem", "0", x);
        }
        private void addPro(Problem pro)
        {
            const string sql = @"
                    INSERT INTO Problem (
                        PID, ProName, ProText, ProCategory, 
                        Ans, Analysis, InputInformation, 
                        ChangeInformation, IsTest ,isValid
                    ) VALUES (
                        @PID, @ProName, @ProText, @ProCategory, 
                        @Ans, @Analysis, @InputInformation, 
                        @ChangeInformation, @IsTest ,@isValid
                    )";

            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var cmd = new SQLiteCommand(sql, conn);


                // 参数化绑定（类型安全校验）
                cmd.Parameters.AddWithValue("@PID", pro.PID);
                cmd.Parameters.AddWithValue("@ProName", pro.ProName.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ProText", pro.ProText.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ProCategory", pro.ProCategory.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Ans", pro.Ans.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Analysis", pro.Analysis.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@InputInformation", pro.InputInformation.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ChangeInformation", pro.ChangeInformation.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsTest", pro.IsTest.Trim());
                cmd.Parameters.AddWithValue("@isValid", 1);
                // 执行并验证影响行数 
                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new ApplicationException("插入操作未影响任何行");
                }

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
            return result;
        }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Recover")
            {
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Problem xer =FindPro(int.Parse(x));
                delPro(int.Parse(x));
                addPro(xer);
                MessageBox.Show("您恢复了第" + x + "题");
                UpdateData();

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Del")
            {
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                delPro(int.Parse(x));
                MessageBox.Show("成功删除:第" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "题");
                UpdateData();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { UpdateData(); }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) { UpdateData(0); }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { UpdateData(1); }
        }
    }
}
