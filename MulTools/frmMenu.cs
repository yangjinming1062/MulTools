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
        /// <summary>
        /// 菜单按钮点击事件（所以按钮都绑定此事件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            Form frm = frmFactory.GetForm(((ToolStripItem)sender).Text);
            Visible = false;
            DialogResult ds = frm.ShowDialog();
            if (ds == DialogResult.Cancel || ds == DialogResult.No)
                Visible = true;
        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
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
    }
}
