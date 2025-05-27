using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class passed_work
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
            this.dgvPassedWork = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassedWork)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPassedWork
            // 
            this.dgvPassedWork.AllowUserToAddRows = false;
            this.dgvPassedWork.AllowUserToDeleteRows = false;
            this.dgvPassedWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassedWork.Location = new System.Drawing.Point(20, 18);
            this.dgvPassedWork.Name = "dgvPassedWork";
            this.dgvPassedWork.ReadOnly = true;
            this.dgvPassedWork.RowHeadersWidth = 62;
            this.dgvPassedWork.RowTemplate.Height = 30;
            this.dgvPassedWork.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPassedWork.Size = new System.Drawing.Size(819, 616);
            this.dgvPassedWork.TabIndex = 0;
            this.dgvPassedWork.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDueWork_CellDoubleClick);
            this.dgvPassedWork.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // 或者 AllCells
            this.dgvPassedWork.RowTemplate.Height = 32;
            this.dgvPassedWork.Font = new Font("微软雅黑", 12F);
            this.dgvPassedWork.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
            this.dgvPassedWork.EnableHeadersVisualStyles = false;
            this.dgvPassedWork.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgvPassedWork.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvPassedWork.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvPassedWork.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            // 
            // passed_work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPassedWork);
            this.Name = "passed_work";
            this.Size = new System.Drawing.Size(859, 652);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassedWork)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPassedWork;
    }
}
