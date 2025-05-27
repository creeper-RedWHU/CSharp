using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EduAdminApp.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_login());
            //Application.Run(new Form_login());
            //初始化数据库
            //if (DbHelper.InitializeDatabase())
            //{
            //    Application.Run(new Form_login());
            //}
            //else
            //{
            //    MessageBox.Show("数据库初始化失败，应用程序将退出。", "错误",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
