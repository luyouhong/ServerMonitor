namespace ServrerMonitor
{
    public partial class FormAppControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_App1Check = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.text_App1name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_App1path = new System.Windows.Forms.TextBox();
            this.label_App1Status = new System.Windows.Forms.Label();
            this.button_App1start = new System.Windows.Forms.Button();
            this.button_App1stop = new System.Windows.Forms.Button();
            this.button_App1WaitStart = new System.Windows.Forms.Button();
            this.label_App1WaitStart = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.text_app1Count0 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.text_app1Count = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_App1DayrRestarMinute = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.text_App1DayrRestarHour = new System.Windows.Forms.TextBox();
            this.label_App1DayrRestart = new System.Windows.Forms.Label();
            this.button_App1DayrRestart = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.text_App1DayrRestarCount = new System.Windows.Forms.TextBox();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.label_timer = new System.Windows.Forms.Label();
            this.text_App1DayRestartDT = new System.Windows.Forms.TextBox();
            this.text_Now = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_App1Check
            // 
            this.button_App1Check.Location = new System.Drawing.Point(295, 29);
            this.button_App1Check.Name = "button_App1Check";
            this.button_App1Check.Size = new System.Drawing.Size(61, 30);
            this.button_App1Check.TabIndex = 0;
            this.button_App1Check.Text = "检查状态";
            this.button_App1Check.UseVisualStyleBackColor = true;
            this.button_App1Check.Click += new System.EventHandler(this.button_App1Check_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "应用程序1";
            // 
            // text_App1name
            // 
            this.text_App1name.Location = new System.Drawing.Point(140, 33);
            this.text_App1name.Name = "text_App1name";
            this.text_App1name.Size = new System.Drawing.Size(134, 21);
            this.text_App1name.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "应用程序路径:";
            // 
            // text_App1path
            // 
            this.text_App1path.Location = new System.Drawing.Point(139, 65);
            this.text_App1path.Name = "text_App1path";
            this.text_App1path.Size = new System.Drawing.Size(634, 21);
            this.text_App1path.TabIndex = 4;
            // 
            // label_App1Status
            // 
            this.label_App1Status.AutoSize = true;
            this.label_App1Status.Location = new System.Drawing.Point(382, 38);
            this.label_App1Status.Name = "label_App1Status";
            this.label_App1Status.Size = new System.Drawing.Size(29, 12);
            this.label_App1Status.TabIndex = 5;
            this.label_App1Status.Text = "运行";
            // 
            // button_App1start
            // 
            this.button_App1start.Location = new System.Drawing.Point(511, 29);
            this.button_App1start.Name = "button_App1start";
            this.button_App1start.Size = new System.Drawing.Size(61, 30);
            this.button_App1start.TabIndex = 6;
            this.button_App1start.Text = "启动";
            this.button_App1start.UseVisualStyleBackColor = true;
            this.button_App1start.Click += new System.EventHandler(this.button_App1start_Click);
            // 
            // button_App1stop
            // 
            this.button_App1stop.Location = new System.Drawing.Point(578, 29);
            this.button_App1stop.Name = "button_App1stop";
            this.button_App1stop.Size = new System.Drawing.Size(61, 30);
            this.button_App1stop.TabIndex = 7;
            this.button_App1stop.Text = "停止";
            this.button_App1stop.UseVisualStyleBackColor = true;
            this.button_App1stop.Click += new System.EventHandler(this.button_App1stop_Click);
            // 
            // button_App1WaitStart
            // 
            this.button_App1WaitStart.Location = new System.Drawing.Point(50, 112);
            this.button_App1WaitStart.Name = "button_App1WaitStart";
            this.button_App1WaitStart.Size = new System.Drawing.Size(128, 23);
            this.button_App1WaitStart.TabIndex = 8;
            this.button_App1WaitStart.Text = "退出后延时重启";
            this.button_App1WaitStart.UseVisualStyleBackColor = true;
            this.button_App1WaitStart.Click += new System.EventHandler(this.button_App1WaitStart_Click);
            // 
            // label_App1WaitStart
            // 
            this.label_App1WaitStart.AutoSize = true;
            this.label_App1WaitStart.Location = new System.Drawing.Point(205, 117);
            this.label_App1WaitStart.Name = "label_App1WaitStart";
            this.label_App1WaitStart.Size = new System.Drawing.Size(41, 12);
            this.label_App1WaitStart.TabIndex = 9;
            this.label_App1WaitStart.Text = "label3";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // text_app1Count0
            // 
            this.text_app1Count0.Location = new System.Drawing.Point(338, 109);
            this.text_app1Count0.Name = "text_app1Count0";
            this.text_app1Count0.Size = new System.Drawing.Size(64, 21);
            this.text_app1Count0.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "设置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "计划";
            // 
            // text_app1Count
            // 
            this.text_app1Count.Location = new System.Drawing.Point(457, 109);
            this.text_app1Count.Name = "text_app1Count";
            this.text_app1Count.Size = new System.Drawing.Size(64, 21);
            this.text_app1Count.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(560, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "后启动";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(542, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "分  重新启动";
            // 
            // text_App1DayrRestarMinute
            // 
            this.text_App1DayrRestarMinute.AcceptsTab = true;
            this.text_App1DayrRestarMinute.Location = new System.Drawing.Point(457, 167);
            this.text_App1DayrRestarMinute.Name = "text_App1DayrRestarMinute";
            this.text_App1DayrRestarMinute.Size = new System.Drawing.Size(64, 21);
            this.text_App1DayrRestarMinute.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "时";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "设置每天";
            // 
            // text_App1DayrRestarHour
            // 
            this.text_App1DayrRestarHour.AcceptsTab = true;
            this.text_App1DayrRestarHour.Location = new System.Drawing.Point(337, 165);
            this.text_App1DayrRestarHour.Name = "text_App1DayrRestarHour";
            this.text_App1DayrRestarHour.Size = new System.Drawing.Size(64, 21);
            this.text_App1DayrRestarHour.TabIndex = 17;
            // 
            // label_App1DayrRestart
            // 
            this.label_App1DayrRestart.AutoSize = true;
            this.label_App1DayrRestart.Location = new System.Drawing.Point(207, 170);
            this.label_App1DayrRestart.Name = "label_App1DayrRestart";
            this.label_App1DayrRestart.Size = new System.Drawing.Size(41, 12);
            this.label_App1DayrRestart.TabIndex = 16;
            this.label_App1DayrRestart.Text = "label3";
            // 
            // button_App1DayrRestart
            // 
            this.button_App1DayrRestart.Location = new System.Drawing.Point(52, 165);
            this.button_App1DayrRestart.Name = "button_App1DayrRestart";
            this.button_App1DayrRestart.Size = new System.Drawing.Size(128, 23);
            this.button_App1DayrRestart.TabIndex = 15;
            this.button_App1DayrRestart.Text = "每天定时重启";
            this.button_App1DayrRestart.UseVisualStyleBackColor = true;
            this.button_App1DayrRestart.Click += new System.EventHandler(this.button_App1DayrRestart_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(560, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "秒 后启动";
            // 
            // text_App1DayrRestarCount
            // 
            this.text_App1DayrRestarCount.Location = new System.Drawing.Point(490, 239);
            this.text_App1DayrRestarCount.Name = "text_App1DayrRestarCount";
            this.text_App1DayrRestarCount.Size = new System.Drawing.Size(64, 21);
            this.text_App1DayrRestarCount.TabIndex = 23;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(52, 249);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(128, 23);
            this.button_Refresh.TabIndex = 24;
            this.button_Refresh.Text = "定时刷新界面";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.Location = new System.Drawing.Point(208, 248);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(71, 12);
            this.label_timer.TabIndex = 25;
            this.label_timer.Text = "label_timer";
            // 
            // text_App1DayRestartDT
            // 
            this.text_App1DayRestartDT.Location = new System.Drawing.Point(316, 200);
            this.text_App1DayRestartDT.Name = "text_App1DayRestartDT";
            this.text_App1DayRestartDT.Size = new System.Drawing.Size(204, 21);
            this.text_App1DayRestartDT.TabIndex = 26;
            // 
            // text_Now
            // 
            this.text_Now.Location = new System.Drawing.Point(285, 239);
            this.text_Now.Name = "text_Now";
            this.text_Now.Size = new System.Drawing.Size(168, 21);
            this.text_Now.TabIndex = 27;
            // 
            // FormAppControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.text_Now);
            this.Controls.Add(this.text_App1DayRestartDT);
            this.Controls.Add(this.label_timer);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.text_App1DayrRestarCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.text_App1DayrRestarMinute);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.text_App1DayrRestarHour);
            this.Controls.Add(this.label_App1DayrRestart);
            this.Controls.Add(this.button_App1DayrRestart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_app1Count);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_app1Count0);
            this.Controls.Add(this.label_App1WaitStart);
            this.Controls.Add(this.button_App1WaitStart);
            this.Controls.Add(this.button_App1stop);
            this.Controls.Add(this.button_App1start);
            this.Controls.Add(this.label_App1Status);
            this.Controls.Add(this.text_App1path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_App1name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_App1Check);
            this.Name = "FormAppControl";
            this.Text = "FormAppControl";
            this.Load += new System.EventHandler(this.FormAppControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_App1Check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_App1name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_App1path;
        private System.Windows.Forms.Label label_App1Status;
        private System.Windows.Forms.Button button_App1start;
        private System.Windows.Forms.Button button_App1stop;
        private System.Windows.Forms.Button button_App1WaitStart;
        private System.Windows.Forms.Label label_App1WaitStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox text_app1Count0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_app1Count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_App1DayrRestarMinute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox text_App1DayrRestarHour;
        private System.Windows.Forms.Label label_App1DayrRestart;
        private System.Windows.Forms.Button button_App1DayrRestart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_App1DayrRestarCount;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Label label_timer;
        private System.Windows.Forms.TextBox text_App1DayRestartDT;
        private System.Windows.Forms.TextBox text_Now;
    }
}