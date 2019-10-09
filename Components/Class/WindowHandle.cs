using MulTools.Components.Function;
using System;
using System.Drawing;
using System.Text;

namespace MulTools.Components.Class
{
    /// <summary>
    /// Helper class that keeps a window handle (HWND),
    /// the title of the window and can load its icon.
    /// </summary>
	public class WindowHandle : System.Windows.Forms.IWin32Window
    {
        /// <summary>
        /// IWin32Window Members
        /// </summary>
        public IntPtr Handle { get; }

        /// <summary>
        /// Creates a new WindowHandle instance. The handle pointer must be valid, the title
        /// may be null or empty and will be updated as requested.
        /// </summary>
		public WindowHandle(IntPtr p, string title = null)
        {
            Handle = p;
            _title = title;
        }

        private string _title;
        public string Title
        {
            get
            {
                if (_title == null)
                    _title = Win32.GetWindowText(Handle) ?? string.Empty;
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
                    IntPtr hIcon;//Fetch icon from window

                    if (Win32.SendMessageTimeout(Handle, WM.GETICON, new IntPtr(2), new IntPtr(0),
                        SendMessageTimeoutFlags.AbortIfHung | SendMessageTimeoutFlags.Block, 500, out hIcon) == IntPtr.Zero)
                    {
                        hIcon = IntPtr.Zero;
                    }

                    if (hIcon != IntPtr.Zero)
                    {
                        _icon = Icon.FromHandle(hIcon);
                    }
                    else
                    {
                        hIcon = (IntPtr)Win32.GetClassLong(Handle, ClassLong.IconSmall);//Fetch icon from window class
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
            sb.AppendFormat("#{0}", Handle);

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

            return !(obj is System.Windows.Forms.IWin32Window win) ? false : Handle.Equals(win.Handle);
        }

        public override int GetHashCode() => Handle.GetHashCode();
        #endregion

        public static WindowHandle FromHandle(IntPtr handle) => new WindowHandle(handle, null);
    }
}
