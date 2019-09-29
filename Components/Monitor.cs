using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MulTools.Components;
using MulTools.Components.Function;
using MulTools.Components.Models;
using MulTools.Components.WindowSeekers;
using WindowsFormsAero.TaskDialog;

namespace MulTools.Components
{
    public partial class Monitor : AspectRatioForm
    {
        //GUI elements
        ThumbnailPanel _thumbnailPanel;

        /// <summary>
        /// Retrieves the window handle of the currently cloned thumbnail.
        /// </summary>
        public WindowHandle CurrentThumbnailWindowHandle { get; set; }

        /// <summary>
        /// Gets the form's message pump manager.
        /// </summary>
        public MessagePumpManager MessagePumpManager { get; } = new MessagePumpManager();

        public BaseWindowSeeker WindowSeeker { get; set; }
        public Monitor()
        {
            _quickRegionDrawingHandler = new ThumbnailPanel.RegionDrawnHandler(HandleQuickRegionDrawn);

            InitializeComponent();

            //Store default values
            DefaultNonClickTransparencyKey = this.TransparencyKey;
            DefaultBorderStyle = this.FormBorderStyle;

            _thumbnailPanel = new ThumbnailPanel
            {
                Location = Point.Empty,
                Dock = DockStyle.Fill
            };
            _thumbnailPanel.CloneClick += new EventHandler<CloneClickEventArgs>(Thumbnail_CloneClick);
            Controls.Add(_thumbnailPanel);

            this.KeyPreview = true;//Set to Key event preview

            WindowSeeker = new TaskWindowSeeker()
            {
                OwnerHandle = this.Handle,
                SkipNotVisibleWindows = true
            };
        }

        public Monitor(WindowHandle h) : this()
        {
            this.SetThumbnail(h, null);
        }

        #region Event override

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            //Window init
            KeepAspectRatio = false;
            GlassMargins = new Padding(-1);

            //Managers
            MessagePumpManager.Initialize(this);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            MessagePumpManager.Dispose();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            AdjustSidePanelLocation();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            RefreshScreenLock();
        }

