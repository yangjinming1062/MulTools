using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MulTools
{
    public static class WinFactory
    {
        public static Window GetWindow(string name)
        {
            Window win;
            switch (name)
            {
                default: win = (Window)Activator.CreateInstance(Type.GetType("MulTools.Win." + name)); break;
            }
            return win;
        }
    }
}
