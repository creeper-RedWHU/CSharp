// namespace WindowsFormsApp1.Form1Tea._5exam
// {
//     partial class PGNext
//     {
//         /// <summary> 
//         /// 必需的设计器变量。
//         /// </summary>
//         private System.ComponentModel.IContainer components = null;

//         /// <summary> 
//         /// 清理所有正在使用的资源。
//         /// </summary>
//         /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
//         protected override void Dispose(bool disposing)
//         {
//             if (disposing && (components != null))
//             {
//                 components.Dispose();
//             }
//             base.Dispose(disposing);
//         }

//         #region 组件设计器生成的代码

//         /// <summary> 
//         /// 设计器支持所需的方法 - 不要修改
//         /// 使用代码编辑器修改此方法的内容。
//         /// </summary>
//         private void InitializeComponent()
//         {
//             this.panel1 = new System.Windows.Forms.Panel();
//             this.label1 = new System.Windows.Forms.Label();
//             this.dataGridView1 = new System.Windows.Forms.DataGridView();
//             this.StuID = new System.Windows.Forms.DataGridViewTextBoxColumn();
//             this.StuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
//             this.isCommit = new System.Windows.Forms.DataGridViewTextBoxColumn();
//             this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
//             this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
//             this.Choose = new System.Windows.Forms.DataGridViewButtonColumn();
//             this.panel1.SuspendLayout();
//             ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
//             this.SuspendLayout();
//             // 
//             // panel1
//             // 
//             this.panel1.Controls.Add(this.label1);
//             this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
//             this.panel1.Location = new System.Drawing.Point(0, 0);
//             this.panel1.Name = "panel1";
//             this.panel1.Size = new System.Drawing.Size(871, 82);
//             this.panel1.TabIndex = 0;
//             // 
//             // label1
//             // 
//             this.label1.AutoSize = true;
//             this.label1.Location = new System.Drawing.Point(313, 33);
//             this.label1.Name = "label1";
//             this.label1.Size = new System.Drawing.Size(127, 15);
//             this.label1.TabIndex = 0;
//             this.label1.Text = "选择学生进行批阅";
//             // 
//             // dataGridView1
//             // 
//             this.dataGridView1.AllowUserToAddRows = false;
//             this.dataGridView1.AllowUserToDeleteRows = false;
//             this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
//             this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
//             this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
//             this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//             this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//             this.StuID,
//             this.StuName,
//             this.isCommit,
//             this.Time,
//             this.Score,
//             this.Choose});
//             this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
//             this.dataGridView1.Location = new System.Drawing.Point(0, 82);
//             this.dataGridView1.Name = "dataGridView1";
//             this.dataGridView1.RowHeadersVisible = false;
//             this.dataGridView1.RowHeadersWidth = 51;
//             this.dataGridView1.RowTemplate.Height = 27;
//             this.dataGridView1.Size = new System.Drawing.Size(871, 568);
//             this.dataGridView1.TabIndex = 1;
//             this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
//             // 
//             // StuID
//             // 
//             this.StuID.HeaderText = "学号";
//             this.StuID.MinimumWidth = 6;
//             this.StuID.Name = "StuID";
//             this.StuID.ReadOnly = true;
//             // 
//             // StuName
//             // 
//             this.StuName.HeaderText = "姓名";
//             this.StuName.MinimumWidth = 6;
//             this.StuName.Name = "StuName";
//             this.StuName.ReadOnly = true;
//             this.StuName.Width = 125;
//             // 
//             // isCommit
//             // 
//             this.isCommit.HeaderText = "提交情况";
//             this.isCommit.MinimumWidth = 6;
//             this.isCommit.Name = "isCommit";
//             this.isCommit.ReadOnly = true;
//             this.isCommit.Width = 180;
//             // 
//             // Time
//             // 
//             this.Time.HeaderText = "提交时间";
//             this.Time.MinimumWidth = 6;
//             this.Time.Name = "Time";
//             this.Time.ReadOnly = true;
//             this.Time.Width = 200;
//             // 
//             // Score
//             // 
//             this.Score.HeaderText = "评分";
//             this.Score.MinimumWidth = 6;
//             this.Score.Name = "Score";
//             this.Score.ReadOnly = true;
//             this.Score.Width = 125;
//             // 
//             // Choose
//             // 
//             this.Choose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
//             this.Choose.HeaderText = "选择";
//             this.Choose.MinimumWidth = 6;
//             this.Choose.Name = "Choose";
//             this.Choose.ReadOnly = true;
//             this.Choose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
//             this.Choose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
//             // 
//             // PGNext
//             // 
//             this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
//             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//             this.Controls.Add(this.dataGridView1);
//             this.Controls.Add(this.panel1);
//             this.Name = "PGNext";
//             this.Size = new System.Drawing.Size(871, 650);
//             this.panel1.ResumeLayout(false);
//             this.panel1.PerformLayout();
//             ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
//             this.ResumeLayout(false);

