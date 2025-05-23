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

namespace WindowsFormsApp1.Form1Tea._2zygl
{
    public partial class glinput : UserControl
    {
        List<tmmodel> tmmodels = new List<tmmodel>();
        public glinput()
        {
            InitializeComponent();
            var jsonStr = System.IO.File.ReadAllText("tst.json");
            tmmodels = Newtonsoft.Json.JsonConvert.DeserializeObject<List<tmmodel>>(jsonStr);
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = tmmodels;
        }
        public event EventHandler NextPage;//跳转到input的下一步
        private void button1_Click(object sender, EventArgs e)
        {
            /*
             补充选择结果进行数据保存的逻辑
             */
            
            //清空

            //跳转
            NextPage?.Invoke(this, e);

        }
    }
}
