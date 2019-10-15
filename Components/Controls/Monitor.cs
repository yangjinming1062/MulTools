using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MulTools.Components.Function;
using MulTools.Components.Class;
using MulTools.Components.Enums;

namespace MulTools.Components
{
    public partial class Monitor : AspectRatioForm
    {
        public ThumbnailPanel ThumbnailPanel { get; }

        public WindowHandle CurrentThumbnailWindowHandle { get; set; }

        public MessagePumpManager MessagePumpManager { get; } = new MessagePumpManager();

        public BaseWindowSeeker WindowSeeker { get; set; }

        private NotifyIcon taskIcon;

        public Monitor()
        {
            InitializeComponent();
            DefaultNonClickTransparencyKey = this.TransparencyKey;
            DefaultBorderStyle = this.FormBorderStyle;
            ThumbnailPanel = new ThumbnailPanel
            {
                Location = Point.Empty,
                Dock = DockStyle.Fill
            };
            Controls.Add(ThumbnailPanel);
            this.KeyPreview = true;
            WindowSeeker = new TaskWindowSeeker()
            {
                OwnerHandle = this.Handle,
                SkipNotVisibleWindows = true
            };
            //分水岭
            taskIcon = new NotifyIcon
            {
                Text = "窗体监控",
                Icon = Icon,
                Visible = true,
                ContextMenuStrip = MenuStrip
            };
            taskIcon.DoubleClick += new EventHandler(TaskIcon_doubleclick);
            ContextMenuStrip = MenuStrip;//传递指针进来构造的，不给右键菜单
            ShowInTaskbar = true;
        }

        public Monitor(IntPtr h)
        {
            InitializeComponent();
            DefaultNonClickTransparencyKey = this.TransparencyKey;
            DefaultBorderStyle = this.FormBorderStyle;

            ThumbnailPanel = new ThumbnailPanel
            {
                Location = Point.Empty,
                Dock = DockStyle.Fill
            };
            Controls.Add(ThumbnailPanel);
            this.KeyPreview = true;

            WindowSeeker = new TaskWindowSeeker()
            {
                OwnerHandle = this.Handle,
                SkipNotVisibleWindows = true
            };
            WindowHandle w = new WindowHandle(h);
            this.SetThumbnail(w, null);
        }

        void TaskIcon_doubleclick(object sender, EventArgs e) => ClickThroughEnabled = false;//强制取消点击穿透

        #region Event override
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            KeepAspectRatio = false;
            GlassMargins = new Padding(-1);
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
            if (taskIcon != null)
                taskIcon.Dispose();
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
            if (ThumbnailPanel.IsShowingThumbnail)
                SetAspectRatio(ThumbnailPanel.ThumbnailPixelSize, false);
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

            if (ThumbnailPanel.IsShowingThumbnail)
                SetAspectRatio(ThumbnailPanel.ThumbnailPixelSize, false);

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
                else
                {
                    if (taskIcon != null)
                        taskIcon.Dispose();
                    this.Dispose();
                }
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
                ThumbnailPanel.SetThumbnailHandle(handle, region);

