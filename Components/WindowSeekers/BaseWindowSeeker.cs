﻿using MulTools.Components.Class;
using MulTools.Components.Function;
using System;
using System.Collections.Generic;

namespace MulTools.Components.WindowSeekers
{
    /// <summary>
    /// Interface for window seekers.
    /// </summary>
    interface IWindowSeeker
    {
        /// <summary>
        /// Get the list of matching windows, ordered by priority (optionally).
        /// </summary>
        IList<WindowHandle> Windows { get; }
        /// <summary>
        /// Refreshes the list of windows.
        /// </summary>
        void Refresh();
    }
    /// <summary>
    /// Base class for window seekers that can populate a list of window handles based on some criteria and with basic filtering.
    /// </summary>
    public abstract class BaseWindowSeeker : IWindowSeeker
    {

        #region IWindowSeeker
        public abstract IList<WindowHandle> Windows
        {
            get;
        }

        public virtual void Refresh() => Win32.EnumWindows(RefreshCallback, IntPtr.Zero);
        #endregion

        private bool RefreshCallback(IntPtr hwnd, IntPtr lParam)
        {
            //Skip owner
            if (hwnd == OwnerHandle)
                return true;

            if (SkipNotVisibleWindows && !Win32.IsWindowVisible(hwnd))
                return true;

            //Extract basic properties
            string title = Win32.GetWindowText(hwnd);
            var handle = new WindowHandle(hwnd, title);

            return InspectWindow(handle);
        }

        /// <summary>
        /// Inspects a window and return whether inspection should continue.
        /// </summary>
        /// <param name="handle">Handle of the window.</param>
        /// <returns>True if inspection should continue. False stops current refresh operation.</returns>
        protected abstract bool InspectWindow(WindowHandle handle);

        /// <summary>
        /// Gets or sets the window handle of the owner.
        /// </summary>
        /// <remarks>
        /// Windows with this handle will be automatically skipped.
        /// </remarks>
        public IntPtr OwnerHandle { get; set; }

        /// <summary>
        /// Gets or sets whether not visible windows should be skipped.
        /// </summary>
        public bool SkipNotVisibleWindows { get; set; }
    }
}
