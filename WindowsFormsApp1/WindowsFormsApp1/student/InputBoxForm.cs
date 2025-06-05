using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
namespace WindowsFormsApp1.student
{
    public partial class InputBoxForm : Form
    {
        public string InputText => textBox1.Text;

        public InputBoxForm(string title, string prompt)
        {
            InitializeComponent();
            this.Text = title;
            label1.Text = prompt;

            // 美化窗口圆角
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackColor = Color.WhiteSmoke;

            // 设置焦点
            this.Load += (s, e) => textBox1.Focus();

            // 按下Enter等同提交
            textBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnOK.PerformClick();
                    e.SuppressKeyPress = true;
                }
            };
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}