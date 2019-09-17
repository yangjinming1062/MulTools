using MulTools.Forms;
using System.Windows.Forms;

namespace MulTools.Function
{
    public class frmFactory
    {
        public static Form GetForm(string name)
        {
            Form frm = null;
            switch (name)
            {
                case "进程专杀": frm = new 进程专杀(); break;
                case "定时关机": frm = new 定时关机(); break;
                case "文件操作": frm = new 文件操作(); break;
                case "IP速换": frm = new IP速换(); break;
            }
            return frm;
        }
    }
}
