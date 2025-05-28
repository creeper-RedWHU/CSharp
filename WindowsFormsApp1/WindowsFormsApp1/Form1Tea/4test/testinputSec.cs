using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Form1Tea._4test
{
    public partial class testinputSec : UserControl
    {
        public ArrayList arrayList;
        public int classID;
        public bool change;
        public int HIDOlder;

        public testinputSec()
        {
            InitializeComponent();
            change = false;
        }
        public void changeFromString(string x, DateTimePicker dateTimePicker1)
        {
            DateTime parsedDateTime;
            if (DateTime.TryParseExact(x,
                          "yyyy-MM-dd HH:mm",
                          CultureInfo.InvariantCulture,
                          DateTimeStyles.None,
                          out parsedDateTime))
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";  // 设置显示格式 
                dateTimePicker1.Value = parsedDateTime;            // 赋值时间值 
            }

        }
        public bool CompareDateTimeWithNow(DateTimePicker datePicker)
        {
            // 获取控件时间（精确到分钟）
            DateTime t1 = datePicker.Value.Date.AddHours(datePicker.Value.Hour)
                                              .AddMinutes(datePicker.Value.Minute);

            // 获取当前时间（精确到分钟）
            DateTime t2 = DateTime.Now.Date.AddHours(DateTime.Now.Hour)
                                           .AddMinutes(DateTime.Now.Minute);


            // 比较逻辑（考虑时间相等的情况）
            return t1 >= t2;
        }
        public void UpdateData()
        {
            if (change)
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                const string sql = @"  
            SELECT HID, HName, StartTime, EndTime  ,HText
            FROM HMK  
            WHERE HID = @HID  
            LIMIT 1";  // 双重唯一性保障  

                var result = (HID: 0, HName: "", StartTime: "", EndTime: "", HText: "");

                SqliteProblemConnectionManager.SafeExecute(conn =>
                {
                    using var cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.Add("@HID", DbType.Int32).Value = HIDOlder;

                    using var reader = cmd.ExecuteReader();

                    reader.Read();

                    // 带空值处理的数据读取  
                    result = (
                        HID: HIDOlder,
                        HName: reader["HName"] is DBNull ? "" : (string)reader["HName"],
                        StartTime: reader["StartTime"] is DBNull ? "" : (string)reader["StartTime"],
                        EndTime: reader["EndTime"] is DBNull ? "" : (string)reader["EndTime"],
                        HText: reader["HText"] is DBNull ? "" : (string)reader["HText"]
                    );

                });
                textBox1.Text = result.HName;
                textBox2.Text = result.HText;
                changeFromString(result.StartTime, dateTimePicker1);
                changeFromString(result.EndTime, dateTimePicker2);
                RefreshGridFromArrayList();
            }
            else
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
            }
        }
        public void RefreshGridFromArrayList()
        {
            dataGridView1.Rows.Clear();
            if (arrayList == null) { return; }
            foreach (var x in arrayList)
            {
                int pid = Convert.ToInt32(x);
                string proName = "";
                // 查询ProName
                const string sql = @"SELECT ProName FROM Problem WHERE PID = @PID LIMIT 1";
                SqliteProblemConnectionManager.SafeExecute(conn =>
                {
                    using var cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@PID", pid);
                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                        proName = reader["ProName"] is DBNull ? "" : (string)reader["ProName"];
                });

                int idx = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[idx];
                row.Cells["ID"].Value = pid;
                row.Cells["Title"].Value = proName;
                row.Cells["Score"].Value = 10;
            }
        }



        private void adder(HT hT)
        {
            if (change) { hT.HID = HIDOlder; }
            else hT.HID = getID.GetNextHTID();
            if (change)
            {

                const string sqldel = @"  
                        DELETE FROM HMK  
                        WHERE HID = @HID";  // 精确匹配目标配置记录  

                SqliteProblemConnectionManager.SafeExecute(conn =>
                {
                    using var transaction = conn.BeginTransaction();
                    try
                    {
                        using var cmd = new SQLiteCommand(sqldel, conn, transaction);

                        // 参数绑定（继承原有安全规范）  
                        var hidParam = cmd.Parameters.Add("@HID", DbType.Int32);
                        hidParam.Value = hT.HID;

                        // 执行验证三重校验  
                        int affected = cmd.ExecuteNonQuery();
                        if (affected == 0)
                        {
                            throw new DataException($"HID={hT.HID} 的作业配置不存在");
                        }


                        transaction.Commit();
                    }
                    catch (Exception ex) when (ex is SQLiteException or DataException)
                    {
                        transaction.Rollback();
                        throw new DataException("作业配置删除操作失败", ex);
                    }
                });
            }

            const string sql = @"
                            INSERT INTO HMK (
                                HID, HName, HText, StartTime,
                                EndTime, InputInformation, 
                                ChangeInformation, IsTest, isValid 
                            ) VALUES (
                                @HID, @HName, @HText, @StartTime,
                                @EndTime, @InputInformation, 
                                @ChangeInformation, @IsTest, @isValid
                            )";

            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var cmd = new SQLiteCommand(sql, conn);

                // 核心参数绑定（带类型安全校验）
                cmd.Parameters.AddWithValue("@HID", hT.HID);
                cmd.Parameters.AddWithValue("@HName", hT.HName.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@HText", hT.HText.Trim() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@StartTime", hT.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", hT.EndTime);
                cmd.Parameters.AddWithValue("@InputInformation", hT.InputInformation);
                cmd.Parameters.AddWithValue("@ChangeInformation", hT.ChangeInformation);
                cmd.Parameters.AddWithValue("@IsTest", hT.IsTest);
                cmd.Parameters.AddWithValue("@isValid", 1); // 默认启用状态 

                // 执行验证
                if (cmd.ExecuteNonQuery() != 1)
                {
                    getID.DecHTID();
                    throw new ApplicationException("数据插入失败，影响行数异常");
                }
            });
            if (change)
            {
                const string sqlDelete = @"
                        DELETE FROM ProH 
                        WHERE HID = @HID"; // 删除条件语句 

                SqliteProblemConnectionManager.SafeExecute(conn =>
                {
                    using var transaction = conn.BeginTransaction();
                    try
                    {
                        using var cmd = new SQLiteCommand(sqlDelete, conn, transaction);

                        // 参数绑定（严格类型声明）
                        cmd.Parameters.Add("@HID", DbType.Int32).Value = hT.HID; // 假设targetHID为预定义输入值 

                        int affectedRows = cmd.ExecuteNonQuery();


                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw; // 保持原有异常传播机制 
                    }
                });
            }


            const string sqlS = @"
                INSERT INTO ProH (
                    HID, IsTest, PID, ClassID, Score
                ) VALUES (
                    @HID, @IsTest, @PID, @ClassID, @Score
                )";
            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var transaction = conn.BeginTransaction();
                try
                {
                    using var cmd = new SQLiteCommand(sqlS, conn, transaction);

                    cmd.Parameters.Add("@HID", DbType.Int32).Value = hT.HID;
                    cmd.Parameters.Add("@ClassID", DbType.String).Value = classID;
                    cmd.Parameters.Add("@IsTest", DbType.Int32).Value = hT.IsTest;
                    cmd.Parameters.Add("@isValid", DbType.Int32).Value = 1;

                    var pidParam = cmd.CreateParameter();
                    pidParam.ParameterName = "@PID";
                    pidParam.DbType = DbType.Int32;
                    cmd.Parameters.Add(pidParam);

                    var scoreParam = cmd.CreateParameter();
                    scoreParam.ParameterName = "@Score";
                    scoreParam.DbType = DbType.Int32;
                    cmd.Parameters.Add(scoreParam);

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        pidParam.Value = row.Cells["ID"].Value ?? 0;
                        scoreParam.Value = row.Cells["Score"].Value ?? 10;
                        if (cmd.ExecuteNonQuery() != 1)
                        {
                            getID.DecHTID();
                            throw new ApplicationException("数据插入失败");
                        }
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            });
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 只处理Score列
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Score")
            {
                // 这里可以做额外的校验或保存操作
                // 例如：
                int newScore = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Score"].Value);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dataGridView1.CellValueChanged -= DataGridView1_CellValueChanged;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged -= DataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0) { MessageBox.Show("请填写核心内容！"); return; }
            if (!CompareDateTimeWithNow(dateTimePicker2)) { MessageBox.Show("结束时间过早，无效！"); return; }
            HT hT = new HT();
            hT.HName = textBox1.Text;
            hT.HText = textBox2.Text;
            hT.IsTest = 1;
            //hT.HID=getID.GetNextHTID();
            hT.StartTime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
            hT.EndTime = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm");
            hT.InputInformation = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            hT.ChangeInformation = hT.InputInformation;
            adder(hT);
            //添加映射表
            const string sqlS = @"
                INSERT INTO CourseHMK (
                    CourseID,HID
                ) VALUES (
                    @CourseID,@HID
                )";
            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var transaction = conn.BeginTransaction();
                try
                {
                    using var cmd = new SQLiteCommand(sqlS, conn, transaction);

                    // 绑定固定参数（显式类型）
                    cmd.Parameters.Add("@CourseID", DbType.Int32).Value = Params.CourseID;
                    cmd.Parameters.Add("@HID", DbType.String).Value = hT.HID;

                    // 动态参数预定义 
                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        getID.DecHTID();
                        throw new ApplicationException("数据插入失败");
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            });
            MessageBox.Show("您成功添加一项考试！");
            textBox1.Text = textBox2.Text = string.Empty;
            dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Now;
        }
    }
}
