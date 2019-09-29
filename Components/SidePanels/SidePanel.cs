using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WindowsFormsAero.Dwm;
using System.Drawing;

namespace MulTools.Components
{

    /// <summary>
    /// Represents a side panel that can be embedded in OnTopReplica.
    /// </summary>
    public class SidePanel : UserControl
    {

        public SidePanel()
        {
            this.FixDefaultFont();
        }

        protected override void OnCreateControl()
        {
            if (!DesignMode)
                Dock = DockStyle.Fill;

            base.OnCreateControl();
        }

        /// <summary>
        /// Gets the panel's parent form.
        /// </summary>
        protected Monitor ParentMainForm { get; private set; }

        /// <summary>
        /// Raised when the side panel requests to be closed.
        /// </summary>
        public event EventHandler RequestClosing;

        protected virtual void OnRequestClosing()
        {
            RequestClosing?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Is called when the side panel is embedded and first shown.
        /// </summary>
        /// <param name="form">Parent form that is embedding the side panel.</param>
        public virtual void OnFirstShown(Monitor form)
        {
            ParentMainForm = form;
        }

        /// <summary>
        /// Is called before removing the side panel.
        /// </summary>
        /// <param name="form">Parent form that is embedding the side panel.</param>
        public virtual void OnClosing(AspectRatioForm form)
        {
        }

        /// <summary>
        /// Gets the side panel's title.
        /// </summary>
        public virtual string Title => "Side panel";

        /// <summary>
        /// Gets the panel's desired glass margins.
        /// </summary>
        public virtual Padding GlassMargins => Padding.Empty;
    }
}