        protected override void OnResizing(EventArgs e)
        {
            //Update aspect ratio from thumbnail while resizing (but do not refresh, resizing does that anyway)
            if (_thumbnailPanel.IsShowingThumbnail)
                SetAspectRatio(_thumbnailPanel.ThumbnailPixelSize, false);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            //Deactivate click-through if form is reactivated
            if (ClickThroughEnabled)
                ClickThroughEnabled = false;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            //HACK: sometimes, even if TopMost is true, the window loses its "always on top" status.
            //  This is a fix attempt that probably won't work...
            TopMost = false;
            TopMost = true;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (_thumbnailPanel.IsShowingThumbnail)
                SetAspectRatio(_thumbnailPanel.ThumbnailPixelSize, false);

            int change = (int)(e.Delta / 6.0); //assumes a mouse wheel "tick" is in the 80-120 range
            AdjustSize(change);
            RefreshScreenLock();
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Right)
                OpenContextMenu(null);
        }

        private ThumbnailPanel.RegionDrawnHandler _quickRegionDrawingHandler;

        protected override void WndProc(ref Message m)
        {
            if (MessagePumpManager == null || !MessagePumpManager.PumpMessage(ref m))
            {
                switch (m.Msg)
                {
                    case WM.NCRBUTTONUP:
                        //Open context menu if right button clicked on caption (i.e. all of the window area because of glass)
                        if (m.WParam.ToInt32() == HT.CAPTION)
                        {
                            OpenContextMenu(null);
                            m.Result = IntPtr.Zero;
                            return;
                        }
                        break;
                    case WM.NCLBUTTONDOWN:
                        if ((ModifierKeys & Keys.Control) == Keys.Control && ThumbnailPanel.IsShowingThumbnail && !ThumbnailPanel.DrawMouseRegions)
                        {
                            ThumbnailPanel.EnableMouseRegionsDrawingWithMouseDown();
                            ThumbnailPanel.RegionDrawn += _quickRegionDrawingHandler;

                            m.Result = IntPtr.Zero;
                            return;
                        }
                        break;
                    case WM.NCLBUTTONDBLCLK:
                        //Toggle fullscreen mode if double click on caption (whole glass area)
                        if (m.WParam.ToInt32() == HT.CAPTION)
                        {
                            m.Result = IntPtr.Zero;
                            return;
                        }
                        break;
                    case WM.NCHITTEST:
                        //Make transparent to hit-testing if in click through mode
                        if (ClickThroughEnabled)
                        {
                            m.Result = (IntPtr)HT.TRANSPARENT;

                            RefreshClickThroughComeBack();
                            return;
                        }
                        break;
                }
                base.WndProc(ref m);
            }
        }

        private void HandleQuickRegionDrawn(object sender, ThumbnailRegion region)
        {
            //Reset region drawing state
            ThumbnailPanel.DrawMouseRegions = false;
            ThumbnailPanel.RegionDrawn -= _quickRegionDrawingHandler;

            SelectedThumbnailRegion = region;
        }

        #endregion

        #region Keyboard event handling

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            //ALT
            if (e.Modifiers == Keys.Alt)
            {
                if (e.KeyCode == Keys.Enter)
                    e.Handled = true;
                else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                    FitToThumbnail(0.25);
                else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                    FitToThumbnail(0.5);
                else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                    FitToThumbnail(1.0);
                else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                    FitToThumbnail(2.0);
            }

            //F11 Fullscreen switch
            else if (e.KeyCode == Keys.F11)
                e.Handled = true;

            //ESCAPE
            else if (e.KeyCode == Keys.Escape)
            {
                if (ClickThroughEnabled)//Disable click-through
                    ClickThroughEnabled = false;
            }
        }
        #endregion

        #region Thumbnail operation

        /// <summary>
        /// Sets a new thumbnail.
        /// </summary>
        /// <param name="handle">Handle to the window to clone.</param>
        /// <param name="region">Region of the window to clone or null.</param>
        public void SetThumbnail(WindowHandle handle, ThumbnailRegion region)
        {
            try
            {
                CurrentThumbnailWindowHandle = handle;
                _thumbnailPanel.SetThumbnailHandle(handle, region);

                //Set aspect ratio (this will resize the form), do not refresh if in fullscreen
                SetAspectRatio(_thumbnailPanel.ThumbnailPixelSize, true);
            }
            catch (Exception ex)
            {
                ThumbnailError(ex, false, "无法创建缩略图");
                _thumbnailPanel.UnsetThumbnail();
            }
        }

        /// <summary>
        /// Enables group mode on a list of window handles.
        /// </summary>
        /// <param name="handles">List of window handles.</param>
        public void SetThumbnailGroup(IList<WindowHandle> handles)
        {
            if (handles.Count == 0)
                return;

            //At last one thumbnail
            SetThumbnail(handles[0], null);

            //Handle if no real group
            if (handles.Count == 1)
                return;

            CurrentThumbnailWindowHandle = null;
            MessagePumpManager.Get<GroupSwitchManager>().EnableGroupMode(handles);
        }

        /// <summary>
        /// Disables the cloned thumbnail.
        /// </summary>
        public void UnsetThumbnail()
        {
            //Unset handle
            CurrentThumbnailWindowHandle = null;
            _thumbnailPanel.UnsetThumbnail();

            //Disable aspect ratio
            KeepAspectRatio = false;
        }

        /// <summary>
        /// Gets or sets the region displayed of the current thumbnail.
        /// </summary>
        public ThumbnailRegion SelectedThumbnailRegion
        {
            get
            {
                if (!_thumbnailPanel.IsShowingThumbnail || !_thumbnailPanel.ConstrainToRegion)
                    return null;

                return _thumbnailPanel.SelectedRegion;
            }
            set
            {
                if (!_thumbnailPanel.IsShowingThumbnail)
                    return;

                _thumbnailPanel.SelectedRegion = value;
                SetAspectRatio(_thumbnailPanel.ThumbnailPixelSize, true);
                FixPositionAndSize();
            }
        }

        const int FixMargin = 10;

        /// <summary>
        /// Fixes the form's position and size, ensuring it is fully displayed in the current screen.
        /// </summary>
        private void FixPositionAndSize()
        {
            var screen = Screen.FromControl(this);

            if (Width > screen.WorkingArea.Width)
                Width = screen.WorkingArea.Width - FixMargin;
            if (Height > screen.WorkingArea.Height)
                Height = screen.WorkingArea.Height - FixMargin;
            if (Location.X + Width > screen.WorkingArea.Right)
                Location = new Point(screen.WorkingArea.Right - Width - FixMargin, Location.Y);
            if (Location.Y + Height > screen.WorkingArea.Bottom)
                Location = new Point(Location.X, screen.WorkingArea.Bottom - Height - FixMargin);
        }

        private void ThumbnailError(Exception ex, bool suppress, string title)
        {
            if (!suppress)
                ShowErrorDialog(title, "所选窗口已被关闭或无效", ex.Message);

            UnsetThumbnail();
        }

        /// <summary>Automatically sizes the window in order to accomodate the thumbnail p times.</summary>
        /// <param name="p">Scale of the thumbnail to consider.</param>
        private void FitToThumbnail(double p)
        {
            try
            {
                Size originalSize = _thumbnailPanel.ThumbnailPixelSize;
                Size fittedSize = new Size((int)(originalSize.Width * p), (int)(originalSize.Height * p));
                ClientSize = fittedSize;
                RefreshScreenLock();
            }
            catch (Exception ex)
            {
                ThumbnailError(ex, false, "无法调整窗口");
            }
        }
        #endregion

        #region Accessors
        /// <summary>
        /// Gets the form's thumbnail panel.
        /// </summary>
        public ThumbnailPanel ThumbnailPanel => _thumbnailPanel;
        #endregion

        #region 点击穿透

        bool _clickThrough = false;

        readonly Color DefaultNonClickTransparencyKey;

        public bool ClickThroughEnabled
        {
            get => _clickThrough;
            set
            {
                TransparencyKey = (value) ? Color.Black : DefaultNonClickTransparencyKey;
                if (value)
                {
                    //Re-force as top most (always helps in some cases)
                    TopMost = false;
                    this.Activate();
                    TopMost = true;
                }
                _clickThrough = value;
            }
        }

        //Must NOT be equal to any other valid opacity value
        const double ClickThroughHoverOpacity = 0.6;

        Timer _clickThroughComeBackTimer = null;
        long _clickThroughComeBackTicks;
        const int ClickThroughComeBackTimerInterval = 1000;

        /// <summary>
        /// When the mouse hovers over a fully opaque click-through form,
        /// this fades the form to semi-transparency
        /// and starts a timeout to get back to full opacity.
        /// </summary>
        private void RefreshClickThroughComeBack()
        {
            if (this.Opacity == 1.0)
                this.Opacity = ClickThroughHoverOpacity;

            if (_clickThroughComeBackTimer == null)
            {
                _clickThroughComeBackTimer = new Timer();
                _clickThroughComeBackTimer.Tick += _clickThroughComeBackTimer_Tick;
                _clickThroughComeBackTimer.Interval = ClickThroughComeBackTimerInterval;
            }
            _clickThroughComeBackTicks = DateTime.UtcNow.Ticks;
            _clickThroughComeBackTimer.Start();
        }

        void _clickThroughComeBackTimer_Tick(object sender, EventArgs e)
        {
            var diff = DateTime.UtcNow.Subtract(new DateTime(_clickThroughComeBackTicks));
            if (diff.TotalSeconds > 2)
            {
                var mousePointer = Win32.GetCursorPos();
                if (!this.ContainsMousePointer(mousePointer))
                {
                    if (this.Opacity == ClickThroughHoverOpacity)
                        this.Opacity = 1.0;
                    _clickThroughComeBackTimer.Stop();
                }
            }
        }
        #endregion

        #region 显示边框
        readonly FormBorderStyle DefaultBorderStyle; // = FormBorderStyle.Sizable; // FormBorderStyle.SizableToolWindow;

        public bool IsChromeVisible
        {
            get => (FormBorderStyle == DefaultBorderStyle);
            set
            {
                //Cancel hiding chrome if no thumbnail is shown
                if (!value && !_thumbnailPanel.IsShowingThumbnail)
                    return;

                if (!value)
                {
                    Location = new Point
                    {
                        X = Location.X + SystemInformation.FrameBorderSize.Width,
                        Y = Location.Y + SystemInformation.FrameBorderSize.Height
                    };
                    FormBorderStyle = FormBorderStyle.None;
                }
                else if (value)
                {
                    Location = new Point
                    {
                        X = Location.X - SystemInformation.FrameBorderSize.Width,
                        Y = Location.Y - SystemInformation.FrameBorderSize.Height
                    };
                    FormBorderStyle = DefaultBorderStyle;
                }
                Invalidate();
            }
        }

        #endregion

        #region 位置锁定
        ScreenPosition? _positionLock = null;

        /// <summary>
        /// Gets or sets the screen position where the window is currently locked in.
        /// </summary>
        public ScreenPosition? PositionLock
        {
            get => _positionLock;
            set
            {
                if (value != null)
                    this.SetScreenPosition(value.Value);

                _positionLock = value;
            }
        }

        /// <summary>
        /// Refreshes window position if in lock mode.
        /// </summary>
        private void RefreshScreenLock()
        {
            //If locked in position, move accordingly
            if (PositionLock.HasValue)
                this.SetScreenPosition(PositionLock.Value);
        }
        #endregion

        //SidePanel _currentSidePanel = null;
        SidePanelContainer _sidePanelContainer = null;

        /// <summary>
        /// Opens a new side panel.
        /// </summary>
        /// <param name="panel">The side panel to embed.</param>
        public void SetSidePanel(SidePanel panel)
        {
            if (IsSidePanelOpen)
                CloseSidePanel();

            _sidePanelContainer = new SidePanelContainer(this);
            _sidePanelContainer.SetSidePanel(panel);
            _sidePanelContainer.Location = ComputeSidePanelLocation(_sidePanelContainer);
            _sidePanelContainer.Show(this);
        }

        /// <summary>
        /// Closes the current side panel.
        /// </summary>
        public void CloseSidePanel()
        {
            if (_sidePanelContainer == null || _sidePanelContainer.IsDisposed)
            {
                _sidePanelContainer = null;
                return;
            }

            _sidePanelContainer.Hide();
            _sidePanelContainer.FreeSidePanel();
        }

        /// <summary>
        /// Gets whether a side panel is currently shown.
        /// </summary>
        public bool IsSidePanelOpen
        {
            get
            {
                if (_sidePanelContainer == null)
                    return false;
                if (_sidePanelContainer.IsDisposed)
                {
                    _sidePanelContainer = null;
                    return false;
                }

                return _sidePanelContainer.Visible;
            }
        }

        /// <summary>
        /// Moves the side panel based on the main form's current location.
        /// </summary>
        protected void AdjustSidePanelLocation()
        {
            if (!IsSidePanelOpen)
                return;

            _sidePanelContainer.Location = ComputeSidePanelLocation(_sidePanelContainer);
        }

        /// <summary>
        /// Computes the target location of a side panel form that ensures it is visible on the current
        /// screen that contains the main form.
        /// </summary>
        private Point ComputeSidePanelLocation(Form sidePanel)
        {
            //Check if moving the panel on the form's right would put it off-screen
            var screen = Screen.FromControl(this);
            if (Location.X + Width + sidePanel.Width > screen.WorkingArea.Right)
                return new Point(Location.X - sidePanel.Width, Location.Y);
            else
                return new Point(Location.X + Width, Location.Y);
        }

        void SidePanel_RequestClosing(object sender, EventArgs e)
        {
            CloseSidePanel();
        }

        void Thumbnail_CloneClick(object sender, CloneClickEventArgs e)
        {
            Win32.InjectFakeMouseClick(CurrentThumbnailWindowHandle.Handle, e);
        }

        #region GUI
        /// <summary>
        /// Opens the context menu.
        /// </summary>
        /// <param name="position">Optional position of the mouse, relative to which the menu is shown.</param>
        public void OpenContextMenu(Point? position)
        {
            Point menuPosition = MousePosition;
            if (position.HasValue)
                menuPosition = position.Value;

            //menuContext.Show(menuPosition);
        }

        /// <summary>
        /// Gets the window's vertical chrome size.
        /// </summary>
        public int ChromeBorderVertical
        {
            get
            {
                if (IsChromeVisible)
                    return SystemInformation.FrameBorderSize.Height;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Gets the window's horizontal chrome size.
        /// </summary>
        public int ChromeBorderHorizontal
        {
            get
            {
                if (IsChromeVisible)
                    return SystemInformation.FrameBorderSize.Width;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Displays an error task dialog.
        /// </summary>
        /// <param name="mainInstruction">Main instruction of the error dialog.</param>
        /// <param name="explanation">Detailed informations about the error.</param>
        /// <param name="errorMessage">Expanded error codes/messages.</param>
        private void ShowErrorDialog(string mainInstruction, string explanation, string errorMessage)
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

        /// <summary>
        /// Ensures that the main form is visible (either closing the fullscreen mode or reactivating from task icon).
        /// </summary>
        public void EnsureMainFormVisible()
        {
            ClickThroughEnabled = false;
        }
        #endregion

        private void Monitor_Load(object sender, EventArgs e)
        {
            WindowSeeker.Refresh();
            this.SetThumbnailGroup(WindowSeeker.Windows);
            //foreach (WindowHandle h in WindowSeeker.Windows)
            //{
                
            //}
        }
    }
}
