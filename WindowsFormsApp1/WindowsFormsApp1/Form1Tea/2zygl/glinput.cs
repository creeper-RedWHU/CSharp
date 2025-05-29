using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Form1Tea._1zy;

namespace WindowsFormsApp1.Form1Tea._2zygl
{
    public partial class glinput : UserControl
    {
        public glinput()
        {
            InitializeComponent();
        }
        public event EventHandler<ArrayList> NextPage;//跳转到input的下一步

        public void UpdateData()
        {
            this.dataGridView1.AutoGenerateColumns=false;
            getID.BindToTable(this.dataGridView1, "Problem", "1", 0);
        }

        private bool findW(ArrayList arrayList, int x)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if (x ==(int)arrayList[i])
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

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             补充选择结果进行数据保存的逻辑
             */

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
            //MessageBox.Show($"选中ID数：{idList.Count}");
            //跳转
            NextPage?.Invoke(this,idList);

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var targetColumn = dataGridView1.Columns[e.ColumnIndex];
            if (targetColumn.Name == "Choose")
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
