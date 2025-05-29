using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class FormProblems
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.lblProblemList = new System.Windows.Forms.Label();
            this.lstProblems = new System.Windows.Forms.ListBox();
            this.rightSplitContainer = new System.Windows.Forms.SplitContainer();
            this.topRightPanel = new System.Windows.Forms.Panel();
            this.lblProblemDetail = new System.Windows.Forms.Label();
            this.rtbProblemContent = new System.Windows.Forms.RichTextBox();
            this.bottomRightPanel = new System.Windows.Forms.Panel();
            this.lblAnswerArea = new System.Windows.Forms.Label();
            this.pnlAnswerContent = new System.Windows.Forms.Panel();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.pnlSubmissionHistory = new System.Windows.Forms.Panel();
            this.dgvSubmissionHistory = new System.Windows.Forms.DataGridView();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnSubmitSingle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).BeginInit();
            this.rightSplitContainer.Panel1.SuspendLayout();
            this.rightSplitContainer.Panel2.SuspendLayout();
            this.rightSplitContainer.SuspendLayout();
            this.topRightPanel.SuspendLayout();
            this.bottomRightPanel.SuspendLayout();
            this.pnlAnswerContent.SuspendLayout();
            this.pnlSubmissionHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubmissionHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplitContainer.Location = new System.Drawing.Point(3, 64);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.leftPanel);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.rightSplitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(1194, 784);
            this.mainSplitContainer.SplitterDistance = 350;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.White;
            this.leftPanel.Controls.Add(this.lblProblemList);
            this.leftPanel.Controls.Add(this.lstProblems);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Padding = new System.Windows.Forms.Padding(10);
            this.leftPanel.Size = new System.Drawing.Size(350, 784);
            this.leftPanel.TabIndex = 0;
            // 
            // lblProblemList
            // 
            this.lblProblemList.AutoSize = true;
            this.lblProblemList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblProblemList.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblProblemList.Location = new System.Drawing.Point(10, 10);
            this.lblProblemList.Name = "lblProblemList";
            this.lblProblemList.Size = new System.Drawing.Size(110, 31);
            this.lblProblemList.TabIndex = 0;
            this.lblProblemList.Text = "题目列表";
            // 
            // lstProblems
            // 
            this.lstProblems.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lstProblems.ItemHeight = 30;
            this.lstProblems.Location = new System.Drawing.Point(10, 40);
            this.lstProblems.Name = "lstProblems";
            this.lstProblems.Size = new System.Drawing.Size(330, 724);
            this.lstProblems.TabIndex = 1;
            this.lstProblems.SelectedIndexChanged += new System.EventHandler(this.lstProblems_SelectedIndexChanged);
            // 
            // rightSplitContainer
            // 
            this.rightSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.rightSplitContainer.Name = "rightSplitContainer";
            this.rightSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rightSplitContainer.Panel1
            // 
            this.rightSplitContainer.Panel1.Controls.Add(this.topRightPanel);
            // 
            // rightSplitContainer.Panel2
            // 
            this.rightSplitContainer.Panel2.Controls.Add(this.bottomRightPanel);
            this.rightSplitContainer.Size = new System.Drawing.Size(840, 784);
            this.rightSplitContainer.SplitterDistance = 294;
            this.rightSplitContainer.TabIndex = 0;
            // 
            // topRightPanel
            // 
            this.topRightPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.topRightPanel.Controls.Add(this.lblProblemDetail);
            this.topRightPanel.Controls.Add(this.rtbProblemContent);
            this.topRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topRightPanel.Location = new System.Drawing.Point(0, 0);
            this.topRightPanel.Name = "topRightPanel";
            this.topRightPanel.Padding = new System.Windows.Forms.Padding(10);
            this.topRightPanel.Size = new System.Drawing.Size(840, 294);
            this.topRightPanel.TabIndex = 0;
            // 
            // lblProblemDetail
            // 
            this.lblProblemDetail.AutoSize = true;
            this.lblProblemDetail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblProblemDetail.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblProblemDetail.Location = new System.Drawing.Point(10, 10);
            this.lblProblemDetail.Name = "lblProblemDetail";
            this.lblProblemDetail.Size = new System.Drawing.Size(110, 31);
            this.lblProblemDetail.TabIndex = 0;
            this.lblProblemDetail.Text = "题目详情";
            // 
            // rtbProblemContent
            // 
            this.rtbProblemContent.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.rtbProblemContent.Location = new System.Drawing.Point(10, 40);
            this.rtbProblemContent.Name = "rtbProblemContent";
            this.rtbProblemContent.ReadOnly = true;
            this.rtbProblemContent.Size = new System.Drawing.Size(826, 250);
            this.rtbProblemContent.TabIndex = 1;
            this.rtbProblemContent.Text = "";
            // 
            // bottomRightPanel
            // 
            this.bottomRightPanel.BackColor = System.Drawing.Color.White;
            this.bottomRightPanel.Controls.Add(this.lblAnswerArea);
            this.bottomRightPanel.Controls.Add(this.pnlAnswerContent);
            this.bottomRightPanel.Controls.Add(this.pnlSubmissionHistory);
            this.bottomRightPanel.Controls.Add(this.btnCommit);
            this.bottomRightPanel.Controls.Add(this.btnSubmitSingle);
            this.bottomRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomRightPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomRightPanel.Name = "bottomRightPanel";
            this.bottomRightPanel.Padding = new System.Windows.Forms.Padding(10);
            this.bottomRightPanel.Size = new System.Drawing.Size(840, 486);
            this.bottomRightPanel.TabIndex = 0;
            // 
            // lblAnswerArea
            // 
            this.lblAnswerArea.AutoSize = true;
            this.lblAnswerArea.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblAnswerArea.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAnswerArea.Location = new System.Drawing.Point(10, 10);
            this.lblAnswerArea.Name = "lblAnswerArea";
            this.lblAnswerArea.Size = new System.Drawing.Size(110, 31);
            this.lblAnswerArea.TabIndex = 0;
            this.lblAnswerArea.Text = "答题区域";
            // 
            // pnlAnswerContent
            // 
            this.pnlAnswerContent.Controls.Add(this.txtAnswer);
            this.pnlAnswerContent.Location = new System.Drawing.Point(10, 40);
            this.pnlAnswerContent.Name = "pnlAnswerContent";
            this.pnlAnswerContent.Size = new System.Drawing.Size(826, 396);
            this.pnlAnswerContent.TabIndex = 1;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtAnswer.Location = new System.Drawing.Point(0, 0);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAnswer.Size = new System.Drawing.Size(826, 396);
            this.txtAnswer.TabIndex = 0;
            // 
            // pnlSubmissionHistory
            // 
            this.pnlSubmissionHistory.Controls.Add(this.dgvSubmissionHistory);
            this.pnlSubmissionHistory.Location = new System.Drawing.Point(10, 40);
            this.pnlSubmissionHistory.Name = "pnlSubmissionHistory";
            this.pnlSubmissionHistory.Size = new System.Drawing.Size(826, 396);
            this.pnlSubmissionHistory.TabIndex = 2;
            this.pnlSubmissionHistory.Visible = false;
            // 
            // dgvSubmissionHistory
            // 
            this.dgvSubmissionHistory.AllowUserToAddRows = false;
            this.dgvSubmissionHistory.AllowUserToDeleteRows = false;
            this.dgvSubmissionHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubmissionHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubmissionHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubmissionHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubmissionHistory.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dgvSubmissionHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvSubmissionHistory.Name = "dgvSubmissionHistory";
            this.dgvSubmissionHistory.ReadOnly = true;
            this.dgvSubmissionHistory.RowHeadersWidth = 62;
            this.dgvSubmissionHistory.Size = new System.Drawing.Size(826, 396);
            this.dgvSubmissionHistory.TabIndex = 0;
            // 
            // btnCommit
            // 
            this.btnCommit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCommit.ForeColor = System.Drawing.Color.White;
            this.btnCommit.Location = new System.Drawing.Point(716, 443);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(120, 40);
            this.btnCommit.TabIndex = 3;
            this.btnCommit.Text = "提交全部";
            this.btnCommit.UseVisualStyleBackColor = false;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnSubmitSingle
            // 
            this.btnSubmitSingle.BackColor = System.Drawing.Color.Green;
            this.btnSubmitSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitSingle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSubmitSingle.ForeColor = System.Drawing.Color.White;
            this.btnSubmitSingle.Location = new System.Drawing.Point(590, 443);
            this.btnSubmitSingle.Name = "btnSubmitSingle";
            this.btnSubmitSingle.Size = new System.Drawing.Size(120, 40);
            this.btnSubmitSingle.TabIndex = 4;
            this.btnSubmitSingle.Text = "提交当前题";
            this.btnSubmitSingle.UseVisualStyleBackColor = false;
            this.btnSubmitSingle.Click += new System.EventHandler(this.btnSubmitSingle_Click);
            // 
            // FormProblems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 851);
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "FormProblems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "题目详情";
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.rightSplitContainer.Panel1.ResumeLayout(false);
            this.rightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).EndInit();
            this.rightSplitContainer.ResumeLayout(false);
            this.topRightPanel.ResumeLayout(false);
            this.topRightPanel.PerformLayout();
            this.bottomRightPanel.ResumeLayout(false);
            this.bottomRightPanel.PerformLayout();
            this.pnlAnswerContent.ResumeLayout(false);
            this.pnlAnswerContent.PerformLayout();
            this.pnlSubmissionHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubmissionHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label lblProblemList;
        private System.Windows.Forms.ListBox lstProblems;
        private System.Windows.Forms.SplitContainer rightSplitContainer;
        private System.Windows.Forms.Panel topRightPanel;
        private System.Windows.Forms.Label lblProblemDetail;
        private System.Windows.Forms.RichTextBox rtbProblemContent;
        private System.Windows.Forms.Panel bottomRightPanel;
        private System.Windows.Forms.Label lblAnswerArea;
        private System.Windows.Forms.Panel pnlAnswerContent;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Panel pnlSubmissionHistory;
        private System.Windows.Forms.DataGridView dgvSubmissionHistory;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnSubmitSingle;
    }
}