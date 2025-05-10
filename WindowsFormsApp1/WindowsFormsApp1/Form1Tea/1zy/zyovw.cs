using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Form1Tea._1zy;

namespace WindowsFormsApp1.Form1Tea.zy
{
    public partial class zyovw : UserControl
    {
        List<tmmodel>tmmodels = new List<tmmodel>();
        public zyovw()
        {
            InitializeComponent();

            var jsonStr = System.IO.File.ReadAllText("tst.json");
            tmmodels=Newtonsoft.Json.JsonConvert.DeserializeObject<List<tmmodel>>(jsonStr);
            this.dataGridView1.AutoGenerateColumns=false;
            this.dataGridView1.DataSource = tmmodels;
        }

        private void customSearchBar2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
