using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryTool1;
using ServerMonitor;

namespace ServerMonitor
{
    public partial class FormAppControl : Form
    {
        ClassAppcontrol myClassAppcontrol = new ClassAppcontrol();
        public FormAppControl()
        {
            InitializeComponent();
        }

        public void GetdatafromModle()
        {
            bool mybool = false;
            //mybool = myClassServicescontrol.Services1check();
            text_App1name.Text = myClassAppcontrol.App1Name;
            text_App1path.Text = myClassAppcontrol.App1Path;
            label_App1Status.Text = myClassAppcontrol.App1Status;
            label_App1WaitStart.Text = myClassAppcontrol.App1WaitStart.ToString();
            text_app1Count0.Text = myClassAppcontrol.App1Count0.ToString();
            text_app1Count.Text = myClassAppcontrol.App1Count.ToString();
            label_App1DayrRestart.Text = myClassAppcontrol.App1DayRestart.ToString();
            text_App1DayrRestarHour.Text = myClassAppcontrol.App1DayRestartHour.ToString();
            text_App1DayrRestarMinute.Text = myClassAppcontrol.App1DayRestartMinute.ToString();
            text_App1DayrRestarCount.Text = myClassAppcontrol.App1DayRestartCount.ToString();
            text_App1DayRestartDT.Text = myClassAppcontrol.App1DayRestartDT.ToString();
            label_timer.Text = timer1.Enabled.ToString();
        }
        private void FormAppControl_Load(object sender, EventArgs e)
        {
            myClassAppcontrol.getInitData();
            GetdatafromModle();
        }

        private void button_App1Check_Click(object sender, EventArgs e)
        {
            bool mybool = false;
            mybool = myClassAppcontrol.App1check();
            GetdatafromModle();
            

        }

        private void button_App1start_Click(object sender, EventArgs e)
        {
            bool mybool = false;
            mybool = myClassAppcontrol.StartApp1();

        }

        private void button_App1stop_Click(object sender, EventArgs e)
        {
            bool mybool = false;
            mybool = myClassAppcontrol.KillApp1();

        }

        private void button_App1WaitStart_Click(object sender, EventArgs e)
        {
            if(myClassAppcontrol.App1WaitStart)
            {
                myClassAppcontrol.App1WaitStart = false;
            }
            else
            {
                myClassAppcontrol.App1WaitStart = true;
            }
        }



        private void button_App1DayrRestart_Click(object sender, EventArgs e)
        {
            if (myClassAppcontrol.App1DayRestart)
            {
                myClassAppcontrol.App1DayRestart = false;
            }
            else
            {
                myClassAppcontrol.App1DayRestart = true;
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;

            }
            label_timer.Text = timer1.Enabled.ToString();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            text_Now.Text = DateTime.Now.ToString();
            GetdatafromModle();
        }

    }
}
