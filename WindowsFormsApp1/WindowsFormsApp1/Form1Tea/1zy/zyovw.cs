using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using WindowsFormsApp1.Form1Tea._1zy;

namespace WindowsFormsApp1.Form1Tea.zy
{
    public partial class zyovw : UserControl
    {
        public zyovw()
        {
            InitializeComponent();
            

        }

        public void UpdateData()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            getID.BindToTable(this.dataGridView1, "Problem");
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
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                MessageBox.Show("您将要编辑第" + x + "题");
                GoToEditPage?.Invoke(x);

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                MessageBox.Show("成功删除:第" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "题");
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
