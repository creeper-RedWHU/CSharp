using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Form1Tea;
using WindowsFormsApp1.Form1Tea._1zy;
using WindowsFormsApp1.Form1Tea._2zygl;
using WindowsFormsApp1.Form1Tea._3test;
using WindowsFormsApp1.Form1Tea._4test;
using WindowsFormsApp1.Form1Tea._5exam;
using WindowsFormsApp1.Form1Tea.zy;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region 教师区域
        public zyovw ovw;//创建用户控件一变量
        public zyinput zyinput;
        public zyrecycle zyrecycle;
        public zyedit zyedit;

        public glinput glinput;
        public glovw glovw;
        public glrecycle glrecycle;

        public tstinput tstinput;
        public tstovw tstovw;
        public tstrcycle tstrcycle;

        public testinput testinput;
        public testovw testovw;
        public testrecycle testrecycle;

        public examipt examipt;
        public examovw examovw;
        public examrecycle examrecycle;

        #endregion
        #region 公共变量
        public string TeacherName;
        #endregion


        public Form1()
        {
            InitializeComponent();
            #region 实例化
            ovw = new zyovw();//实例化ovw
            ovw.GoToEditPage +=ovw_GoToEditPage;//绑定事件
            zyrecycle = new zyrecycle();
            zyinput = new zyinput();

            glinput = new glinput();
            glovw = new glovw();
            glrecycle = new glrecycle();

            testovw = new testovw();
            testinput = new testinput();
            testrecycle= new testrecycle();

            tstinput = new tstinput();
            tstovw = new tstovw();
            tstrcycle = new tstrcycle();

            examipt = new examipt();
            examovw = new examovw();
            examrecycle = new examrecycle();

            TeacherName = "";
            #endregion
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

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            glovw.Show();
            panel3.Controls.Add(glovw);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            glinput.Show();
            panel3.Controls.Add(glinput);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            glrecycle.Show();
            panel3.Controls.Add(glrecycle);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            tstovw.Show();
            panel3.Controls.Add(tstovw);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            tstinput.Show();
            panel3.Controls.Add(tstinput);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            tstrcycle.Show();
            panel3.Controls.Add(tstrcycle);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            testovw.Show();
            panel3.Controls.Add(testovw);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            testinput.Show();
            panel3.Controls.Add(testinput);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            testrecycle.Show();
            panel3.Controls.Add(testrecycle);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            examovw.Show();
            panel3.Controls.Add(examovw);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            examipt.Show();
            panel3.Controls.Add(examipt);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            examrecycle.Show();
            panel3.Controls.Add(examrecycle);
        }

        public void ovw_GoToEditPage(string t)
        {
            zyedit = new zyedit(t);
            panel3.Controls.Clear();
            zyedit.Show();
            panel3.Controls.Add(zyedit);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            home home = new home(TeacherName);
            panel3.Controls.Clear();
            panel2.Hide();
            home.Show();
            panel3.Controls.Add(home);
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
