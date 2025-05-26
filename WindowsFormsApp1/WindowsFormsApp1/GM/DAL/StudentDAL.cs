using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EduAdminApp.Models;

namespace EduAdminApp.DAL
{
    public class StudentDAL
    {
        private static string connStr = "Data Source=database.db";

        public static List<Student> GetAll()
        {
            var list = new List<Student>();
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Student";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Student
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Gender = reader.GetString(2),
                                Major = reader.GetString(3),
                                Email = reader.GetString(4),
                                Phone = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Add(Student s)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO Student (Name, Gender, Major, Email, Phone) VALUES (@Name, @Gender, @Major, @Email, @Phone)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", s.Name);
                    cmd.Parameters.AddWithValue("@Gender", s.Gender);
                    cmd.Parameters.AddWithValue("@Major", s.Major);
                    cmd.Parameters.AddWithValue("@Email", s.Email);
                    cmd.Parameters.AddWithValue("@Phone", s.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Student s)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE Student SET Name=@Name, Gender=@Gender, Major=@Major, Email=@Email, Phone=@Phone WHERE Id=@Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
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

        public void Delete(int id)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM Student WHERE Id=@Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}