﻿using System;
using System.Collections;
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
using WindowsFormsApp1.Form1Tea._4test;
using WindowsFormsApp1.Form1Tea._5exam;
using WindowsFormsApp1.Form1Tea._6home;
using WindowsFormsApp1.Form1Tea.zy;
using static MaterialSkin.Controls.MaterialForm;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly FormStyle _styleHandler;//用于更改窗口样式
        #region 教师区域
        public zyovw ovw;//创建用户控件一变量
        public zyinput zyinput;
        public zyrecycle zyrecycle;
        public zyedit zyedit;

        public glinput glinput;
        public glovw glovw;
        public glinputSec glinputSec;
        public glrecycle glrecycle;


        public testinput testinput;
        public testovw testovw;
        public testinputSec testinputSec;
        public testrecycle testrecycle;

        public examPG examipt;
        public zyPG examovw;
        public PGNext pgnext;


        public Create create;
        public CreateNext createnext;
        public home_s Home;


        public string TeacherName;
        public int TeacherID;
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
            glinput.NextPage += NextPage;
            glinputSec = new glinputSec();
            glovw = new glovw();
            glovw.GoToEditPager += glovw_GoToEdit;
            glrecycle = new glrecycle();

            testovw = new testovw();
            testovw.GoToEditPager += testovw_GoToEdit;
            testinput = new testinput();
            testinput.NextPageTest += NextPageTest;
            testrecycle= new testrecycle();
            testinputSec = new testinputSec();


            examipt = new examPG();
            examovw = new zyPG();
            examovw.GoToPGNext += GoToPGNext;
            examipt.GoToPGNext += GoToPGNext;
            /*
             常数
             */
            //TeacherID = 2;
            //TeacherName = "李华";
            /*
             修改为：
             */
            TeacherID=Params.TeacherID;
            TeacherName=Params.TeacherName;


            Home=new home_s();
            create=new Create();
            createnext=new CreateNext();
            Home.GoToCreate += home_GoToNext;
            Home.GoToShow += home_GoToShow;
            create.GoToNextHome += Create_GoToNext;
            createnext.goToHome += button5_Click;
            createnext.TeacherID = TeacherID;


            #endregion

            _styleHandler = new FormStyle(this);
            /*直接展示首页部分*/
            Home.teacherId = TeacherID;
            Home.UpdataData(TeacherName);
            panel3.Controls.Clear();
            panel2.Hide();
            Home.Show();
            panel3.Controls.Add(Home);
            Button[] sidebarButtons = { button7, button8, button10, button11, button12, button17, button18, button20, button21,  button23, button25 };

            foreach (var btn in sidebarButtons)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
            }

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
        
        private void GoToPGNext(int id)
        {
            pgnext=new PGNext(id);
            pgnext.UpdateData();
            pgnext.GoToFinal += GoToFinal;
            panel3.Controls.Clear();
            pgnext.Show();
            panel3.Controls.Add(pgnext);
        }

        private void GoToFinal(int id)
        {

            PYFinal pyfinal = new PYFinal(id);
            panel3.Controls.Clear();
            panel3.Controls.Add(pyfinal);
        }

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

        private void home_GoToShow(object sender, EventArgs e)
        {
            Button[] sidebarButtons = { button7, button8, button10, button11, button12, button17, button18, button20, button21,  button23, button25 };

            foreach (var btn in sidebarButtons)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
            }
            panel2.Show(); 
            panel3.Controls.Clear();
        }

        private void Create_GoToNext(object sender,Classes classes)
        {
            createnext.UpdateData();
            createnext.classes = classes;
            createnext.Show();
            panel3.Controls.Clear();
            panel3.Controls.Add(createnext);
        }

        public void NextPageTest(object sender,ArrayList arrayList)
        {
            testinputSec.arrayList = arrayList;
            testinputSec.RefreshGridFromArrayList();
            testinputSec.Show();
            panel3.Controls.Clear();
            panel3.Controls.Add(testinputSec);
        }

        private void glovw_GoToEdit(ArrayList arrayList)
        {
            glinput.UpdateData();
            glinputSec.change = true;
            glinputSec.HIDOlder = int.Parse((string)arrayList[arrayList.Count - 1]);
            glinputSec.UpdateData();
            arrayList.RemoveAt(arrayList.Count - 1);
            glinput.load(arrayList);
            
            glinput.Show();
            panel3.Controls.Clear();
            panel3.Controls.Add(glinput);
        }

        private void home_GoToNext(object sender, EventArgs e)
        {
            
            panel3.Controls.Clear();
            create.Show();
            panel3.Controls.Add(create);
        }

        private void testovw_GoToEdit(ArrayList arrayList)
        {
            testinput.UpdateData();
            testinputSec.change = true;
            testinputSec.HIDOlder = int.Parse((string)arrayList[arrayList.Count - 1]);
            testinputSec.UpdateData();
            arrayList.RemoveAt(arrayList.Count - 1);
            testinput.load(arrayList);

            testinput.Show();
            panel3.Controls.Clear();
            panel3.Controls.Add(testinput);
        }


        private void NextPage(object sender,ArrayList arraylist)
        {
            glinputSec.arrayList = arraylist;
            glinputSec.RefreshGridFromArrayList();
            glinputSec.Show();
            panel3.Controls.Clear();
            panel3.Controls.Add(glinputSec);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetSidebarButtonSelected(button7);
            ovw.UpdateData();
            ovw.Show();
            panel3.Controls.Clear();
            panel3.Controls.Add(ovw);

        }

        private void SetSidebarButtonSelected(Button selectedButton)
        {
            // 所有侧边栏按钮
            Button[] sidebarButtons = { button7, button8, button10, button11, button12, button17, button18, button20, button21, button23, button25 };
            foreach (var btn in sidebarButtons)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("微软雅黑", 10F, FontStyle.Regular);
            }
            selectedButton.BackColor = Color.FromArgb(40, 167, 69); // 绿色
            selectedButton.ForeColor = Color.White;
            selectedButton.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SetSidebarButtonSelected(button8);
            panel3.Controls.Clear();
            zyinput.Show();
            panel3.Controls.Add(zyinput);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SetSidebarButtonSelected(button23);
            panel3.Controls.Clear();
            zyrecycle.UpdateData();
            zyrecycle.Show();
            
            panel3.Controls.Add(zyrecycle);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SetSidebarButtonSelected(button10);
            panel3.Controls.Clear();
            glovw.UpdateData(); 
            glovw.Show();
            panel3.Controls.Add(glovw);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SetSidebarButtonSelected(button11);
            panel3.Controls.Clear();
            glinput.UpdateData(); 
            glinput.Show();
            panel3.Controls.Add(glinput);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SetSidebarButtonSelected(button12);
            panel3.Controls.Clear();
            glrecycle.UpdateData(); glrecycle.Show();
            panel3.Controls.Add(glrecycle);
        }

        
        

        private void button17_Click(object sender, EventArgs e)
        {
            SetSidebarButtonSelected(button17);
            panel3.Controls.Clear();
            testovw.UpdateData(); testovw.Show();
            panel3.Controls.Add(testovw);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SetSidebarButtonSelected(button18);
            panel3.Controls.Clear();
            testinput.UpdateData(); 
            testinput.Show();
            panel3.Controls.Add(testinput);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SetSidebarButtonSelected(button25);
            panel3.Controls.Clear();
            testrecycle.UpdateData();
            testrecycle.Show();
            panel3.Controls.Add(testrecycle);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            examovw.UpdateData();
            SetSidebarButtonSelected(button20);
            panel3.Controls.Clear();
            examovw.Show();
            panel3.Controls.Add(examovw);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SetSidebarButtonSelected(button21);
            examipt.UpdateData();
            panel3.Controls.Clear();
            examipt.Show();
            panel3.Controls.Add(examipt);
        }

        
        


        public void zyedit_GoToViewPage()
        {
            panel3.Controls.Clear();
            ovw.Show();
            panel3.Controls.Add(ovw);
        }

        public void ovw_GoToEditPage(string t)
        {
            zyedit = new zyedit(t);
            zyedit.GoToViewPage += zyedit_GoToViewPage;
            panel3.Controls.Clear();
            zyedit.Show();
            panel3.Controls.Add(zyedit);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home.UpdataData(TeacherName);
            Home.teacherName =TeacherName;
            Home.teacherId=TeacherID;
            panel3.Controls.Clear();
            panel2.Hide();
            Home.Show();
            panel3.Controls.Add(Home);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
