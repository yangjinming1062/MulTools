using MulTools.Components.Function;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MulTools.Forms
{
    public partial class 定时关机 : Form
    {
        public 定时关机()
        {
            InitializeComponent();
        }

        private System.Timers.Timer timerClose = null;
        /// <summary>
        /// 实现热键功能
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Win32.WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case 1062:
                        Opacity = (Opacity + 0.1) % 1;
                        break;
                    case 1063:
                        if (Opacity < 1)
                            Opacity = 1;
                        else
                            Opacity = 0;
                        break;
                    case 1064:
                        if (Opacity > 0.5)
                            Close();
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void Dtp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbJS.Checked)
                {
                    DateTime dateTime = ((DateTimePicker)(sender)).Value;
                    int time = (dateTime.Hour * 60 + dateTime.Minute) * 60000 + dateTime.Second * 1000;
                    timerClose = new System.Timers.Timer(Convert.ToDouble(time));
                }
                else
                {
                    TimeSpan span = ((DateTimePicker)(sender)).Value - DateTime.Now;
                    if (span.Milliseconds < 0)
                        span = ((DateTimePicker)(sender)).Value.AddDays(1) - DateTime.Now;
                    timerClose = new System.Timers.Timer(Convert.ToDouble(span.TotalMilliseconds));
                }
                timerClose.Elapsed += TimerClose_Elapsed;
                timerClose.Start();
                Top = Screen.PrimaryScreen.WorkingArea.Height - Size.Height;
                Left = Screen.PrimaryScreen.WorkingArea.Width - Size.Width;
            }
            if (e.KeyCode == Keys.Space)
                Components.Functions.DoExitWin(Win32.EWX_SHUTDOWN);
        }

        private void TimerClose_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Components.Functions.DoExitWin(Win32.EWX_SHUTDOWN);
        }

        private void 定时关机_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            Win32.RegisterHotKey(Handle, 1062, 0x0004, Keys.J);
            Win32.RegisterHotKey(Handle, 1063, 0x0004, Keys.G);
            Win32.RegisterHotKey(Handle, 1064, 0, Keys.Escape);
        }

        private void 定时关机_FormClosed(object sender, FormClosedEventArgs e)
        {
            Win32.UnregisterHotKey(Handle, 100);//释放热键
        }

        private void CbJS_CheckedChanged(object sender, EventArgs e)
        {
            dtp.Value = cbJS.Checked ? DateTime.Now.Date : DateTime.Now;
        }
    }
}
