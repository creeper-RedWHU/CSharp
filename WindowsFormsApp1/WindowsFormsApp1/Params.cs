using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class Params
    {
        public static int TeacherID;
        public static string TeacherName;
        public static int CourseID;
        public static ArrayList array;
        public static int PYFinalStuID;
        public static string connstr = "Data Source=StudentSystem.db;Version=3;Pooling=True;";
        public static void GetStudentIDsByCourse()
        {
            ArrayList studentIDs = new ArrayList();
            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT StudentID FROM CourseStudent WHERE CourseID = @courseId";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@courseId", Params.CourseID);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentIDs.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            array = studentIDs;
        }

    }
}
