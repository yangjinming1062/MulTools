using MulTools.Components.Class;
using MulTools.Components.Enums;
using MulTools.Components.Function;
using System.Collections.Generic;

namespace MulTools.Components
{
    /// <summary>
    /// Window seeker that attempts to mimic ALT+TAB behavior in filtering windows to show.
    /// </summary>
    class TaskWindowSeeker : BaseWindowSeeker
    {
        List<WindowHandle> _list = new List<WindowHandle>();

        public override IList<WindowHandle> Windows => _list;

        public override void Refresh()
        {
            _list.Clear();
            base.Refresh();
        }

        protected override bool InspectWindow(WindowHandle handle)
        {
            //Reject empty titles
            if (string.IsNullOrEmpty(handle.Title))
                return true;

            //Accept windows that
            // - are visible
            // - do not have a parent
            // - have no owner and are not Tool windows OR
            // - have an owner and are App windows
            if ((long)Win32.GetParent(handle.Handle) == 0)
            {
                bool hasOwner = (long)Win32.GetWindow(handle.Handle, GetWindowMode.GW_OWNER) != 0;
                WindowExStyles exStyle = (WindowExStyles)Win32.GetWindowLong(handle.Handle, WindowLong.ExStyle);

                if (((exStyle & WindowExStyles.ToolWindow) == 0 && !hasOwner) || //unowned non-tool window
                    ((exStyle & WindowExStyles.AppWindow) == WindowExStyles.AppWindow && hasOwner))
                { //owned application window

                    _list.Add(handle);
                }
            }
            return true;
        }
    }
}
