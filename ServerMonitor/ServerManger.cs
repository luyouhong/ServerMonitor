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

namespace ServerMonitor
{
    public partial class ServerManger : Form
    {
        #region  全局数据
        static FormAppControl myformAppControl = new FormAppControl();
        static FormServiceControl myformServiceControl = new FormServiceControl();
        static ServerMonitorIp myServerMonitorIp = new ServerMonitorIp();
        static ServerMonitorIp myServerMonitorUrl = new ServerMonitorIp();


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
                myServerMonitorIp.CheckIp = true;
                myServerMonitorIp.CheckUrl = false;
                ClassLog.Writelog(temtime.ToString(), "ServerManger.button3_Click", "myServerMonitorIp.Show() 开始IP监测 ");
                ClassLog.WritedataTodo(temtime.ToString(), "ServerManger.button3_Click", "myServerMonitorIp.Show()  开始IP监测 ");
                Debug.Print("myServerMonitorIp.Show() 开始IP监测  ");

            }
            catch (Exception ex)
            {
                ClassLog.WritedataTodo(temtime.ToString(), "ServerManger.button3_Click", "myServerMonitorIp.Show()  开始IP监测 " + ex.ToString());
                Debug.Print(ex.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime temtime = DateTime.Now;
            try
            {
                if (myformServiceControl.IsDisposed)
                {
                    myformServiceControl = new FormServiceControl();
                }
                myformServiceControl.Show();
                ClassLog.Writelog(temtime.ToString(), "ServerManger.button2_Click", "myformServiceControl.Show() 开始服务监测 ");
                ClassLog.WritedataTodo(temtime.ToString(), "ServerManger.button2_Click", " myformServiceControl.Show()  开始服务监测 ");
                Debug.Print("myformServiceControl.Show() ");

            }
            catch (Exception ex)
            {
                ClassLog.Writelog(temtime.ToString(), "ServerManger.button2_Click", " myformServiceControl.Show()  开始服务监测 " + ex.ToString());
                Debug.Print(ex.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime temtime = DateTime.Now;
            try
            {
                if (myServerMonitorUrl.IsDisposed)
                {
                    myServerMonitorUrl = new ServerMonitor.ServerMonitorIp();
                }
                myServerMonitorUrl.Show();
                myServerMonitorUrl.CheckIp = false ;
                myServerMonitorUrl.CheckUrl = true;
                ClassLog.Writelog(temtime.ToString(), "ServerManger.button4_Click", "myServerMonitorUrl.Show() 开始Url监测 ");
                ClassLog.WritedataTodo(temtime.ToString(), "ServerManger.button4_Click", "myServerMonitorUrl.Show()  开始Url监测 ");
                Debug.Print("myServerMonitorUrl.Show() 开始Url监测  ");

            }
            catch (Exception ex)
            {
                ClassLog.WritedataTodo(temtime.ToString(), "ServerManger.button4_Click", "myServerMonitorUrl.Show()  开始Url监测 " + ex.ToString());
                Debug.Print(ex.ToString());
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            python1 python1a = new python1();
            python1a.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormPython2 formPython2a = new FormPython2();
            formPython2a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormSpeech formSpeech = new FormSpeech();
            formSpeech.Show();
        }
    }
}
