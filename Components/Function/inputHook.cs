using MulTools.Function;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MulTools.Function
{
    /// <summary>  
    /// 鼠标和键盘钩子的抽象类
    /// </summary>  
    public abstract class GlobalHook
    {
        #region Windows API Code
        [StructLayout(LayoutKind.Sequential)]
        protected class POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        protected class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        protected class MouseLLHookStruct
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        protected class KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        protected const int WH_MOUSE_LL = 14;
        protected const int WH_KEYBOARD_LL = 13;

        protected const int WH_MOUSE = 7;
        protected const int WH_KEYBOARD = 2;
        protected const int WM_MOUSEMOVE = 0x200;
        protected const int WM_LBUTTONDOWN = 0x201;
        protected const int WM_RBUTTONDOWN = 0x204;
        protected const int WM_MBUTTONDOWN = 0x207;
        protected const int WM_LBUTTONUP = 0x202;
        protected const int WM_RBUTTONUP = 0x205;
        protected const int WM_MBUTTONUP = 0x208;
        protected const int WM_LBUTTONDBLCLK = 0x203;
        protected const int WM_RBUTTONDBLCLK = 0x206;
        protected const int WM_MBUTTONDBLCLK = 0x209;
        protected const int WM_MOUSEWHEEL = 0x020A;
        protected const int WM_KEYDOWN = 0x100;
        protected const int WM_KEYUP = 0x101;
        protected const int WM_SYSKEYDOWN = 0x104;
        protected const int WM_SYSKEYUP = 0x105;

        protected const byte VK_SHIFT = 0x10;
        protected const byte VK_CAPITAL = 0x14;
        protected const byte VK_NUMLOCK = 0x90;

        protected const byte VK_LSHIFT = 0xA0;
        protected const byte VK_RSHIFT = 0xA1;
        protected const byte VK_LCONTROL = 0xA2;
        protected const byte VK_RCONTROL = 0x3;
        protected const byte VK_LALT = 0xA4;
        protected const byte VK_RALT = 0xA5;

        protected const byte LLKHF_ALTDOWN = 0x20;
        #endregion

        #region Private Variables
        protected int _hookType;
        protected int _handleToHook;
        protected bool _isStarted;
        protected Win32.HookProc _hookCallback;
        #endregion

        #region Properties
        public bool IsStarted => _isStarted;
        #endregion

        #region Constructor
        public GlobalHook()
        {
            //绑定ApplicationExit事件
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }
        #endregion

        #region Methods
        public void Start()
        {
            if (!_isStarted && _hookType != 0)
            {
                //确保_hookCallback不是一个空的引用,如果是，GC会随机回收它，并且一个空的引用会爆出异常
                _hookCallback = new Win32.HookProc(HookCallbackProcedure);
                using (Process curPro = Process.GetCurrentProcess())
                {
                    using (ProcessModule curMod = curPro.MainModule)
                    {
                        _handleToHook = (int)Win32.SetWindowsHookExW(_hookType, _hookCallback, Win32.GetModuleHandle(curMod.ModuleName), 0);
                    }
                }
                // 钩成功
                if (_handleToHook != 0)
                {
                    _isStarted = true;
                }
            }
        }

        public void Stop()
        {
            if (_isStarted)
            {
                Win32.UnhookWindowsHookEx(_handleToHook);
                _isStarted = false;
            }
        }
        /// <summary>
        /// 钩子回调函数
        /// </summary>
        protected virtual int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {
            return 0;// This method must be overriden by each extending hook  
        }
        /// <summary>
        /// 程序退出方法
        /// </summary>
        protected void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (_isStarted)
                Stop();
        }
        #endregion
    }

    /// <summary>  
    /// 键盘钩子类
    /// </summary>  
    public class KeyboardHook : GlobalHook
    {
        #region Events
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        public event KeyPressEventHandler KeyPress;
        #endregion

        #region Constructor
        public KeyboardHook()
        {
            _hookType = WH_KEYBOARD_LL;
        }
        #endregion

        #region Methods
        protected override int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {
            bool handled = false;
            if (nCode > -1 && (KeyDown != null || KeyUp != null || KeyPress != null))
            {
                KeyboardHookStruct keyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

                // Is Control being held down?  
                bool control = ((Win32.GetKeyState(VK_LCONTROL) & 0x80) != 0) || ((Win32.GetKeyState(VK_RCONTROL) & 0x80) != 0);
                // Is Shift being held down?  
                bool shift = ((Win32.GetKeyState(VK_LSHIFT) & 0x80) != 0) || ((Win32.GetKeyState(VK_RSHIFT) & 0x80) != 0);
                // Is Alt being held down?  
                bool alt = ((Win32.GetKeyState(VK_LALT) & 0x80) != 0) || ((Win32.GetKeyState(VK_RALT) & 0x80) != 0);
                // Is CapsLock on?  
                bool capslock = (Win32.GetKeyState(VK_CAPITAL) != 0);

                // Create event using keycode and control/shift/alt values found above  
                KeyEventArgs e = new KeyEventArgs((Keys)(keyboardHookStruct.vkCode | (control ? (int)Keys.Control : 0) | (shift ? (int)Keys.Shift : 0) | (alt ? (int)Keys.Alt : 0)));

                // Handle KeyDown and KeyUp events  
                switch (wParam)
                {
                    case WM_KEYDOWN:
                    case WM_SYSKEYDOWN:
                        if (KeyDown != null)
                        {
                            KeyDown(this, e);
                            handled = handled || e.Handled;
                        }
                        break;
                    case WM_KEYUP:
                    case WM_SYSKEYUP:
                        if (KeyUp != null)
                        {
                            KeyUp(this, e);
                            handled = handled || e.Handled;
                        }
                        break;
                }

                // Handle KeyPress event  
                if (wParam == WM_KEYDOWN && !handled && !e.SuppressKeyPress && KeyPress != null)
                {
                    byte[] keyState = new byte[256];
                    byte[] inBuffer = new byte[2];
                    Win32.GetKeyboardState(keyState);

                    if (Win32.ToAscii(keyboardHookStruct.vkCode, keyboardHookStruct.scanCode, keyState, inBuffer, keyboardHookStruct.flags) == 1)
                    {
                        char key = (char)inBuffer[0];
                        if ((capslock ^ shift) && char.IsLetter(key))
                            key = char.ToUpper(key);
                        KeyPressEventArgs e2 = new KeyPressEventArgs(key);
                        KeyPress(this, e2);
                        handled = handled || e.Handled;
                    }
                }
            }

            if (handled)
                return 1;
            else
                return Win32.CallNextHookEx(_handleToHook, nCode, wParam, lParam);
        }
        #endregion
    }

    /// <summary>  
    /// 鼠标钩子类
    /// </summary>  
    public class MouseHook : GlobalHook
    {
        private enum MouseEventType
        {
            None,
            MouseDown,
            MouseUp,
            DoubleClick,
            MouseWheel,
            MouseMove
        }

        #region Events
        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        public event MouseEventHandler MouseDown;
        /// <summary>
        /// 送开鼠标事件
        /// </summary>
        public event MouseEventHandler MouseUp;
        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        public event MouseEventHandler MouseMove;
        /// <summary>
        /// 鼠标滚轮事件
        /// </summary>
        public event MouseEventHandler MouseWheel;
        /// <summary>
        /// 鼠标单击事件
        /// </summary>
        public event EventHandler Click;
        /// <summary>
        /// 鼠标双击事件
        /// </summary>
        public event EventHandler DoubleClick;
        #endregion

        #region Constructor
        public MouseHook()
        {
            _hookType = WH_MOUSE_LL;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 钩子回调函数
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected override int HookCallbackProcedure(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode > -1 && (MouseDown != null || MouseUp != null || MouseMove != null))
            {
                MouseLLHookStruct mouseHookStruct = (MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseLLHookStruct));

                MouseButtons button = GetButton(wParam);
                MouseEventType eventType = GetEventType(wParam);

                MouseEventArgs e = new MouseEventArgs(button, (eventType == MouseEventType.DoubleClick ? 2 : 1), mouseHookStruct.pt.x,
                    mouseHookStruct.pt.y, (eventType == MouseEventType.MouseWheel ? (short)((mouseHookStruct.mouseData >> 16) & 0xffff) : 0));

                // Prevent multiple Right Click events (this probably happens for popup menus)  
                if (button == MouseButtons.Right && mouseHookStruct.flags != 0)
                    eventType = MouseEventType.None;

                switch (eventType)
                {
                    case MouseEventType.MouseDown:
                        if (MouseDown != null)
                            MouseDown(this, e);
                        break;
                    case MouseEventType.MouseUp:
                        if (Click != null)
                            Click(this, new EventArgs());
                        if (MouseUp != null)
                            MouseUp(this, e);
                        break;
                    case MouseEventType.DoubleClick:
                        if (DoubleClick != null)
                            DoubleClick(this, new EventArgs());
                        break;
                    case MouseEventType.MouseWheel:
                        if (MouseWheel != null)
                            MouseWheel(this, e);
                        break;
                    case MouseEventType.MouseMove:
                        if (MouseMove != null)
                            MouseMove(this, e);
                        break;
                    default:
                        break;
                }
            }
            return Win32.CallNextHookEx(_handleToHook, nCode, wParam, lParam);
        }

        private MouseButtons GetButton(int wParam)
        {
            switch (wParam)
            {
                case WM_LBUTTONDOWN:
                case WM_LBUTTONUP:
                case WM_LBUTTONDBLCLK:
                    return MouseButtons.Left;
                case WM_RBUTTONDOWN:
                case WM_RBUTTONUP:
                case WM_RBUTTONDBLCLK:
                    return MouseButtons.Right;
                case WM_MBUTTONDOWN:
                case WM_MBUTTONUP:
                case WM_MBUTTONDBLCLK:
                    return MouseButtons.Middle;
                default:
                    return MouseButtons.None;
            }
        }

        private MouseEventType GetEventType(int wParam)
        {
            switch (wParam)
            {
                case WM_LBUTTONDOWN:
                case WM_RBUTTONDOWN:
                case WM_MBUTTONDOWN:
                    return MouseEventType.MouseDown;
                case WM_LBUTTONUP:
                case WM_RBUTTONUP:
                case WM_MBUTTONUP:
                    return MouseEventType.MouseUp;
                case WM_LBUTTONDBLCLK:
                case WM_RBUTTONDBLCLK:
                case WM_MBUTTONDBLCLK:
                    return MouseEventType.DoubleClick;
                case WM_MOUSEWHEEL:
                    return MouseEventType.MouseWheel;
                case WM_MOUSEMOVE:
                    return MouseEventType.MouseMove;
                default:
                    return MouseEventType.None;
            }
        }
        #endregion
    }
}