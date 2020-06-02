using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Configuration;
using System.ServiceProcess;
using System.Diagnostics;

namespace ClassLibraryTool1
{
    public class ClassMonitor
    {
        #region 检查IP 服务 网页 端口的通讯
        /// <summary>
        /// 检测IP
        /// </summary>
        /// <param name>strIP</param>
        /// <returns></returns>
        public static bool PingIP(string strIP, ref long pingReplyRoundtripTime)
        {

            try
            {
                if (!IsValidIP(strIP))
                {
                    return false;
                }
                System.Net.NetworkInformation.Ping psender = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply prep = psender.Send(strIP, 500, Encoding.Default.GetBytes("welcome_use_this_soft_write_by_airotop"));
                if (prep.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    pingReplyRoundtripTime = prep.RoundtripTime;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
                string date_str = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
                ClassLog.Writelog(date_str, " ServrerMonitor_PingIP ", ex.Message);
                
                return false;
            }

        }

        /// <summary>
        /// 验证IP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsValidIP(string ip)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(ip, "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}"))
                {
                    string[] ips = ip.Split('.');
                    if (ips.Length == 4 || ips.Length == 6)
                    {
                        if (System.Int32.Parse(ips[0]) < 256 && System.Int32.Parse(ips[1]) < 256 & System.Int32.Parse(ips[2]) < 256 & System.Int32.Parse(ips[3]) < 256)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
                string date_str = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
                ClassLog.Writelog(date_str, " ServrerMonitor_IsValidIP ", ex.Message);
                return false;
            }

        }

        /// <summary>
        ///  public bool IsStop(string 服务名) 检测服务运行
        /// </summary>
        /// <param name>服务名</param>
        /// <returns></returns>

        public static bool IsStop(string serviceNamestr)//检测服务运行
        {
            bool isStop = false;
            using (System.ServiceProcess.ServiceController control = new ServiceController(serviceNamestr))
            {
                ClassLog.WriteLog1(control.Status.ToString());
                if (control.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                {
                    isStop = true;
                }
            }
            return isStop;
        }

        /// <summary>
        ///  bool AppIsrunning(string 应用程序名) 检测应用程序运行
        /// </summary>
        /// <param name>应用程序名</param>
        /// <returns></returns>
        public static bool AppIsrunning(string processName)
        {
            bool myreturnbool = false;
            try
            {
                int c = 0;
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName == processName)
                    {
                        c += 1;
                        break;
                    }
                }
                if (c == 0)
                {
                    //Process p;
                    //p = Process.Start(path[j]);
                    myreturnbool = false;
                }
                else
                {
                    myreturnbool = true;

                }

                return myreturnbool;
            }
            catch( Exception ex)
            {
                string date_str = DateTime.Now.ToString();
                ClassLog.Writelog(date_str, " appIsrunning("+ processName + ") ", ex.Message);
                return myreturnbool;

            }

        }

