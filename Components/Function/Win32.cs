using MulTools.Components.Enums;
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

        #region Common methods for Win32 messaging.
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageTimeout(IntPtr hwnd, uint message, IntPtr wparam, IntPtr lparam, SendMessageTimeoutFlags flags, uint timeout, out IntPtr result);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = false)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static IntPtr MakeLParam(int LoWord, int HiWord) => new IntPtr((HiWord << 16) | (LoWord & 0xffff));
        #endregion
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
