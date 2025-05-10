using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Form1Tea.zy;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public zyovw ovw;//创建用户控件一变量
        public zyinput zyinput;
        public zyrecycle zyrecycle;
        public Form1()
        {
            InitializeComponent();
            ovw = new zyovw();//实例化ovw
            zyrecycle = new zyrecycle();
            zyinput = new zyinput();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #region 窗口移动
        private Point mPoint;
        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }
        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Location=new Point(this.Location.X + e.X -mPoint.X,this.Location.Y+e.Y-mPoint.Y);
            }
        }

        #endregion
        #region 右上角控件
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; //最小化
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) //若最大化
            {
                this.WindowState = FormWindowState.Normal; //则正常化
            }
            else if (this.WindowState == FormWindowState.Normal) //若正常化
            {
                this.WindowState = FormWindowState.Maximized; //则最大化
            }
        }
        #endregion

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ovw.Show();
            panel3.Controls.Clear();
            panel3.Controls.Add(ovw);

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            zyinput.Show();
            panel3.Controls.Add(zyinput);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            zyrecycle.Show();
            panel3.Controls.Add(zyrecycle);
        }
    }
}
