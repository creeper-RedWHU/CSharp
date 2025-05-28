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
    public partial class home_s : UserControl
    {
        public string teacherName;
        public int teacherId;
        public home_s()
        {
            InitializeComponent();
        }

        

        public void UpdataData(string TeaName)
        {
            teacherName = TeaName;
            label1.Text = teacherName + "老师，您好！";
            dataGridView1.AutoGenerateColumns=false;
            getID.CourseToTeacherBindToTable(dataGridView1, "Course", teacherId);
        }

        public event EventHandler GoToCreate;

        private void button1_Click(object sender, EventArgs e)
        {
            GoToCreate?.Invoke(this,EventArgs.Empty);
        }

        public event EventHandler GoToShow;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Choice")
            {
                string x = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Params.CourseID = int.Parse(x);
                Params.GetStudentIDsByCourse();
                GoToShow?.Invoke(this,EventArgs.Empty);
            }
        }
    }
}
