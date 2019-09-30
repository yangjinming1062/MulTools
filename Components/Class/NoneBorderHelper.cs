using MulTools.Components.Function;
using System.Drawing;
using System.Windows.Forms;

namespace MulTools.Components.Class
{
    /// <summary>
    /// 由于一次只有一个具体功能使用，所以就不需要实例化了，
    /// </summary>
    public static class NoneBorderHelper
    {
        /// <summary>
        /// 利用无边框窗体的panel实现操作
        /// </summary>
        /// <param name="f">无边框窗体</param>
        /// <param name="p">窗体的panel，最佳选择是Dock.Top或者Fill的</param>
        /// <param name="FeelBorderSize">调整大小感知区宽度</param>
        public static void Set(Form f, Panel p, int FeelBorderSize = 5)
        {
            frm = f;
            panel = p;
            feelSize = FeelBorderSize;
            panel.MouseDown += new MouseEventHandler(Panel_MouseDown);
            panel.MouseMove += new MouseEventHandler(Panel_MouseMove);
            panel.MouseUp += new MouseEventHandler(Panel_MouseUp);
        }
        private static Form frm;
        private static Panel panel;

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_RESTORE = 0xF120;
        private const int SC_SIZE = 0xF000;
        //改变窗体大小，SC_SIZE+下面的值
        private const int LEFT = 0x0001;//光标在窗体左边缘
        private const int RIGHT = 0x0002;//右边缘
        private const int UP = 0x0003;//上边缘
        private const int LEFTUP = 0x0004;//左上角
        private const int RIGHTUP = 0x0005;//右上角
        private const int BOTTOM = 0x0006;//下边缘
        private const int LEFTBOTTOM = 0x0007;//左下角
        private const int RIGHTBOTTOM = 0x0008;//右下角

        private static bool InClick = false;
        private static Point mouseOff;//鼠标移动位置变量
        private static int feelSize = 5;

        private static void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                if (frm.WindowState == FormWindowState.Maximized)
                    frm.WindowState = FormWindowState.Normal;
                else
                    frm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    int direction;
                    if (e.Location.X < feelSize && e.Location.Y < feelSize)
                        direction = LEFTUP;
                    else if (e.Location.X > panel.Width - feelSize && e.Location.Y < feelSize)
                        direction = RIGHTUP;
                    else if (e.Location.X < feelSize && e.Location.Y >= feelSize)
                        direction = LEFT;
                    else if (e.Location.X > panel.Width - feelSize && e.Location.Y >= feelSize)
                        direction = RIGHT;
                    else if (e.Location.Y < feelSize)
                        direction = UP;
                    else
                    {
                        mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                        InClick = true; //点击左键按下时标注为true
                        return;
                    }
                    Win32.ReleaseCapture();
                    Win32.SendMessage(frm.Handle, WM_SYSCOMMAND, SC_SIZE + direction, 0);
                }
            }
        }

        private static void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (InClick)
                InClick = false;//释放鼠标后标注为false
        }

        private static void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (InClick)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                frm.Location = mouseSet;
            }

            if (e.Location.X < feelSize && e.Location.Y < feelSize)
                panel.Cursor = Cursors.SizeNWSE;
            else if (e.Location.X > panel.Width - feelSize && e.Location.Y < feelSize)
                panel.Cursor = Cursors.SizeNESW;
            else if (e.Location.X < feelSize && e.Location.Y >= feelSize)
                panel.Cursor = Cursors.SizeWE;
            else if (e.Location.X > panel.Width - 10 && e.Location.Y >= feelSize)
                panel.Cursor = Cursors.SizeWE;
            else if (e.Location.Y < feelSize)
                panel.Cursor = Cursors.SizeNS;
            else
                panel.Cursor = Cursors.Default;
        }
    }
}
