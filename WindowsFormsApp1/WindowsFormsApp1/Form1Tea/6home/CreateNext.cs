using Org.BouncyCastle.Crmf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Form1Tea._6home
{
    public partial class CreateNext : UserControl
    {
        public Classes classes;
        public int TeacherID;
        public CreateNext()
        {
            InitializeComponent();
        }

        public void UpdateData()
        {
            dataGridView1.AutoGenerateColumns = false;
            getID.UserBindToTable(dataGridView1, "Users");
        }

        public event EventHandler goToHome;

        private void adder(ArrayList idList)
        {
            const string sql = @"
                INSERT INTO Course (
                    CourseName, TeacherID, StartTime, EndTime,NUM,Classroom,Credit
                ) VALUES (
                    @CourseName, @TeacherID, @StartTime, @EndTime ,@NUM,@Classroom,@Credit
                )";

            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var transaction = conn.BeginTransaction();
                try
                {
                    using var cmd = new SQLiteCommand(sql, conn, transaction);

                    // 绑定参数（强化类型安全）
                    cmd.Parameters.Add("@CourseName", DbType.String).Value = classes.ClassName;
                    cmd.Parameters.Add("@TeacherID", DbType.Int32).Value = TeacherID;
                    cmd.Parameters.Add("@StartTime", DbType.String).Value = classes.StartTime;
                    cmd.Parameters.Add("@EndTime", DbType.String).Value = classes.EndTime;
                    cmd.Parameters.Add("@NUM", DbType.Int32).Value = idList.Count;
                    cmd.Parameters.Add("@Classroom", DbType.Int32).Value = classes.Classroom;
                    cmd.Parameters.Add("@Credit", DbType.Int32).Value = classes.Credits;

                    if (cmd.ExecuteNonQuery() != 1)
                    {
                        throw new ApplicationException("课程数据插入失败");
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            });
            
            int courseID=getID.GetNextClassID();

            const string sqlS = @"
                INSERT INTO CourseStudent (
                    CourseID, StudentID 
                ) VALUES (
                    @CourseID, @StudentID 
                )";

            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var transaction = conn.BeginTransaction();
                try
                {
                    using var cmd = new SQLiteCommand(sqlS, conn, transaction);

                    // 绑定固定参数（课程ID）
                    cmd.Parameters.Add("@CourseID", DbType.Int32).Value = courseID;

                    // 创建动态参数（学生ID）
                    var studentIdParam = cmd.CreateParameter();
                    studentIdParam.ParameterName = "@StudentID";
                    studentIdParam.DbType = DbType.Int32;
                    cmd.Parameters.Add(studentIdParam);

                    foreach (var item in idList)
                    {
                        // 类型安全转换（兼容.NET泛型与非泛型集合）
                        if (item is int validId)
                        {
                            studentIdParam.Value = validId;
                            if (cmd.ExecuteNonQuery() != 1)
                            {
                                transaction.Rollback();
                                throw new ApplicationException($"学生{validId}关联失败");
                            }
                        }
                        else
                        {
                            transaction.Rollback();
                            throw new ArgumentException("非法学生ID类型");
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

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList idList = new ArrayList();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                var cellValue = row.Cells["Choose"].Value;

                // 复选框状态判断
                bool isChecked = cellValue != null && (bool)cellValue;
                if (!isChecked) continue;

                // 获取ID并重置复选框 
                int id = Convert.ToInt32(row.Cells[0].Value);
                idList.Add(id);
                row.Cells["Choose"].Value = false;
            }
            //清空
            if (idList.Count == 0) { MessageBox.Show("请至少选择一个学生！"); return; }

            adder(idList);
            MessageBox.Show("创建课程成功！");
            goToHome?.Invoke(this, EventArgs.Empty);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var targetColumn = dataGridView1.Columns[e.ColumnIndex];
            if (targetColumn.Name == "Choose")
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
