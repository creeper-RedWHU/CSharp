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
            this.dgvDueWork = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDueWork)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDueWork
            // 
            this.dgvDueWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDueWork.Location = new System.Drawing.Point(47, 52);
            this.dgvDueWork.Name = "dgvDueWork";
            this.dgvDueWork.RowHeadersWidth = 62;
            this.dgvDueWork.RowTemplate.Height = 30;
            this.dgvDueWork.Size = new System.Drawing.Size(752, 558);
            this.dgvDueWork.TabIndex = 0;
            this.dgvDueWork.ReadOnly = true;
            this.dgvDueWork.AllowUserToAddRows = false;
            this.dgvDueWork.AllowUserToDeleteRows = false;
            this.dgvDueWork.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
