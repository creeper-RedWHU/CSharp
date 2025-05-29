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
    public partial class glrecycle : UserControl
    {
        public glrecycle()
        {
            InitializeComponent();
        }
        public void UpdateData(int x = 0)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            ArrayList list = getID.getList();
            dataGridView1.DataSource = null;
            if (list.Count != 0)
            {
                getID.HMKBindToTable(dataGridView1, "HMK", "0", x, list);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Del")
            {
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                int xint=int.Parse(x);
                //补充代码，实现删除HMK数据表中HID的值为xint的数据项
                //再实现删除ProH数据表中HID的值为xint的数据项
                /*风格参考
                 * ArrayList list = new ArrayList();
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
                 */
                try
                {
                    SqliteProblemConnectionManager.SafeExecute(conn =>
                    {
                        using var transaction = conn.BeginTransaction();

                        try
                        {
                            // 删除主表HMK
                            const string delHMK = "DELETE FROM HMK WHERE HID=@HID";
                            using var cmdHMK = new SQLiteCommand(delHMK, conn, transaction);
                            cmdHMK.Parameters.Add("@HID", DbType.Int32).Value = xint;
                            if (cmdHMK.ExecuteNonQuery() == 0)
                                throw new KeyNotFoundException("HMK记录不存在");

                            // 删除关联表ProH 
                            const string delProH = "DELETE FROM ProH WHERE HID=@HID";
                            using var cmdProH = new SQLiteCommand(delProH, conn, transaction);
                            cmdProH.Parameters.Add("@HID", DbType.Int32).Value = xint;
                            cmdProH.ExecuteNonQuery();

                            transaction.Commit();
                            dataGridView1.Rows.RemoveAt(e.RowIndex);
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    });
                    MessageBox.Show("删除成功！");
                    UpdateData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"删除失败: {ex.Message}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Rec")
            {
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                int xint = int.Parse(x);
                //补充代码，实现更新HMK数据表中HID的值为xint的数据项的isValid列为1.参考上面的代码
                try
                {
                    SqliteProblemConnectionManager.SafeExecute(conn =>
                    {
                        const string updateSql = "UPDATE HMK SET isValid = 1 WHERE HID = @HID";
                        using var cmd = new SQLiteCommand(updateSql, conn);
                        cmd.Parameters.Add("@HID", DbType.Int32).Value = xint;
                        if (cmd.ExecuteNonQuery() == 0)
                            throw new KeyNotFoundException("HMK记录不存在");
                    });
                    MessageBox.Show("恢复成功！");
                    UpdateData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"恢复失败: {ex.Message}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
