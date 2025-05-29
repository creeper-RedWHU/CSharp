using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Question
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
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.lblQuestionList = new System.Windows.Forms.Label();
            this.btnAsk = new System.Windows.Forms.Button();
            this.lstQuestions = new System.Windows.Forms.ListBox();
            this.rightSplitContainer = new System.Windows.Forms.SplitContainer();
            this.topRightPanel = new System.Windows.Forms.Panel();
            this.lblQuestionDetail = new System.Windows.Forms.Label();
            this.rtbQuestionContent = new System.Windows.Forms.RichTextBox();
            this.bottomRightPanel = new System.Windows.Forms.Panel();
            this.lblAnswers = new System.Windows.Forms.Label();
            this.pnlAnswerButtons = new System.Windows.Forms.Panel();
            this.btnReply = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlAnswersList = new System.Windows.Forms.Panel();
            this.flpAnswers = new System.Windows.Forms.FlowLayoutPanel();
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
            this.pnlAnswerButtons.SuspendLayout();
            this.pnlAnswersList.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.leftPanel);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.rightSplitContainer);
            this.mainSplitContainer.Size = new System.Drawing.Size(1200, 800);
            this.mainSplitContainer.SplitterDistance = 350;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.White;
            this.leftPanel.Controls.Add(this.lblQuestionList);
            this.leftPanel.Controls.Add(this.btnAsk);
            this.leftPanel.Controls.Add(this.lstQuestions);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Padding = new System.Windows.Forms.Padding(15);
            this.leftPanel.Size = new System.Drawing.Size(350, 800);
            this.leftPanel.TabIndex = 0;
            // 
            // lblQuestionList
            // 
            this.lblQuestionList.AutoSize = true;
            this.lblQuestionList.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuestionList.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblQuestionList.Location = new System.Drawing.Point(15, 15);
            this.lblQuestionList.Name = "lblQuestionList";
            this.lblQuestionList.Size = new System.Drawing.Size(107, 26);
            this.lblQuestionList.TabIndex = 0;
            this.lblQuestionList.Text = "问题讨论区";
            // 
            // btnAsk
            // 
            this.btnAsk.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAsk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsk.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnAsk.ForeColor = System.Drawing.Color.White;
            this.btnAsk.Location = new System.Drawing.Point(15, 50);
            this.btnAsk.Name = "btnAsk";
            this.btnAsk.Size = new System.Drawing.Size(320, 45);
            this.btnAsk.TabIndex = 1;
            this.btnAsk.Text = "💬 我要提问";
            this.btnAsk.UseVisualStyleBackColor = false;
            this.btnAsk.Click += new System.EventHandler(this.btnAsk_Click);
            // 
            // lstQuestions
            // 
            this.lstQuestions.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lstQuestions.ItemHeight = 18;
            this.lstQuestions.Location = new System.Drawing.Point(15, 105);
            this.lstQuestions.Name = "lstQuestions";
            this.lstQuestions.Size = new System.Drawing.Size(320, 680);
            this.lstQuestions.TabIndex = 2;
            this.lstQuestions.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstQuestions_DrawItem);
            this.lstQuestions.SelectedIndexChanged += new System.EventHandler(this.lstQuestions_SelectedIndexChanged);
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
            this.rightSplitContainer.Size = new System.Drawing.Size(846, 800);
            this.rightSplitContainer.SplitterDistance = 300;
            this.rightSplitContainer.TabIndex = 0;
            // 
            // topRightPanel
            // 
            this.topRightPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.topRightPanel.Controls.Add(this.lblQuestionDetail);
            this.topRightPanel.Controls.Add(this.rtbQuestionContent);
            this.topRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topRightPanel.Location = new System.Drawing.Point(0, 0);
            this.topRightPanel.Name = "topRightPanel";
            this.topRightPanel.Padding = new System.Windows.Forms.Padding(15);
            this.topRightPanel.Size = new System.Drawing.Size(846, 300);
            this.topRightPanel.TabIndex = 0;
            // 
            // lblQuestionDetail
            // 
            this.lblQuestionDetail.AutoSize = true;
            this.lblQuestionDetail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuestionDetail.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblQuestionDetail.Location = new System.Drawing.Point(15, 15);
            this.lblQuestionDetail.Name = "lblQuestionDetail";
            this.lblQuestionDetail.Size = new System.Drawing.Size(90, 22);
            this.lblQuestionDetail.TabIndex = 0;
            this.lblQuestionDetail.Text = "问题详情📖";
            // 
            // rtbQuestionContent
            // 
            this.rtbQuestionContent.BackColor = System.Drawing.Color.White;
            this.rtbQuestionContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbQuestionContent.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.rtbQuestionContent.Location = new System.Drawing.Point(15, 45);
            this.rtbQuestionContent.Name = "rtbQuestionContent";
            this.rtbQuestionContent.ReadOnly = true;
            this.rtbQuestionContent.Size = new System.Drawing.Size(816, 240);
            this.rtbQuestionContent.TabIndex = 1;
            this.rtbQuestionContent.Text = "请选择左侧问题列表中的问题查看详情...";
            // 
            // bottomRightPanel
            // 
            this.bottomRightPanel.BackColor = System.Drawing.Color.White;
            this.bottomRightPanel.Controls.Add(this.lblAnswers);
            this.bottomRightPanel.Controls.Add(this.pnlAnswerButtons);
            this.bottomRightPanel.Controls.Add(this.pnlAnswersList);
            this.bottomRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomRightPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomRightPanel.Name = "bottomRightPanel";
            this.bottomRightPanel.Padding = new System.Windows.Forms.Padding(15);
            this.bottomRightPanel.Size = new System.Drawing.Size(846, 496);
            this.bottomRightPanel.TabIndex = 0;
            // 
            // lblAnswers
            // 
            this.lblAnswers.AutoSize = true;
            this.lblAnswers.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblAnswers.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAnswers.Location = new System.Drawing.Point(15, 15);
            this.lblAnswers.Name = "lblAnswers";
            this.lblAnswers.Size = new System.Drawing.Size(90, 22);
            this.lblAnswers.TabIndex = 0;
            this.lblAnswers.Text = "讨论回复💬";
            // 
            // pnlAnswerButtons
            // 
            this.pnlAnswerButtons.Controls.Add(this.btnReply);
            this.pnlAnswerButtons.Controls.Add(this.btnRefresh);
            this.pnlAnswerButtons.Location = new System.Drawing.Point(15, 45);
            this.pnlAnswerButtons.Name = "pnlAnswerButtons";
            this.pnlAnswerButtons.Size = new System.Drawing.Size(816, 50);
            this.pnlAnswerButtons.TabIndex = 1;
            // 
            // btnReply
            // 
            this.btnReply.BackColor = System.Drawing.Color.Green;
            this.btnReply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReply.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnReply.ForeColor = System.Drawing.Color.White;
            this.btnReply.Location = new System.Drawing.Point(0, 5);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(120, 40);
            this.btnReply.TabIndex = 0;
            this.btnReply.Text = "💬 回复问题";
            this.btnReply.UseVisualStyleBackColor = false;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Orange;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(130, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 刷新";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlAnswersList
            // 
            this.pnlAnswersList.AutoScroll = true;
            this.pnlAnswersList.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlAnswersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAnswersList.Controls.Add(this.flpAnswers);
            this.pnlAnswersList.Location = new System.Drawing.Point(15, 105);
            this.pnlAnswersList.Name = "pnlAnswersList";
            this.pnlAnswersList.Size = new System.Drawing.Size(816, 376);
            this.pnlAnswersList.TabIndex = 2;
            // 
            // flpAnswers
            // 
            this.flpAnswers.AutoScroll = true;
            this.flpAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAnswers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAnswers.Location = new System.Drawing.Point(0, 0);
            this.flpAnswers.Name = "flpAnswers";
            this.flpAnswers.Padding = new System.Windows.Forms.Padding(10);
            this.flpAnswers.Size = new System.Drawing.Size(814, 374);
            this.flpAnswers.TabIndex = 0;
            this.flpAnswers.WrapContents = false;
            // 
            // Question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "Question";
            this.Size = new System.Drawing.Size(1200, 800);
            this.Load += new System.EventHandler(this.Question_Load);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).EndInit();
            this.rightSplitContainer.Panel1.ResumeLayout(false);
            this.rightSplitContainer.Panel2.ResumeLayout(false);
            this.rightSplitContainer.ResumeLayout(false);
            this.topRightPanel.ResumeLayout(false);
            this.topRightPanel.PerformLayout();
            this.bottomRightPanel.ResumeLayout(false);
            this.bottomRightPanel.PerformLayout();
            this.pnlAnswerButtons.ResumeLayout(false);
            this.pnlAnswersList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label lblQuestionList;
        private System.Windows.Forms.Button btnAsk;
        private System.Windows.Forms.ListBox lstQuestions;
        private System.Windows.Forms.SplitContainer rightSplitContainer;
        private System.Windows.Forms.Panel topRightPanel;
        private System.Windows.Forms.Label lblQuestionDetail;
        private System.Windows.Forms.RichTextBox rtbQuestionContent;
        private System.Windows.Forms.Panel bottomRightPanel;
        private System.Windows.Forms.Label lblAnswers;
        private System.Windows.Forms.Panel pnlAnswerButtons;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlAnswersList;
        private System.Windows.Forms.FlowLayoutPanel flpAnswers;
    }
}