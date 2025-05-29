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
            this.lblHeader = new System.Windows.Forms.Label();
            this.flpDueWorks = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Green;
            this.lblHeader.Location = new System.Drawing.Point(15, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(240, 26);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "⏰ 正在进行的作业 (可提交)";
            // 
            // flpDueWorks
            // 
            this.flpDueWorks.AutoScroll = true;
            this.flpDueWorks.BackColor = System.Drawing.Color.White;
            this.flpDueWorks.Location = new System.Drawing.Point(15, 50);
            this.flpDueWorks.Name = "flpDueWorks";
            this.flpDueWorks.Padding = new System.Windows.Forms.Padding(10);
            this.flpDueWorks.Size = new System.Drawing.Size(1010, 580);
            this.flpDueWorks.TabIndex = 1;
            // 
            // due_work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.flpDueWorks);
            this.Controls.Add(this.lblHeader);
            this.Name = "due_work";
            this.Size = new System.Drawing.Size(1040, 645);
            this.Load += new System.EventHandler(this.due_work_Load);
            this.Resize += new System.EventHandler(this.due_work_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.FlowLayoutPanel flpDueWorks;
    }
}