        /// <summary>
        ///  bool AppIsrunning(string 应用程序名) 检测应用程序运行
        /// </summary>
        /// <param name>应用程序名</param>
        /// <returns></returns>
        public static bool StartApp(string appName,string appPath)
        {
            bool myreturnbool = false;
            try
            {
                int c = 0;
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName == appName)
                    {
                        c += 1;
                        break;
                    }
                }
                if (c == 0)
                {
                    //Process p;
                    //p = Process.Start(appPath);
                    Process mProcess = new Process();
                    mProcess.StartInfo.FileName = appName;
                    mProcess.StartInfo.WorkingDirectory = appPath.Substring(0, appName.LastIndexOf("\\"));
                    mProcess.Start();

                    myreturnbool = false;

                }
                else
                {
                    myreturnbool = true;
                }
                string date_str = DateTime.Now.ToString();
                ClassLog.WritedataTodo(date_str, " StartApp(" + appName + "," + appPath + ") ", " start! ");
                return myreturnbool;
            }
            catch (Exception ex)
            {
                string date_str = DateTime.Now.ToString();
                ClassLog.Writelog(date_str, " StartApp("+ appName+","+ appPath+") ", ex.Message);
                return myreturnbool;

            }

        }


        /// <summary>
        /// public bool KillApp1()//中止应用程序进程
        /// </summary>
        /// <param name>无</param>
        /// <returns>已经运行或正在开启状态为真</returns>
        public static bool KillApp(string appname)
        {
            try
            {
                ClassLog.WriteLog1("kill " + appname + " Start.");
                Process[] ps = Process.GetProcessesByName(appname);
                if (ps.Length > 0)
                {
                    foreach (Process p in ps)
                    {
                        p.Kill();
                        p.Close();
                    }
                        
                    
                }
                ClassLog.WriteLog1("kill " + appname + " End.");
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool KillApp( " + appname + ")  ",
                    ex.Message.ToString());
                return false;
            }
        }


        /// <summary>
        ///  IsResponse(string strUrl, string strUrldesc, int j)//检测网页响应未测试
        /// </summary>
        /// <param name>网页链接</param>
        /// <returns></returns>
        public static  bool IsResponse(string strUrl, string strUrldesc, int j)//检测网页响应
        {
            try
            {
                string str_tem;
                bool isRes = false;
                System.Net.HttpWebRequest request;
                int counter = 0;
                request = (System.Net.HttpWebRequest)WebRequest.Create(strUrl);
                request.Timeout = 10000;

                //request.Method="get";
                System.Net.HttpWebResponse response;
                while (counter < 1)
                {
                    str_tem = " " + DateTime.Now.ToString() + " " + strUrldesc + strUrl + " try connect:" + counter.ToString() + "\r\n";
                    //str_Doing = str_Doing + str_tem;
                    ClassLog.WritedataTodo(" ", " ServrerMonitor_IsResponse ", str_tem);
                    counter++;
                    try
                    {
                        response = (System.Net.HttpWebResponse)request.GetResponse();
                        Debug.Print(response.ContentLength.ToString() + response.Server.ToString());
                        isRes = true;
                        counter = 10;
                        //str_Doing = str_Doing + DateTime.Now.ToString() + " " + strUrldesc + strUrl + " connect success \r\n";
                        ClassLog.WritedataTodo(" ", " ServrerMonitor_IsResponse ", " " + strUrldesc + strUrl + " connect success \r\n");
                        break;
                    }
                    catch (WebException ex)
                    {
                        //if (Target_Url_fail_count_alarm[j] < 4)
                        //    str_Do_fail = str_Do_fail + DateTime.Now.ToString() + " " + strUrldesc + strUrl + " connect fail\r\n" + ex.Message.ToString() + "\r\n";
                        ClassLog.WritedataTodo(" ", " ServrerMonitor_IsResponse ", " " + strUrldesc + strUrl + " connect fail \r\n" + ex.Message.ToString() + "\r\n");
                        ClassLog.Writedata(" ", " ServrerMonitor_IsResponse ", " " + strUrldesc + strUrl + " connect fail \r\n" + ex.Message.ToString() + "\r\n");
                        //Thread.Sleep(3000);
                    }
                }
                return isRes;
            }
            catch (Exception ex)
            {
                string date_str = DateTime.Now.ToString();
                ClassLog.Writelog(date_str, " ServrerMonitor_IsResponse " + strUrldesc, ex.Message);
                return false;
            }

        }

        #endregion


        private void TimerCall(object obj)//暂时不用杀进程
        {
            try
            {
                if (IsStop("serviceName"))
                {
                    using (System.ServiceProcess.ServiceController control = new ServiceController("serviceName"))
                    {
                        control.Start();
                    }
                }
                else if (!IsResponse("strUrl", "miaoshu", 0))
                {
                    Process[] processes = Process.GetProcessesByName("exeName");

                    foreach (Process p in processes)
                    {
                        ClassLog.WriteLog1("kill Start.");
                        p.Kill();
                        p.Close();
                        ClassLog.WriteLog1("kill end.");
                    }
                }
            }
            catch (Exception ex)
            {
                ClassLog.WriteLog1(ex.ToString());
            }

        }

    }
}
