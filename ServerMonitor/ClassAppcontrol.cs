using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using ClassLibraryTool1;
using System.Threading;
using System.Windows;
using System.Timers;

namespace ServerMonitor
{
    class ClassAppcontrol
    {
        #region 变量定义
        string app1Name = "";
        string app1Path = "";
        string app1Status = "";
        bool app1Statusbool = false;
        bool app1WaitStart = false;
        bool app1DayRestart = false;
        bool app1DayRestart1 = false;
        bool app1DayRestart2 = false;
        int app1Count0 = 100;
        int app1Count = 0;
        int app1DayRestartHour = 4;
        int app1DayRestartMinute = 0;
        int app1DayRestartCount = 3600;
        DateTime app1DayRestartDT;
        static int aTimercount1 = 0;
        DateTime TimercountDT = DateTime.Now;

        System.Timers.Timer aTimer = new System.Timers.Timer();
        public string App1Path { get => app1Path; set => app1Path = value; }
        public string App1Status { get => app1Status; set => app1Status = value; }
        public bool App1Statusbool { get => app1Statusbool; set => app1Statusbool = value; }
        /// <summary>
        ///  设置的等待应用程序重启的秒数
        /// </summary>
        public int App1Count0 { get => app1Count0; set => app1Count0 = value; }
        /// <summary>
        ///  当前等待应用程序重启的秒数
        /// </summary>
        public int App1Count { get => app1Count; set => app1Count = value; }
        /// <summary>
        ///  应用程序名
        /// </summary>
        public string App1Name { get => app1Name; set => app1Name = value; }
        /// <summary>
        ///  应用程序自动重启标志
        /// </summary>
        public bool App1WaitStart { get => app1WaitStart; set => app1WaitStart = value; }
        /// <summary>
        ///  应用程序每天自动重启标志
        /// </summary>
        public bool App1DayRestart { get => app1DayRestart; set => app1DayRestart = value; }
        /// <summary>
        ///  应用程序每天自动重启小时
        /// </summary>
        public int App1DayRestartHour { get => app1DayRestartHour; set => app1DayRestartHour = value; }
        /// <summary>
        ///  应用程序每天自动重启分钟小于57
        /// </summary>
        public int App1DayRestartMinute { get => app1DayRestartMinute; set => app1DayRestartMinute = value; }
        /// <summary>
        ///  应用程序每天自动重启倒计时
        /// </summary>
        public int App1DayRestartCount { get => app1DayRestartCount; set => app1DayRestartCount = value; }
        public DateTime App1DayRestartDT { get => app1DayRestartDT; set => app1DayRestartDT = value; }

