using MulTools.Function;
using MulTools.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MulTools
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private Form _frm;
        private Form CurrentForm
        {
            get { return _frm; }
            set
            {
                _frm = value;
                if (!Settings.Default.Menu功能多开)
                {
                    for (int i = 4; i < contextMenuStrip.Items.Count; i++)
                    {
                        contextMenuStrip.Items[i].Enabled = value == null;
                    }
                    foreach(Button bt in tbPanel.Controls)
                    {
                        bt.Enabled = value == null;
                    }
                }
            }
        }
        /// <summary>
        /// 按钮点击事件（所有按钮都绑定此事件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            string name = sender.GetType() == typeof(Button) ? ((Button)sender).Text : ((ToolStripItem)sender).Text;
            CurrentForm = frmFactory.GetForm(name);
            Visible = false;
            DialogResult ds = CurrentForm.ShowDialog();
            if (ds == DialogResult.Cancel || ds == DialogResult.No)
                try
                {
                    CurrentForm = null;
                    Visible = true;
                }
                catch { }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (CurrentForm == null)
            {
                if (WindowState == FormWindowState.Minimized)
                    ActiveWindow();
                else
                {
                    WindowState = FormWindowState.Minimized;
                    Hide();
                }
            }
            else
            {
                CurrentForm.Show();
                CurrentForm.WindowState = FormWindowState.Normal;
                CurrentForm.Activate();
            }
        }

        private void ActiveWindow()
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            List<string> frmName = new List<string>() { "进程专杀", "定时关机", "文件操作", "IP速换", "屏幕截图", "窗体监控" };
            for (int i = 0; i < frmName.Count; i++)
            {
                Button bt = new Button();
                bt.Text = frmName[i];
                bt.Dock = DockStyle.Fill;
                bt.Click += MenuItem_Click;
                tbPanel.Controls.Add(bt, i % tbPanel.ColumnCount, i / tbPanel.RowCount);
            }
        }

        private void tmiMenu_Click(object sender, EventArgs e)
        {
            if (CurrentForm == null)
                ActiveWindow();
            else
            {
                if(MessageBox.Show("当前有已经打开的功能界面，选择 是 关闭并进入菜单界面，选择 否 激活功能界面", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CurrentForm.Close();
                    CurrentForm = null;
                }
                else
                {
                    CurrentForm.Show();
                    CurrentForm.WindowState = FormWindowState.Normal;
                    CurrentForm.Activate();
                }
            }
        }

        private void tmiClose_Click(object sender, EventArgs e) => Close();

        private void tmiSet_DropDownOpening(object sender, EventArgs e)
        {
            cmbSetFunc.Text = Settings.Default.Menu功能多开 ? "是" : "否";
            cmbSetEXE.Text = Settings.Default.Menu程序多开 ? "是" : "否";
        }

        private void tmiSet_DropDownClosed(object sender, EventArgs e)
        {
            if (!cmbSetFunc.Text.Equals("是") && Settings.Default.Menu功能多开)//从允许多开到不允许多开变化的时候
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name != "frmMenu")
                        f.Close();
                }
            }
            Settings.Default.Menu功能多开 = cmbSetFunc.Text.Equals("是");
            Settings.Default.Menu程序多开 = cmbSetEXE.Text.Equals("是");
        }
    }
}
