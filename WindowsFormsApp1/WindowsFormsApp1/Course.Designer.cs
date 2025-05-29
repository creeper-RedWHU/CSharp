namespace WindowsFormsApp1
{
    partial class Course
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvcourses = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn(); // 新增
            this.ColumnNum = new System.Windows.Forms.DataGridViewTextBoxColumn();     // 新增
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcourses)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.label1);
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(1060, 104);
            this.TitlePanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label1.Location = new System.Drawing.Point(436, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "课程信息";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvcourses
            // 
            this.dgvcourses.AllowUserToDeleteRows = false;
            this.dgvcourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvcourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Column1,
                this.ColumnEndTime, // 新增
                this.ColumnNum      // 新增
            });
            this.dgvcourses.Location = new System.Drawing.Point(0, 102);
            this.dgvcourses.MultiSelect = false;
            this.dgvcourses.Name = "dgvcourses";
            this.dgvcourses.RowHeadersWidth = 62;
            this.dgvcourses.RowTemplate.Height = 30;
            this.dgvcourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcourses.Size = new System.Drawing.Size(1060, 639);
            this.dgvcourses.TabIndex = 1;
            this.dgvcourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcourses_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CourseName";
            this.Column1.HeaderText = "课程名称";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            // 
            // ColumnEndTime
            // 
            this.ColumnEndTime.DataPropertyName = "Endtim";
            this.ColumnEndTime.HeaderText = "结束时间";
            this.ColumnEndTime.MinimumWidth = 8;
            this.ColumnEndTime.Name = "ColumnEndTime";
            // 
            // ColumnNum
            // 
            this.ColumnNum.DataPropertyName = "NUM";
            this.ColumnNum.HeaderText = "上课人数";
            this.ColumnNum.MinimumWidth = 8;
            this.ColumnNum.Name = "ColumnNum";
            // 
            // Course
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvcourses);
            this.Controls.Add(this.TitlePanel);
            this.Name = "Course";
            this.Size = new System.Drawing.Size(1060, 744);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvcourses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEndTime; // 新增
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNum;    // 新增
    }
}
