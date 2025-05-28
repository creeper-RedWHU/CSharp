using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class online_work
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabContainer = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPassedWork = new System.Windows.Forms.Button();
            this.btnDueWork = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.tabContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1178, 72);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(22, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(57, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📝";
            // 
            // tabContainer
            // 
            this.tabContainer.BackColor = System.Drawing.Color.White;
            this.tabContainer.Controls.Add(this.btnRefresh);
            this.tabContainer.Controls.Add(this.btnPassedWork);
            this.tabContainer.Controls.Add(this.btnDueWork);
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabContainer.Location = new System.Drawing.Point(0, 72);
            this.tabContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.Padding = new System.Windows.Forms.Padding(22, 18, 22, 18);
            this.tabContainer.Size = new System.Drawing.Size(1178, 84);
            this.tabContainer.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Orange;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1012, 18);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(135, 48);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 刷新";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPassedWork
            // 
            this.btnPassedWork.BackColor = System.Drawing.Color.Gray;
            this.btnPassedWork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassedWork.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnPassedWork.ForeColor = System.Drawing.Color.White;
            this.btnPassedWork.Location = new System.Drawing.Point(225, 18);
            this.btnPassedWork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPassedWork.Name = "btnPassedWork";
            this.btnPassedWork.Size = new System.Drawing.Size(180, 48);
            this.btnPassedWork.TabIndex = 1;
            this.btnPassedWork.Text = "📋 过期作业";
            this.btnPassedWork.UseVisualStyleBackColor = false;
            this.btnPassedWork.Click += new System.EventHandler(this.btnPassedWork_Click);
            // 
            // btnDueWork
            // 
            this.btnDueWork.BackColor = System.Drawing.Color.Green;
            this.btnDueWork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDueWork.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnDueWork.ForeColor = System.Drawing.Color.White;
            this.btnDueWork.Location = new System.Drawing.Point(22, 18);
            this.btnDueWork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDueWork.Name = "btnDueWork";
            this.btnDueWork.Size = new System.Drawing.Size(180, 48);
            this.btnDueWork.TabIndex = 0;
            this.btnDueWork.Text = "⏰ 正在进行";
            this.btnDueWork.UseVisualStyleBackColor = false;
            this.btnDueWork.Click += new System.EventHandler(this.btnDueWork_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 156);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.contentPanel.Size = new System.Drawing.Size(1178, 742);
            this.contentPanel.TabIndex = 2;
            // 
            // online_work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.headerPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "online_work";
            this.Size = new System.Drawing.Size(1178, 898);
            this.Load += new System.EventHandler(this.online_work_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.tabContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel tabContainer;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPassedWork;
        private System.Windows.Forms.Button btnDueWork;
        private System.Windows.Forms.Panel contentPanel;
    }
}