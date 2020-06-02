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
    public class ClassLog
    {
        #region 数据及日志记录



        /// <summary>
        /// rest接口写日志
        /// </summary>
        /// <param name="postUrl 接口"></param>
        /// <param name="jsonStr 要写的json "></param>
        /// <returns>"返回字符串"</returns>

        public static string PostWebRequest(string postUrl, string jsonStr)
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


        public static bool Writelog(string datetimestr1, string appnamestrandfunctionnamestr, string errorstr)
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
        public static bool Writedata(string datetimestr1, string appnamestrandfunctionnamestr, string eventstr)
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
        public static bool WritedataTodo(string datetimestr1, string appnamestrandfunctionnamestr, string eventstr)
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
                Writelog(date_str, " ServrerMonitor_writedataTodo ", ex.Message);
                return false;
            }
        }
        public static void WriteLog1(string strLog)//临时写日志
        {
            Writelog(" ", " ", strLog);
        }

        #endregion


    }
}
