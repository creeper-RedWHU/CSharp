using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CustomSearchBar : TextBox
    {
        private readonly Label lblwaterText = new Label();

        private readonly PictureBox clearButton = new PictureBox();

        private readonly int cancelImageSize = 12;

        private int loadingCharsCount = 0;

        public CustomSearchBar()
        {
            InitializeComponent();

            lblwaterText.BorderStyle = BorderStyle.None;
            lblwaterText.Enabled = false;
            lblwaterText.BackColor = Color.White;
            lblwaterText.AutoSize = false;
            lblwaterText.Top = 1;
            lblwaterText.Left = 2;
            lblwaterText.FlatStyle = FlatStyle.System;
            Controls.Add(lblwaterText);

            clearButton.Size = new Size(cancelImageSize, cancelImageSize);
            //clearButton.AutoSize = false;
            clearButton.SizeMode = PictureBoxSizeMode.StretchImage;
            //clearButton.Image = ResourceHandler.LoadImage("Loading");
            clearButton.Top = 1;
            clearButton.Left = this.Width - cancelImageSize - 2;
            clearButton.Click += new EventHandler(clearButton_Click);
            Controls.Add(clearButton);
        }

        public void AdjustClearButtonPosition(int width)
        {
            this.clearButton.Left = width - cancelImageSize - 2;
        }

        public string WaterText
        {
            get { return lblwaterText.Text; }
            set { lblwaterText.Text = value; }
        }

        public override string Text
        {
            set
            {
                lblwaterText.Visible = value == string.Empty;
                base.Text = value;
            }
            get
            {
                return base.Text;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Multiline && (ScrollBars == ScrollBars.Vertical || ScrollBars == ScrollBars.Both))
                lblwaterText.Width = Width - 20;
            else
                lblwaterText.Width = Width;
            lblwaterText.Height = Height - 2;
            base.OnSizeChanged(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            lblwaterText.Visible = base.Text == string.Empty;
            base.OnTextChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            lblwaterText.Visible = false;
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            lblwaterText.Visible = base.Text == string.Empty;
            base.OnMouseLeave(e);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            this.Text = string.Empty;
            ClearSearchingTextHandler();
        }

        public void StartLoadSmartTip()
        {
            loadingCharsCount++;
        }

        public void EndLoadSmartTip()
        {
            loadingCharsCount--;
        }

        public delegate void ClearSearchingText();
        public event ClearSearchingText ClearSearchingTextHandler;
    }
}
