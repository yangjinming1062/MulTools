﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MulTools.Components.Class
{
    public class CloneClickEventArgs : EventArgs
    {
        public Point ClientClickLocation { get; set; }

        public bool IsDoubleClick { get; set; }

        public MouseButtons Buttons { get; set; }

        public CloneClickEventArgs(Point location, MouseButtons buttons)
        {
            ClientClickLocation = location;
            Buttons = buttons;
            IsDoubleClick = false;
        }

        public CloneClickEventArgs(Point location, MouseButtons buttons, bool doubleClick)
        {
            ClientClickLocation = location;
            Buttons = buttons;
            IsDoubleClick = doubleClick;
        }
    }
}