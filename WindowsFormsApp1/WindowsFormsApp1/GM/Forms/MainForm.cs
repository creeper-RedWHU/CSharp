﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading.Tasks; // 顶部添加
using EduAdminApp.DAL;
using EduAdminApp.Models;
using EduAdminApp.Forms;
using System.Data.SqlClient; // 顶部添加
using System.Data.SQLite; // 顶部添加

// 移除 MaterialSkin 引用

namespace EduAdminApp.Forms
{
    public partial class MainForm : Form  // 改为普通 Form
    {
        private enum ViewMode { Student, Teacher, Audit } // 新增 Audit
        private ViewMode currentMode = ViewMode.Student;

        // 敏感词列表
        private readonly List<string> sensitiveWords = new List<string>
{
    // 政治相关（涉政）
    "中国", "台湾", "西藏", "香港独立", "法轮功", "六四", "共产党", "民主运动",

    // 涉黄低俗
    "黄片", "裸照", "A片", "约炮", "开房", "床上运动", "啪啪啪", "AV", "鸡",

    // 暴力恐怖
    "炸弹", "恐袭", "杀人", "枪击", "血腥", "自杀", "爆炸", "人体炸弹",

    // 侮辱谩骂
    "傻逼", "滚", "去死", "妈的", "狗东西", "死全家", "畜生", "王八蛋", "SB",

    // 宗教敏感
    "真主", "圣战", "异教徒", "伊斯兰国", "ISIS", "穆罕默德漫画",

    // 国家相关（涉外/民族）
    "美国", "日本鬼子", "韩国棒子", "越共", "白皮猪",

    // 违禁品相关
    "毒品", "冰毒", "大麻", "鸦片", "走私", "贩毒", "枪支", "军火","吸毒",

    // 网络敏感行为
    "翻墙", "VPN", "代理服务器", "境外势力", "推特", "telegram",

    // 其他禁忌内容
    "邪教", "迷信", "跳大神", "轮回转世", "邪术"
};

        // 审核数据结构
        private class AuditItem
        {
            public int Id { get; set; }
            public string 类型 { get; set; }
            public string 内容 { get; set; }
            public string 来源表 { get; set; }
        }

        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        private Button _activeNavButton;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;
            dataGridViewMain.DataBindingComplete += DataGridViewMain_DataBindingComplete;
            dataGridViewMain.CellFormatting += dataGridViewMain_CellFormatting;
            dataGridViewMain.CellContentClick += dataGridViewMain_CellContentClick; // 新增
            btnAudit.Click += btnAudit_Click; // 新增
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
            if (btn == btnAudit) return Color.FromArgb(155, 89, 182); // 新增
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

