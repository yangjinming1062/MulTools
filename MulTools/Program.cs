using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace MulTools
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            if(!Properties.Settings.Default.Menu程序多开)
            {
                Process current = Process.GetCurrentProcess();
                //防止程序被改名，按文件的名称去查找
                Process[] pro = Process.GetProcessesByName(current.ProcessName);
                try
                {
                    foreach (Process temp in pro)
                    {
                        if (temp.Id != current.Id)
                            temp.Kill();
                    }
                }
                catch { }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMenu());
        }
    }
}
