using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MulTools.Forms
{
    public partial class 进程专杀 : Form
    {
        public 进程专杀()
        {
            InitializeComponent();
        }
        private System.Timers.Timer timerKill;//定时查杀则一秒杀一次

        private void Kill()
        {
            if (string.IsNullOrEmpty(txtName.Text))
                return;
            string[] killList = txtName.Text.Replace("!", "").Split(',');
            Process[] pro = Process.GetProcesses();
            try
            {
                foreach (Process temp in pro)
                {
                    foreach (string killName in killList)
                    {
                        if (temp.ProcessName.Equals(killName))
                            temp.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("由于：" + ex.Message + " 原因，我没能杀死制定进程，Sorry~");
            }
        }

        private void BtKill_Click(object sender, EventArgs e)
        {
            if (txtName.Text.StartsWith("!"))
            {
                timerKill.Start();
            }
            else
            {
                timerKill.Stop();
                Kill();
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtKill_Click(null, null);
        }

        private void 进程专杀_Load(object sender, EventArgs e)
        {
            Top = Screen.PrimaryScreen.WorkingArea.Height - Size.Height;
            Left = Screen.PrimaryScreen.WorkingArea.Width - Size.Width;
            TopMost = true;
            timerKill = new System.Timers.Timer(Properties.Settings.Default.K_查杀间隔);
            timerKill.Elapsed += TimerKill_Elapsed;
            txtName.Focus();
            txtDefaultName.Text = Properties.Settings.Default.K_默认进程;
            txtName.Text = Properties.Settings.Default.K_默认进程;
            txtSpantime.Text = Properties.Settings.Default.K_查杀间隔.ToString();
        }

        private void 进程专杀_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.K_默认进程 = txtDefaultName.Text;
            Properties.Settings.Default.K_查杀间隔 = Convert.ToInt32(txtSpantime.Text);
        }

        private void TimerKill_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Kill();
        }

        private void menuItemHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("在文本框中输入待查杀进程名称点击“杀”即可\n当需要查杀多个进程，每个名字之间以\",\"间隔\n文本框以\"!\"号开头表示循环查杀（间隔配置单位毫秒）", "使用说明");
        }
    }
}
