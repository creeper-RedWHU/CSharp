using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

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
                        string filename = "DataBase.txt";
                        string[] line = File.ReadAllLines(filename);
                        for (int i = 0; i < line.Length; i++)
                        {
                            {
                                command.CommandText = line[i];
                                command.ExecuteNonQuery();
                            }

                        }

                        // 如果是新数据库，插入默认用户
                        if (isNewDb)
                        {
                            InsertDefaultUsers(connection);
                        }
                    }

                    return true;
                }
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
            string dbPath = "StudentSystem.db";
            string connStr = $"Data Source={dbPath};Version=3;";
            string hash = PasswordHelper.HashPassword(password);

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Users WHERE Username=@username AND Password=@password AND Role=@role";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hash);
                    cmd.Parameters.AddWithValue("@role", role);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static void ConvertAllPasswordsToHash()
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                // 读取所有用户
                string selectSql = "SELECT Username, Password FROM Users";
                var users = new List<(string Username, string Password)>();
                using (SQLiteCommand cmd = new SQLiteCommand(selectSql, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add((reader.GetString(0), reader.GetString(1)));
                    }
                }
                // 更新为哈希
                foreach (var user in users)
                {
                    string hash = PasswordHelper.HashPassword(user.Password);
                    string updateSql = "UPDATE Users SET Password=@pwd WHERE Username=@username";
                    using (SQLiteCommand cmd = new SQLiteCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@pwd", hash);
                        cmd.Parameters.AddWithValue("@username", user.Username);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}