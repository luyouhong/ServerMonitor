using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServrerMonitor;

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
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerManger());
            Application.ApplicationExit += Application_ApplicationExit; 

        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {

            throw new NotImplementedException();
        }
    }
}
