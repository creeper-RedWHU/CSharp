using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Microsoft.SqlServer;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class SqliteProblemConnectionManager
    {
        private static readonly Lazy<SQLiteConnection> _conn = new(() =>
        {
            var conn = new SQLiteConnection("Data Source=StudentSystem.db;Pooling=True;");
            conn.Open();
            return conn;
        });
        
        public static SQLiteConnection GetConnection() => _conn.Value;

        public static void SafeExecute(Action<SQLiteConnection> action)
        {
            var conn = GetConnection();
            lock (conn)
            {
                try
                {
                    action(conn);
                }
                catch (SQLiteException ex)
                {
                    // 智能错误分类处理 
                    HandleSqlError(ex);
                }
            }
        }

        private static void HandleSqlError(SQLiteException ex)
        {
            switch (ex.ResultCode)
            {
                case SQLiteErrorCode.Constraint:
                    MessageBox.Show("请勿重复点击！");
                    getID.DecProID();
                    break;
                case SQLiteErrorCode.TooBig:
                    throw new ArgumentException($"字段长度超限: {ex.Message}", ex);
                default:
                    throw new ApplicationException($"数据库错误: [CODE:{ex.ErrorCode}] {ex.Message}", ex);
            }
        }
    }
}
