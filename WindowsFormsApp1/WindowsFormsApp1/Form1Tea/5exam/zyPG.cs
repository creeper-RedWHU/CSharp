using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Form1Tea._5exam
{
    public partial class zyPG : UserControl
    {
        public zyPG()
        {
            InitializeComponent();
        }

        public void UpdateData(int x = 0)
        {
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            ArrayList list = getID.getList();
            if (list.Count != 0)
            {
                getID.HMKBindToTable(dataGridView1, "HMK", "1", x, list);
            }
        }

        public event Action<int> GoToPGNext;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                MessageBox.Show("您将要批阅第" + x + "份作业");
                GoToPGNext?.Invoke(int.Parse(x));

            }
        }
    }
}
