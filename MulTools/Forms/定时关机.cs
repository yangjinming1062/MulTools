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
                        this.Opacity = (this.Opacity + 0.1) % 1;
                        break;
                    case 1063:
                        if (this.Opacity < 1)
                            this.Opacity = 1;
                        else
                            this.Opacity = 0;
                        break;
                    case 1064:
                        if (this.Opacity > 0.5)
                            this.Close();
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
                    DateTime dateTime = (DateTime)((DateTimePicker)(sender)).Value;
                    int time = (dateTime.Hour * 60 + dateTime.Minute) * 60000 + dateTime.Second * 1000;
                    this.timerClose = new System.Timers.Timer(Convert.ToDouble(time));
                }
                else
                {
                    TimeSpan span = (DateTime)((DateTimePicker)(sender)).Value - DateTime.Now;
                    if (span.Milliseconds < 0)
                        span = ((DateTime)((DateTimePicker)(sender)).Value).AddDays(1) - DateTime.Now;
                    this.timerClose = new System.Timers.Timer(Convert.ToDouble(span.TotalMilliseconds));
                }
                this.timerClose.Start();
                this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height;
                this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width;
            }
            if (e.KeyCode == Keys.Space)
                Functions.DoExitWin(Win32.EWX_SHUTDOWN);
        }

        private void 定时关机_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;
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
            if (cbJS.Checked)
            {
                this.dtp.Value = DateTime.Now.Date;
            }
            else
            {
                this.dtp.Value = DateTime.Now;
            }
        }
    }
}
