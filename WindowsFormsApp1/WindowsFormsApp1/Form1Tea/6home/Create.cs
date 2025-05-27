using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Form1Tea._6home
{
    public partial class Create : UserControl
    {
        public Classes classes;
        public Create()
        {
            InitializeComponent();
        }
        
        public event EventHandler<Classes> GoToNextHome;
        public bool CompareDateTimeWithNow(DateTimePicker datePicker)
        {
            // 获取控件时间（精确到分钟）
            DateTime t1 = datePicker.Value.Date.AddHours(datePicker.Value.Hour)
                                              .AddMinutes(datePicker.Value.Minute);

            // 获取当前时间（精确到分钟）
            DateTime t2 = DateTime.Now.Date.AddHours(DateTime.Now.Hour)
                                           .AddMinutes(DateTime.Now.Minute);


            // 比较逻辑（考虑时间相等的情况）
            return t1 >= t2;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("请填写关键信息！");
                return;
            }
            if (!CompareDateTimeWithNow(dateTimePicker2)) { MessageBox.Show("结束时间过早，无效！"); return; }
            classes = new Classes();
            classes.ClassName=textBox1.Text;
            classes.ClassSaying=textBox2.Text;
            classes.StartTime=dateTimePicker1.Text;
            classes.EndTime=dateTimePicker2.Text;
            GoToNextHome?.Invoke(this, classes);
        }
    }
}
