using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerMonitor
{

    public partial class FormServiceControl : Form
    {
        ClassServicecontrol myClassServicescontrol = new ClassServicecontrol();
        public FormServiceControl()
        {
            InitializeComponent();
        }
        public void GetdatafromModle()
        {
            bool mybool = false;
            //mybool = myClassServicescontrol.Services1check();
            text_Services1name.Text = myClassServicescontrol.Services1Name;
            text_App1path.Text = myClassServicescontrol.ServicesStatus;
            label_Services1Status.Text = myClassServicescontrol.Service1Status;
            label_Services1WaitStart.Text = myClassServicescontrol.Services1WaitStart.ToString();
            text_Services1Count0.Text = myClassServicescontrol.Services1Count0.ToString();
            text_Services1Count.Text = myClassServicescontrol.Services1Count.ToString();
            label_Services1DayrRestart.Text = myClassServicescontrol.Services1DayRestart.ToString();
            text_Services1DayrRestarHour.Text = myClassServicescontrol.Services1DayRestartHour.ToString();
            text_Services1DayrRestarMinute.Text = myClassServicescontrol.Services1DayRestartMinute.ToString();
            text_Services1DayrRestarCount.Text = myClassServicescontrol.Service1DayRestartCount.ToString();
            text_Services1DayRestartDT.Text = myClassServicescontrol.App1DayRestartDT.ToString();
            label_timer.Text = timer1.Enabled.ToString();
        }
        private void FormServiceControl_Load(object sender, EventArgs e)
        {
            myClassServicescontrol.getInitData();
            GetdatafromModle();
        }

        private void button_Services1Check_Click(object sender, EventArgs e)
        {
            bool mybool = false;
            mybool = myClassServicescontrol.Services1check();
            GetdatafromModle();
        }

        private void button_Services1start_Click(object sender, EventArgs e)
        {
            bool mybool = false;
            mybool = myClassServicescontrol.StartServices1();

        }

        private void button_Services1stop_Click(object sender, EventArgs e)
        {
            bool mybool = false;
            mybool = myClassServicescontrol.StopServices1();

        }

        private void button_Services1WaitStart_Click(object sender, EventArgs e)
        {
            if (myClassServicescontrol.Services1WaitStart)
            {
                myClassServicescontrol.Services1WaitStart = false;
            }
            else
            {
                myClassServicescontrol.Services1WaitStart = true;
            }

        }

        private void button_Services1DayrRestart_Click(object sender, EventArgs e)
        {
            if (myClassServicescontrol.Services1DayRestart)
            {
                myClassServicescontrol.Services1DayRestart = false;
            }
            else
            {
                myClassServicescontrol.Services1DayRestart = true;
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
