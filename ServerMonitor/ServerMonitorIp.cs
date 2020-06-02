using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Configuration;
using System.ServiceProcess;
using System.Diagnostics;
using ClassLibraryTool1;
using ServrerMonitor;


namespace ServerMonitor
{
    public partial class ServerMonitorIp : Form
    {
        #region  全局数据
        int UpdateInterval = 1000;
        int Target_IP_count = 0;
        int Target_Url_Count = 0;
        string[] Target_IP;         //目标服务器 IP
        string[] Target_Host;         //目标服务器 主机名
        string[] Target_result;        //目标服务器 监测结果
        long[] Target_fail_count;        //目标服务器 监测连通连续失败计数
        long[] Target_fail_count_alarm;        //目标服务器 监测连通失败计数
        long[] Target_return_total_ms;        //目标服务器 返回时间毫秒数
        long[] Target_Success_count;        //目标服务器 监测连通成功计数
        Color[] Target_color;        //目标服务器 监测结果
        string[] Target_Url;                //目标网址
        string[] Target_Url_desc;           //目标网址描述
        string[] Target_Url_result;           //目标网址连通结果
        long[] Target_Url_fail_count;           //目标网址连通失败计数
        long[] Target_Url_fail_count_alarm;           //目标网址连通连续失败计数
        long[] Target_Url_return_total_ms;        //目标网址 返回时间总毫秒数
        long[] Target_Url_Success_count;        //目标网址 监测连通成功计数
        Color[] Target_Url_color;           //目标网址字符颜色
        int now_i = 0;
        int now_j = 0;
        int now_k = 0;
        long total_count = 0;
        string Old_Date;
        string str_Doing = " ";
        string str_Do_fail = " ";
        string str_url_show = "";
        string Target_Phone1 = "";
        string Target_Phone2 = "";
        string Rest_Url = "";

        #endregion

