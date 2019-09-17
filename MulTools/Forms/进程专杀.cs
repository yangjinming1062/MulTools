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
        private readonly System.Timers.Timer timerKill = new System.Timers.Timer(1000);//定时查杀则一秒杀一次

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
            timerKill.Elapsed += TimerKill_Elapsed;
            txtName.Focus();
        }

        private void TimerKill_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Kill();
        }
    }
}
