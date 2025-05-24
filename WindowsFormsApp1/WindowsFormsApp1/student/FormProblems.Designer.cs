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
            this.dgvProblems = new System.Windows.Forms.DataGridView();
            this.panelAnswers = new System.Windows.Forms.Panel();
            this.btnCommit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblems)).BeginInit();
            this.panelAnswers.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProblems
            // 
            this.dgvProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProblems.Location = new System.Drawing.Point(32, 35);
            this.dgvProblems.Name = "dgvProblems";
            this.dgvProblems.ReadOnly = true;
            this.dgvProblems.RowHeadersWidth = 62;
            this.dgvProblems.RowTemplate.Height = 30;
            this.dgvProblems.Size = new System.Drawing.Size(800, 450);
            this.dgvProblems.TabIndex = 0;
            // 
            // panelAnswers
            // 
            this.panelAnswers.Controls.Add(this.textBox1);
            this.panelAnswers.Controls.Add(this.btnCommit);
            this.panelAnswers.Location = new System.Drawing.Point(32, 492);
            this.panelAnswers.Name = "panelAnswers";
            this.panelAnswers.Size = new System.Drawing.Size(800, 100);
            this.panelAnswers.TabIndex = 1;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(657, 30);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(111, 43);
            this.btnCommit.TabIndex = 0;
            this.btnCommit.Text = "提交作业";
            this.btnCommit.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(563, 28);
            this.textBox1.TabIndex = 1;
            // 
            // FormProblems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 604);
            this.Controls.Add(this.panelAnswers);
            this.Controls.Add(this.dgvProblems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProblems";
            this.Text = "FormProblems";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblems)).EndInit();
            this.panelAnswers.ResumeLayout(false);
            this.panelAnswers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProblems;
        private System.Windows.Forms.Panel panelAnswers;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCommit;
    }
}