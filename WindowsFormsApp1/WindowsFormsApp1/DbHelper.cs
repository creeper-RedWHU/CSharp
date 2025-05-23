using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class DbHelper
    {
        // 数据库文件路径 (相对于应用程序根目录)
        public static string DbFilePath = "StudentSystem.db";
        public static string ConnectionString => $"Data Source={DbFilePath};Version=3;";

        /// <summary>
        /// 初始化数据库
        /// </summary>
        public static bool InitializeDatabase()
        {
            try
            {
                // 确保数据库文件存在，如果不存在则创建
                bool isNewDb = !File.Exists(DbFilePath);

                if (isNewDb)
                {
                    SQLiteConnection.CreateFile(DbFilePath);
                }

                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // 创建用户表
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Users (
                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                Username TEXT NOT NULL UNIQUE,
                                Password TEXT NOT NULL,
                                Role TEXT NOT NULL
                            );";
                        command.ExecuteNonQuery();
                    }

                    // 如果是新数据库，插入默认用户
                    if (isNewDb)
                    {
                        InsertDefaultUsers(connection);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化数据库出错: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 插入默认用户
        /// </summary>
        private static void InsertDefaultUsers(SQLiteConnection connection)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = @"
                    INSERT INTO Users (Username, Password, Role) VALUES 
                    ('student', '123456', '学生'),
                    ('teacher', '123456', '老师'),
                    ('admin', '123456', '管理员');";
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 验证用户登录
        /// </summary>
        public static bool ValidateUser(string username, string password, string role)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password AND Role = @role";
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@role", role);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"验证用户时出错: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}