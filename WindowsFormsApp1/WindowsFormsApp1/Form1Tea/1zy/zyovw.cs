using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
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
        #region 跳转界面
        //父窗体panel控件跳转到编辑界面
        public event Action<string> GoToEditPage;

        #endregion


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                MessageBox.Show("行: " + e.RowIndex.ToString() + ", 列: " + e.ColumnIndex.ToString() + "; 被点击了");
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                GoToEditPage?.Invoke(x);

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                MessageBox.Show("成功删除:第" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "题");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