        #region 事件
        public ServerMonitorIp()
        {
            try
            {
                int i;
                InitializeComponent();
                var appSettings = ConfigurationManager.AppSettings;
                string result = "";
                string str_Window_Caption = "";
                writelog(DateTime.Now.ToString(), " ServrerMonitor_Start_Run ", "  starting" );
                writedataTodo(DateTime.Now.ToString(), " ServrerMonitor_Start_Run ", "  starting");
                writedata(DateTime.Now.ToString(), " ServrerMonitor_Start_Run ", "  starting");

                str_Window_Caption = appSettings["Window_Caption"] ?? " ";
                this.Text = this.Text + " -- " + str_Window_Caption;
                result = appSettings["UpdateInterval"] ?? "Not Found";
                UpdateInterval = int.Parse(result);
                result = appSettings["Target_Ip_Count"] ?? "Not Found";
                Target_IP_count = int.Parse(result);
                result = appSettings["Target_Url_Count"] ?? "Not Found";
                Target_Url_Count = int.Parse(result);
                Target_Phone1 = appSettings["Target_Phone1"] ?? " ";
                Target_Phone2 = appSettings["Target_Phone2"] ?? " ";
                Rest_Url = appSettings["Rest_Url"] ?? " ";
                //   Convert.ToInt16(System.Configuration.ConfigurationSettings.AppSettings["TootherPort"].ToString());

                Target_IP = new string[Target_IP_count];
                Target_Host = new string[Target_IP_count];
                Target_result = new string[Target_IP_count];
                Target_fail_count = new long[Target_IP_count];
                Target_fail_count_alarm = new long[Target_IP_count];
                Target_return_total_ms = new long[Target_IP_count];
                Target_Success_count = new long[Target_IP_count];
                Target_color = new Color[Target_IP_count];

                Target_Url = new string[Target_Url_Count];
                Target_Url_desc = new string[Target_Url_Count];
                Target_Url_result = new string[Target_Url_Count];
                Target_Url_fail_count = new long[Target_Url_Count];
                Target_Url_fail_count_alarm = new long[Target_Url_Count];
                Target_Url_return_total_ms = new long[Target_Url_Count];
                Target_Url_Success_count = new long[Target_Url_Count];
                Target_Url_color = new Color[Target_Url_Count];

                for (i = 0; i < Target_IP_count; i++)
                {
                    int i1 = i + 1;
                    string Target_IP_str = "Target_Ip_" + i1.ToString();
                    result = appSettings[Target_IP_str] ?? "Not Found ";
                    Target_IP[i] = result;
                    string Target_Host_str = "Target_Host_" + i1.ToString();
                    result = appSettings[Target_Host_str] ?? "Not Found ";
                    Target_Host[i] = result;
                    Target_result[i] = " \r\n";
                    Target_fail_count[i] = 0;
                    Target_fail_count_alarm[i] = 0;
                    Target_return_total_ms[i] = 0;
                    Target_Success_count[i] = 0;
                    Target_color[i] = Color.Black;
                }
                for (i = 0; i < Target_Url_Count; i++)
                {
                    int i1 = i + 1;
                    string Target_Url_str = "Target_Url_" + i1.ToString();
                    result = appSettings[Target_Url_str] ?? "Not Found ";
                    Target_Url[i] = result;
                    string Target_Url_desc_str = "Target_Url_desc_" + i1.ToString();
                    result = appSettings[Target_Url_desc_str] ?? "Not Found ";
                    Target_Url_desc[i] = result;
                    Target_Url_result[i] = " \r\n";           //目标网址描述
                    Target_Url_fail_count[i] = 0;
                    Target_Url_fail_count_alarm[i] = 0;
                    Target_Url_return_total_ms[i] = 0;
                    Target_Url_Success_count[i] = 0;
                    Target_Url_color[i] = Color.Black;
                }
                Old_Date = DateTime.Now.ToLongDateString();
                textBox1.Text = Old_Date = DateTime.Now.ToString();
                ;
                //textBox1.ForeColor = Color.Red;
                now_k = Target_Url_Count + Target_IP_count;
            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
                string date_str = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
                date_str = "";
                writelog(date_str, " ServrerMonitor_ServerMonitor ", ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool boolaa;
                Ping_All_host_Onetime();
                boolaa=IsResponse("http://10.157.3.32","miaoshu",0);
                label5.Text = boolaa.ToString();
                boolaa = IsResponse("http://10.157.3.37:8080/default", "miaoshu",0);
                boolaa = IsResponse("http://10.157.5.2", "miaoshu",0);
                boolaa = IsResponse("http://10.157.6.15", "miaoshu",0);
                boolaa = IsResponse("http://10.157.8.200", "miaoshu",0);
                boolaa = IsResponse("http://10.157.3.24:8080/tobacco", "miaoshu",0);
                textBoxdone.Text = str_Doing;
                textBoxfail.Text = str_Do_fail;

            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
                string date_str = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
                writelog(date_str, " ServrerMonitor_button1_Click ", ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ping ping = new Ping();
            PingReply result = ping.Send(label2.Text);
            if (result.Status == IPStatus.Success)
                label4.Text = string.Format("已经成功与IP为{0}链接成功", label2.Text);
            else
                label4.Text = string.Format("与IP为{0}的PC机不能正常链接，请检查网络", label2.Text);
            Old_Date = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                long  pingReplytime=0;
                string TargetIP = label5.Text;
                string date_str = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
                label3.Text = date_str;
                //label4.Text = "aaaa";
                string Ping_result = "";
                if (IsValidIP(TargetIP))
                {
                    if (PingIP(TargetIP,ref pingReplytime))
                    {
                        Ping_result = " Success! ";
                        writedataTodo(date_str, "ServrerMonitor_button3_Click", " PingIP " + TargetIP + Ping_result);
                    }
                    else
                    {
                        Ping_result = " Fail! ";

                        writedataTodo(date_str, "ServrerMonitor_button3_Click", " PingIP " + TargetIP + Ping_result);
                        writedata(date_str, "ServrerMonitor_button3_Click", " PingIP " + TargetIP + Ping_result);
                    }
                }
                label4.Text = Ping_result;
            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
                string date_str = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
                writelog(date_str, " ServrerMonitor_button3_Click ", ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //UpdateInterval
            timer1.Interval = UpdateInterval;
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int textBoxdone_use = 0;
            int i=0;
            if (now_j==0) total_count = total_count + 1;
            if (now_j < Target_IP_count)
            {
                #region 检查IP的连通
                Ping_All_host_Onetime();
                string rest_json = "";
                if (Target_fail_count_alarm[now_j] == 3)
                {
                    rest_json = "{    \"row_action\":\"1\",	\"msg_type\":\"SM\",	\"reply\":\"0\",	\"receives\":\"";
                    rest_json = rest_json + Target_Phone1 + "\"";
                    rest_json = rest_json + ",	\"title\":\"22\",	\"tcontent\":\"";
                    rest_json = rest_json + DateTime.Now.TimeOfDay.ToString()+ " " + Target_IP[now_j] + " " + Target_Host[now_j] + " 连续Ping 3次失败\"";
                    rest_json = rest_json + ",	\"start_time\":\"";
                    //rest_json = rest_json + DateTime.Now.ToString() + "\",	\"creator\":\"XXX\"}          ";
                    rest_json = rest_json + "\",	\"creator\":\"top\"}          ";
                    textBox2.Text = Rest_Url;
                    textBox3.Text = rest_json;
                    if (Target_Phone1.Length>9) textBox4.Text = PostWebRequest(Rest_Url, rest_json);
                    rest_json = "{    \"row_action\":\"1\",	\"msg_type\":\"SM\",	\"reply\":\"0\",	\"receives\":\"";
                    rest_json = rest_json + Target_Phone2 + "\"";
                    rest_json = rest_json + ",	\"title\":\"22\",	\"tcontent\":\"";
                    rest_json = rest_json + DateTime.Now.TimeOfDay.ToString() + " " + Target_IP[now_j] + " " + Target_Host[now_j] + " 连续Ping 3次失败\"";
                    rest_json = rest_json + ",	\"start_time\":\"";
                    //rest_json = rest_json + DateTime.Now.ToString() + "\",	\"creator\":\"XXX\"}          ";
                    rest_json = rest_json + "\",	\"creator\":\"top\"}          ";
                    textBox2.Text = Rest_Url;
                    textBox3.Text = rest_json;
                    if (Target_Phone2.Length > 9) textBox4.Text = PostWebRequest(Rest_Url, rest_json);
                    str_Do_fail = str_Do_fail + textBox4.Text + "\r\n";
                }
                #endregion
            }
            else
            {
                string rest_json = "";
                IsResponse_All_host_Onetime();  //检查网址的响应
                int url_i = now_j - Target_IP_count;
                if (Target_Url_fail_count_alarm[url_i] == 3)
                {

                    rest_json = "{    \"row_action\":\"1\",	\"msg_type\":\"SM\",	\"reply\":\"0\",	\"receives\":\"";
                    rest_json = rest_json + Target_Phone1 + "\"";
                    rest_json = rest_json + ",	\"title\":\"22\",	\"tcontent\":\"";
                    rest_json = rest_json + DateTime.Now.TimeOfDay.ToString() + " " + Target_Url[url_i] + Target_Url_desc[url_i] + " 连续访问 3次失败\"";
                    rest_json = rest_json + ",	\"start_time\":\"";
                    //rest_json = rest_json + DateTime.Now.ToString() + "\",	\"creator\":\"TOP\"}          ";
                    rest_json = rest_json + "\",	\"creator\":\"TOP\"}          ";
                    textBox2.Text = Rest_Url;
                    textBox3.Text = rest_json;
                    if (Target_Phone1.Length > 9) textBox4.Text = PostWebRequest(Rest_Url, rest_json);
                    rest_json = "{    \"row_action\":\"1\",	\"msg_type\":\"SM\",	\"reply\":\"0\",	\"receives\":\"";
                    rest_json = rest_json + Target_Phone2 + "\"";
                    rest_json = rest_json + ",	\"title\":\"22\",	\"tcontent\":\"";
                    rest_json = rest_json + DateTime.Now.TimeOfDay.ToString() + " " + Target_Url[url_i] + Target_Url_desc[url_i] + " 连续访问 3次失败\"";
                    rest_json = rest_json + ",	\"start_time\":\"";
                    //rest_json = rest_json + DateTime.Now.ToString() + "\",	\"creator\":\"TOP\"}          ";
                    rest_json = rest_json + "\",	\"creator\":\"TOP\"}          ";
                    textBox2.Text = Rest_Url;
                    textBox3.Text = rest_json;
                    if (Target_Phone2.Length > 9) textBox4.Text = PostWebRequest(Rest_Url, rest_json);
                    str_Do_fail = str_Do_fail + textBox4.Text + "\r\n";
                }

            }
            textBoxfail.Text = str_Do_fail;
            if (textBoxdone_use==1) textBoxdone.Text = "";
            richTextBox1.Text = "";
            int str_sel_strart_pos = 0;
            int str_sel_end_pos = 0;
            string tem_str = "";
            /// textBoxdone_use = 0 时不用
            for (i = 0; i < Target_IP_count; i++)//textBoxdone_use = 0 时不用
            {
                if (textBoxdone_use == 1) textBoxdone.ForeColor = Target_color[i];
                if (textBoxdone_use == 1) textBoxdone.Text = textBoxdone.Text + " PingIP " + Target_Host[i] + " " 
                        + Target_IP[i] + "   " + Target_result[i];
                tem_str = "PingIP " + Target_Host[i] + " " + Target_IP[i] + "   " + Target_result[i];
                //richTextBox1.Text = richTextBox1.Text + tem_str;


            }
            for (i = 0; i < Target_Url_Count; i++) //textBoxdone_use = 0 时不用
            {
                tem_str = "连接 " + Target_Url_desc[i] + "     " + Target_Url[i] + "    " + Target_Url_result[i];
                if (textBoxdone_use == 1) textBoxdone.ForeColor = Target_Url_color[i];
                if (textBoxdone_use == 1) textBoxdone.Text = textBoxdone.Text + " 连接 " + Target_Url_desc[i] + "     "
                        + Target_Url[i] + "    " + Target_Url_result[i];
                //richTextBox1.Text = richTextBox1.Text + tem_str;
            }
            ///
            for (i = 0; i < Target_IP_count; i++)
            {
                tem_str = "PingIP " + Target_Host[i] + " " + Target_IP[i] + "   " + Target_result[i];
                richTextBox1.AppendText(tem_str);
                str_sel_end_pos = str_sel_strart_pos + tem_str.Length - 1;
                richTextBox1.Select(str_sel_strart_pos, tem_str.Length - 1);
                richTextBox1.SelectionColor = Target_color[i];
                if (now_j == i) richTextBox1.SelectionColor = Color.Blue;
              str_sel_strart_pos = str_sel_end_pos;

            }
            for (i = 0; i < Target_Url_Count; i++)
            {
                tem_str = "连接 " + Target_Url_desc[i] + "     " + Target_Url[i] + "    " + Target_Url_result[i];
                richTextBox1.AppendText(tem_str);
                str_sel_end_pos = str_sel_strart_pos + tem_str.Length - 1;
                richTextBox1.Select(str_sel_strart_pos, tem_str.Length - 1);
                richTextBox1.SelectionColor = Target_Url_color[i];
                int ii = now_j - Target_IP_count;
                if (i == ii) richTextBox1.SelectionColor = Color.Blue;
                str_sel_strart_pos = str_sel_end_pos;
            }

            now_j = now_j + 1;
            if (now_j >= now_k) now_j = 0;
        }


        #endregion

        #region 检查IP 服务 网页 端口的通讯
        /// <summary>
        /// 检测IP
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public static bool PingIP(string strIP,ref long pingReplyRoundtripTime)
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
                writelog(date_str, " ServrerMonitor_PingIP ", ex.Message);
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
                writelog(date_str, " ServrerMonitor_IsValidIP ", ex.Message);
                return false;
            }

        }

        public bool IsStop( string serviceNamestr )//检测服务运行
        {
            bool isStop = false;
            using (System.ServiceProcess.ServiceController control = new ServiceController(serviceNamestr))
            {
                WriteLog(control.Status.ToString());
                if (control.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                {
                    control.Start();
                    isStop = true;
                }
                else
                {
                    control.Stop();
                }
            }
            return isStop;
        }
        public bool IsResponse(string strUrl, string strUrldesc,int j)//检测网页响应
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
                    writedataTodo(" ", " ServrerMonitor_IsResponse ", str_tem);
                    counter++;
                    try
                    {
                        response = (System.Net.HttpWebResponse)request.GetResponse();
                        Debug.Print(   response.ContentLength.ToString( ) + response.Server.ToString());
                        isRes = true;
                        counter = 10;
                        //str_Doing = str_Doing + DateTime.Now.ToString() + " " + strUrldesc + strUrl + " connect success \r\n";
                        writedataTodo(" ", " ServrerMonitor_IsResponse ", " " + strUrldesc +  strUrl + " connect success \r\n");
                        break;
                    }
                    catch (WebException ex)
                    {
                        if  (Target_Url_fail_count_alarm[j]<4)
                        str_Do_fail = str_Do_fail + DateTime.Now.ToString() + " " + strUrldesc +  strUrl + " connect fail\r\n" + ex.Message.ToString() + "\r\n";
                        writedataTodo(" ", " ServrerMonitor_IsResponse ", " " + strUrldesc + strUrl + " connect fail \r\n" + ex.Message.ToString() + "\r\n");
                        writedata(" ", " ServrerMonitor_IsResponse ", " " + strUrldesc + strUrl + " connect fail \r\n" + ex.Message.ToString() + "\r\n");
                        //Thread.Sleep(3000);
                    }
                }
                return isRes;
            }
            catch (Exception ex)
            {
                string date_str = DateTime.Now.ToString();
                writelog(date_str, " ServrerMonitor_IsResponse " + strUrldesc, ex.Message);
                return false;
            }

        }
        private void Ping_All_host_Onetime()//ping检查通讯
        {
            try
            {
                string now_date_str;
                now_date_str = DateTime.Now.ToLongDateString();
                if (Old_Date != now_date_str)
                {
                    str_Do_fail = "";
                    Old_Date = now_date_str;
                }
                int i = 0;
                i = now_i;
                string TargetIP = Target_IP[i];
                string TargetHost = Target_Host[i];  // Target_IP[i];
                now_i = now_i + 1;
                if (now_i >= Target_IP_count) now_i = 0;
                //Target_IP
                string date_str = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
                SetLabel1(TargetHost);
                SetLabel2(TargetIP);
                SetLabel3(date_str);
                SetLabel4("wait ");
                string Ping_result = "";
                bool testbool;
                testbool = IsValidIP(TargetIP);
                //testbool = true;
                long pingReplyRoundtripTime = 0;
                if (testbool)
                {
                    if (PingIP(TargetIP, ref pingReplyRoundtripTime))
                    {
                        Target_fail_count_alarm[i] = 0;
                        Target_return_total_ms[i] = Target_return_total_ms[i] + pingReplyRoundtripTime;
                        Target_Success_count[i] = Target_Success_count[i] + 1;
                        long acg_return_ms = 0;
                        acg_return_ms = Target_return_total_ms[i] / Target_Success_count[i];
                        Ping_result = " Success! " + pingReplyRoundtripTime.ToString() + "ms ";
                        Ping_result = Ping_result +  " avg:" + acg_return_ms.ToString() + "ms ";
                        Ping_result = Ping_result + "(fail " + Target_fail_count[i].ToString() + "/" + total_count.ToString() + ") \r\n";
                        writedataTodo(date_str, "ServrerMonitor_Ping_All_host_Onetime", " PingIP " +
                            TargetHost + "  " + TargetIP + "  " + Ping_result);
                        Target_color[i] = Color.Black;
                        label4.ForeColor = Color.Black;

                    }
                    else
                    {
                        Target_fail_count_alarm[i] = Target_fail_count_alarm[i] + 1 ;
                        Ping_result = " Fail! ";
                        Target_fail_count[i] = Target_fail_count[i] + 1;
                        Ping_result = Ping_result + "(fail " + Target_fail_count[i].ToString() + "/" + total_count.ToString() + ") \r\n";
                        if (Target_fail_count_alarm[i]<4 )
                            str_Do_fail = str_Do_fail + DateTime.Now.ToString() + " " + Target_Host[i] + " " + TargetIP + " " + Ping_result + "  ";
                        writedataTodo(date_str, "ServrerMonitor_Ping_All_host_Onetime", " PingIP " + TargetIP + Ping_result);
                        writedata(date_str, "ServrerMonitor_Ping_All_host_Onetime", " PingIP " + TargetIP + Ping_result);
                        Target_color[i] = Color.Red;
                        label4.ForeColor = Color.Red;

                    }
                    now_date_str =  DateTime.Now.ToString() + "      ";
                    Target_result[i] = DateTime.Now.ToString() + Ping_result + "";
                    SetLabel4(Ping_result);
                }
                else
                {
                    SetLabel4(TargetIP + " IP 地址格式不正确！ ");
                    Target_result[i] = Target_Host[i] + TargetIP + "    "  + " IP 地址格式不正确！ ";
                }
                str_Doing = "";
                for (i = 0; i < Target_IP_count; i++)
                {
                    str_Doing = str_Doing + Target_Host[i] + " " + TargetIP + " " +   Target_result[i];
                }
                str_Doing = str_Doing + str_url_show;
            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
                string date_str = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
                writelog(date_str, " ServrerMonitor_Ping_All_host_Onetime ", ex.Message);
            }


        }
        private void IsResponse_All_host_Onetime()//IsResponse检查网址
        {
            try
            {
                #region 检查网页地址的回应
                int i = 0;
                //if (now_j == Target_IP_count)
                //{
                //    str_Doing = "";
                //    str_url_show = "";
                //    for (i = 0; i < Target_IP_count; i++)
                //    {
                //        str_Doing = str_Doing + Target_result[i];
                //    }

                //}
                i = now_j - Target_IP_count;
                if (i < 0) i = 0;
                bool isResponse = false;
                DateTime tt0 =  DateTime.Now;
                TimeSpan ts0 =new  TimeSpan(tt0.Ticks);
                isResponse = IsResponse(Target_Url[i], Target_Url_desc[i],i);// 
                DateTime tt1 = DateTime.Now;
                TimeSpan ts1 = new TimeSpan(tt1.Ticks);
                TimeSpan tsd = ts0.Subtract(ts1).Duration();
                long l1 = tt1.Ticks - tt0.Ticks;
                int il2 = tsd.Milliseconds;
                if (isResponse)
                {
                    Target_Url_fail_count_alarm[i] = 0;
                    Target_Url_Success_count[i] = Target_Url_Success_count[i] + 1;
                    Target_Url_return_total_ms[i] = Target_Url_return_total_ms[i] + il2;
                    long ii3 = Target_Url_return_total_ms[i] / Target_Url_Success_count[i];
                    str_Doing = str_Doing + " " + Target_Url_desc[i] + " " + Target_Url[i] + " " + DateTime.Now.ToString() + " connect success"
                        +  " " + l1.ToString() + " \r\n";
                    str_url_show = str_url_show + " " + Target_Url_desc[i] + " " + Target_Url[i] + " " + DateTime.Now.ToString() + " connect success \r\n";
                    Target_Url_result[i] = DateTime.Now.ToString() + " connect success  " + " " + il2.ToString() + "ms! avg:" + ii3.ToString() + " ";
                    //Target_Url_result[i] = DateTime.Now.ToString() + " connect success  " + l1.ToString() + " " + il2.ToString() + "ms! avg:" + ii3.ToString() + " ";
                    Target_Url_result[i] = Target_Url_result[i] + "( fail " + Target_Url_fail_count[i].ToString() + "/" + total_count.ToString() + ") \r\n";
                    Target_Url_color[i]= Color.Black;
                    label4.ForeColor = Color.Black;
                    SetLabel4(" success! ");
                }
                else
                {
                    Target_Url_fail_count[i] = Target_Url_fail_count[i] + 1;
                    long ii3 = 0;
                    if (Target_Url_Success_count[i] >0) ii3= Target_Url_return_total_ms[i] / Target_Url_Success_count[i];
                    Target_Url_fail_count_alarm[i] = Target_Url_fail_count_alarm[i] + 1;
                    str_Doing = str_Doing + " " + Target_Url_desc[i] + " " + Target_Url[i] + " " + DateTime.Now.ToString() + "  connect fail\r\n ";
                    str_Do_fail = str_Do_fail + " " + Target_Url_desc[i] + " " + Target_Url[i] + " " + DateTime.Now.ToString()
                        + "  connect fail!";
                    if (ii3>0) str_Do_fail= str_Do_fail + "avg:" + ii3.ToString()+" ";
                    str_Do_fail = str_Do_fail + "( fail " + Target_Url_fail_count[i].ToString() + "/" + total_count.ToString() + ") \r\n";
                    str_url_show = str_url_show + " " + Target_Url_desc[i] + " " + Target_Url[i] + " " + DateTime.Now.ToString() + " connect fail\r\n ";
                    Target_Url_result[i] = DateTime.Now.ToString() + "  connect fail! ";
                    if (ii3 > 0) Target_Url_result[i] = Target_Url_result[i] + "avg:" + ii3.ToString() + " ";
                    Target_Url_result[i] = Target_Url_result[i] + "( fail " + Target_Url_fail_count[i].ToString() + "/" + total_count.ToString() + ") \r\n";
                    Target_Url_color[i] = Color.Red;
                    label4.ForeColor = Color.Red;
                    SetLabel4("  fail! ");
                }

                SetLabel1(Target_Url_desc[i]);
                SetLabel2(Target_Url[i]);
                SetLabel3(DateTime.Now.ToString());
                #endregion

            }
            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
                string date_str = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
                writelog(date_str, " ServrerMonitor_IsResponse_All_host_Onetime ", ex.Message);
            }


        }