                //Set aspect ratio (this will resize the form), do not refresh if in fullscreen
                SetAspectRatio(ThumbnailPanel.ThumbnailPixelSize, true);
            }
            catch (Exception ex)
            {
                ThumbnailError(ex, false, "无法创建缩略图");
                ThumbnailPanel.UnsetThumbnail();
            }
        }

        /// <summary>
        /// Disables the cloned thumbnail.
        /// </summary>
        public void UnsetThumbnail()
        {
            CurrentThumbnailWindowHandle = null;
            ThumbnailPanel.UnsetThumbnail();
            KeepAspectRatio = false;
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
                Size originalSize = ThumbnailPanel.ThumbnailPixelSize;
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
                    menuitem_ClickThrough.Checked = value;
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
            {
                this.Opacity = ClickThroughHoverOpacity;
            }

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
                    {
                        this.Opacity = 1.0;
                    }
                    _clickThroughComeBackTimer.Stop();
                }
            }
        }
        #endregion

        #region 选择区域
        //SidePanel _currentSidePanel = null;
        SidePanelContainer _sidePanelContainer = null;

        /// <summary>
        /// Opens a new side panel.
        /// </summary>
        /// <param name="panel">The side panel to embed.</param>
        public void SetSidePanel(SidePanel panel)
        {
            if (IsSidePanelOpen)
            {
                CloseSidePanel();
            }

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

        protected void AdjustSidePanelLocation()
        {
            if (!IsSidePanelOpen)
                return;

            _sidePanelContainer.Location = ComputeSidePanelLocation(_sidePanelContainer);
        }

        private Point ComputeSidePanelLocation(Form sidePanel)
        {
            var screen = Screen.FromControl(this);
            return (Location.X + Width + sidePanel.Width > screen.WorkingArea.Right) ? 
                new Point(Location.X - sidePanel.Width, Location.Y) : new Point(Location.X + Width, Location.Y);
        }

        /// <summary>
        /// Gets or sets the region displayed of the current thumbnail.
        /// </summary>
        public ThumbnailRegion SelectedThumbnailRegion
        {
            get
            {
                if (!ThumbnailPanel.IsShowingThumbnail || !ThumbnailPanel.ConstrainToRegion)
                    return null;
                return ThumbnailPanel.SelectedRegion;
            }
            set
            {
                if (!ThumbnailPanel.IsShowingThumbnail)
                    return;

                ThumbnailPanel.SelectedRegion = value;
                SetAspectRatio(ThumbnailPanel.ThumbnailPixelSize, true);
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
            {
                Width = screen.WorkingArea.Width - FixMargin;
            }
            if (Height > screen.WorkingArea.Height)
            {
                Height = screen.WorkingArea.Height - FixMargin;
            }
            if (Location.X + Width > screen.WorkingArea.Right)
            {
                Location = new Point(screen.WorkingArea.Right - Width - FixMargin, Location.Y);
            }
            if (Location.Y + Height > screen.WorkingArea.Bottom)
            {
                Location = new Point(Location.X, screen.WorkingArea.Bottom - Height - FixMargin);
            }
        }
        #endregion

        #region 显示边框
        readonly FormBorderStyle DefaultBorderStyle; // = FormBorderStyle.Sizable; // FormBorderStyle.SizableToolWindow;

        public bool IsBorderVisible
        {
            get => (FormBorderStyle == DefaultBorderStyle);
            set
            {
                //Cancel hiding chrome if no thumbnail is shown
                if (!value && !ThumbnailPanel.IsShowingThumbnail)
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
            if (PositionLock.HasValue)//If locked in position, move accordingly
                this.SetScreenPosition(PositionLock.Value);
        }
        #endregion

        #region 菜单
        public void OpenContextMenu(Point? position)
        {
            Point menuPosition = MousePosition;
            if (position.HasValue)
                menuPosition = position.Value;
            MenuStrip.Show(menuPosition);
        }

        private void IsShowBorder_Click(object sender, EventArgs e) => IsBorderVisible = !IsBorderVisible;

        private void MenuStrip_Opening(object sender, CancelEventArgs e)
        {
            bool showing = ThumbnailPanel.IsShowingThumbnail;
            menuitem_IsShowBorder.Checked = IsBorderVisible;
            menuItem_Region.Enabled = showing;
            menuitem_ClickThrough.Enabled = showing;
        }

        private void ClickThrough_Click(object sender, EventArgs e) => ClickThroughEnabled = !ClickThroughEnabled;

        private void PositionLock_Click(object sender, EventArgs e)
        {
            switch(((ToolStripMenuItem)sender).Text)
            {
                case "不锁定": PositionLock = null;break;
                case "左上": PositionLock = ScreenPosition.TopLeft; break;
                case "右上": PositionLock = ScreenPosition.TopRight; break;
                case "中间": PositionLock = ScreenPosition.Center; break;
                case "左下": PositionLock = ScreenPosition.BottomLeft; break;
                case "右下": PositionLock = ScreenPosition.BottomRight; break;
            }
        }

        private void Opacity_Click(object sender, EventArgs e) => this.Opacity = this.Visible ? Convert.ToDouble(((ToolStripMenuItem)sender).Tag) : this.Opacity;

        private void Close_Click(object sender, EventArgs e) => Close();

        private void Region_Click(object sender, EventArgs e) => SetSidePanel(new RegionPanel());

        private void Minimize_Click(object sender, EventArgs e)
        {
            if (menuItem_minimize.Text == "最小化")
            {
                WindowState = FormWindowState.Minimized;
                MenuItemVisable(false);
                menuItem_minimize.Text = "恢复显示";
            }
            else
            {
                menuItem_minimize.Text = "最小化";
                MenuItemVisable(true);
                WindowState = FormWindowState.Normal;
            }
        }

        private void MenuItemVisable(bool visable)
        {
            menuitem_Select.Visible = visable;
            menuitem_IsShowBorder.Visible = visable;
            menuitem_Opacity.Visible = visable;
            menuitem_PositionLock.Visible = visable;
            menuItem_Region.Visible = visable;
            menuitem_ClickThrough.Visible = visable;
            tsSeparator1.Visible = visable;
        }

        private void SelectWindows_DropDownOpening(object sender, EventArgs e)
        {
            WindowSeeker.Refresh();
            menuitem_Select.DropDownItems.Clear();
            foreach (WindowHandle h in WindowSeeker.Windows)
            {
                var tsi = new ToolStripMenuItem();

                if (h.Title.Length > 60)
                {
                    tsi.Text = h.Title.Substring(0, 60) + "...";
                    tsi.ToolTipText = h.Title;
                }
                else
                    tsi.Text = h.Title;

                if (h.Icon != null)
                    tsi.Image = h.Icon.ToBitmap();

                tsi.Checked = h.Equals(CurrentThumbnailWindowHandle);
                tsi.Tag = h;
                tsi.Click += MenuWindowClickHandler;

                menuitem_Select.DropDownItems.Add(tsi);
            }
        }

        private void MenuWindowClickHandler(object sender, EventArgs args)
        {
            var tsi = (ToolStripMenuItem)sender;
            if (tsi.Tag == null)
                UnsetThumbnail();
            else
                SetThumbnail((WindowHandle)tsi.Tag, null);
        }
        #endregion
    }
}