        #endregion
        #region 初始化数据
        /// <summary>
        ///  getInitData( )//初始化数据
        /// </summary>
        /// <param name>无</param>
        /// <returns></returns>
        public bool getInitData()
        {
            try
            {
                //int i;
                var appSettings = ConfigurationManager.AppSettings;
                ClassLog.Writedata(DateTime.Now.ToString(), " ClassAppcontrol_Run ", "  starting");
                ClassLog.WritedataTodo(DateTime.Now.ToString(), " ClassAppcontrol_Run ", "  starting");
                ClassLog.Writelog(DateTime.Now.ToString(), " ClassAppcontrol_Run ", "  starting");

                app1Name = appSettings["AppName1"] ?? "";
                app1Path = appSettings["AppPath1"] ?? "";
                app1Count0 = int.Parse(appSettings["Services1Count0"] ?? "-1");
                app1DayRestartHour = int.Parse(appSettings["App1DayRestartHour"] ?? "4");
                app1DayRestartMinute = int.Parse(appSettings["App1DayRestartMinute"] ?? "0");
                SetTimerParam();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());
                ClassLog.Writelog(DateTime.Now.ToString(), " ClassAppcontrol_getInitData() ", ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        ///  public void SetTimerParam()//设置定时器参数
        /// </summary>
        /// <param name>无</param>
        /// <returns>void</returns>
        public void SetTimerParam()
        {
            //到时间的时候执行事件  
            aTimer.Interval = 1000;
            aTimer.AutoReset = true;//执行一次 false，一直执行true  
            //是否执行System.Timers.Timer.Elapsed事件  
            aTimer.Elapsed += new ElapsedEventHandler(aTimer_Elapsed);

            aTimer.Enabled = true;
        }
        #endregion
        #region 事件
        /// <summary>
        /// private void aTimer_Elapsed(object source, System.Timers.ElapsedEventArgs e)//定时器回调函数
        /// </summary>
        /// <param name>无</param>
        /// <returns>void</returns>
        private void aTimer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            aTimercount1 = aTimercount1 + 1;
            if (aTimercount1 > 100000)
            {
                aTimercount1 = 0;
                TimercountDT = DateTime.Now;
            }
            string temstr = " ClassAppcontrol 定时器1 从" + TimercountDT.ToString()+ " 开始 共执行 " + aTimercount1.ToString() + " 次 ";
            ClassLog.Writedata("", " aTimer_Elapsed ", temstr);
            App1check();
            //MessageBox.Show(DateTime.Now.ToString());
        }
        #endregion
        #region 函数
        /// <summary>
        /// public bool Services1check()//检查应用程序状态
        /// </summary>
        public bool App1check()
        {
            /// <param name>无</param>
            /// <returns>已经运行或正在开启状态为真</returns>

            bool startapp = false;
            try
            {

                if (Process.GetProcessesByName(app1Name).ToList().Count > 0)        //应用程序正在运行
                {
                    //存在
                    app1Count = app1Count0;
                    app1Status = "正在运行！ ";
                    app1Statusbool = true;
                    startapp = true;
                }//应用程序正在运行时给标志赋值
                else
                {
                    app1Status = " 没有运行 ";
                    if (app1WaitStart || app1DayRestart1)
                    {
                        if (app1Count0 != -1)  // 等待秒数设置不为-1 ，-1表示不重启
                        {
                            if (app1Count != 0)
                            {
                                app1Count = app1Count - 1;      //当前计数
                                app1Status = " 等待启动！ ";
                            }
                        }// 等待秒数设置不为-1 ，-1表示不重启
                    }// 等待重新启动应用程序标志为真时执行

                    if (app1Count == 1)
                    {
                        startapp = StartApp1();
                        app1Status = " 开始启动！ ";
                        app1Count = 0;
                    }

                }
                int nowHour, nowMinute;
                nowHour = DateTime.Now.Hour;
                nowMinute = DateTime.Now.Minute;
                DateTime restartDT;
                restartDT = DateTime.Now.Date;
                double doubleapp1DayRestartHour = (double)app1DayRestartHour;
                restartDT = restartDT.AddHours(doubleapp1DayRestartHour);
                double doubleapp1DayRestartMinute = (double)app1DayRestartMinute;
                restartDT = restartDT.AddMinutes(doubleapp1DayRestartMinute);
                app1DayRestartDT = restartDT;
                //if ((nowHour > services1DayRestartHour) && (nowMinute > services1DayRestartMinute) && services1DayRestart)
                if ((app1DayRestart))
                {
                    if (DateTime.Now > restartDT) 
                    {
                        app1DayRestartCount = 0;
                        if ((!app1DayRestart1)&&(!app1DayRestart2))
                        {
                            app1DayRestart2 = true;
                            app1DayRestart1 = true;
                            KillApp1();
                        }
                    }
                    else
                    {
                        app1DayRestart2 = false;
                        TimeSpan ts = restartDT.Subtract(DateTime.Now);
                        app1DayRestartCount = (int)ts.TotalSeconds;
                    }
                }
                else
                {
                    app1DayRestartCount = 0;
                }
                DateTime restartDT1;
                restartDT1 = restartDT;
                restartDT1 = restartDT1.AddMinutes(2.0);
                //if ((nowHour > services1DayRestartHour) && (nowMinute > (services1DayRestartMinute + 2)) && services1DayRestart)
                if ((DateTime.Now > restartDT1) && app1DayRestart)
                {
                    app1DayRestart1 = false;
                }
                return startapp;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool App1check() " + app1Name + "  ",
                    ex.Message.ToString());
                return false;
            }

        }

        /// <summary>
        /// public bool StartApp1()//启动应用程序
        /// </summary>
        /// <param name>无</param>
        /// <returns>已经运行或正在开启状态为真</returns>
        public bool StartApp1()
        {
            bool tembool = false;
            try
            {
                //Process mProcess = new Process();
                //mProcess.StartInfo.FileName = app1Name;
                string temstr = app1Path.Substring(0, app1Path.LastIndexOf("\\"));        //mProcess.StartInfo.WorkingDirectory = app1Path.Substring(0, app1Path.LastIndexOf("\\"));
                tembool = ClassMonitor.StartApp(app1Name, app1Path);            //mProcess.Start();
                ClassLog.WritedataTodo(DateTime.Now.ToString(), " public bool StartApp1() "+ temstr + " " + app1Name + "  ", " Start! ");
               return tembool;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool StartApp1() " + app1Name +"  ", 
                    ex.Message.ToString());
                return tembool;
            }
        }

        /// <summary>
        /// public bool StopServices1()//中止应用程序进程
        /// </summary>
        /// <param name>无</param>
        /// <returns>已经运行或正在开启状态为真</returns>
        public bool KillApp1()
        {
            bool tembool = false;
            try
            {
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool KillApp( " + app1Name + ")  ",
                    " start ");
                tembool = ClassMonitor.KillApp(app1Name);
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool KillApp( " + app1Name + ")  ",
                    " end ");
                return tembool;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool KillApp( " + app1Name + ")  ",
                    ex.Message.ToString());
                return tembool;
            }
        }
        #endregion
    }
}