        private void btnAudit_Click(object sender, EventArgs e)
        {
            SetActiveNavigationButton(btnAudit);
            currentMode = ViewMode.Audit;

            // 先设置标题
            uiLabel1.Text = "📝 内容审核管理";
            uiLabel1.Refresh(); // 强制刷新

            // 隐藏下方操作按钮
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnExportExcel.Visible = false;

            // 再加载数据
            LoadAuditData();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            SetActiveNavigationButton(btnStudent);
            currentMode = ViewMode.Student;
            uiLabel1.Text = "👨‍🎓 学生信息管理";

            // 显示下方操作按钮
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnExportExcel.Visible = true;

            try
            {
                students = StudentDAL.GetAll();
                dataGridViewMain.DataSource = null;
                dataGridViewMain.Columns.Clear();
                dataGridViewMain.DataSource = students;
                AdjustGridViewLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取学生数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            SetActiveNavigationButton(btnTeacher);
            currentMode = ViewMode.Teacher;
            uiLabel1.Text = "👩‍🏫 教师信息管理";

            // 显示下方操作按钮
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnExportExcel.Visible = true;

            Task.Run(() =>
            {
                try
                {
                    var teachersResult = TeacherDAL.GetAll();
                    Regex phoneRegex = new Regex(@"^\d{11}$");
                    Regex emailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
                    Regex nameRegex = new Regex(@"^[\u4e00-\u9fa5A-Za-z]{2,20}$");
                    var filteredTeachers = teachersResult
                        .Where(t =>
                            !string.IsNullOrEmpty(t.Phone) && phoneRegex.IsMatch(t.Phone) &&
                            !string.IsNullOrEmpty(t.Email) && emailRegex.IsMatch(t.Email) &&
                            !string.IsNullOrEmpty(t.Name) && nameRegex.IsMatch(t.Name)
                        )
                        .OrderBy(t => t.Id)
                        .ToList();
                    this.Invoke((MethodInvoker)delegate
                    {
                        teachers = teachersResult;
                        dataGridViewMain.DataSource = null;
                        dataGridViewMain.Columns.Clear();
                        dataGridViewMain.DataSource = filteredTeachers;
                        AdjustGridViewLayout();
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("获取教师数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            });
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
                    try
                    {
                        students = StudentDAL.GetAll();
                        RefreshStudentGrid(students);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("获取学生数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (currentMode == ViewMode.Teacher)
            {
                TeacherForm form = new TeacherForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TeacherDAL dal = new TeacherDAL();
                    dal.Add(form.Teacher);
                    try
                    {
                        teachers = TeacherDAL.GetAll();
                        RefreshTeacherGrid(teachers);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("获取教师数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadAuditData()
        {
            string connStr = "Data Source=StudentSystem.db";
            var auditList = new List<AuditItem>();
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT QID, Content FROM Question", conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        auditList.Add(new AuditItem
                        {
                            Id = reader.GetInt32(0),
                            类型 = "问题",
                            内容 = reader.GetString(1),
                            来源表 = "Question"
                        });
                    }
                }
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT AID, Content FROM Answer", conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        auditList.Add(new AuditItem
                        {
                            Id = reader.GetInt32(0),
                            类型 = "回答",
                            内容 = reader.GetString(1),
                            来源表 = "Answer"
                        });
                    }
                }
            }
            dataGridViewMain.DataSource = null;
            dataGridViewMain.Columns.Clear();
            dataGridViewMain.DataSource = auditList;

            // 只在审核界面添加“操作”按钮列
            if (!dataGridViewMain.Columns.Contains("操作"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "操作";
                btnCol.HeaderText = "操作";
                btnCol.Text = "删除";
                btnCol.UseColumnTextForButtonValue = true;
                btnCol.Width = 80;
                dataGridViewMain.Columns.Add(btnCol);
            }
            AdjustGridViewLayout();
        }

        // 审核内容敏感词标红
        private void dataGridViewMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (currentMode == ViewMode.Audit && dataGridViewMain.Columns[e.ColumnIndex].Name == "内容" && e.Value != null)
            {
                string content = e.Value.ToString();
                foreach (var word in sensitiveWords)
                {
                    if (content.Contains(word))
                    {
                        dataGridViewMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                        dataGridViewMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = new Font(dataGridViewMain.Font, FontStyle.Bold);
                        break;
                    }
                    else
                    {
                        dataGridViewMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                        dataGridViewMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = dataGridViewMain.Font;
                    }
                }
            }
            else if (e.Value != null)
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
            dataGridViewMain.CellContentClick += dataGridViewMain_CellContentClick; // 新增
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
                    try
                    {
                        students = StudentDAL.GetAll();
                        RefreshStudentGrid(students);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("获取学生数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (currentMode == ViewMode.Teacher)
            {
                Teacher selectedTeacher = dataGridViewMain.CurrentRow.DataBoundItem as Teacher;
                if (selectedTeacher != null)
                {
                    TeacherDAL dal = new TeacherDAL();
                    dal.Delete(selectedTeacher.Id);
                    try
                    {
                        teachers = TeacherDAL.GetAll();
                        RefreshTeacherGrid(teachers);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("获取教师数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                        try
                        {
                            students = StudentDAL.GetAll();
                            RefreshStudentGrid(students);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("获取学生数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
                        try
                        {
                            teachers = TeacherDAL.GetAll();
                            RefreshTeacherGrid(teachers);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("获取教师数据失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.Rows.Count == 0)
            {
                MessageBox.Show("没有可导出的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel文件 (*.csv)|*.csv";
                sfd.FileName = "导出数据.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();

                        // 导出列标题
                        for (int i = 0; i < dataGridViewMain.Columns.Count; i++)
                        {
                            sb.Append(dataGridViewMain.Columns[i].HeaderText);
                            if (i < dataGridViewMain.Columns.Count - 1)
                                sb.Append(",");
                        }
                        sb.AppendLine();

                        // 导出每行数据
                        foreach (DataGridViewRow row in dataGridViewMain.Rows)
                        {
                            if (row.IsNewRow) continue;
                            for (int i = 0; i < dataGridViewMain.Columns.Count; i++)
                            {
                                var value = row.Cells[i].Value?.ToString().Replace(",", "，") ?? "";
                                sb.Append(value);
                                if (i < dataGridViewMain.Columns.Count - 1)
                                    sb.Append(",");
                            }
                            sb.AppendLine();
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 审核删除按钮事件
        private void dataGridViewMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentMode == ViewMode.Audit && dataGridViewMain.Columns[e.ColumnIndex].Name == "操作" && e.RowIndex >= 0)
            {
                var item = dataGridViewMain.Rows[e.RowIndex].DataBoundItem as AuditItem;
                if (item == null) return;

                if (MessageBox.Show("确定要删除该内容吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string connStr = "Data Source=StudentSystem.db";
                    string sql = "";
                    string idField = "";
                    if (item.来源表 == "Question")
                    {
                        sql = "DELETE FROM Question WHERE QID=@id";
                        idField = "QID";
                    }
                    else if (item.来源表 == "Answer")
                    {
                        sql = "DELETE FROM Answer WHERE AID=@id";
                        idField = "AID";
                    }
                    if (!string.IsNullOrEmpty(sql))
                    {
                        using (SQLiteConnection conn = new SQLiteConnection(connStr))
                        {
                            conn.Open();
                            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", item.Id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        LoadAuditData();
                    }
                }
            }
        }
    }
}