// namespace WindowsFormsApp1.Form1Tea._2zygl
// {
//     partial class glrecycle
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
//             this.customSearchBar2 = new WindowsFormsApp1.CustomSearchBar();
//             this.label1 = new System.Windows.Forms.Label();
//             this.dataGridView1 = new System.Windows.Forms.DataGridView();
//             this.HID = new System.Windows.Forms.DataGridViewTextBoxColumn();
//             this.HName = new System.Windows.Forms.DataGridViewTextBoxColumn();
//             this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
//             this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
//             this.InputInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
//             this.Del = new System.Windows.Forms.DataGridViewButtonColumn();
//             this.panel1.SuspendLayout();
//             ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
//             this.SuspendLayout();
//             // 
//             // panel1
//             // 
//             this.panel1.Controls.Add(this.customSearchBar2);
//             this.panel1.Controls.Add(this.label1);
//             this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
//             this.panel1.Location = new System.Drawing.Point(0, 0);
//             this.panel1.Name = "panel1";
//             this.panel1.Size = new System.Drawing.Size(871, 100);
//             this.panel1.TabIndex = 4;
//             // 
//             // customSearchBar2
//             // 
//             this.customSearchBar2.Location = new System.Drawing.Point(653, 36);
//             this.customSearchBar2.Name = "customSearchBar2";
//             this.customSearchBar2.Size = new System.Drawing.Size(147, 25);
//             this.customSearchBar2.TabIndex = 2;
//             this.customSearchBar2.WaterText = "   标题的索引词  ";
//             // 
//             // label1
//             // 
//             this.label1.AutoSize = true;
//             this.label1.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
//             this.label1.Location = new System.Drawing.Point(20, 20);
//             this.label1.Name = "label1";
//             this.label1.Size = new System.Drawing.Size(207, 37);
//             this.label1.TabIndex = 0;
//             this.label1.Text = "作业回收站";
//             // 
//             // dataGridView1
//             // 
//             this.dataGridView1.AllowUserToAddRows = false;
//             this.dataGridView1.AllowUserToDeleteRows = false;
//             this.dataGridView1.AllowUserToOrderColumns = true;
//             this.dataGridView1.AllowUserToResizeRows = false;
//             this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
//             this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
//             this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
//             this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//             this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//             this.HID,
//             this.HName,
//             this.StartTime,
//             this.EndTime,
//             this.InputInformation,
//             this.Del});
//             this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
//             this.dataGridView1.GridColor = System.Drawing.Color.White;
//             this.dataGridView1.Location = new System.Drawing.Point(0, 100);
//             this.dataGridView1.Name = "dataGridView1";
//             this.dataGridView1.RowHeadersVisible = false;
//             this.dataGridView1.RowHeadersWidth = 51;
//             this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
//             this.dataGridView1.RowTemplate.Height = 27;
//             this.dataGridView1.Size = new System.Drawing.Size(871, 650);
//             this.dataGridView1.TabIndex = 6;
//             this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
//             // 
//             // HID
//             // 
//             this.HID.DataPropertyName = "HID";
//             this.HID.HeaderText = "作业编号";
//             this.HID.MinimumWidth = 6;
//             this.HID.Name = "HID";
//             this.HID.ReadOnly = true;
//             this.HID.Width = 125;
//             // 
//             // HName
//             // 
//             this.HName.DataPropertyName = "HName";
//             this.HName.HeaderText = "作业标题";
//             this.HName.MinimumWidth = 6;
//             this.HName.Name = "HName";
//             this.HName.ReadOnly = true;
//             this.HName.Width = 125;
//             // 
//             // StartTime
//             // 
//             this.StartTime.DataPropertyName = "StartTime";
//             this.StartTime.HeaderText = "起始时间";
//             this.StartTime.MinimumWidth = 6;
//             this.StartTime.Name = "StartTime";
//             this.StartTime.ReadOnly = true;
//             this.StartTime.Width = 125;
//             // 
//             // EndTime
//             // 
//             this.EndTime.DataPropertyName = "EndTime";
//             this.EndTime.HeaderText = "结束时间";
//             this.EndTime.MinimumWidth = 6;
//             this.EndTime.Name = "EndTime";
//             this.EndTime.ReadOnly = true;
//             this.EndTime.Width = 125;
//             // 
//             // InputInformation
//             // 
//             this.InputInformation.DataPropertyName = "InputInformation";
//             this.InputInformation.HeaderText = "输入信息";
//             this.InputInformation.MinimumWidth = 6;
//             this.InputInformation.Name = "InputInformation";
//             this.InputInformation.ReadOnly = true;
//             this.InputInformation.Width = 125;
//             // 
//             // Del
//             // 
//             this.Del.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
//             this.Del.HeaderText = "操作";
//             this.Del.MinimumWidth = 6;
//             this.Del.Name = "Del";
//             this.Del.ReadOnly = true;
//             this.Del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
//             this.Del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
//             this.Del.Text = "删除";
//             this.Del.UseColumnTextForButtonValue = true;
//             // 
//             // glrecycle
//             // 
//             this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
//             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//             this.Controls.Add(this.dataGridView1);
//             this.Controls.Add(this.panel1);
//             this.Name = "glrecycle";
//             this.Size = new System.Drawing.Size(871, 750);
//             this.panel1.ResumeLayout(false);
//             this.panel1.PerformLayout();
//             ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
//             this.ResumeLayout(false);

