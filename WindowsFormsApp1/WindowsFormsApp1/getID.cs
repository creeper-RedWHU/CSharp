using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

     
        public static ArrayList getList()
        {
            ArrayList list = new ArrayList();
            const string sql = @"
                SELECT HID 
                FROM CourseHMK 
                WHERE CourseID = @CourseID";

            SqliteProblemConnectionManager.SafeExecute(conn =>
            {
                using var transaction = conn.BeginTransaction();
                try
                {
                    using var cmd = new SQLiteCommand(sql, conn, transaction);
                    cmd.Parameters.Add("@CourseID", DbType.Int32).Value = Params.CourseID;

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            list.Add(reader.GetInt32(0)); // 读取HID列的值 
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
            return list;
        }

        public static void HMKBindToTable(DataGridView dgv, string tableName, string judge, int typer, ArrayList arraylist)
        {
            try
            {
                using var conn = new SQLiteConnection(ConnectionString);
                var query = new StringBuilder("SELECT * FROM ").Append(tableName);
                query.Append(" WHERE isValid = ").Append(judge);

                // 动态生成查询条件（兼容原有逻辑）
                if (typer == 1) query.Append(" AND IsTest = 1");
                else if (typer == 0) query.Append(" AND IsTest = 0");

                // 高效内存过滤算法（哈希集合实现O(1)查找）
                var hidFilter = arraylist?.Cast<int>().ToHashSet();
                if (hidFilter?.Count > 0)
                {
                    query.Append(" AND HID IN (");
                    query.Append(string.Join(",", hidFilter));
                    query.Append(")");
                }

                // 数据绑定核心流程 
                using var adapter = new SQLiteDataAdapter(query.ToString(), conn);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("HID列表包含非整型数据");
            }
            catch
            {
                MessageBox.Show("绑定失败，请检查表是否存在");
            }
        }

        public static void UserBindToTable(DataGridView dgv, string tableName)
        {
            try
            {
                using var conn = new SQLiteConnection(ConnectionString);
                SQLiteDataAdapter adapter;
                adapter = new SQLiteDataAdapter($"SELECT * FROM {tableName} WHERE Role='学生'", conn);
                var dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                dgv.DataSource = dataTable;
            }
            catch
            {
                MessageBox.Show("绑定失败，请检查表是否存在");
            }
        }

        public static void CourseToTeacherBindToTable(DataGridView dgv, string tableName,int id)
        {
            try
            {
                using var conn = new SQLiteConnection(ConnectionString);
                SQLiteDataAdapter adapter;
                adapter = new SQLiteDataAdapter($"SELECT * FROM {tableName} WHERE TeacherID="+id.ToString(), conn);
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
        public static int GetNextClassID() => AtomicIncrement("ClassID");
        public static int GetNextHTID() => AtomicIncrement("HTID");
        public static void DecProID() => AtomicDecrement("ProID");
        public static void DecHTID() => AtomicDecrement("HTID");
    }
}
