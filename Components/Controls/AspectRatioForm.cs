﻿using MulTools.Components.Enums;
using MulTools.Components.Function;
using MulTools.Components.Struct;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsFormsAero.TaskDialog;

namespace MulTools.Components
{
    /// <summary>
    /// Form that automatically keeps a certain aspect ratio and resizes without flickering.
    /// </summary>
    public class AspectRatioForm : WindowsFormsAero.AeroForm
    {
        bool _keepAspectRatio = true;
        [Description("Gets or sets whether the form should keep its aspect ratio."), Category("Appearance"), DefaultValue(true)]
        public bool KeepAspectRatio
        {
            get => _keepAspectRatio;
            set
            {
                _keepAspectRatio = value;
                if (value)
                    RefreshAspectRatio();
            }
        }

        double _aspectRatio = 1.0;
        [Description("Determines this form's fixed aspect ratio."), Category("Appearance"), DefaultValue(1.0)]
        public double AspectRatio
        {
            get => _aspectRatio;
            set
            {
                if (value <= 0.0 || Double.IsInfinity(value))
                    return;

                _aspectRatio = value;
            }
        }

        Padding _extraPadding;
        [Description("Sets some padding inside the form's client area that is ignored when keeping the aspect ratio."), Category("Appearance")]
        public Padding ExtraPadding
        {
            get => _extraPadding;
            set
            {
                _extraPadding = value;
                if (KeepAspectRatio)
                    RefreshAspectRatio();
            }
        }

        /// <summary>
        /// Forces the form to update its height based on the current aspect ratio setting.
        /// </summary>
        public void RefreshAspectRatio()
        {
            int newWidth = ClientSize.Width;
            int newHeight = (int)((ClientSize.Width - ExtraPadding.Horizontal) / AspectRatio) + ExtraPadding.Vertical;

            //Adapt height if it doesn't respect the form's minimum size
            Size clientMinimumSize = FromSizeToClientSize(MinimumSize);
            if (newHeight < clientMinimumSize.Height)
            {
                newHeight = clientMinimumSize.Height;
                newWidth = (int)((newHeight - ExtraPadding.Vertical) * AspectRatio) + ExtraPadding.Horizontal;
            }

            //Adapt height if it exceeds the screen's height
            var workingArea = Screen.GetWorkingArea(this);
            if (newHeight >= workingArea.Height)
            {
                newHeight = workingArea.Height;
                newWidth = (int)((newHeight - ExtraPadding.Vertical) * AspectRatio) + ExtraPadding.Horizontal;
            }

            ClientSize = new Size(newWidth, newHeight);//Update size
        }

        /// <summary>
        /// Adjusts the size of the form by a pixel increment while keeping its aspect ratio.
        /// </summary>
        /// <param name="pixelIncrement">Change of size in pixels.</param>
        public void AdjustSize(int pixelOffset)
        {
            Size origSize = Size;

            //Resize to new width (clamped to max allowed size and minimum form size)
            int newWidth = Math.Max(Math.Min(origSize.Width + pixelOffset, SystemInformation.MaxWindowTrackSize.Width), MinimumSize.Width);

            //Determine new height while keeping aspect ratio
            var clientConversionDifference = ClientWindowDifference;
            int newHeight = (int)((newWidth - ExtraPadding.Horizontal - clientConversionDifference.Width) / AspectRatio) + ExtraPadding.Vertical + clientConversionDifference.Height;

            //Apply and move form to recenter
            Size = new Size(newWidth, newHeight);
            int deltaX = Size.Width - origSize.Width;
            int deltaY = Size.Height - origSize.Height;
            Location = new Point(Location.X - (deltaX / 2), Location.Y - (deltaY / 2));
        }

        /// <summary>
        /// Updates the aspect ratio of the form and optionally forces a refresh.
        /// </summary>
        /// <param name="aspectRatioSource">Size from which aspect ratio should be computed.</param>
        /// <param name="forceRefresh">True if the size of the form should be refreshed to match the new aspect ratio.</param>
        public void SetAspectRatio(Size aspectRatioSource, bool forceRefresh)
        {
            AspectRatio = ((double)aspectRatioSource.Width / (double)aspectRatioSource.Height);
            _keepAspectRatio = true;

            if (forceRefresh)
                RefreshAspectRatio();
        }

        #region Event overriding
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            //Ensure that the ClientSize of the form is always respected
            //(not ensured by the WM_SIZING message alone because of rounding errors and the chrome space)
            if (KeepAspectRatio)
            {
                var newHeight = ComputeHeightFromWidth(ClientSize.Width);
                ClientSize = new Size(ClientSize.Width, newHeight);
            }
        }

