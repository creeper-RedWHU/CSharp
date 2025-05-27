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
        private int _courseId;
        private int _studentId;

        public online_work(int courseId, int studentId)
        {
            InitializeComponent();
            _courseId = courseId;
            _studentId = studentId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            due_work dueControl = new due_work(_courseId, _studentId);
            dueControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(dueControl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            passed_work passedControl = new passed_work(_courseId, _studentId);
            passedControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(passedControl);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // 可以留空，除非你需要自定义绘制
        }
    }
}
