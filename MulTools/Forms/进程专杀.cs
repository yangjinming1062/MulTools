using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace MulTools.Forms
{
    public partial class 进程专杀 : Form
    {
        public 进程专杀()
        {
            InitializeComponent();
        }
        private System.Timers.Timer timerKill = new System.Timers.Timer(1000);//定时查杀则一秒杀一次

        private void Kill()
        {
            if (string.IsNullOrEmpty(this.txtName.Text))
                return;
            string[] killList = this.txtName.Text.Replace("!","").Split(',');
            Process[] pro = Process.GetProcesses();
            try
            {
                foreach (var temp in pro)
                {
                    foreach (string killName in killList)
                    {
                        if (temp.ProcessName.Contains(killName))
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
            if(this.txtName.Text.StartsWith("!"))
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
            this.Close();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtKill_Click(null, null);
        }

        private void 进程专杀_Load(object sender, EventArgs e)
        {
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width;
            this.TopMost = true;
            timerKill.Elapsed += TimerKill_Elapsed;
        }

        private void TimerKill_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Kill();
        }
    }
}
