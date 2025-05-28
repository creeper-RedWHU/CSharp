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
// 移除 MaterialSkin 引用

namespace EduAdminApp.Forms
{
    public partial class MainForm : Form  // 改为普通 Form
    {
        private enum ViewMode { Student, Teacher }
        private ViewMode currentMode = ViewMode.Student;

        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        private Button _activeNavButton;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;

            dataGridViewMain.DataBindingComplete += DataGridViewMain_DataBindingComplete;

            // 初始化样式
            InitializeStyles();
        }

        private void InitializeStyles()
        {
            // 设置窗体样式
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.DodgerBlue;
            this.Padding = new Padding(2);

            // 设置窗口控制按钮样式
            SetWindowControlStyle(btnMinimize, Color.FromArgb(52, 152, 219));
            SetWindowControlStyle(btnMaximize, Color.FromArgb(52, 152, 219));
            SetWindowControlStyle(btnExit, Color.FromArgb(231, 76, 60));

            // 设置导航按钮样式
            SetNavigationButtonStyle(btnStudent, Color.FromArgb(52, 152, 219));
            SetNavigationButtonStyle(btnTeacher, Color.FromArgb(39, 174, 96));

            // 设置操作按钮样式
            SetActionButtonStyle(btnAdd, Color.FromArgb(39, 174, 96));
            SetActionButtonStyle(btnEdit, Color.FromArgb(230, 126, 34));
            SetActionButtonStyle(btnDelete, Color.FromArgb(231, 76, 60));

            // 默认激活学生管理按钮
            SetActiveNavigationButton(btnStudent);
        }

        private void SetWindowControlStyle(Button btn, Color baseColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = baseColor;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => {
                btn.BackColor = ControlPaint.Light(baseColor);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = baseColor;
            };
        }

        private void SetNavigationButtonStyle(Button btn, Color baseColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = baseColor;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => {
                if (btn != _activeNavButton)
                {
                    btn.BackColor = ControlPaint.Light(baseColor);
                }
            };
            btn.MouseLeave += (s, e) => {
                if (btn != _activeNavButton)
                {
                    btn.BackColor = baseColor;
                }
            };
        }

        private void SetActionButtonStyle(Button btn, Color baseColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = baseColor;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => {
                btn.BackColor = ControlPaint.Light(baseColor);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = baseColor;
            };
        }

        private void SetActiveNavigationButton(Button activeButton)
        {
            // 重置所有按钮为非激活状态
            if (_activeNavButton != null)
            {
                Color originalColor = GetOriginalButtonColor(_activeNavButton);
                _activeNavButton.BackColor = originalColor;
            }

            // 设置新的激活按钮
            _activeNavButton = activeButton;
            if (activeButton != null)
            {
                Color originalColor = GetOriginalButtonColor(activeButton);
                activeButton.BackColor = ControlPaint.Dark(originalColor);
            }
        }

        private Color GetOriginalButtonColor(Button btn)
        {
            if (btn == btnStudent) return Color.FromArgb(52, 152, 219);
            if (btn == btnTeacher) return Color.FromArgb(39, 174, 96);
            return Color.Gray;
        }

        // 绘制边框
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen borderPen = new Pen(Color.DodgerBlue, 2))
            {
                e.Graphics.DrawRectangle(borderPen, 1, 1, this.Width - 3, this.Height - 3);
            }
        }

        #region 窗口控制按钮事件
        private bool isMaximized = false;
        private Size normalSize;
        private Point normalLocation;

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (!isMaximized)
            {
                normalSize = this.Size;
                normalLocation = this.Location;
                Rectangle workingArea = Screen.GetWorkingArea(this);
                this.Size = new Size(workingArea.Width, workingArea.Height);
                this.Location = new Point(workingArea.X, workingArea.Y);
                ((Button)sender).Text = "⧉";
                isMaximized = true;
            }
            else
            {
                this.Size = normalSize;
                this.Location = normalLocation;
                ((Button)sender).Text = "□";
                isMaximized = false;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        // 保持所有原有的业务逻辑方法不变
        private Dictionary<Control, Rectangle> originalControls = new Dictionary<Control, Rectangle>();
        private Size originalFormSize;

        private void DataGridViewMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewMain.ClearSelection();
            dataGridViewMain.CurrentCell = null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            StoreOriginalControlSizes(this);
        }

        Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();

        private void StoreOriginalControlSizes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                originalControls[ctrl] = ctrl.Bounds;
                originalFontSizes[ctrl] = ctrl.Font.Size;

                if (ctrl.HasChildren)
                    StoreOriginalControlSizes(ctrl);
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

                ctrl.Bounds = new Rectangle(
                    (int)(orig.X * xRatio),
                    (int)(orig.Y * yRatio),
                    (int)(orig.Width * xRatio),
                    (int)(orig.Height * yRatio)
                );

                if (originalFontSizes.TryGetValue(ctrl, out float originalSize))
                {
                    float fontScale = Math.Min(xRatio, yRatio);
                    float newFontSize = Math.Max(1f, originalSize * fontScale);

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
            SetActiveNavigationButton(btnTeacher);
            currentMode = ViewMode.Teacher;
            teachers = TeacherDAL.GetAll();
            dataGridViewMain.DataSource = teachers;
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            SetActiveNavigationButton(btnStudent);
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
                    dal.Add(form.Student);
                    students = StudentDAL.GetAll();
                    RefreshStudentGrid(students);
                }
            }
            else if (currentMode == ViewMode.Teacher)
            {
                TeacherForm form = new TeacherForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TeacherDAL dal = new TeacherDAL();
                    dal.Add(form.Teacher);
                    teachers = TeacherDAL.GetAll();
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
            foreach (DataGridViewColumn column in dataGridViewMain.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.FillWeight = 100;
            }

            if (dataGridViewMain.Columns.Contains("Email"))
                dataGridViewMain.Columns["Email"].FillWeight = 250;
            if (dataGridViewMain.Columns.Contains("Phone"))
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
            dataGridViewMain.CellFormatting += dataGridViewMain_CellFormatting;
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
                    dal.Delete(selectedStudent.Id);
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
                    dal.Delete(selectedTeacher.Id);
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
                    StudentForm form = new StudentForm(selectedStudent);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        StudentDAL dal = new StudentDAL();
                        dal.Update(form.Student);
                        students = StudentDAL.GetAll();
                        RefreshStudentGrid(students);
                    }
                }
            }
            else if (currentMode == ViewMode.Teacher)
            {
                Teacher selectedTeacher = dataGridViewMain.CurrentRow.DataBoundItem as Teacher;
                if (selectedTeacher != null)
                {
                    TeacherForm form = new TeacherForm(selectedTeacher);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TeacherDAL dal = new TeacherDAL();
                        dal.Update(form.Teacher);
                        teachers = TeacherDAL.GetAll();
                        RefreshTeacherGrid(teachers);
                    }
                }
            }
        }
    }
}