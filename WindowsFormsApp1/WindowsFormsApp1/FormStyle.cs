using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    ///通用更改窗口样式
    /// </summary>
    public class FormStyle
    {
        private readonly Form _targetForm;//目标窗体

        public FormStyle(Form form)
        {
            _targetForm = form;
            ShadowForm();
        }

        /// <summary>
        /// 设置边框与阴影
        /// </summary>
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        public void ShadowForm()
        {
            _targetForm.Padding = new Padding(10); // 阴影区域大小

            //启用现代窗口阴影（Win10+）
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int attrValue = 2; //DWMWCP_ROUND
                DwmSetWindowAttribute(_targetForm.Handle, 33 /*DWMWA_WINDOW_CORNER_PREFERENCE*/, ref attrValue, sizeof(int));

                var margins = new MARGINS()
                {
                    leftWidth = 1,
                    rightWidth = 1,
                    topHeight = 1,
                    bottomHeight = 1
                };
                DwmExtendFrameIntoClientArea(_targetForm.Handle, ref margins);
            }
        }

        
    }
}
