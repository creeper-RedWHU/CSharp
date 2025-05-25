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
            this.listBoxQuestions = new System.Windows.Forms.ListBox();
            this.labelQuestionContent = new System.Windows.Forms.Label();
            this.listBoxAnswers = new System.Windows.Forms.ListBox();
            this.textBoxReply = new System.Windows.Forms.TextBox();
            this.btnReply = new System.Windows.Forms.Button();
            this.btnAsk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxQuestions
            // 
            this.listBoxQuestions.FormattingEnabled = true;
            this.listBoxQuestions.ItemHeight = 18;
            this.listBoxQuestions.Location = new System.Drawing.Point(38, 143);
            this.listBoxQuestions.Name = "listBoxQuestions";
            this.listBoxQuestions.Size = new System.Drawing.Size(352, 472);
            this.listBoxQuestions.TabIndex = 0;
            this.listBoxQuestions.SelectedIndexChanged += new System.EventHandler(this.listBoxQuestions_SelectedIndexChanged);
            // 
            // labelQuestionContent
            // 
            this.labelQuestionContent.AutoSize = true;
            this.labelQuestionContent.Location = new System.Drawing.Point(434, 53);
            this.labelQuestionContent.Name = "labelQuestionContent";
            this.labelQuestionContent.Size = new System.Drawing.Size(62, 18);
            this.labelQuestionContent.TabIndex = 1;
            this.labelQuestionContent.Text = "label1";
            // 
            // listBoxAnswers
            // 
            this.listBoxAnswers.FormattingEnabled = true;
            this.listBoxAnswers.ItemHeight = 18;
            this.listBoxAnswers.Location = new System.Drawing.Point(437, 142);
            this.listBoxAnswers.Name = "listBoxAnswers";
            this.listBoxAnswers.Size = new System.Drawing.Size(408, 472);
            this.listBoxAnswers.TabIndex = 2;
            // 
            // textBoxReply
            // 
            this.textBoxReply.Location = new System.Drawing.Point(76, 681);
            this.textBoxReply.Name = "textBoxReply";
            this.textBoxReply.Size = new System.Drawing.Size(606, 28);
            this.textBoxReply.TabIndex = 3;
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(746, 681);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(99, 30);
            this.btnReply.TabIndex = 4;
            this.btnReply.Text = "回复";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // btnAsk
            // 
            this.btnAsk.Location = new System.Drawing.Point(38, 53);
            this.btnAsk.Name = "btnAsk";
            this.btnAsk.Size = new System.Drawing.Size(103, 40);
            this.btnAsk.TabIndex = 5;
            this.btnAsk.Text = "我要提问";
            this.btnAsk.UseVisualStyleBackColor = true;
            this.btnAsk.Click += new System.EventHandler(this.btnAsk_Click);
            // 
            // Question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAsk);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.textBoxReply);
            this.Controls.Add(this.listBoxAnswers);
            this.Controls.Add(this.labelQuestionContent);
            this.Controls.Add(this.listBoxQuestions);
            this.Name = "Question";
            this.Size = new System.Drawing.Size(922, 766);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxQuestions;
        private System.Windows.Forms.Label labelQuestionContent;
        private System.Windows.Forms.ListBox listBoxAnswers;
        private System.Windows.Forms.TextBox textBoxReply;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Button btnAsk;
    }
}
