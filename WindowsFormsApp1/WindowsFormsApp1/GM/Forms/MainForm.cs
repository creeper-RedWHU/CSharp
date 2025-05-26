using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EduAdminApp.DAL;
using EduAdminApp.Models;
using EduAdminApp.Forms;

namespace EduAdminApp.Forms
{
    public partial class MainForm : Form
    {
        private enum ViewMode { Student, Teacher }
        private ViewMode currentMode = ViewMode.Student;

        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;

            dataGridViewMain.DataBindingComplete += DataGridViewMain_DataBindingComplete;
        }

        private Dictionary<Control, Rectangle> originalControls = new Dictionary<Control, Rectangle>();
        private Size originalFormSize;

        private void DataGridViewMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewMain.ClearSelection();          // 取消所有选中行
            dataGridViewMain.CurrentCell = null;        // 避免第一行高亮
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            StoreOriginalControlSizes(this);

            //EduAdminApp.Utils.DatabaseInitializer.Initialize();
        }

        private void AddChildControls(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                originalControls[child] = child.Bounds;
                AddChildControls(child);
            }
        }

        // 初始化时：记录每个控件原始字体大小
        Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        private void StoreOriginalControlSizes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                originalControls[ctrl] = ctrl.Bounds;
                originalFontSizes[ctrl] = ctrl.Font.Size;

                if (ctrl.HasChildren)
                    StoreOriginalControlSizes(ctrl); // 递归
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            foreach (var item in originalControls)
            {
                Control ctrl = item.Key;
                Rectangle orig = item.Value;

                // 设置控件位置和大小
                ctrl.Bounds = new Rectangle(
                    (int)(orig.X * xRatio),
                    (int)(orig.Y * yRatio),
                    (int)(orig.Width * xRatio),
                    (int)(orig.Height * yRatio)
                );

                // 恢复原始字体大小后进行缩放
                if (originalFontSizes.TryGetValue(ctrl, out float originalSize))
                {
                    float fontScale = Math.Min(xRatio, yRatio);
                    float newFontSize = Math.Max(1f, originalSize * fontScale);

                    // 特别处理 DataGridView，避免字体过大
                    if (ctrl is DataGridView dgv)
                    {
                        dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font.FontFamily, newFontSize, dgv.Font.Style);
                        dgv.DefaultCellStyle.Font = new Font(dgv.Font.FontFamily, newFontSize, dgv.Font.Style);
                    }
                    else
                    {
                        ctrl.Font = new Font(ctrl.Font.FontFamily, newFontSize, ctrl.Font.Style);
                    }
                }
            }
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            currentMode = ViewMode.Teacher;
            teachers = TeacherDAL.GetAll();
            dataGridViewMain.DataSource = teachers;
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            currentMode = ViewMode.Student;
            students = StudentDAL.GetAll();
            dataGridViewMain.DataSource = students;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentMode == ViewMode.Student)
            {
                StudentForm form = new StudentForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    StudentDAL dal = new StudentDAL();
                    dal.Add(form.Student); // 保存到数据库
                    students = StudentDAL.GetAll();  // 重新加载数据
                    RefreshStudentGrid(students);
                }
            }
            else if (currentMode == ViewMode.Teacher)
            {
                TeacherForm form = new TeacherForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TeacherDAL dal = new TeacherDAL();
                    dal.Add(form.Teacher); // 保存到数据库
                    teachers = TeacherDAL.GetAll();  // 重新加载数据
                    RefreshTeacherGrid(teachers);
                }
            }
        }

        private void dataGridViewMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                dataGridViewMain.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = e.Value.ToString();
            }
        }

        private void AdjustGridViewLayout()
        {
            // 让每一列都填满 DataGridView 宽度
            foreach (DataGridViewColumn column in dataGridViewMain.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.FillWeight = 100; // 默认权重
            }

            
            dataGridViewMain.Columns["Email"].FillWeight = 250;
            dataGridViewMain.Columns["Phone"].FillWeight = 250;

        }

        private void RefreshStudentGrid(List<Student> students)
        {
            dataGridViewMain.DataSource = null;
            dataGridViewMain.DataSource = students;

            AdjustGridViewLayout();
        }

        private void RefreshTeacherGrid(List<Teacher> teachers)
        {
            dataGridViewMain.DataSource = null;
            dataGridViewMain.DataSource = teachers;

            AdjustGridViewLayout();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           // EduAdminApp.Utils.DatabaseInitializer.Initialize();
            dataGridViewMain.CellFormatting += dataGridViewMain_CellFormatting;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Point mPoint;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                button2.Text = "🗗";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                button2.Text = "🗖";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.CurrentRow == null)
            {
                MessageBox.Show("请先选择要删除的记录！");
                return;
            }

            DialogResult result = MessageBox.Show("确定要删除选中的记录吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            if (currentMode == ViewMode.Student)
            {
                Student selectedStudent = dataGridViewMain.CurrentRow.DataBoundItem as Student;
                if (selectedStudent != null)
                {
                    StudentDAL dal = new StudentDAL();
                    dal.Delete(selectedStudent.Id); // 你需要确保 Student 有 Id 属性，并且 Delete 方法支持 Id 删除
                    students = StudentDAL.GetAll();
                    RefreshStudentGrid(students);
                }
            }
            else if (currentMode == ViewMode.Teacher)
            {
                Teacher selectedTeacher = dataGridViewMain.CurrentRow.DataBoundItem as Teacher;
                if (selectedTeacher != null)
                {
                    TeacherDAL dal = new TeacherDAL();
                    dal.Delete(selectedTeacher.Id); // 同样需要 Teacher 有 Id，Delete 支持 Id 删除
                    teachers = TeacherDAL.GetAll();
                    RefreshTeacherGrid(teachers);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.CurrentRow == null)
            {
                MessageBox.Show("请先选择要编辑的记录！");
                return;
            }

            if (currentMode == ViewMode.Student)
            {
                Student selectedStudent = dataGridViewMain.CurrentRow.DataBoundItem as Student;
                if (selectedStudent != null)
                {
                    StudentForm form = new StudentForm(selectedStudent); // 使用带参数构造函数加载数据
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        StudentDAL dal = new StudentDAL();
                        dal.Update(form.Student); // 你需要有 Update 方法
                        students = StudentDAL.GetAll(); // 重新加载数据
                        RefreshStudentGrid(students);
                    }
                }
            }
            else if (currentMode == ViewMode.Teacher)
            {
                Teacher selectedTeacher = dataGridViewMain.CurrentRow.DataBoundItem as Teacher;
                if (selectedTeacher != null)
                {
                    TeacherForm form = new TeacherForm(selectedTeacher); // 使用带参数构造函数加载数据
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TeacherDAL dal = new TeacherDAL();
                        dal.Update(form.Teacher); // 你需要有 Update 方法
                        teachers = TeacherDAL.GetAll(); // 重新加载数据
                        RefreshTeacherGrid(teachers);
                    }
                }
            }
        }



       
    }
}