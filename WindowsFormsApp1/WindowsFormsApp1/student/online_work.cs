using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class online_work : UserControl
    {
        public online_work()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear(); // 清空原有内容
            due_work dueControl = new due_work();
            dueControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(dueControl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear(); // 清空原有内容
            passed_work passedControl = new passed_work();
            passedControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(passedControl);
        }
    }
}