//         }

//         #endregion

//         private System.Windows.Forms.Panel panel1;
//         private System.Windows.Forms.Label label1;
//         private System.Windows.Forms.DataGridView dataGridView1;
//         private System.Windows.Forms.DataGridViewTextBoxColumn StuID;
//         private System.Windows.Forms.DataGridViewTextBoxColumn StuName;
//         private System.Windows.Forms.DataGridViewTextBoxColumn isCommit;
//         private System.Windows.Forms.DataGridViewTextBoxColumn Time;
//         private System.Windows.Forms.DataGridViewTextBoxColumn Score;
//         private System.Windows.Forms.DataGridViewButtonColumn Choose;
//     }
// }
namespace WindowsFormsApp1.Form1Tea._5exam
{
    partial class PGNext
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelEmoji = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StuID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCommit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Choose = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelEmoji);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Emoji", 20F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 82);
            this.panel1.TabIndex = 0;
            // 
            // labelEmoji
            // 
            this.labelEmoji.AutoSize = true;
            this.labelEmoji.Font = new System.Drawing.Font("Segoe UI Emoji", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEmoji.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.labelEmoji.Location = new System.Drawing.Point(260, 18);
            this.labelEmoji.Name = "labelEmoji";
            this.labelEmoji.Size = new System.Drawing.Size(50, 34);
            this.labelEmoji.TabIndex = 0;
            this.labelEmoji.Text = "👩‍🎓";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Emoji", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.labelTitle.Location = new System.Drawing.Point(320, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(295, 34);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "选择学生进行批阅";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(201)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StuID,
            this.StuName,
            this.isCommit,
            this.Time,
            this.Score,
            this.Choose});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 36;
            this.dataGridView1.Size = new System.Drawing.Size(871, 568);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // StuID
            // 
            this.StuID.HeaderText = "🆔 学号";
            this.StuID.MinimumWidth = 6;
            this.StuID.Name = "StuID";
            this.StuID.ReadOnly = true;
            this.StuID.Width = 125;
            // 
            // StuName
            // 
            this.StuName.HeaderText = "👤 姓名";
            this.StuName.MinimumWidth = 6;
            this.StuName.Name = "StuName";
            this.StuName.ReadOnly = true;
            this.StuName.Width = 125;
            // 
            // isCommit
            // 
            this.isCommit.HeaderText = "📤 提交情况";
            this.isCommit.MinimumWidth = 6;
            this.isCommit.Name = "isCommit";
            this.isCommit.ReadOnly = true;
            this.isCommit.Width = 180;
            // 
            // Time
            // 
            this.Time.HeaderText = "⏰ 提交时间";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 200;
            // 
            // Score
            // 
            this.Score.HeaderText = "⭐ 评分";
            this.Score.MinimumWidth = 6;
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            this.Score.Width = 125;
            // 
            // Choose
            // 
            this.Choose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Choose.HeaderText = "✏️ 批阅";
            this.Choose.MinimumWidth = 6;
            this.Choose.Name = "Choose";
            this.Choose.ReadOnly = true;
            this.Choose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Choose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Choose.Text = "";
            // 
            // PGNext
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "PGNext";
            this.Size = new System.Drawing.Size(871, 650);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelEmoji;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StuID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn isCommit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewButtonColumn Choose;
    }
}