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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnMaximize);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 89);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_student_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_student_MouseMove);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Location = new System.Drawing.Point(1075, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(42, 36);
            this.btnMinimize.TabIndex = 14;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = true;
            // 
            // btnMaximize
            // 
            this.btnMaximize.Location = new System.Drawing.Point(1123, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(42, 36);
            this.btnMaximize.TabIndex = 13;
            this.btnMaximize.Text = "□";
            this.btnMaximize.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1171, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(42, 36);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "×";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(279, 4);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(127, 55);
            this.button10.TabIndex = 12;
            this.button10.Text = "当前课程名称";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 85);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 899);
            this.panel2.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(140, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 55);
            this.button2.TabIndex = 2;
            this.button2.Text = "首页";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "学生页面";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(447, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "教学作业考试一体化在线平台";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(257, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(956, 809);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.button6);
            this.panel4.Controls.Add(this.button9);
            this.panel4.Controls.Add(this.button8);
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button7);
            this.panel4.Location = new System.Drawing.Point(3, 85);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(234, 809);
            this.panel4.TabIndex = 3;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(0, 489);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(111, 55);
            this.button6.TabIndex = 13;
            this.button6.Text = "个人信息";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(0, 390);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(111, 55);
            this.button9.TabIndex = 11;
            this.button9.Text = "在线答疑";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(0, 299);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(111, 55);
            this.button8.TabIndex = 10;
            this.button8.Text = "在线考试";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 208);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 55);
            this.button5.TabIndex = 9;
            this.button5.Text = "在线作业";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 122);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 55);
            this.button4.TabIndex = 8;
            this.button4.Text = "课程信息";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(84, 847);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // Form_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 898);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "教学作业考试一体化在线平台 - 学生端";
            this.Load += new System.EventHandler(this.Form_student_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnMinimize;
    }
}