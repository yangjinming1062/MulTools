using MulTools.Components.Models;
using MulTools.Components.Struct;
using System;
using System.Drawing;
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

        public static string[] PrivilegesList = { SE_CREATE_TOKEN_NAME, SE_ASSIGNPRIMARYTOKEN_NAME, SE_LOCK_MEMORY_NAME, SE_INCREASE_QUOTA_NAME, SE_UNSOLICITED_INPUT_NAME, SE_MACHINE_ACCOUNT_NAME
                                  ,SE_TCB_NAME,SE_SECURITY_NAME,SE_TAKE_OWNERSHIP_NAME,SE_LOAD_DRIVER_NAME,SE_SYSTEM_PROFILE_NAME,SE_SYSTEMTIME_NAME,SE_PROF_SINGLE_PROCESS_NAME,
                                  SE_INC_BASE_PRIORITY_NAME,SE_CREATE_PAGEFILE_NAME,SE_CREATE_PERMANENT_NAME,SE_BACKUP_NAME,SE_RESTORE_NAME,SE_SHUTDOWN_NAME,SE_DEBUG_NAME,SE_AUDIT_NAME,
                                  SE_SYSTEM_ENVIRONMENT_NAME,SE_CHANGE_NOTIFY_NAME,SE_REMOTE_SHUTDOWN_NAME,SE_UNDOCK_NAME,SE_SYNC_AGENT_NAME,SE_ENABLE_DELEGATION_NAME,SE_MANAGE_VOLUME_NAME,
                                  SE_IMPERSONATE_NAME,SE_CREATE_GLOBAL_NAME,SE_TRUSTED_CREDMAN_ACCESS_NAME,SE_RELABEL_NAME,SE_INC_WORKING_SET_NAME,SE_TIME_ZONE_NAME,SE_CREATE_SYMBOLIC_LINK_NAME};
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

        [System.Runtime.InteropServices.DllImport("User32.dll")]
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
                    return String.Empty;
            }
            else
                return String.Empty;
        }

        public enum WindowLong
        {
            WndProc = (-4),
            HInstance = (-6),
            HwndParent = (-8),
            Style = (-16),
            ExStyle = (-20),
            UserData = (-21),
            Id = (-12)
        }

        [Flags]
        public enum WindowStyles : long
        {
            None = 0,
            Child = 0x40000000L,
            Disabled = 0x8000000L,
            Minimize = 0x20000000L,
            MinimizeBox = 0x20000L,
            Visible = 0x10000000L
        }

        [Flags]
        public enum WindowExStyles : long
        {
            AppWindow = 0x40000,
            Layered = 0x80000,
            NoActivate = 0x8000000L,
            ToolWindow = 0x80,
            TopMost = 8,
            Transparent = 0x20
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

        #region Window class

        const int MaxClassLength = 255;

        public static string GetWindowClass(IntPtr hwnd)
        {
            var sb = new StringBuilder(MaxClassLength + 1);
            RealGetWindowClass(hwnd, sb, MaxClassLength);
            return sb.ToString();
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RealGetWindowClass(IntPtr hwnd, [Out] StringBuilder lpString, uint maxCount);

        public enum ClassLong
        {
            Icon = -14,
            IconSmall = -34
        }

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
        #endregion

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

        #region Injection
        [DllImport("user32.dll")]
        public static extern IntPtr RealChildWindowFromPoint(IntPtr parent, NPoint point);
        [DllImport("user32.dll")]
        static extern bool ScreenToClient(IntPtr hwnd, ref NPoint point);

        /// <summary>
        /// Converts a point in screen coordinates in client coordinates relative to a window.
        /// </summary>
        /// <param name="hwnd">Handle of the window whose client coordinate system should be used.</param>
        /// <param name="screenPoint">Point expressed in screen coordinates.</param>
        /// <returns>Point expressed in client coordinates.</returns>
        public static NPoint ScreenToClient(IntPtr hwnd, NPoint screenPoint)
        {
            NPoint localCopy = new NPoint(screenPoint);
            if (ScreenToClient(hwnd, ref localCopy))
                return localCopy;
            else
                return new NPoint();
        }
        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hwnd, ref NPoint point);

        /// <summary>
        /// Converts a point in client coordinates of a window to screen coordinates.
        /// </summary>
        /// <param name="hwnd">Handle to the window of the original point.</param>
        /// <param name="clientPoint">Point expressed in client coordinates.</param>
        /// <returns>Point expressed in screen coordinates.</returns>
        public static NPoint ClientToScreen(IntPtr hwnd, NPoint clientPoint)
        {
            NPoint localCopy = new NPoint(clientPoint);
            if (ClientToScreen(hwnd, ref localCopy))
                return localCopy;
            else
                return new NPoint();
        }

        /// <summary>Inject a fake left mouse click on a target window, on a location expressed in client coordinates.</summary>
		/// <param name="window">Target window to click on.</param>
		/// <param name="clickLocation">Location of the mouse click expressed in client coordiantes of the target window.</param>
		/// <param name="doubleClick">True if a double click should be injected.</param>
		public static void InjectFakeMouseClick(IntPtr window, CloneClickEventArgs clickArgs)
        {
            NPoint clientClickLocation = NPoint.FromPoint(clickArgs.ClientClickLocation);
            NPoint scrClickLocation = ClientToScreen(window, clientClickLocation);

            //HACK (?)
            //If target window has a Menu (which appears on the thumbnail) move the clicked location down
            //in order to adjust (the menu isn't part of the window's client rect).
            IntPtr hMenu = Win32.GetMenu(window);
            if (hMenu != IntPtr.Zero)
                scrClickLocation.Y -= SystemInformation.MenuHeight;

            IntPtr hChild = GetRealChildControlFromPoint(window, scrClickLocation);
            NPoint clntClickLocation = ScreenToClient(hChild, scrClickLocation);

            if (clickArgs.Buttons == MouseButtons.Left)
            {
                if (clickArgs.IsDoubleClick)
                    InjectDoubleLeftMouseClick(hChild, clntClickLocation);
                else
                    InjectLeftMouseClick(hChild, clntClickLocation);
            }
            else if (clickArgs.Buttons == MouseButtons.Right)
            {
                if (clickArgs.IsDoubleClick)
                    InjectDoubleRightMouseClick(hChild, clntClickLocation);
                else
                    InjectRightMouseClick(hChild, clntClickLocation);
            }
        }

        /// <summary>Returns the child control of a window corresponding to a screen location.</summary>
		/// <param name="parent">Parent window to explore.</param>
		/// <param name="scrClickLocation">Child control location in screen coordinates.</param>
		private static IntPtr GetRealChildControlFromPoint(IntPtr parent, NPoint scrClickLocation)
        {
            IntPtr curr = parent, child = IntPtr.Zero;
            do
            {
                child = RealChildWindowFromPoint(curr, ScreenToClient(curr, scrClickLocation));

                if (child == IntPtr.Zero || child == curr)
                    break;

                curr = child;//Update for next loop
            }
            while (true);

            //Safety check, shouldn't happen
            if (curr == IntPtr.Zero)
                curr = parent;

            return curr;
        }

        private static void InjectLeftMouseClick(IntPtr child, NPoint clientLocation)
        {
            IntPtr lParamClickLocation = MessagingMethods.MakeLParam(clientLocation.X, clientLocation.Y);

            MessagingMethods.PostMessage(child, WM.LBUTTONDOWN, new IntPtr(MK.LBUTTON), lParamClickLocation);
            MessagingMethods.PostMessage(child, WM.LBUTTONUP, new IntPtr(MK.LBUTTON), lParamClickLocation);
        }

        private static void InjectRightMouseClick(IntPtr child, NPoint clientLocation)
        {
            IntPtr lParamClickLocation = MessagingMethods.MakeLParam(clientLocation.X, clientLocation.Y);

            MessagingMethods.PostMessage(child, WM.RBUTTONDOWN, new IntPtr(MK.RBUTTON), lParamClickLocation);
            MessagingMethods.PostMessage(child, WM.RBUTTONUP, new IntPtr(MK.RBUTTON), lParamClickLocation);
        }

        private static void InjectDoubleLeftMouseClick(IntPtr child, NPoint clientLocation)
        {
            IntPtr lParamClickLocation = MessagingMethods.MakeLParam(clientLocation.X, clientLocation.Y);
            MessagingMethods.PostMessage(child, WM.LBUTTONDBLCLK, new IntPtr(MK.LBUTTON), lParamClickLocation);
        }

        private static void InjectDoubleRightMouseClick(IntPtr child, NPoint clientLocation)
        {
            IntPtr lParamClickLocation = MessagingMethods.MakeLParam(clientLocation.X, clientLocation.Y);
            MessagingMethods.PostMessage(child, WM.RBUTTONDBLCLK, new IntPtr(MK.RBUTTON), lParamClickLocation);
        }
        #endregion
    }
    public static class MK
    {
        public const int LBUTTON = 0x0001;
        public const int RBUTTON = 0x0002;
        public const int MBUTTON = 0x0010;
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
    /// Helper class that keeps a window handle (HWND),
    /// the title of the window and can load its icon.
    /// </summary>
	public class WindowHandle : System.Windows.Forms.IWin32Window
    {

        IntPtr _handle;
        string _title;

        /// <summary>
        /// Creates a new WindowHandle instance. The handle pointer must be valid, the title
        /// may be null or empty and will be updated as requested.
        /// </summary>
		public WindowHandle(IntPtr p, string title)
        {
            _handle = p;
            _title = title;
        }

        /// <summary>
        /// Creates a new WindowHandle instance. Additional features of the handle will be queried as needed.
        /// </summary>
        /// <param name="p"></param>
        public WindowHandle(IntPtr p)
        {
            _handle = p;
            _title = null;
        }

        public string Title
        {
            get
            {
                if (_title == null)
                    _title = Win32.GetWindowText(_handle) ?? string.Empty;
                return _title;
            }
        }

        Icon _icon = null;
        bool _iconFetched = false;
        public Icon Icon
        {
            get
            {
                if (!_iconFetched)
                {
                    //Fetch icon from window
                    IntPtr hIcon;

                    if (MessagingMethods.SendMessageTimeout(_handle, WM.GETICON, new IntPtr(2), new IntPtr(0),
                        MessagingMethods.SendMessageTimeoutFlags.AbortIfHung | MessagingMethods.SendMessageTimeoutFlags.Block, 500, out hIcon) == IntPtr.Zero)
                    {
                        hIcon = IntPtr.Zero;
                    }

                    if (hIcon != IntPtr.Zero)
                    {
                        _icon = Icon.FromHandle(hIcon);
                    }
                    else
                    {
                        hIcon = (IntPtr)Win32.GetClassLong(_handle, Win32.ClassLong.IconSmall);//Fetch icon from window class
                        if (hIcon.ToInt64() != 0)
                            _icon = Icon.FromHandle(hIcon);
                    }
                }

                _iconFetched = true;
                return _icon;
            }
        }

        string _class = null;

        /// <summary>
        /// Gets the window's class name.
        /// </summary>
        /// <remarks>
        /// This value is cached and is never null.
        /// </remarks>
        public string Class
        {
            get
            {
                if (_class == null)
                    _class = Win32.GetWindowClass(Handle) ?? string.Empty;
                return _class;
            }
        }

        #region Object override
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("#{0}", _handle);

            if (!string.IsNullOrWhiteSpace(_title) || !string.IsNullOrWhiteSpace(_class))
            {
                sb.Append(" (");
                if (!string.IsNullOrWhiteSpace(_title))
                {
                    sb.AppendFormat("title '{0}'", _title);
                    if (!string.IsNullOrWhiteSpace(_class))
                        sb.Append(", ");
                }
                if (!string.IsNullOrWhiteSpace(_class))
                    sb.AppendFormat("class {0}", _class);
                sb.Append(")");
            }
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
                return true;

            System.Windows.Forms.IWin32Window win = obj as System.Windows.Forms.IWin32Window;
            if (win == null)
                return false;

            return (_handle.Equals(win.Handle));
        }

        public override int GetHashCode()
        {
            return _handle.GetHashCode();
        }
        #endregion

        /// <summary>
        /// IWin32Window Members
        /// </summary>
        public IntPtr Handle
        {
            get { return _handle; }
        }

        /// <summary>
        /// Creates a new windowHandle instance from a given IntPtr handle.
        /// </summary>
        /// <param name="handle">Handle value.</param>
        public static WindowHandle FromHandle(IntPtr handle)
        {
            return new WindowHandle(handle, null);
        }
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

        public static IntPtr MakeLParam(int LoWord, int HiWord)
        {
            return new IntPtr((HiWord << 16) | (LoWord & 0xffff));
        }
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