//         }

//         #endregion
//         private System.Windows.Forms.Panel panel1;
//         private CustomSearchBar customSearchBar2;
//         private System.Windows.Forms.Label label1;
//         private System.Windows.Forms.DataGridView dataGridView1;
//         private System.Windows.Forms.DataGridViewTextBoxColumn HID;
//         private System.Windows.Forms.DataGridViewTextBoxColumn HName;
//         private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
//         private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
//         private System.Windows.Forms.DataGridViewTextBoxColumn InputInformation;
//         private System.Windows.Forms.DataGridViewButtonColumn Del;
//     }
// }
namespace WindowsFormsApp1.Form1Tea._2zygl
{
    partial class glrecycle
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.HID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 100);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "🗑️";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(99)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HID,
            this.HName,
            this.StartTime,
            this.EndTime,
            this.InputInformation,
            this.Del});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 36;
            this.dataGridView1.Size = new System.Drawing.Size(871, 650);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // HID
            // 
            this.HID.DataPropertyName = "HID";
            this.HID.HeaderText = "🆔 编号";
            this.HID.MinimumWidth = 6;
            this.HID.Name = "HID";
            this.HID.ReadOnly = true;
            this.HID.Width = 125;
            // 
            // HName
            // 
            this.HName.DataPropertyName = "HName";
            this.HName.HeaderText = "🏷️ 作业标题";
            this.HName.MinimumWidth = 6;
            this.HName.Name = "HName";
            this.HName.ReadOnly = true;
            this.HName.Width = 180;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "⏰ 起始时间";
            this.StartTime.MinimumWidth = 6;
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 140;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "⏳ 结束时间";
            this.EndTime.MinimumWidth = 6;
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.Width = 140;
            // 
            // InputInformation
            // 
            this.InputInformation.DataPropertyName = "InputInformation";
            this.InputInformation.HeaderText = "📝 输入信息";
            this.InputInformation.MinimumWidth = 6;
            this.InputInformation.Name = "InputInformation";
            this.InputInformation.ReadOnly = true;
            this.InputInformation.Width = 160;
            // 
            // Del
            // 
            this.Del.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Del.HeaderText = "🗑️ 操作";
            this.Del.MinimumWidth = 6;
            this.Del.Name = "Del";
            this.Del.ReadOnly = true;
            this.Del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Del.Text = "🗑️ 删除";
            this.Del.UseColumnTextForButtonValue = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.label2.Location = new System.Drawing.Point(69, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "作业回收站";
            // 
            // glrecycle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "glrecycle";
            this.Size = new System.Drawing.Size(871, 750);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HID;
        private System.Windows.Forms.DataGridViewTextBoxColumn HName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputInformation;
        private System.Windows.Forms.DataGridViewButtonColumn Del;
        private System.Windows.Forms.Label label2;
    }
}