using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form_student
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.courseSelectionPanel = new System.Windows.Forms.Panel();
            this.lblCourseSelection = new System.Windows.Forms.Label();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.homeButtonsPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.sidebarHeader = new System.Windows.Forms.Panel();
            this.lblNavigation = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.lblWelcomeContent = new System.Windows.Forms.Label();
            this.lblWelcomeTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.courseSelectionPanel.SuspendLayout();
            this.homeButtonsPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.sidebarHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            this.welcomePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.headerPanel.Controls.Add(this.courseSelectionPanel);
            this.headerPanel.Controls.Add(this.homeButtonsPanel);
            this.headerPanel.Controls.Add(this.titlePanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1621, 107);
            this.headerPanel.TabIndex = 0;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_student_MouseDown);
            this.headerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_student_MouseMove);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(54, 20);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(53, 53);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.Text = "—";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            this.btnMinimize.MouseEnter += new System.EventHandler(this.BtnMinimize_MouseEnter);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.BtnMinimize_MouseLeave);
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
            this.btnMaximize.Location = new System.Drawing.Point(107, 20);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(53, 53);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.Text = "□";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.BtnMaximize_Click);
            this.btnMaximize.MouseEnter += new System.EventHandler(this.BtnMaximize_MouseEnter);
            this.btnMaximize.MouseLeave += new System.EventHandler(this.BtnMaximize_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(161, 20);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 53);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "×";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.BtnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.BtnExit_MouseLeave);
            // 
            // courseSelectionPanel
            // 
            this.courseSelectionPanel.Controls.Add(this.btnMinimize);
            this.courseSelectionPanel.Controls.Add(this.btnMaximize);
            this.courseSelectionPanel.Controls.Add(this.btnExit);
            this.courseSelectionPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.courseSelectionPanel.Location = new System.Drawing.Point(1354, 0);
            this.courseSelectionPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.courseSelectionPanel.Name = "courseSelectionPanel";
            this.courseSelectionPanel.Size = new System.Drawing.Size(267, 107);
            this.courseSelectionPanel.TabIndex = 2;
            // 
            // lblCourseSelection
            // 
            this.lblCourseSelection.AutoSize = true;
            this.lblCourseSelection.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblCourseSelection.ForeColor = System.Drawing.Color.White;
            this.lblCourseSelection.Location = new System.Drawing.Point(287, 9);
            this.lblCourseSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCourseSelection.Name = "lblCourseSelection";
            this.lblCourseSelection.Size = new System.Drawing.Size(169, 36);
            this.lblCourseSelection.TabIndex = 2;
            this.lblCourseSelection.Text = "📚 当前课程";
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCourse.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(286, 49);
            this.comboBoxCourse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(159, 39);
            this.comboBoxCourse.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(454, 49);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 45);
            this.button3.TabIndex = 1;
            this.button3.Text = "🔄";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // homeButtonsPanel
            // 
            this.homeButtonsPanel.Controls.Add(this.button1);
            this.homeButtonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.homeButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.homeButtonsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.homeButtonsPanel.Name = "homeButtonsPanel";
            this.homeButtonsPanel.Size = new System.Drawing.Size(267, 107);
            this.homeButtonsPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(37, 20);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 67);
            this.button1.TabIndex = 0;
            this.button1.Text = "👨‍🎓 学生";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.lblCourseSelection);
            this.titlePanel.Controls.Add(this.label1);
            this.titlePanel.Controls.Add(this.comboBoxCourse);
            this.titlePanel.Controls.Add(this.button3);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(1621, 107);
            this.titlePanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(601, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(657, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "🎓 教学作业考试一体化在线平台";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.sidebarPanel.Controls.Add(this.navigationPanel);
            this.sidebarPanel.Controls.Add(this.sidebarHeader);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 107);
            this.sidebarPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(293, 1090);
            this.sidebarPanel.TabIndex = 1;
            // 
            // navigationPanel
            // 
            this.navigationPanel.Controls.Add(this.button6);
            this.navigationPanel.Controls.Add(this.button9);
            this.navigationPanel.Controls.Add(this.button8);
            this.navigationPanel.Controls.Add(this.button5);
            this.navigationPanel.Controls.Add(this.button4);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanel.Location = new System.Drawing.Point(0, 80);
            this.navigationPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Padding = new System.Windows.Forms.Padding(13, 13, 13, 13);
            this.navigationPanel.Size = new System.Drawing.Size(293, 1010);
            this.navigationPanel.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(13, 361);
            this.button6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(267, 87);
            this.button6.TabIndex = 4;
            this.button6.Text = "👤 个人信息";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(13, 274);
            this.button9.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.button9.Name = "button9";
            this.button9.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button9.Size = new System.Drawing.Size(267, 87);
            this.button9.TabIndex = 3;
            this.button9.Text = "💬 在线答疑";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button8.Dock = System.Windows.Forms.DockStyle.Top;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(13, 187);
            this.button8.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.button8.Name = "button8";
            this.button8.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button8.Size = new System.Drawing.Size(267, 87);
            this.button8.TabIndex = 2;
            this.button8.Text = "📊 在线考试";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(13, 100);
            this.button5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(267, 87);
            this.button5.TabIndex = 1;
            this.button5.Text = "📝 在线作业";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(13, 13);
            this.button4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(267, 87);
            this.button4.TabIndex = 0;
            this.button4.Text = "📚 课程信息";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // sidebarHeader
            // 
            this.sidebarHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.sidebarHeader.Controls.Add(this.lblNavigation);
            this.sidebarHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.sidebarHeader.Location = new System.Drawing.Point(0, 0);
            this.sidebarHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sidebarHeader.Name = "sidebarHeader";
            this.sidebarHeader.Size = new System.Drawing.Size(293, 80);
            this.sidebarHeader.TabIndex = 0;
            // 
            // lblNavigation
            // 
            this.lblNavigation.AutoSize = true;
            this.lblNavigation.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblNavigation.ForeColor = System.Drawing.Color.White;
            this.lblNavigation.Location = new System.Drawing.Point(5, 27);
            this.lblNavigation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNavigation.Name = "lblNavigation";
            this.lblNavigation.Size = new System.Drawing.Size(233, 50);
            this.lblNavigation.TabIndex = 0;
            this.lblNavigation.Text = "🧭 功能导航";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.welcomePanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(293, 107);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(13, 13, 13, 13);
            this.panel3.Size = new System.Drawing.Size(1328, 1090);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // welcomePanel
            // 
            this.welcomePanel.BackColor = System.Drawing.Color.White;
            this.welcomePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.welcomePanel.Controls.Add(this.lblWelcomeContent);
            this.welcomePanel.Controls.Add(this.lblWelcomeTitle);
            this.welcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomePanel.Location = new System.Drawing.Point(13, 13);
            this.welcomePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Padding = new System.Windows.Forms.Padding(40, 40, 40, 40);
            this.welcomePanel.Size = new System.Drawing.Size(1302, 1064);
            this.welcomePanel.TabIndex = 0;
            // 
            // lblWelcomeContent
            // 
            this.lblWelcomeContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcomeContent.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lblWelcomeContent.ForeColor = System.Drawing.Color.Gray;
            this.lblWelcomeContent.Location = new System.Drawing.Point(268, 468);
            this.lblWelcomeContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcomeContent.Name = "lblWelcomeContent";
            this.lblWelcomeContent.Size = new System.Drawing.Size(800, 200);
            this.lblWelcomeContent.TabIndex = 1;
            this.lblWelcomeContent.Text = "📚 选择左侧导航栏中的功能开始学习\r\n📝 完成在线作业和考试\r\n💬 参与在线答疑讨论\r\n👤 管理个人学习信息\r\n\r\n祝您学习愉快！ 🎉";
            this.lblWelcomeContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcomeTitle
            // 
            this.lblWelcomeTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWelcomeTitle.AutoSize = true;
            this.lblWelcomeTitle.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblWelcomeTitle.Location = new System.Drawing.Point(347, 363);
            this.lblWelcomeTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcomeTitle.Name = "lblWelcomeTitle";
            this.lblWelcomeTitle.Size = new System.Drawing.Size(656, 86);
            this.lblWelcomeTitle.TabIndex = 0;
            this.lblWelcomeTitle.Text = "🎓 欢迎来到学习平台";
            this.lblWelcomeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 107);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 133);
            this.panel2.TabIndex = 3;
            // 
            // Form_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1621, 1197);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.sidebarPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_student";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "教学作业考试一体化在线平台 - 学生端";
            this.Load += new System.EventHandler(this.Form_student_Load);
            this.headerPanel.ResumeLayout(false);
            this.courseSelectionPanel.ResumeLayout(false);
            this.homeButtonsPanel.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.sidebarPanel.ResumeLayout(false);
            this.navigationPanel.ResumeLayout(false);
            this.sidebarHeader.ResumeLayout(false);
            this.sidebarHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel homeButtonsPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel courseSelectionPanel;
        private System.Windows.Forms.Label lblCourseSelection;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel sidebarHeader;
        private System.Windows.Forms.Label lblNavigation;
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.Label lblWelcomeContent;
        private System.Windows.Forms.Label lblWelcomeTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnExit;
    }
}