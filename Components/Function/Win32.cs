using MulTools.Components.Struct;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MulTools.Components.Function
{
    public class Win32
    {
        #region 权限
        // 这个结构体将会传递给API。使用StructLayout 
        //(...特性，确保其中的成员是按顺序排列的，C#编译器不会对其进行调整。
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        /// <summary>
        /// LUID_AND_ATTRIBUTES结构
        /// </summary>
        internal struct TokPriv1Luid { public int PrivilegeCount; public long Luid; public int Attr; }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string newPrivileges, ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;

        internal const string SE_CREATE_TOKEN_NAME = "SeCreateTokenPrivilege";
        internal const string SE_ASSIGNPRIMARYTOKEN_NAME = "SeAssignPrimaryTokenPrivilege";
        internal const string SE_LOCK_MEMORY_NAME = "SeLockMemoryPrivilege";
        internal const string SE_INCREASE_QUOTA_NAME = "SeIncreaseQuotaPrivilege";
        internal const string SE_UNSOLICITED_INPUT_NAME = "SeUnsolicitedInputPrivilege";
        internal const string SE_MACHINE_ACCOUNT_NAME = "SeMachineAccountPrivilege";
        internal const string SE_TCB_NAME = "SeTcbPrivilege";
        internal const string SE_SECURITY_NAME = "SeSecurityPrivilege";
        internal const string SE_TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege";
        internal const string SE_LOAD_DRIVER_NAME = "SeLoadDriverPrivilege";
        internal const string SE_SYSTEM_PROFILE_NAME = "SeSystemProfilePrivilege";
        internal const string SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege";
        internal const string SE_PROF_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";
        internal const string SE_INC_BASE_PRIORITY_NAME = "SeIncreaseBasePriorityPrivilege";
        internal const string SE_CREATE_PAGEFILE_NAME = "SeCreatePagefilePrivilege";
        internal const string SE_CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege";
        internal const string SE_BACKUP_NAME = "SeBackupPrivilege";
        internal const string SE_RESTORE_NAME = "SeRestorePrivilege";
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        internal const string SE_DEBUG_NAME = "SeDebugPrivilege";
        internal const string SE_AUDIT_NAME = "SeAuditPrivilege";
        internal const string SE_SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege";
        internal const string SE_CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege";
        internal const string SE_REMOTE_SHUTDOWN_NAME = "SeRemoteShutdownPrivilege";
        internal const string SE_UNDOCK_NAME = "SeUndockPrivilege";
        internal const string SE_SYNC_AGENT_NAME = "SeSyncAgentPrivilege";
        internal const string SE_ENABLE_DELEGATION_NAME = "SeEnableDelegationPrivilege";
        internal const string SE_MANAGE_VOLUME_NAME = "SeManageVolumePrivilege";
        internal const string SE_IMPERSONATE_NAME = "SeImpersonatePrivilege";
        internal const string SE_CREATE_GLOBAL_NAME = "SeCreateGlobalPrivilege";
        internal const string SE_TRUSTED_CREDMAN_ACCESS_NAME = "SeTrustedCredManAccessPrivilege";
        internal const string SE_RELABEL_NAME = "SeRelabelPrivilege";
        internal const string SE_INC_WORKING_SET_NAME = "SeIncreaseWorkingSetPrivilege";
        internal const string SE_TIME_ZONE_NAME = "SeTimeZonePrivilege";
        internal const string SE_CREATE_SYMBOLIC_LINK_NAME = "SeCreateSymbolicLinkPrivilege";
        #endregion

        #region 热键
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);//注册热键

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);//取消注册热键

        public const int WM_HOTKEY = 0x312;//热键
        #endregion

        #region 关机
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool ExitWindowsEx(int flg, int rea);//关机

        public const int EWX_LOGOFF = 0x00000000;//ExitWindowsEx的参数类型：关闭所有进程然后注销用户
        public const int EWX_SHUTDOWN = 0x00000001;//ExitWindowsEx的参数类型：关机
        public const int EWX_REBOOT = 0x00000002;//ExitWindowsEx的参数类型：重启
        public const int EWX_FORCE = 0x00000004;
        public const int EWX_POWEROFF = 0x00000008;//ExitWindowsEx的参数类型：关闭系统并关闭电源，该系统必须支持断电
        public const int EWX_FORCEIFHUNG = 0x00000010;
        #endregion

        #region 键鼠钩子
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr Hwnd);

        [DllImport("User32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookExW(int idHook, HookProc lpfn, IntPtr hmod, uint dwThreadID);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern short GetKeyState(int vKey);

        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion

        #region Other
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [return: MarshalAs(UnmanagedType.Bool)]
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hwnd, GetWindowMode mode);
        #endregion

        #region 缩略图相关
        public static System.Drawing.Point GetCursorPos()
        {
            NPoint ret;
            if (GetCursorPosInternal(out ret))
                return ret.ToPoint();
            else
                return default(System.Drawing.Point);
        }

        [DllImport("user32.dll", EntryPoint = "GetCursorPos")]
        private static extern bool GetCursorPosInternal(out NPoint point);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetClientRect(IntPtr handle, out NRectangle rect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr handle, out NRectangle rect);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// Gets a window's text via API call.
        /// </summary>
        /// <param name="hwnd">Window handle.</param>
        /// <returns>Title of the window.</returns>
        public static string GetWindowText(IntPtr hwnd)
        {
            int length = GetWindowTextLength(hwnd);
            if (length > 0)
            {
                StringBuilder sb = new StringBuilder(length + 1);
                if (GetWindowText(hwnd, sb, sb.Capacity) > 0)
                    return sb.ToString();
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }

        public static IntPtr GetWindowLong(IntPtr hWnd, WindowLong i)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, i);
            else
                return new IntPtr(GetWindowLong32(hWnd, i));
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        static extern int GetWindowLong32(IntPtr hWnd, WindowLong nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, WindowLong nIndex);

        public static IntPtr SetWindowLong(IntPtr hWnd, WindowLong i, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, i, dwNewLong);
            else
                return new IntPtr(SetWindowLong32(hWnd, i, dwNewLong.ToInt32()));
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        static extern int SetWindowLong32(IntPtr hWnd, WindowLong nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, WindowLong nIndex, IntPtr dwNewLong);

        const int MaxClassLength = 255;

        public static string GetWindowClass(IntPtr hwnd)
        {
            var sb = new StringBuilder(MaxClassLength + 1);
            RealGetWindowClass(hwnd, sb, MaxClassLength);
            return sb.ToString();
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RealGetWindowClass(IntPtr hwnd, [Out] StringBuilder lpString, uint maxCount);

        [DllImport("user32.dll", EntryPoint = "GetClassLongPtrW")]
        static extern IntPtr GetClassLong64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetClassLongW")]
        static extern int GetClassLong32(IntPtr hWnd, int nIndex);

        public static IntPtr GetClassLong(IntPtr hWnd, ClassLong i)
        {
            if (IntPtr.Size == 8)
                return GetClassLong64(hWnd, (int)i);
            else
                return new IntPtr(GetClassLong32(hWnd, (int)i));
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetMenu(IntPtr hwnd);

        [DllImport("user32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool AdjustWindowRectEx(ref NRectangle clientToWindowRect, long windowStyle, bool hasMenu, long extendedWindowStyle);

        /// <summary>
        /// Converts client size rectangle to window rectangle, according to window styles.
        /// </summary>
        /// <param name="clientRectangle">Client area bounding box.</param>
        /// <param name="windowStyle">Style of window to compute.</param>
        /// <param name="extendedWindowStyle">Extended style of window to compute.</param>
        public static NRectangle ConvertClientToWindowRect(NRectangle clientRectangle, long windowStyle, long extendedWindowStyle)
        {
            NRectangle tmp = clientRectangle;
            if (AdjustWindowRectEx(ref tmp, windowStyle, false, extendedWindowStyle))
                return tmp;
            else
                return clientRectangle;
        }
        #endregion
    }
    /// <summary>
    /// Windows Message codes.
    /// </summary>
    public static class WM
    {
        public const int GETICON = 0x7f;
        public const int SIZING = 0x214;
        public const int NCHITTEST = 0x84;
        public const int NCPAINT = 0x0085;
        public const int LBUTTONDOWN = 0x0201;
        public const int LBUTTONUP = 0x0202;
        public const int LBUTTONDBLCLK = 0x0203;
        public const int RBUTTONDOWN = 0x0204;
        public const int RBUTTONUP = 0x0205;
        public const int RBUTTONDBLCLK = 0x0206;
        public const int NCLBUTTONUP = 0x00A2;
        public const int NCLBUTTONDOWN = 0x00A1;
        public const int NCLBUTTONDBLCLK = 0x00A3;
        public const int NCRBUTTONUP = 0x00A5;
        public const int NCMOUSELEAVE = 0x02A2;
        public const int SYSCOMMAND = 0x0112;
        public const int GETTEXT = 0x000D;
        public const int GETTEXTLENGTH = 0x000E;
    }

    /// <summary>
    /// Native Win32 sizing codes (used by WM_SIZING message).
    /// </summary>
    public static class WMSZ
    {
        public const int LEFT = 1;
        public const int RIGHT = 2;
        public const int TOP = 3;
        public const int BOTTOM = 6;
    }
    /// <summary>
    /// Native Win32 Hit Testing codes.
    /// </summary>
    public static class HT
    {
        public const int TRANSPARENT = -1;
        public const int CLIENT = 1;
        public const int CAPTION = 2;
    }

    /// <summary>
    /// Common methods for Win32 messaging.
    /// </summary>
    public static class MessagingMethods
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [Flags]
        public enum SendMessageTimeoutFlags : uint
        {
            AbortIfHung = 2,
            Block = 1,
            Normal = 0
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageTimeout(IntPtr hwnd, uint message, IntPtr wparam, IntPtr lparam, SendMessageTimeoutFlags flags, uint timeout, out IntPtr result);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = false)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static IntPtr MakeLParam(int LoWord, int HiWord) => new IntPtr((HiWord << 16) | (LoWord & 0xffff));
    }

    public static class HookMethods
    {
        static HookMethods()
        {
            WM_SHELLHOOKMESSAGE = RegisterWindowMessage("SHELLHOOK");
        }

        public static int WM_SHELLHOOKMESSAGE
        {
            get;
            private set;
        }

        const int HSHELL_HIGHBIT = 0x8000;

        public const int HSHELL_WINDOWCREATED = 1;
        public const int HSHELL_WINDOWDESTROYED = 2;
        public const int HSHELL_WINDOWACTIVATED = 4;
        public const int HSHELL_REDRAW = 6;
        public const int HSHELL_RUDEAPPACTIVATED = (HSHELL_WINDOWACTIVATED | HSHELL_HIGHBIT);
        public const int HSHELL_FLASH = (HSHELL_REDRAW | HSHELL_HIGHBIT);

        /// <summary>
        /// Registers the WM_ID for a window message.
        /// </summary>
        /// <param name="wndMessageName">Name of the window message.</param>
        [DllImport("User32.dll")]
        public static extern int RegisterWindowMessage(string wndMessageName);

        /// <summary>
        /// Registers a window as a shell hook window.
        /// </summary>
        [DllImport("User32.dll")]
        public static extern bool RegisterShellHookWindow(IntPtr hwnd);

        /// <summary>
        /// Deregisters a window as a shell hook window.
        /// </summary>
        [DllImport("User32.dll")]
        public static extern bool DeregisterShellHookWindow(IntPtr hwnd);
    }
}
