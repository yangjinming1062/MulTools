using MulTools.Components.Class;
using MulTools.Components.Enums;
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
        private KeyboardHook keyboardHook = new KeyboardHook();// 键盘钩子

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
                Opacity = 0;
            }
            if (e.KeyCode == Keys.Space)
                Components.Functions.DoExitWin(EWX.EWX_SHUTDOWN);
        }

        private void TimerClose_Elapsed(object sender, System.Timers.ElapsedEventArgs e) => Components.Functions.DoExitWin(EWX.EWX_SHUTDOWN);

        private void 定时关机_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
            keyboardHook.KeyDown += KeyboardHook_KeyDown;
            keyboardHook.Start();
        }

        private void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.G)
                Opacity = (Opacity + 0.1) % 1;
            if (e.Alt && e.KeyCode == Keys.J)
                Opacity = Opacity < 1 ? 1 : 0;
            if (e.KeyCode == Keys.Escape && Opacity > 0.5)
                Close();
        }

        private void CbJS_CheckedChanged(object sender, EventArgs e) => dtp.Value = cbJS.Checked ? DateTime.Now.Date : DateTime.Now;
    }
}
