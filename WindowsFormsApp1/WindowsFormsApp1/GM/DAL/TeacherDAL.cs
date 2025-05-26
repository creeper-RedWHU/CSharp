using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EduAdminApp.Models;

namespace EduAdminApp.DAL
{
    public class TeacherDAL
    {
        private static string connStr = "Data Source=StudentSystem.db";

        // 获取所有老师
        public static List<Teacher> GetAll()
        {
            var list = new List<Teacher>();
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT ID, Username, Password, Role, Name, Gender, Major, Email, Phone FROM Users WHERE Role = '老师'";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Teacher
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3),
                                Name = reader.GetString(4),
                                Gender = reader.GetString(5),
                                Major = reader.GetString(6),
                                Email = reader.GetString(7),
                                Phone = reader.GetString(8)
                            });
                        }
                    }
                }
            }
            return list;
        }

        // 添加老师
        public void Add(Teacher t)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"INSERT INTO Users 
                    (Username, Password, Role, Name, Gender, Major, Email, Phone)
                    VALUES (@Username, @Password, @Role, @Name, @Gender, @Major, @Email, @Phone)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", t.Username);
                    cmd.Parameters.AddWithValue("@Password", t.Password);
                    cmd.Parameters.AddWithValue("@Role", t.Role);  // 应为 "老师"
                    cmd.Parameters.AddWithValue("@Name", t.Name);
                    cmd.Parameters.AddWithValue("@Gender", t.Gender);
                    cmd.Parameters.AddWithValue("@Major", t.Major);
                    cmd.Parameters.AddWithValue("@Email", t.Email);
                    cmd.Parameters.AddWithValue("@Phone", t.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 修改老师信息
        public void Update(Teacher t)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"UPDATE Users SET 
                    Username = @Username,
                    Password = @Password,
                    Role = @Role,
                    Name = @Name,
                    Gender = @Gender,
                    Major = @Major,
                    Email = @Email,
                    Phone = @Phone
                    WHERE ID = @Id AND Role = '老师'";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", t.Username);
                    cmd.Parameters.AddWithValue("@Password", t.Password);
                    cmd.Parameters.AddWithValue("@Role", t.Role);  // 应为 "老师"
                    cmd.Parameters.AddWithValue("@Name", t.Name);
                    cmd.Parameters.AddWithValue("@Gender", t.Gender);
                    cmd.Parameters.AddWithValue("@Major", t.Major);
                    cmd.Parameters.AddWithValue("@Email", t.Email);
                    cmd.Parameters.AddWithValue("@Phone", t.Phone);
                    cmd.Parameters.AddWithValue("@Id", t.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 删除老师
        public void Delete(int id)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM Users WHERE ID = @Id AND Role = '老师'";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}