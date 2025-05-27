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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProblems = new System.Windows.Forms.DataGridView();
            this.panelAnswers = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCommit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblems)).BeginInit();
            this.panelAnswers.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProblems
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvProblems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProblems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProblems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProblems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProblems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProblems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProblems.EnableHeadersVisualStyles = false;
            this.dgvProblems.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dgvProblems.Location = new System.Drawing.Point(32, 50);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(563, 35);
            this.textBox1.TabIndex = 1;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(657, 30);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(125, 43);
            this.btnCommit.TabIndex = 0;
            this.btnCommit.Text = "提交作业";
            this.btnCommit.UseVisualStyleBackColor = true;
            // 
            // FormProblems
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 604);
            this.Controls.Add(this.panelAnswers);
            this.Controls.Add(this.dgvProblems);
            this.Name = "FormProblems";
            //this.RectColor = System.Drawing.Color.Transparent;
            this.Text = "FormProblems";
            //this.TitleColor = System.Drawing.Color.White;
            //this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 884, 604);
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