using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Configuration;
using System.ServiceProcess;
using System.Diagnostics;
using ClassLibraryTool1;
using ServerMonitor;

namespace ServrerMonitor
{
    public partial class ServerManger : Form
    {
        #region  全局数据
        static FormAppControl myformAppControl = new FormAppControl();
        static ServerMonitorIp myServerMonitorIp = new ServerMonitorIp();


        #endregion

        public ServerManger()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime temtime= DateTime.Now;
            try
            {
                if (myformAppControl.IsDisposed) 
                {
                    myformAppControl = new FormAppControl();
                }
                myformAppControl.Show();
                ClassLog.Writelog(temtime.ToString(), "ServerManger.button1_Click", "myformAppControl.Show() 开始应用程序监测 ");
                ClassLog.WritedataTodo(temtime.ToString(), "ServerManger.button1_Click", " myformAppControl.Show()  开始应用程序监测 ");
                Debug.Print("myformAppControl.Show() ");

            }
            catch (Exception ex)
            {
                ClassLog.Writelog(temtime.ToString(), "ServerManger.button1_Click", " myformAppControl.Show()  开始应用程序监测 "+ ex.ToString());
                Debug.Print(ex.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime temtime = DateTime.Now;
            try
            {
                if (myServerMonitorIp.IsDisposed)
                {
                    myServerMonitorIp = new   ServerMonitor.ServerMonitorIp();
                }
                myServerMonitorIp.Show();
                ClassLog.Writelog(temtime.ToString(), "ServerManger.button3_Click", "myServerMonitorIp.Show() 开始IP监测 ");
                ClassLog.WritedataTodo(temtime.ToString(), "ServerManger.button3_Click", "myServerMonitorIp.Show()  开始IP监测 ");
                Debug.Print("myformAppControl.Show() 开始IP监测  ");

            }
            catch (Exception ex)
            {
                ClassLog.WritedataTodo(temtime.ToString(), "ServerManger.button3_Click", "myServerMonitorIp.Show()  开始IP监测 " + ex.ToString());
                Debug.Print(ex.ToString());
            }

        }
    }
}
