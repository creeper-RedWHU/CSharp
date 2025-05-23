using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Form1Tea._4test
{
    public partial class testinput : UserControl
    {
        public testinput()
        {
            InitializeComponent();
        }
        public event EventHandler NextPageTest;
        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * 获取题目
             */
            //清空
            NextPageTest?.Invoke(this, EventArgs.Empty);
        }
    }
}
