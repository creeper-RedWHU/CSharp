namespace EduAdminApp
{
    partial class Course
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelCourseInfo = new System.Windows.Forms.Panel();
            this.labelCourseID = new System.Windows.Forms.Label();
            this.labelCourseName = new System.Windows.Forms.Label();
            this.labelTeacher = new System.Windows.Forms.Label();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelCredits = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.panelScheduleInfo = new System.Windows.Forms.Panel();
            this.labelClassroom = new System.Windows.Forms.Label();
            this.labelSchedule = new System.Windows.Forms.Label();
            this.panelDescription = new System.Windows.Forms.Panel();
            this.labelDescriptionTitle = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.panelCourseInfo.SuspendLayout();
            this.panelScheduleInfo.SuspendLayout();
            this.panelDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(114)))));
            this.labelTitle.Location = new System.Drawing.Point(36, 21);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1287, 80);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "📚 课程详细信息";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCourseInfo
            // 
            this.panelCourseInfo.BackColor = System.Drawing.Color.White;
            this.panelCourseInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCourseInfo.Controls.Add(this.labelCourseID);
            this.panelCourseInfo.Controls.Add(this.labelCourseName);
            this.panelCourseInfo.Controls.Add(this.labelTeacher);
            this.panelCourseInfo.Controls.Add(this.labelStartTime);
            this.panelCourseInfo.Controls.Add(this.labelCredits);
            this.panelCourseInfo.Controls.Add(this.labelDuration);
            this.panelCourseInfo.Location = new System.Drawing.Point(104, 104);
            this.panelCourseInfo.Name = "panelCourseInfo";
            this.panelCourseInfo.Size = new System.Drawing.Size(580, 300);
            this.panelCourseInfo.TabIndex = 1;
            // 
            // labelCourseID
            // 
            this.labelCourseID.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.labelCourseID.ForeColor = System.Drawing.Color.DimGray;
            this.labelCourseID.Location = new System.Drawing.Point(20, 20);
            this.labelCourseID.Name = "labelCourseID";
            this.labelCourseID.Size = new System.Drawing.Size(540, 40);
            this.labelCourseID.TabIndex = 0;
            this.labelCourseID.Text = "📘 课程编号：";
            // 
            // labelCourseName
            // 
            this.labelCourseName.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.labelCourseName.ForeColor = System.Drawing.Color.DimGray;
            this.labelCourseName.Location = new System.Drawing.Point(20, 65);
            this.labelCourseName.Name = "labelCourseName";
            this.labelCourseName.Size = new System.Drawing.Size(540, 40);
            this.labelCourseName.TabIndex = 1;
            this.labelCourseName.Text = "📖 课程名称：";
            // 
            // labelTeacher
            // 
            this.labelTeacher.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.labelTeacher.ForeColor = System.Drawing.Color.DimGray;
            this.labelTeacher.Location = new System.Drawing.Point(20, 111);
            this.labelTeacher.Name = "labelTeacher";
            this.labelTeacher.Size = new System.Drawing.Size(540, 40);
            this.labelTeacher.TabIndex = 2;
            this.labelTeacher.Text = "👨‍🏫 授课教师：";
            // 
            // labelStartTime
            // 
            this.labelStartTime.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.labelStartTime.ForeColor = System.Drawing.Color.DimGray;
            this.labelStartTime.Location = new System.Drawing.Point(20, 157);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(540, 40);
            this.labelStartTime.TabIndex = 3;
            this.labelStartTime.Text = "🕒 开课时间：";
            // 
            // labelCredits
            // 
            this.labelCredits.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.labelCredits.ForeColor = System.Drawing.Color.DimGray;
            this.labelCredits.Location = new System.Drawing.Point(20, 201);
            this.labelCredits.Name = "labelCredits";
            this.labelCredits.Size = new System.Drawing.Size(540, 40);
            this.labelCredits.TabIndex = 4;
            this.labelCredits.Text = "🎓 学分：";
            // 
            // labelDuration
            // 
            this.labelDuration.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.labelDuration.ForeColor = System.Drawing.Color.DimGray;
            this.labelDuration.Location = new System.Drawing.Point(20, 246);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(540, 40);
            this.labelDuration.TabIndex = 5;
            this.labelDuration.Text = "⏳ 课时：";
            // 
            // panelScheduleInfo
            // 
            this.panelScheduleInfo.BackColor = System.Drawing.Color.White;
            this.panelScheduleInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelScheduleInfo.Controls.Add(this.labelClassroom);
            this.panelScheduleInfo.Controls.Add(this.labelSchedule);
            this.panelScheduleInfo.Location = new System.Drawing.Point(734, 104);
            this.panelScheduleInfo.Name = "panelScheduleInfo";
            this.panelScheduleInfo.Size = new System.Drawing.Size(580, 300);
            this.panelScheduleInfo.TabIndex = 2;
            // 
            // labelClassroom
            // 
            this.labelClassroom.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.labelClassroom.ForeColor = System.Drawing.Color.DimGray;
            this.labelClassroom.Location = new System.Drawing.Point(20, 44);
            this.labelClassroom.Name = "labelClassroom";
            this.labelClassroom.Size = new System.Drawing.Size(540, 40);
            this.labelClassroom.TabIndex = 0;
            this.labelClassroom.Text = "🏫 上课地点：";
            // 
            // labelSchedule
            // 
            this.labelSchedule.Font = new System.Drawing.Font("微软雅黑", 11.5F);
            this.labelSchedule.ForeColor = System.Drawing.Color.DimGray;
            this.labelSchedule.Location = new System.Drawing.Point(20, 180);
            this.labelSchedule.Name = "labelSchedule";
            this.labelSchedule.Size = new System.Drawing.Size(540, 40);
            this.labelSchedule.TabIndex = 1;
            this.labelSchedule.Text = "📅 上课时间：";
            // 
            // panelDescription
            // 
            this.panelDescription.BackColor = System.Drawing.Color.White;
            this.panelDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDescription.Controls.Add(this.labelDescriptionTitle);
            this.panelDescription.Controls.Add(this.labelDescription);
            this.panelDescription.Location = new System.Drawing.Point(104, 434);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(1210, 458);
            this.panelDescription.TabIndex = 3;
            // 
            // labelDescriptionTitle
            // 
            this.labelDescriptionTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.labelDescriptionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(60)))), ((int)(((byte)(114)))));
            this.labelDescriptionTitle.Location = new System.Drawing.Point(20, 20);
            this.labelDescriptionTitle.Name = "labelDescriptionTitle";
            this.labelDescriptionTitle.Size = new System.Drawing.Size(300, 50);
            this.labelDescriptionTitle.TabIndex = 0;
            this.labelDescriptionTitle.Text = "📝 课程简介";
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.labelDescription.Location = new System.Drawing.Point(20, 84);
            this.labelDescription.MaximumSize = new System.Drawing.Size(1160, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(1160, 327);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "该课程将帮助学生深入了解……（从数据库加载），自动换行，完整展示内容，无需滚动条。";
            // 
            // Course
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panelCourseInfo);
            this.Controls.Add(this.panelScheduleInfo);
            this.Controls.Add(this.panelDescription);
            this.Name = "Course";
            this.Size = new System.Drawing.Size(1422, 932);
            this.panelCourseInfo.ResumeLayout(false);
            this.panelScheduleInfo.ResumeLayout(false);
            this.panelDescription.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelCourseInfo;
        private System.Windows.Forms.Panel panelScheduleInfo;
        private System.Windows.Forms.Panel panelDescription;
        private System.Windows.Forms.Label labelCourseID;
        private System.Windows.Forms.Label labelCourseName;
        private System.Windows.Forms.Label labelTeacher;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.Label labelCredits;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelClassroom;
        private System.Windows.Forms.Label labelSchedule;
        private System.Windows.Forms.Label labelDescriptionTitle;
        private System.Windows.Forms.Label labelDescription;
    }
}