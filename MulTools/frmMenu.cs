using MulTools.Function;
using System;
using System.Windows.Forms;

namespace MulTools
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        Form frm;//因为菜单一次只提供一个功能，把具体功能窗体作为全局变量，大家都通过一个NotifyIcon实现显示
        /// <summary>
        /// 菜单按钮点击事件（所以按钮都绑定此事件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            frm = frmFactory.GetForm(((ToolStripItem)sender).Text);
            Visible = false;
            DialogResult ds = frm.ShowDialog();
            if (ds == DialogResult.Cancel || ds == DialogResult.No)
                try
                {
                    frm = null;
                    Visible = true;
                }
                catch { }
        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
        {
            if (frm == null)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    Show();
                    WindowState = FormWindowState.Normal;
                    Activate();
                }
                else
                {
                    WindowState = FormWindowState.Minimized;
                    Hide();
                }
            }
            else
            {
                frm.WindowState = FormWindowState.Normal;
                frm.Show();
                frm.Activate();
            }
        }
    }
}
