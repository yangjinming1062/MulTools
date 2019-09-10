using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MulTools.Function;

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
            var frm = frmFactory.GetForm(((ToolStripItem)sender).Text);
            this.Visible = false;
            DialogResult ds = frm.ShowDialog();
            if (ds == DialogResult.Cancel || ds == DialogResult.No)
                this.Visible = true;
        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }
    }
}
