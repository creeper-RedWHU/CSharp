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
            this.lblHeader = new System.Windows.Forms.Label();
            this.flpPassedWorks = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Gray;
            this.lblHeader.Location = new System.Drawing.Point(15, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(240, 26);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "📋 过期作业 (仅可查看)";
            // 
            // flpPassedWorks
            // 
            this.flpPassedWorks.AutoScroll = true;
            this.flpPassedWorks.BackColor = System.Drawing.Color.White;
            this.flpPassedWorks.Location = new System.Drawing.Point(15, 50);
            this.flpPassedWorks.Name = "flpPassedWorks";
            this.flpPassedWorks.Padding = new System.Windows.Forms.Padding(10);
            this.flpPassedWorks.Size = new System.Drawing.Size(1010, 580);
            this.flpPassedWorks.TabIndex = 1;
            // 
            // passed_work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.flpPassedWorks);
            this.Controls.Add(this.lblHeader);
            this.Name = "passed_work";
            this.Size = new System.Drawing.Size(1040, 645);
            this.Load += new System.EventHandler(this.passed_work_Load);
            this.Resize += new System.EventHandler(this.passed_work_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.FlowLayoutPanel flpPassedWorks;
    }
}