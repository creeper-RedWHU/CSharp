using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class getID
    {
        private const  string ConnectionString = "Data Source=StudentSystem.db;Version=3;Pooling=True;";

        // 通用原子操作模板 
        private static int AtomicIncrement(string columnName)
        {
            using var conn = new SQLiteConnection(ConnectionString);
            conn.Open();

            using var transaction = conn.BeginTransaction(System.Data.IsolationLevel.Serializable);
            var cmd = conn.CreateCommand();

            // 使用参数化SQL防止注入 
            cmd.CommandText = $"SELECT {columnName} FROM IDs LIMIT 1;";
            int currentValue = Convert.ToInt32(cmd.ExecuteScalar());

            cmd.Parameters.Clear();
            cmd.CommandText = $"UPDATE IDs SET {columnName} = @newValue;";
            cmd.Parameters.AddWithValue("@newValue", currentValue + 1);
            cmd.ExecuteNonQuery();

            transaction.Commit();
            return currentValue;
        }

        private static void AtomicDecrement(string columnName)
        {
            using var conn = new SQLiteConnection(ConnectionString);
            conn.Open();

            using var transaction = conn.BeginTransaction(System.Data.IsolationLevel.Serializable);
            var cmd = conn.CreateCommand();

            // 使用参数化SQL防止注入 
            cmd.CommandText = $"SELECT {columnName} FROM IDs LIMIT 1;";
            int currentValue = Convert.ToInt32(cmd.ExecuteScalar());

            cmd.Parameters.Clear();
            cmd.CommandText = $"UPDATE IDs SET {columnName} = @newValue;";
            cmd.Parameters.AddWithValue("@newValue", currentValue - 1);
            cmd.ExecuteNonQuery();

            transaction.Commit();
        }
        public static void BindToTable(DataGridView dgv, string tableName,string judge,int typer)
        {
            try
            {
                using var conn = new SQLiteConnection(ConnectionString);
                SQLiteDataAdapter adapter;
                if(typer == 2)
                    adapter = new SQLiteDataAdapter($"SELECT * FROM {tableName} WHERE isValid="+judge, conn);
                else if(typer == 1) { adapter = new SQLiteDataAdapter($"SELECT * FROM {tableName} WHERE isValid=" + judge +" AND IsTest ='考试题'", conn); }
                else { adapter = new SQLiteDataAdapter($"SELECT * FROM {tableName} WHERE isValid=" + judge + " AND IsTest ='作业题'", conn); }
                var dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
            catch
            {
                MessageBox.Show("绑定失败，请检查表是否存在");
            }
        }

        public static void HMKBindToTable(DataGridView dgv, string tableName, string judge, int typer)
        {
            try
            {
                using var conn = new SQLiteConnection(ConnectionString);
                SQLiteDataAdapter adapter;
                if (typer == 2)
                    adapter = new SQLiteDataAdapter($"SELECT * FROM {tableName} WHERE isValid=" + judge, conn);
                else if (typer == 1) { adapter = new SQLiteDataAdapter($"SELECT * FROM {tableName} WHERE isValid=" + judge + " AND IsTest =1", conn); }
                else { adapter = new SQLiteDataAdapter($"SELECT * FROM {tableName} WHERE isValid=" + judge + " AND IsTest = 0", conn); }
                var dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
            catch
            {
                MessageBox.Show("绑定失败，请检查表是否存在");
            }
        }

        public static int GetNextProID() => AtomicIncrement("ProID");
        public static int GetNextHTID() => AtomicIncrement("HTID");
        public static void DecProID() => AtomicDecrement("ProID");
        public static void DecHTID() => AtomicDecrement("HTID");
    }
}
