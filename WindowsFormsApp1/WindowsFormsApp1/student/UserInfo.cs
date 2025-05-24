using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserInfo : UserControl
    {
        private int _userId;

        // 构造函数传入用户ID
        public UserInfo(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            string connStr = "Data Source=StudentSystem.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT ID, Username FROM Users WHERE ID=@id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _userId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 假设你有两个Label控件：labelId, labelName
                            labelId.Text = "ID号：" + reader["ID"].ToString();
                            labelName.Text = "姓名：" + reader["Username"].ToString();
                        }
                    }
                }
            }
        }
    }
}
