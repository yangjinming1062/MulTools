using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
