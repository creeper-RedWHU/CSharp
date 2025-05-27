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

namespace WindowsFormsApp1.Form1Tea._4test
{
    public partial class testovw : UserControl
    {
        public testovw()
        {
            InitializeComponent();
        }
        public void UpdateData(int x = 1)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            ArrayList list = getID.getList();
            dataGridView1.DataSource = null;
            if (list.Count != 0)
            {
                getID.HMKBindToTable(dataGridView1, "HMK", "1", x, list);
            }
        }
        private ArrayList FindPro(int HID)
        {
            ArrayList list = new ArrayList();
            const string sql = @"
                        SELECT PID
                        FROM ProH 
                        WHERE HID = @HID ";
            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@HID", HID);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())  // 使用while循环读取所有记录 
                {
                    list.Add(Convert.ToInt32(reader["PID"]));

                }
            });

            return list;
        }
        public event Action<ArrayList> GoToEditPager;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                ArrayList arrayList;
                //在表里查找当前的题目编号并加入
                arrayList = FindPro(int.Parse(x));
                arrayList.Add(x);
                MessageBox.Show("您将要编辑第" + x + "份考试！");
                GoToEditPager?.Invoke(arrayList);

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Del")
            {
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                const string sqlUpdate = @"
                        UPDATE HMK 
                        SET isValid = @newIsValid 
                        WHERE HID = @targetHID";

                SqliteProblemConnectionManager.SafeExecute(conn =>
                {
                    using var transaction = conn.BeginTransaction();
                    try
                    {
                        using var cmd = new SQLiteCommand(sqlUpdate, conn, transaction);

                        cmd.Parameters.Add("@targetHID", DbType.Int32).Value = x;  // 输入值 
                        cmd.Parameters.Add("@newIsValid", DbType.Int32).Value = 0;  // 强制归零 

                        int affectedRows = cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });


                MessageBox.Show("成功删除:第" + x + "份作业！");
                UpdateData();
            }
        }
    }
}
