using System;
using System.Collections.Generic;
using System.Data.SQLite;
using EduAdminApp.Models;

namespace EduAdminApp.DAL
{
    public class TeacherDAL
    {
        private static string connStr = "Data Source=database.db";

        public static List<Teacher> GetAll()
        {
            var list = new List<Teacher>();
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Teacher";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Teacher
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Gender = reader.GetString(2),
                                Department = reader.GetString(3),
                                Email = reader.GetString(4),
                                Phone = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Add(Teacher t)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO Teacher (Name, Gender, Department, Email, Phone) VALUES (@Name, @Gender, @Department, @Email, @Phone)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", t.Name);
                    cmd.Parameters.AddWithValue("@Gender", t.Gender);
                    cmd.Parameters.AddWithValue("@Department", t.Department);
                    cmd.Parameters.AddWithValue("@Email", t.Email);
                    cmd.Parameters.AddWithValue("@Phone", t.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Teacher t)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE Teacher SET Name=@Name, Gender=@Gender, Department=@Department, Email=@Email, Phone=@Phone WHERE Id=@Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", t.Name);
                    cmd.Parameters.AddWithValue("@Gender", t.Gender);
                    cmd.Parameters.AddWithValue("@Department", t.Department);
                    cmd.Parameters.AddWithValue("@Email", t.Email);
                    cmd.Parameters.AddWithValue("@Phone", t.Phone);
                    cmd.Parameters.AddWithValue("@Id", t.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM Teacher WHERE Id=@Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}