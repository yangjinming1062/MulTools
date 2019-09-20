using System;
using System.Drawing;

namespace MulTools.Function
{
    public static class Functions
    {
        /// <summary>
        /// 提升进程权限
        /// </summary>
        public static void PrivilegesUp()
        {
            bool ToF;
            Win32.TokPriv1Luid tp;
            tp.PrivilegeCount = 1;
            tp.Luid = 0;
            tp.Attr = Win32.SE_PRIVILEGE_ENABLED;

            IntPtr hproc = Win32.GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;

            ToF = Win32.OpenProcessToken(hproc, Win32.TOKEN_ADJUST_PRIVILEGES | Win32.TOKEN_QUERY, ref htok);//获得进程访问令牌的句柄
            ToF = Win32.LookupPrivilegeValue(null, Win32.SE_DEBUG_NAME, ref tp.Luid);//查找newPrivileges参数对应的Luid
            ToF = Win32.AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);//通知系统修改进程权限
        }

        public static void PrivilegesUp(string Privilege)
        {
            bool ToF;
            Win32.TokPriv1Luid tp;
            tp.PrivilegeCount = 1;
            tp.Luid = 0;
            tp.Attr = Win32.SE_PRIVILEGE_ENABLED;

            IntPtr hproc = Win32.GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;

            ToF = Win32.OpenProcessToken(hproc, Win32.TOKEN_ADJUST_PRIVILEGES | Win32.TOKEN_QUERY, ref htok);//获得进程访问令牌的句柄
            ToF = Win32.LookupPrivilegeValue(null, Privilege, ref tp.Luid);//查找newPrivileges参数对应的Luid
            ToF = Win32.AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);//通知系统修改进程权限
        }

        public static void DoExitWin(int flg)
        {
            bool ok;
            Win32.TokPriv1Luid tp;
            tp.PrivilegeCount = 1;
            tp.Luid = 0;
            tp.Attr = Win32.SE_PRIVILEGE_ENABLED;

            IntPtr hproc = Win32.GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;

            ok = Win32.OpenProcessToken(hproc, Win32.TOKEN_ADJUST_PRIVILEGES | Win32.TOKEN_QUERY, ref htok);//获得进程访问令牌的句柄
            ok = Win32.LookupPrivilegeValue(null, Win32.SE_SHUTDOWN_NAME, ref tp.Luid);//修改进程权限
            ok = Win32.AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);//通知系统修改进程权限
            ok = Win32.ExitWindowsEx(flg, 0);
        }

        /// <summary>
        /// 当前系统显示的缩放比
        /// </summary>
        public static decimal Rate
        {
            get
            {
                IntPtr hdc = Win32.GetDC(IntPtr.Zero);
                int realH = Win32.GetDeviceCaps(hdc, 10);//DeviceCaps常量,VERTRES = 10,实际显示分辨率
                int H = Win32.GetDeviceCaps(hdc, 117);//DeviceCaps常量,DESKTOPVERTRES = 117，设置的分辨率
                Win32.ReleaseDC(IntPtr.Zero, hdc);
                return Convert.ToDecimal(H) / Convert.ToDecimal(realH);
            }
        }
        /// <summary>
        /// 因为缩放率的影响，需要进行比例换算
        /// </summary>
        public static int GetRated(decimal res)
        {
            return Convert.ToInt32(res * Rate);
        }
        /// <summary>
        /// 这里主要是处理鼠标返回的坐标点，需要除以缩放比例
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Point GetRated(Point source)
        {
            Point res = new Point(Convert.ToInt32(source.X / Rate), Convert.ToInt32(source.Y / Rate));
            return res;
        }
    }
}
