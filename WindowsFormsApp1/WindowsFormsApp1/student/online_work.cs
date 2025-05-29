using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class online_work : UserControl
    {
        private int _courseId;
        private int _studentId;
        private Button _activeButton;

        public online_work(int courseId, int studentId)
        {
            InitializeComponent();
            _courseId = courseId;
            _studentId = studentId;

            InitializeStyles();
        }

        private void InitializeStyles()
        {
            // 设置按钮样式
            SetButtonStyle(btnDueWork, Color.Green, false);
            SetButtonStyle(btnPassedWork, Color.Gray, false);
            SetButtonStyle(btnRefresh, Color.Orange, false);

            // 默认选中正在进行的作业
            _activeButton = btnDueWork;
            SetButtonActive(btnDueWork, true);
        }

        private void SetButtonStyle(Button btn, Color baseColor, bool isActive)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("微软雅黑", 11F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            if (isActive)
            {
                btn.BackColor = baseColor;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = ControlPaint.Light(baseColor);
                btn.ForeColor = Color.White;
            }

            // 添加鼠标悬停效果
            btn.MouseEnter += (s, e) => {
                if (btn != _activeButton)
                {
                    btn.BackColor = baseColor;
                }
            };

            btn.MouseLeave += (s, e) => {
                if (btn != _activeButton)
                {
                    btn.BackColor = ControlPaint.Light(baseColor);
                }
            };
        }

        private void SetButtonActive(Button btn, bool isActive)
        {
            if (isActive)
            {
                if (_activeButton != null && _activeButton != btn)
                {
                    // 取消之前按钮的激活状态
                    Color prevColor = _activeButton == btnDueWork ? Color.Green : Color.Gray;
                    SetButtonStyle(_activeButton, prevColor, false);
                }

                _activeButton = btn;
                Color activeColor = btn == btnDueWork ? Color.Green : Color.Gray;
                SetButtonStyle(btn, activeColor, true);
            }
        }

        private void online_work_Load(object sender, EventArgs e)
        {
            // 默认显示正在进行的作业
            ShowDueWork();
        }

        private void btnDueWork_Click(object sender, EventArgs e)
        {
            SetButtonActive(btnDueWork, true);
            ShowDueWork();
        }

        private void btnPassedWork_Click(object sender, EventArgs e)
        {
            SetButtonActive(btnPassedWork, true);
            ShowPassedWork();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // 刷新当前显示的内容
            if (_activeButton == btnDueWork)
            {
                ShowDueWork();
            }
            else
            {
                ShowPassedWork();
            }

            MessageBox.Show("刷新完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowDueWork()
        {
            contentPanel.Controls.Clear();
            due_work dueControl = new due_work(_courseId, _studentId);
            dueControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(dueControl);
        }

        private void ShowPassedWork()
        {
            contentPanel.Controls.Clear();
            passed_work passedControl = new passed_work(_courseId, _studentId);
            passedControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(passedControl);
        }
    }
}