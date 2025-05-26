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

namespace WindowsFormsApp1.Form1Tea._4test
{
    public partial class testinput : UserControl
    {
        public testinput()
        {
            InitializeComponent();
        }

        public void UpdateData()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            getID.BindToTable(this.dataGridView1, "Problem", "1", 1);
        }
        private bool findW(ArrayList arrayList, int x)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if (x == (int)arrayList[i])
                    return true;
            }
            return false;
        }
        public void load(ArrayList arrayList)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                var cellValue = row.Cells["Choose"].Value;
                int id = Convert.ToInt32(row.Cells[0].Value);
                // 复选框状态判断

                if (findW(arrayList, id)) { row.Cells["Choose"].Value = true; }
            }
        }
        public event EventHandler<ArrayList> NextPageTest;
        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * 获取题目
             */
            //清空
            ArrayList idList = new ArrayList();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                var cellValue = row.Cells["Choose"].Value;

                // 复选框状态判断
                bool isChecked = cellValue != null && (bool)cellValue;
                if (!isChecked) continue;

                // 获取ID并重置复选框 
                int id = Convert.ToInt32(row.Cells[0].Value);
                idList.Add(id);
                row.Cells["Choose"].Value = false;
            }
            //清空
            if (idList.Count == 0) { MessageBox.Show("请至少选择一道题目！"); return; }


            NextPageTest?.Invoke(this, idList);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var targetColumn = dataGridView1.Columns[e.ColumnIndex];
            if (targetColumn.Name == "Choose")
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
