using Mysqlx.Expr;
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

namespace WindowsFormsApp1.Form1Tea._2zygl
{
    public partial class glinputSec : UserControl
    {
        public ArrayList arrayList;
        public int classID;
        public glinputSec()
        {
            InitializeComponent();
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
        private void adder(HT hT)
        {
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
            const string sqlS = @"
                INSERT INTO ProH (
                    HID, IsTest, PID, ClassID
                ) VALUES (
                    @HID, @IsTest, @PID, @ClassID
                )";
            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var transaction = conn.BeginTransaction();
                try
                {
                    using var cmd = new SQLiteCommand(sqlS, conn, transaction);

                    // 绑定固定参数（显式类型）
                    cmd.Parameters.Add("@HID", DbType.Int32).Value = hT.HID;
                    cmd.Parameters.Add("@ClassID", DbType.String).Value = classID;
                    cmd.Parameters.Add("@IsTest", DbType.Int32).Value = hT.IsTest;
                    cmd.Parameters.Add("@isValid", DbType.Int32).Value = 1;

                    // 动态参数预定义 
                    var pidParam = cmd.CreateParameter();
                    pidParam.ParameterName = "@PID";
                    pidParam.DbType = DbType.Int32;
                    cmd.Parameters.Add(pidParam);

                    foreach (var item in arrayList)
                    {
                        pidParam.Value = item;
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
            //SqliteProblemConnectionManager.SafeExecute(conn =>
            //{
            //    using var cmd = new SQLiteCommand(sqlS, conn);

            //    // 核心参数绑定（带类型安全校验）
            //    cmd.Parameters.AddWithValue("@HID", hT.HID);
            //    cmd.Parameters.AddWithValue("@ClassID", classID);
            //    cmd.Parameters.AddWithValue("@IsTest", hT.IsTest);
            //    cmd.Parameters.AddWithValue("@isValid", 1); // 默认启用状态

            //    for (int i = 0;i<arrayList.Count;i++)
            //    {
            //        cmd.Parameters.AddWithValue("@PID", arrayList[i]);
            //        // 执行验证
            //        if (cmd.ExecuteNonQuery() != 1)
            //        {
            //            getID.DecHTID();
            //            throw new ApplicationException("数据插入失败，影响行数异常");
            //        }
            //    }



            //});
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0) { MessageBox.Show("请填写核心内容！"); return; }
            if (!CompareDateTimeWithNow(dateTimePicker2)) { MessageBox.Show("结束时间过早，无效！"); return; }
            HT hT = new HT();
            hT.HName = textBox1.Text;
            hT.HText = textBox2.Text;
            hT.IsTest = 0;
            hT.HID=getID.GetNextHTID();
            hT.StartTime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
            hT.EndTime = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm");
            hT.InputInformation = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            hT.ChangeInformation=hT.InputInformation;
            adder(hT);
            //添加映射表
            
            MessageBox.Show("您成功添加一项作业！");
            textBox1.Text= textBox2.Text=string.Empty;
            dateTimePicker1.Value = dateTimePicker2.Value=DateTime.Now;
            
        }
    }
}