        #endregion

        #region 设置Label的文本
        public void SetLabel1(string lasel1_str)
        {
            try
            {
                label1.Text = lasel1_str;
            }
            catch (Exception ex)
            {
                writelog(DateTime.Now.ToString(), " ServrerMonitor_SetLabell " + lasel1_str, ex.Message);

            }

        }
        public void SetLabel2(string lasel2_str)
        {
            try
            {
                label2.Text = lasel2_str;
            }
            catch (Exception ex)
            {
                writelog(DateTime.Now.ToString(), " ServrerMonitor_SetLabel2 " + lasel2_str, ex.Message);

            }

        }
        public void SetLabel3(string lasel3_str)
        {
            try
            {
                label3.Text = lasel3_str;
            }
            catch (Exception ex)
            {
                writelog(DateTime.Now.ToString(), " ServrerMonitor_SetLabel3 " + lasel3_str, ex.Message);

            }

        }

        public void SetLabel4(string lasel4_str)
        {
            try
            {
                label4.Text = lasel4_str;
            }
            catch (Exception ex)
            {
                writelog(DateTime.Now.ToString(), " ServrerMonitor_SetLabel4 " + lasel4_str, ex.Message);

            }

        }

        #endregion

        #region 数据及日志记录
        static string PostWebRequest(string postUrl, string jsonStr)
        {
            string result = string.Empty;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonStr);
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/json";
                webReq.ContentLength = byteArray.Length;
                Stream reqStream = webReq.GetRequestStream();
                reqStream.Write(byteArray, 0, byteArray.Length);
                reqStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = streamReader.ReadToEnd();
                streamReader.Close();
                response.Close();
                reqStream.Close();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return result;
        }


        public static bool writelog(string datetimestr1, string appnamestrandfunctionnamestr, string errorstr)
        {
            try
            {

                string File1NameStr, File2NameStr, File3NameStr, FileNameStr, FileNameStr0;
                FileInfo file1Info, file2Info, file3Info;
                long file1size, file2size, file3size;
                StreamWriter applog;
                string datetimestr, WritelogTxt;
                File1NameStr = "applog1.txt";
                File2NameStr = "applog2.txt";
                File3NameStr = "applog3.txt";
                datetimestr = " " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                if (File.Exists(File1NameStr) == false)
                {
                    applog = new StreamWriter(File1NameStr);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }
                if (File.Exists(File2NameStr) == false)
                {
                    applog = new StreamWriter(File2NameStr);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }
                if (File.Exists(File3NameStr) == false)
                {
                    applog = new StreamWriter(File3NameStr);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }

                file1Info = new FileInfo(File1NameStr);
                file2Info = new FileInfo(File2NameStr);
                file3Info = new FileInfo(File3NameStr);
                file1size = file1Info.Length;
                file2size = file2Info.Length;
                file3size = file3Info.Length;
                FileNameStr0 = "notdel";
                FileNameStr = File1NameStr;
                if ((file1size > 500000))
                {
                    FileNameStr = File2NameStr;
                }
                if ((file2size > 500000))
                {
                    FileNameStr = File3NameStr;
                }
                if ((file3size > 500000))
                {
                    FileNameStr = File1NameStr;
                }
                if ((file1size > 500000) && (file2size > 500000))
                {
                    FileNameStr0 = File1NameStr;
                    FileNameStr = File3NameStr;
                }
                if ((file2size > 500000) && (file3size > 500000))
                {
                    FileNameStr0 = File2NameStr;
                    FileNameStr = File1NameStr;
                }
                if ((file3size > 500000) && (file1size > 500000))
                {
                    FileNameStr0 = File3NameStr;
                    FileNameStr = File2NameStr;
                }
                if (FileNameStr0 != "notdel")
                {
                    applog = new StreamWriter(FileNameStr0);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }


                applog = File.AppendText(FileNameStr);
                WritelogTxt = "  " + datetimestr + " write log  "
                    + datetimestr1 + "  " + datetimestr1 + " " + appnamestrandfunctionnamestr + " " + errorstr + " \r\n ";
                applog.Write(WritelogTxt);
                applog.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());
                // MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool writedata(string datetimestr1, string appnamestrandfunctionnamestr, string eventstr)
        {
            try
            {

                string File1NameStr, File2NameStr, File3NameStr, FileNameStr, FileNameStr0;
                FileInfo file1Info, file2Info, file3Info;
                long file1size, file2size, file3size;
                StreamWriter applog;
                string datetimestr, WritelogTxt;
                File1NameStr = "appdata1.txt";
                File2NameStr = "appdata2.txt";
                File3NameStr = "appdata3.txt";
                datetimestr = " " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                if (File.Exists(File1NameStr) == false)
                {
                    applog = new StreamWriter(File1NameStr);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }
                if (File.Exists(File2NameStr) == false)
                {
                    applog = new StreamWriter(File2NameStr);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }
                if (File.Exists(File3NameStr) == false)
                {
                    applog = new StreamWriter(File3NameStr);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }

                file1Info = new FileInfo(File1NameStr);
                file2Info = new FileInfo(File2NameStr);
                file3Info = new FileInfo(File3NameStr);
                file1size = file1Info.Length;
                file2size = file2Info.Length;
                file3size = file3Info.Length;
                FileNameStr0 = "notdel";
                FileNameStr = File1NameStr;
                if ((file1size > 800000))
                {
                    FileNameStr = File2NameStr;
                }
                if ((file2size > 800000))
                {
                    FileNameStr = File3NameStr;
                }
                if ((file3size > 800000))
                {
                    FileNameStr = File1NameStr;
                }
                if ((file1size > 800000) && (file2size > 800000))
                {
                    FileNameStr0 = File1NameStr;
                    FileNameStr = File3NameStr;
                }
                if ((file2size > 800000) && (file3size > 800000))
                {
                    FileNameStr0 = File2NameStr;
                    FileNameStr = File1NameStr;
                }
                if ((file3size > 800000) && (file1size > 800000))
                {
                    FileNameStr0 = File3NameStr;
                    FileNameStr = File2NameStr;
                }
                if (FileNameStr0 != "notdel")
                {
                    applog = new StreamWriter(FileNameStr0);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }


                applog = File.AppendText(FileNameStr);
                WritelogTxt = "  " + datetimestr + " write data  "
                    + datetimestr1 + "  " + datetimestr1 + " " + appnamestrandfunctionnamestr + " " + eventstr + " \r\n ";
                applog.Write(WritelogTxt);
                applog.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message.ToString());

                // MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool writedataTodo(string datetimestr1, string appnamestrandfunctionnamestr, string eventstr)
        {
            try
            {

                string File1NameStr, File2NameStr, File3NameStr, FileNameStr, FileNameStr0;
                FileInfo file1Info, file2Info, file3Info;
                long file1size, file2size, file3size;
                StreamWriter applog;
                string datetimestr, WritelogTxt;
                File1NameStr = "appdatatodo1.txt";
                File2NameStr = "appdatatodo2.txt";
                File3NameStr = "appdatatodo3.txt";
                datetimestr = " " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                if (File.Exists(File1NameStr) == false)
                {
                    applog = new StreamWriter(File1NameStr);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }
                if (File.Exists(File2NameStr) == false)
                {
                    applog = new StreamWriter(File2NameStr);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }
                if (File.Exists(File3NameStr) == false)
                {
                    applog = new StreamWriter(File3NameStr);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }

                file1Info = new FileInfo(File1NameStr);
                file2Info = new FileInfo(File2NameStr);
                file3Info = new FileInfo(File3NameStr);
                file1size = file1Info.Length;
                file2size = file2Info.Length;
                file3size = file3Info.Length;
                FileNameStr0 = "notdel";
                FileNameStr = File1NameStr;
                if ((file1size > 800000))
                {
                    FileNameStr = File2NameStr;
                }
                if ((file2size > 800000))
                {
                    FileNameStr = File3NameStr;
                }
                if ((file3size > 800000))
                {
                    FileNameStr = File1NameStr;
                }
                if ((file1size > 800000) && (file2size > 800000))
                {
                    FileNameStr0 = File1NameStr;
                    FileNameStr = File3NameStr;
                }
                if ((file2size > 800000) && (file3size > 800000))
                {
                    FileNameStr0 = File2NameStr;
                    FileNameStr = File1NameStr;
                }
                if ((file3size > 800000) && (file1size > 800000))
                {
                    FileNameStr0 = File3NameStr;
                    FileNameStr = File2NameStr;
                }
                if (FileNameStr0 != "notdel")
                {
                    applog = new StreamWriter(FileNameStr0);
                    WritelogTxt = "  " + datetimestr + " creat File .  \r\n";
                    applog.Write(WritelogTxt);
                    applog.Close();
                }


                applog = File.AppendText(FileNameStr);
                WritelogTxt = "  " + datetimestr + " write data  "
                    + datetimestr1 + "  " + datetimestr1 + " " + appnamestrandfunctionnamestr + " " + eventstr + " \r\n ";
                applog.Write(WritelogTxt);
                applog.Close();
                return true;
            }

            catch (Exception ex)
            {

                // MessageBox.Show(ex.Message);
                string date_str = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
                writelog(date_str, " ServrerMonitor_writedataTodo ", ex.Message);
                return false;
            }
        }
        private void WriteLog(string strLog)//临时写日志
        {
            writelog(" ", " ", strLog);
        }

        private void writeLog(string strLog)//临时写日志
        {
            writelog(" ", " ", strLog);
        }

        #endregion

        private void timerCall(object obj)//暂时不用杀进程
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
                else if (!IsResponse("strUrl", "miaoshu",0))
                {
                    Process[] processes = Process.GetProcessesByName("exeName");

                    foreach (Process p in processes)
                    {
                        WriteLog("kill Start.");
                        p.Kill();
                        p.Close();
                        WriteLog("kill end.");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }

        }

        /// <summary>
        /// 检查服务
        /// </summary>

        private void checkApp(string appName, string apppath)//
        {


        }

            /// <summary>
            /// 检查服务
            /// </summary>

            private void checkService(string serviceName)//
        {
            try
            {
                IsStop(serviceName);
                /*
                if (IsStop(serviceName))
                {
                    var serviceControllers = ServiceController.GetServices();

                    // iphlpsvc
                     var server = serviceControllers.FirstOrDefault(service => service.ServiceName == serviceName);
                    if (server != null && server.Status != ServiceControllerStatus.Running)
                    {
                        server.Start();
                    }
                   
                    using (System.ServiceProcess.ServiceController control = new ServiceController(appname))
                    {
                        control.Start();
                    }
                    
                    writedata(" ", " checkService ", serviceName + " start ");

                }
                else //if (!IsResponse("strUrl", "miaoshu", 0))
                {
                    writedata(" ", " checkService ", serviceName + " is running ");
                                       Process[] processes = Process.GetProcessesByName("exeName");

                    foreach (Process p in processes)
                    {
                        WriteLog("kill Start.");
                        p.Kill();
                        p.Close();
                        WriteLog("kill end.");
                    }
                    
                }*/

            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }

        }


        private void button6_Click(object sender, EventArgs e)
        {
            int str_sel_strart_pos = 0;
            int str_sel_end_pos = 0;
            int i = 0;
            for (i = 0; i < Target_IP_count; i++)
            {
                string tem_str = "";
                tem_str = " PingIP " + Target_Host[i] + " " + Target_IP[i] + "   " + Target_result[i];
                str_sel_end_pos = str_sel_strart_pos + tem_str.Length;
                //richTextBox1.Text = richTextBox1.Text + tem_str;
                //richTextBox1.Select(str_sel_strart_pos, richTextBox1.Text.Length - str_sel_strart_pos);
                richTextBox1.Select(str_sel_strart_pos, tem_str.Length);
                richTextBox1.SelectionColor = Target_color[i];
                str_sel_strart_pos = str_sel_end_pos;

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string str_Window_Caption = "";
            str_Window_Caption = appSettings["Window_Caption"] ?? " ";
            this.Text = this.Text + str_Window_Caption;
            total_count = 1000000000000000000;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox4.Text= PostWebRequest(textBox2.Text, textBox3.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkService("iphlpsvc");
        }

        private void button_AppControl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("现在没有功能");
        }
    }
}