        protected virtual void OnResizing(EventArgs e) { }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM.SIZING)
            {
                this.OnResizing(EventArgs.Empty);

                if (KeepAspectRatio)
                {
                    var clientSizeConversion = ClientWindowDifference;

                    var rc = (NRectangle)Marshal.PtrToStructure(m.LParam, typeof(NRectangle));
                    int res = m.WParam.ToInt32();

                    int width = (rc.Right - rc.Left) - clientSizeConversion.Width - ExtraPadding.Horizontal;
                    int height = (rc.Bottom - rc.Top) - clientSizeConversion.Height - ExtraPadding.Vertical;

                    if (res == WMSZ.LEFT || res == WMSZ.RIGHT)
                    {
                        //Left or right resize, adjust top and bottom
                        int targetHeight = (int)(width / AspectRatio);
                        int diffHeight = height - targetHeight;

                        rc.Top += (int)(diffHeight / 2.0);
                        rc.Bottom = rc.Top + targetHeight + ExtraPadding.Vertical + clientSizeConversion.Height;
                    }
                    else if (res == WMSZ.TOP || res == WMSZ.BOTTOM)
                    {
                        //Up or down resize, adjust left and right
                        int targetWidth = (int)(height * AspectRatio);
                        int diffWidth = width - targetWidth;

                        rc.Left += (int)(diffWidth / 2.0);
                        rc.Right = rc.Left + targetWidth + ExtraPadding.Horizontal + clientSizeConversion.Width;
                    }
                    else if (res == WMSZ.RIGHT + WMSZ.BOTTOM || res == WMSZ.LEFT + WMSZ.BOTTOM)
                    {
                        //Lower corner resize, adjust bottom
                        rc.Bottom = rc.Top + (int)(width / AspectRatio) + ExtraPadding.Vertical + clientSizeConversion.Height;
                    }
                    else if (res == WMSZ.LEFT + WMSZ.TOP || res == WMSZ.RIGHT + WMSZ.TOP)
                    {
                        //Upper corner resize, adjust top
                        rc.Top = rc.Bottom - (int)(width / AspectRatio) - ExtraPadding.Vertical - clientSizeConversion.Height;
                    }
                    Marshal.StructureToPtr(rc, m.LParam, false);
                }
            }

            base.WndProc(ref m);
        }
        #endregion

        #region Conversion helpers
        /// <summary>
        /// Converts a client size measurement to a window size measurement.
        /// </summary>
        /// <param name="clientSize">Size of the window's client area.</param>
        /// <returns>Size of the whole window.</returns>
        public Size FromClientSizeToSize(Size clientSize)
        {
            var difference = ClientWindowDifference;
            return new Size(clientSize.Width + difference.Width, clientSize.Height + difference.Height);
        }

        /// <summary>
        /// Converts a window size measurement to a client size measurement.
        /// </summary>
        /// <param name="size">Size of the whole window.</param>
        /// <returns>Size of the window's client area.</returns>
        public Size FromSizeToClientSize(Size size)
        {
            var difference = ClientWindowDifference;
            return new Size(size.Width - difference.Width, size.Height - difference.Height);
        }

        /// <summary>
        /// Computes height from width value, according to aspect ratio of window.
        /// </summary>
        public int ComputeHeightFromWidth(int width) => (int)Math.Round(((width - ExtraPadding.Horizontal) / AspectRatio) + ExtraPadding.Vertical);

        /// <summary>
        /// Computes width from height value, according to aspect ratio of window.
        /// </summary>
        public int ComputeWidthFromHeight(int height) => (int)Math.Round(((height - ExtraPadding.Vertical) * AspectRatio) + ExtraPadding.Horizontal);
        #endregion

        /// <summary>
        /// Gets the difference in pixels between a client size value and a window size value (depending on window decoration).
        /// </summary>
        protected Size ClientWindowDifference
        {
            get
            {
                long style = Win32.GetWindowLong(this.Handle, WindowLong.Style).ToInt64();
                long exStyle = Win32.GetWindowLong(this.Handle, WindowLong.ExStyle).ToInt64();
                return Win32.ConvertClientToWindowRect(new NRectangle(0, 0, 0, 0), style, exStyle).Size;
            }
        }
        /// <summary>
        /// Displays an error task dialog.
        /// </summary>
        /// <param name="mainInstruction">Main instruction of the error dialog.</param>
        /// <param name="explanation">Detailed informations about the error.</param>
        /// <param name="errorMessage">Expanded error codes/messages.</param>
        public void ShowErrorDialog(string mainInstruction, string explanation, string errorMessage)
        {
            TaskDialog dlg = new TaskDialog(mainInstruction, "错误", explanation)
            {
                CommonIcon = CommonIcon.Stop,
                IsExpanded = false
            };
            if (!string.IsNullOrEmpty(errorMessage))
            {
                dlg.ExpandedInformation = "错误：" + errorMessage;
                dlg.ExpandedControlText = "详细错误";
            }
            dlg.Show(this);
        }
    }
}