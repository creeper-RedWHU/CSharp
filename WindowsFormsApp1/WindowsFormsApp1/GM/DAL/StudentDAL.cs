using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EduAdminApp.Models;

namespace EduAdminApp.DAL
{
    public class StudentDAL
    {
        private static string connStr = "Data Source=StudentSystem.db";

        // 获取所有学生
        public static List<Student> GetAll()
        {
            var list = new List<Student>();
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT ID, Username, Password, Role, Name, Gender, Major, Email, Phone FROM Users WHERE Role = '学生'";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Student
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

        // 添加学生
        public void Add(Student s)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = @"INSERT INTO Users 
                    (Username, Password, Role, Name, Gender, Major, Email, Phone) 
                    VALUES (@Username, @Password, @Role, @Name, @Gender, @Major, @Email, @Phone)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", s.Username);
                    cmd.Parameters.AddWithValue("@Password", s.Password);
                    cmd.Parameters.AddWithValue("@Role", s.Role); // 应该为 "学生"
                    cmd.Parameters.AddWithValue("@Name", s.Name);
                    cmd.Parameters.AddWithValue("@Gender", s.Gender);
                    cmd.Parameters.AddWithValue("@Major", s.Major);
                    cmd.Parameters.AddWithValue("@Email", s.Email);
                    cmd.Parameters.AddWithValue("@Phone", s.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 修改学生信息
        public void Update(Student s)
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
                    WHERE ID = @Id AND Role = '学生'";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", s.Username);
                    cmd.Parameters.AddWithValue("@Password", s.Password);
                    cmd.Parameters.AddWithValue("@Role", s.Role);  // 一般为 "学生"
                    cmd.Parameters.AddWithValue("@Name", s.Name);
                    cmd.Parameters.AddWithValue("@Gender", s.Gender);
                    cmd.Parameters.AddWithValue("@Major", s.Major);
                    cmd.Parameters.AddWithValue("@Email", s.Email);
                    cmd.Parameters.AddWithValue("@Phone", s.Phone);
                    cmd.Parameters.AddWithValue("@Id", s.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 删除学生
        public void Delete(int id)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM Users WHERE ID = @Id AND Role = '学生'";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}