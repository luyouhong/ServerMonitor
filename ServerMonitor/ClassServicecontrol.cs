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
    class ClassServicecontrol
    {
        #region 变量定义
        string services1Name = "";
        string servicesStatus = "";
        string services1Status = "";
        bool services1Statusbool = false;
        bool services1WaitStart = false;
        bool services1DayRestart = false;
        bool services1DayRestart1 = false;
        bool services1DayRestart2 = false;
        int services1Count0 = 100;
        int services1Count = 0;
        int services1DayRestartHour = 4;
        int services1DayRestartMinute = 0;
        int services1DayRestartCount = 3600;
        DateTime services1DayRestartDT;
        static int aTimercount1 = 0;
        DateTime TimercountDT = DateTime.Now;

        System.Timers.Timer aTimer = new System.Timers.Timer();
        public string ServicesStatus { get => servicesStatus; set => servicesStatus = value; }
        public string Service1Status { get => services1Status; set => services1Status = value; }
        public bool Service1Statusbool { get => services1Statusbool; set => services1Statusbool = value; }
        /// <summary>
        ///  设置的等待服务重启的秒数
        /// </summary>
        public int Services1Count0 { get => services1Count0; set => services1Count0 = value; }
        /// <summary>
        ///  当前等待服务重启的秒数
        /// </summary>
        public int Services1Count { get => services1Count; set => services1Count = value; }
        /// <summary>
        ///  服务名
        /// </summary>
        public string Services1Name { get => services1Name; set => services1Name = value; }
        /// <summary>
        ///  服务自动重启标志
        /// </summary>
        public bool Services1WaitStart { get => services1WaitStart; set => services1WaitStart = value; }
        /// <summary>
        ///  服务每天自动重启标志
        /// </summary>
        public bool Services1DayRestart { get => services1DayRestart; set => services1DayRestart = value; }
        /// <summary>
        ///  服务每天自动重启小时
        /// </summary>
        public int Services1DayRestartHour { get => services1DayRestartHour; set => services1DayRestartHour = value; }
        /// <summary>
        ///  服务每天自动重启分钟小于57
        /// </summary>
        public int Services1DayRestartMinute { get => services1DayRestartMinute; set => services1DayRestartMinute = value; }
        /// <summary>
        ///  服务每天自动重启倒计时
        /// </summary>
        public int Service1DayRestartCount { get => services1DayRestartCount; set => services1DayRestartCount = value; }
        public DateTime App1DayRestartDT { get => services1DayRestartDT; set => services1DayRestartDT = value; }

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
                ClassLog.Writedata(DateTime.Now.ToString(), " ClassServicecontrol_Run ", "  starting");
                ClassLog.WritedataTodo(DateTime.Now.ToString(), " ClassServicecontrol_Run ", "  starting");
                ClassLog.Writelog(DateTime.Now.ToString(), " ClassServicecontrol_Run ", "  starting");

                services1Name = appSettings["ServicesName1"] ?? "";
                servicesStatus = "待检查"; // appSettings["AppPath1"] ?? "";
                services1Count0 = int.Parse(appSettings["Services1Count0"] ?? "-1");
                services1DayRestartHour = int.Parse(appSettings["Services1DayRestartHour"] ?? "5");
                services1DayRestartMinute = int.Parse(appSettings["Services1DayRestartMinute"] ?? "0");
                SetTimerParam();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());
                ClassLog.Writelog(DateTime.Now.ToString(), " ClassServicecontrol_getInitData() ", ex.Message.ToString());
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
            string temstr = " ClassServicecontrol 定时器1 从" + TimercountDT.ToString() + " 开始 共执行 " + aTimercount1.ToString() + " 次 ";
            ClassLog.Writedata("", " aTimer_Elapsed ", temstr);
            Services1check();
            //MessageBox.Show(DateTime.Now.ToString());
        }
        #endregion
        #region 函数
        /// <summary>
        /// public bool Services1check()//检查服务状态
        /// </summary>
        public bool Services1check()
        {
            /// <param name>无</param>
            /// <returns>已经运行或正在开启状态为真</returns>

            bool startservices = false;
            try
            {
                servicesStatus = ClassMonitor.GetServiceStatus(services1Name);
                if (!ClassMonitor.ServiceIsStop( services1Name))        //服务正在运行
                {
                    //存在
                    services1Count = services1Count0;
                    services1Status = "正在运行！ ";
                    services1Statusbool = true;
                    startservices = true;
                }//服务正在运行时给标志赋值
                else
                {
                    services1Status = " 没有运行 ";
                    if (services1WaitStart || services1DayRestart1)
                    {
                        if (services1Count0 != -1)  // 等待秒数设置不为-1 ，-1表示不重启
                        {
                            if (services1Count != 0)
                            {
                                services1Count = services1Count - 1;      //当前计数
                                services1Status = " 等待启动！ ";
                            }
                        }// 等待秒数设置不为-1 ，-1表示不重启
                    }// 等待重新启动服务标志为真时执行

                    if (services1Count == 1)
                    {
                        startservices = StartServices1();
                        services1Status = " 开始启动！ ";
                        services1Count = 0;
                    }

                }
                int nowHour, nowMinute;
                nowHour = DateTime.Now.Hour;
                nowMinute = DateTime.Now.Minute;
                DateTime restartDT;
                restartDT = DateTime.Now.Date;
                double doubleapp1DayRestartHour = (double)services1DayRestartHour;
                restartDT = restartDT.AddHours(doubleapp1DayRestartHour);
                double doubleapp1DayRestartMinute = (double)services1DayRestartMinute;
                restartDT = restartDT.AddMinutes(doubleapp1DayRestartMinute);
                services1DayRestartDT = restartDT;
                //if ((nowHour > services1DayRestartHour) && (nowMinute > services1DayRestartMinute) && services1DayRestart)
                if ((services1DayRestart))
                {
                    if (DateTime.Now > restartDT)
                    {
                        services1DayRestartCount = 0;
                        if ((!services1DayRestart1) && (!services1DayRestart2))
                        {
                            services1DayRestart2 = true;
                            services1DayRestart1 = true;
                            StopServices1();
                        }
                    }
                    else
                    {
                        services1DayRestart2 = false;
                        TimeSpan ts = restartDT.Subtract(DateTime.Now);
                        services1DayRestartCount = (int)ts.TotalSeconds;
                    }
                }
                else
                {
                    services1DayRestartCount = 0;
                }
                DateTime restartDT1;
                restartDT1 = restartDT;
                restartDT1 = restartDT1.AddMinutes(2.0);
                //if ((nowHour > services1DayRestartHour) && (nowMinute > (services1DayRestartMinute + 2)) && services1DayRestart)
                if ((DateTime.Now > restartDT1) && services1DayRestart)
                {
                    services1DayRestart1 = false;
                }
                return startservices;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool Services1check() " + services1Name + "  ",
                    ex.Message.ToString());
                return false;
            }

        }

        /// <summary>
        /// public bool StartServices1()//启动服务
        /// </summary>
        /// <param name>无</param>
        /// <returns>已经运行或正在开启状态为真</returns>
        public bool StartServices1()
        {
            bool tembool = false;
            try
            {
                //Process mProcess = new Process();
                //mProcess.StartInfo.FileName = services1Name;
                //mProcess.StartInfo.WorkingDirectory = servicesStatus.Substring(0, servicesStatus.LastIndexOf("\\"));
                tembool = ClassMonitor.ServiceStart(services1Name);        //mProcess.Start();
                ClassLog.WritedataTodo(DateTime.Now.ToString(), " public bool StartServices1() " + services1Name + "  " ," Start! ");
                return tembool;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool StartServices1() " + services1Name + "  ",
                    ex.Message.ToString());
                return tembool;
            }
        }

        /// <summary>
        /// public bool StopServices1()//中止服务
        /// </summary>
        /// <param name>无</param>
        /// <returns>已经运行或正在开启状态为真</returns>
        public bool StopServices1()
        {
            bool tembool = false;
            try
            {
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool StopServices1( " + services1Name + ")  ",
                    " start ");
                tembool = ClassMonitor.ServiceStop(services1Name);
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool StopServices1( " + services1Name + ")  ",
                    " end ");
                return tembool;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());
                ClassLog.Writelog(DateTime.Now.ToString(), " public bool StopServices1( " + services1Name + ")  ",
                    ex.Message.ToString());
                return tembool;
            }
        }
        #endregion
    }
}
