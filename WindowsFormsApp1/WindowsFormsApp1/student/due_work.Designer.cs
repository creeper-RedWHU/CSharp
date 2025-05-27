using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class due_work
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
            this.dgvDueWork = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDueWork)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDueWork
            // 
            this.dgvDueWork.AllowUserToAddRows = false;
            this.dgvDueWork.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvDueWork.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDueWork.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDueWork.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDueWork.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDueWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDueWork.EnableHeadersVisualStyles = false;
            this.dgvDueWork.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dgvDueWork.Location = new System.Drawing.Point(0, 0);
            this.dgvDueWork.Name = "dgvDueWork";
            this.dgvDueWork.ReadOnly = true;
            this.dgvDueWork.RowHeadersWidth = 62;
            this.dgvDueWork.RowTemplate.Height = 32;
            this.dgvDueWork.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDueWork.Size = new System.Drawing.Size(840, 650);
            this.dgvDueWork.TabIndex = 0;
            this.dgvDueWork.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDueWork_CellDoubleClick);
            // 
            // due_work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDueWork);
            this.Name = "due_work";
            this.Size = new System.Drawing.Size(843, 650);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDueWork)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDueWork;
    }
}
