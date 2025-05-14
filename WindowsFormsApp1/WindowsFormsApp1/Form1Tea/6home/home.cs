using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Form1Tea
{
    public partial class home : UserControl
    {
        public home()
        {
            InitializeComponent();
        }
        public home(string TeaName)
        {
            InitializeComponent();
            label2.Text = TeaName + "老师，您好！";
        }
    }
}
