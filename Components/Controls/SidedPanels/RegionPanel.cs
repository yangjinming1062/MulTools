using System;
using System.Drawing;
using System.Windows.Forms;

namespace MulTools.Components
{
    partial class RegionPanel : SidePanel
    {
        public RegionPanel()
        {
            InitializeComponent();
            this.SuspendLayout();
            UpdateRegionLabels();
            this.ResumeLayout();

            _regionDrawnHandler = new ThumbnailPanel.RegionDrawnHandler(ThumbnailPanel_RegionDrawn);
        }
        public override string Title => "选择区域…";

        ThumbnailPanel.RegionDrawnHandler _regionDrawnHandler;

        // Used to signal to the value change handler that all events should be temporarily ignored.
        bool _ignoreValueChanges = false;

        /// <summary>
        /// Updates the labels for the region value selectors and the relative mode checkbox.
        /// </summary>
        private void UpdateRegionControls(ThumbnailRegion region)
        {
            checkRelative.Checked = region.Relative;

            if (region.Relative)
            {
                Padding p = region.BoundsAsPadding;
                numX.Value = p.Left;
                numY.Value = p.Top;
                numW.Value = p.Right;
                numH.Value = p.Bottom;
            }
            else
            {
                Rectangle r = region.Bounds;
                numX.Value = r.X;
                numY.Value = r.Y;
                numW.Value = r.Width;
                numH.Value = r.Height;
            }
            UpdateRegionLabels();
        }

        private void UpdateRegionLabels()
        {
            if (checkRelative.Checked)
            {
                labelX.Text = "左";
                labelY.Text = "上";
                labelWidth.Text = "右";
                labelHeight.Text = "下";
            }
            else
            {
                labelX.Text = "X";
                labelY.Text = "Y";
                labelWidth.Text = "宽度";
                labelHeight.Text = "高度";
            }
        }

        public override void OnFirstShown(Monitor form)
        {
            base.OnFirstShown(form);
            //Init shown region if current thumbnail is clipped to region
            if (form.SelectedThumbnailRegion != null)
            {
                SetRegion(form.SelectedThumbnailRegion);
            }
            form.ThumbnailPanel.DrawMouseRegions = true;
            form.ThumbnailPanel.RegionDrawn += _regionDrawnHandler;
        }

        public override void OnClosing(Monitor form)
        {
            base.OnClosing(form);
            form.ThumbnailPanel.DrawMouseRegions = false;
            form.ThumbnailPanel.RegionDrawn -= _regionDrawnHandler;
        }

        void ThumbnailPanel_RegionDrawn(object sender, ThumbnailRegion region) => SetRegion(region);

        #region Interface
        /// <summary>
        /// Sets the current selected region to a specific region rectangle.
        /// </summary>
        /// <param name="region">The region boundaries.</param>
		public void SetRegion(ThumbnailRegion region)
        {
            try
            {
                _ignoreValueChanges = true;
                UpdateRegionControls(region);
                numX.Enabled = numY.Enabled = numW.Enabled = numH.Enabled = true;
            }
            finally
            {
                _ignoreValueChanges = false;
            }
            OnRegionSet(region);
        }

        /// <summary>
        /// Resets the selected region and disables the num spinners.
        /// </summary>
		public void Reset()
        {
            try
            {
                _ignoreValueChanges = true;

                numX.Value = numY.Value = numW.Value = numH.Value = 0;
                numX.Enabled = numY.Enabled = numW.Enabled = numH.Enabled = false;
                checkRelative.Checked = false;
                UpdateRegionLabels();
            }
            finally
            {
                _ignoreValueChanges = false;
            }
        }
        #endregion

        /// <summary>
        /// Constructs a ThumbnailRegion from the dialog's current state.
        /// </summary>
        protected ThumbnailRegion ConstructCurrentRegion()
        {
            Rectangle bounds = new Rectangle
            {
                X = (int)numX.Value,
                Y = (int)numY.Value,
                Width = (int)numW.Value,
                Height = (int)numH.Value
            };

            ThumbnailRegion newRegion = new ThumbnailRegion(bounds, checkRelative.Checked);
            return newRegion;
        }

        protected virtual void OnRegionSet(ThumbnailRegion region) => ParentMainForm.SelectedThumbnailRegion = region;//Forward region to thumbnail

        #region GUI event handlers

        private void Close_click(object sender, EventArgs e) => OnRequestClosing();

        private void Reset_click(object sender, EventArgs e)
        {
            Reset();
            ParentMainForm.SelectedThumbnailRegion = null;
        }

        private void RegionValueSpinner_value_change(object sender, EventArgs e)
        {
            if (_ignoreValueChanges)
                return;

            OnRegionSet(ConstructCurrentRegion());
        }

        private void CheckRelative_checked(object sender, EventArgs e)
        {
            if (_ignoreValueChanges)
                return;

            //Get current region and switch mode
            var region = ConstructCurrentRegion();
            region.Relative = !region.Relative; //this must be reversed because the GUI has already switched state when calling ConstructCurrentRegion()
            if (checkRelative.Checked)
                region.SwitchToRelative(ParentMainForm.ThumbnailPanel.ThumbnailOriginalSize);
            else
                region.SwitchToAbsolute(ParentMainForm.ThumbnailPanel.ThumbnailOriginalSize);

            SetRegion(region);//Update GUI
        }
        #endregion
    }
}
