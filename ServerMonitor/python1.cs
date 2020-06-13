using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using ClassLibraryTool1;
using System.Web;

namespace ServerMonitor
{
    public partial class python1 : Form
    {
        public python1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime temtime = DateTime.Now;
            try
            {
                string pypathstr = "";
                string pyfilestr = "";
                ScriptRuntime pyRunTime = Python.CreateRuntime();
                pypathstr = AppContext.BaseDirectory;
                //pypathstr = "E:\\mysoft\\202003test\\ServerMonitor\\ServerMonitor\\pythonfiles\\";
                pyfilestr = "pythonfiles\\digital1.py";
                dynamic obj = pyRunTime.UseFile(pypathstr + pyfilestr );
                //dynamic obj = pyRunTime.UseFile("digital1.py");
                int int1 = 0, int2 = 0;
                int1 = int.Parse(text_data1.Text);
                int2 = int.Parse(text_data2.Text);
                int val = obj.sum(int1, int2);

                label_result1.Text = val.ToString();
                //MessageBox.Show(val + "");
            }
            catch (Exception ex)
            {
                ClassLog.Writelog(temtime.ToString(), "ServerManger.python1", " .button1_Click()  调用python计算 " + ex.ToString());
                Debug.Print(ex.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pypathstr = "";
            string pyfilestr = "";
            ScriptRuntime pyRunTime = Python.CreateRuntime();
            pypathstr = AppContext.BaseDirectory;
            //pypathstr = "E:\\mysoft\\202003test\\ServerMonitor\\ServerMonitor\\pythonfiles\\";
            pyfilestr = "pythonfiles\\digital1.py";
            dynamic obj = pyRunTime.UseFile(pypathstr + pyfilestr);
            string strfind1 = "";
            string strfind2 = "";
            UTF8Encoding utf8 = new UTF8Encoding();
            strfind1 = textBox1.Text;
            strfind2 = strfind1; // utf8.GetString(encodedBytes);
            strfind2 = StringToUnicode(strfind1);
            Debug.Print(strfind1);
            Debug.Print(strfind2);
            var strArray = obj.regSearch1("e:\\city.txt", strfind2);
            listBox1.Items.Clear();
            foreach (var s in strArray)
            {

                string ss0 = "";
                string ss1 = "";
                ss0 = "\\" + s;
                //Debug.Print(s);
                ss1 = UnicodeToString(ss0);
                listBox1.Items.Add(s);
            }
            int count = listBox1.Items.Count;
            label3.Text = count.ToString();

        }

        /// <summary>
        /// 字符串转Unicode
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>Unicode编码后的字符串</returns>
        public static string String2Unicode(string source)
        {
            var bytes = Encoding.Unicode.GetBytes(source);
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0:x2}{1:x2}", bytes[i + 1], bytes[i]);
            }
            return stringBuilder.ToString();
        }
        /// <summary>  
        /// 字符串转为UniCode码字符串  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        public static string StringToUnicode(string s)
        {
            char[] charbuffers = s.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }
        /// <summary>  
        /// Unicode字符串转为正常字符串  
        /// </summary>  
        /// <param name="srcText"></param>  
        /// <returns></returns>  
        public static string UnicodeToString(string srcText)
        {
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }
    }
}
