using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ClassLibraryTool1;

namespace ServerMonitor
{
    public partial class FormPython2 : Form
    {
        public static string getpyresult = "";
        public FormPython2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime temtime = DateTime.Now;
            try
            {
                string getstr = " ";
                string[] strArr = new string[2];//参数列表
                string sArguments = @"pythonfiles\main.py";//这里是python的文件名字
                getpyresult = "";
                strArr[0] = text_data1.Text;  // "2";
                strArr[1] = text_data2.Text;  // "3";
                getstr = RunPythonScript(sArguments, "-u", strArr);
                label_result1.Text = getpyresult;
            }
            catch (Exception ex)
            {
                ClassLog.Writelog(temtime.ToString(), "ServerManger.FormPython2", " .button1_Click()  调用python计算 " + ex.ToString());
                Debug.Print(ex.ToString());
            }
        }
        //调用python核心代码
        public static string RunPythonScript(string sArgName, string args = "", params string[] teps)
        {
            string resultstr1 = "";
            string pypathstr = "";
            string pyfilestr = "";
            pypathstr = AppContext.BaseDirectory;
            //pypathstr = @"E:\mysoft\202003test\ServerMonitor\ServerMonitor\pythonfiles\";
            pyfilestr = @"pythonfiles\main.py";
            pyfilestr = sArgName;
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;// 获得python文件的绝对路径（将文件放在c#的debug文件夹中可以这样操作）
            path = @"C:\Users\user\Desktop\test\" + sArgName;//(因为我没放debug下，所以直接写的绝对路径,替换掉上面的路径了)
            path = pypathstr + pyfilestr;
            p.StartInfo.FileName = @"D:\Python\envs\python3\python.exe";//没有配环境变量的话，可以像我这样写python.exe的绝对路径。如果配了，直接写"python.exe"即可
            p.StartInfo.FileName = @"C:\Python27\python.exe";
            p.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python37_64\python.exe";
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;//传递参数
            }
            
            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardError = true;

            p.StartInfo.CreateNoWindow = true;

            p.Start();
            /*
             * // 将控制台的首选编码转为UTF-8
                    p.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
             *             p.StartInfo.Arguments = " " + "https://blog.csdn.net/leotao9527/article/details/104878591";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            label1.Text = output;
             * 
             * */
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            resultstr1 = Console.ReadLine();
            //Debug.Print(resultstr1);
            getpyresult = getpyresult + " gets " + resultstr1 + " gete ";

            p.WaitForExit();
            return resultstr1;
        }
        //输出打印的信息
        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data + Environment.NewLine);
                getpyresult = getpyresult+ " py3rs " + e.Data + " py3re ";
            }
        }
        public delegate void AppendTextCallback(string text);
        public static void AppendText(string text)
        {
            Console.WriteLine(text);     //此处在控制台输出.py文件print的结果
            Console.WriteLine("AppendText");     //此处在控制台输出.py文件print的结果

        }

        //调用python核心代码 加上python.exe的文件路径和名称
        public static string RunPythonScript1(string pyexefile, string pyfile, string args = "", params string[] teps)
        {
            string resultstr1 = "";
            Process p = new Process();
            p.StartInfo.FileName = @pyexefile;
            string sArguments = pyfile;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;//传递参数
            }
            sArguments += " " + args;
            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            resultstr1 = Console.ReadLine();
            //Debug.Print(resultstr1);
            getpyresult = getpyresult + " py3s " + resultstr1 + " py3e ";

            p.WaitForExit();
            return resultstr1;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            DateTime temtime = DateTime.Now;
            string pyexefilestr = "";//这里是python程序执行文件名字
            string sArguments = "";//这里是python文件名字
            try
            {
                string getstr = " ";
                string[] strArr = new string[3];//参数列表
                pyexefilestr = text_pyexe.Text;//这里是python程序执行文件名字
                sArguments = text_pyname.Text;//这里是python文件名字
                getpyresult = "";
                strArr[0] = text_data1.Text;  // "2";
                strArr[1] = text_data2.Text;  // "3";
                getstr = RunPythonScript1(pyexefilestr,sArguments, "-u", strArr);
                text_result2.Text = getpyresult;
                string strtem = "";
                strtem = " .button2_Click() "
                    + " 调用" + pyexefilestr + " 执行 " + pyexefilestr + " 时 " + getpyresult;
                ClassLog.WritedataTodo(temtime.ToString(), "ServerManger.FormPython2", strtem);
                Debug.Print(strtem);
            }
            catch (Exception ex)
            {
                string strtem = "";
                strtem = " .button2_Click() "
                    + " 调用" + pyexefilestr + " 执行 " + pyexefilestr + " 时 " + ex.ToString();
                ClassLog.Writelog(temtime.ToString(), "ServerManger.FormPython2", strtem);
                Debug.Print(strtem);
            }

        }
    }
}
