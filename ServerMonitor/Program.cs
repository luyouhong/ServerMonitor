using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerMonitor;
using System.Diagnostics;
namespace ServerMonitor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Check();
            #region 检测是否已经打开
            Process[] processes = Process.GetProcesses();
            int c = 0;
            foreach (Process process in processes)
            {
                if (process.ProcessName == "ServerMonitor")
                    c += 1;
            }
            #endregion
            if (c > 1)
            {
                MessageBox.Show("服务器监测程序已经开启！请勿重复打开！");
                Application.Exit();
            }
            else
            { 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ServerManger());
                Application.ApplicationExit += Application_ApplicationExit;
            }
            
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {

            throw new NotImplementedException();
        }
    }
}
