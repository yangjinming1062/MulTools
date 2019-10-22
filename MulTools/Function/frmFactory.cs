using System;
using System.Windows.Forms;

namespace MulTools.Function
{
    public class frmFactory
    {
        public static Form GetForm(string name)
        {
            Form frm;
            switch (name)
            {
                case "窗体监控": frm = new Components.Monitor(); break;
                default: frm = (Form)Activator.CreateInstance(Type.GetType("MulTools.Forms." + name)); break;
            }
            return frm;
        }
    }
}
