namespace ServerMonitor
{
    partial class FormServiceControl
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
            this.text_Now = new System.Windows.Forms.TextBox();
            this.text_Services1DayRestartDT = new System.Windows.Forms.TextBox();
            this.label_timer = new System.Windows.Forms.Label();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.text_Services1DayrRestarCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_Services1DayrRestarMinute = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.text_Services1DayrRestarHour = new System.Windows.Forms.TextBox();
            this.label_Services1DayrRestart = new System.Windows.Forms.Label();
            this.button_Services1DayrRestart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.text_Services1Count = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_Services1Count0 = new System.Windows.Forms.TextBox();
            this.label_Services1WaitStart = new System.Windows.Forms.Label();
            this.button_Services1WaitStart = new System.Windows.Forms.Button();
            this.button_Services1stop = new System.Windows.Forms.Button();
            this.button_Services1start = new System.Windows.Forms.Button();
            this.label_Services1Status = new System.Windows.Forms.Label();
            this.text_App1path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_Services1name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Services1Check = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // text_Now
            // 
            this.text_Now.Location = new System.Drawing.Point(273, 260);
            this.text_Now.Name = "text_Now";
            this.text_Now.Size = new System.Drawing.Size(168, 21);
            this.text_Now.TabIndex = 55;
            // 
            // text_Services1DayRestartDT
            // 
            this.text_Services1DayRestartDT.Location = new System.Drawing.Point(304, 221);
            this.text_Services1DayRestartDT.Name = "text_Services1DayRestartDT";
            this.text_Services1DayRestartDT.Size = new System.Drawing.Size(204, 21);
            this.text_Services1DayRestartDT.TabIndex = 54;
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.Location = new System.Drawing.Point(196, 269);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(71, 12);
            this.label_timer.TabIndex = 53;
            this.label_timer.Text = "label_timer";
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(40, 270);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(128, 23);
            this.button_Refresh.TabIndex = 52;
            this.button_Refresh.Text = "定时刷新界面";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // text_Services1DayrRestarCount
            // 
            this.text_Services1DayrRestarCount.Location = new System.Drawing.Point(478, 260);
            this.text_Services1DayrRestarCount.Name = "text_Services1DayrRestarCount";
            this.text_Services1DayrRestarCount.Size = new System.Drawing.Size(64, 21);
            this.text_Services1DayrRestarCount.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(548, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 50;
            this.label10.Text = "秒 后启动";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(530, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "分  重新启动";
            // 
            // text_Services1DayrRestarMinute
            // 
            this.text_Services1DayrRestarMinute.AcceptsTab = true;
            this.text_Services1DayrRestarMinute.Location = new System.Drawing.Point(445, 188);
            this.text_Services1DayrRestarMinute.Name = "text_Services1DayrRestarMinute";
            this.text_Services1DayrRestarMinute.Size = new System.Drawing.Size(64, 21);
            this.text_Services1DayrRestarMinute.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(398, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 47;
            this.label7.Text = "时";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 46;
            this.label8.Text = "设置每天";
            // 
            // text_Services1DayrRestarHour
            // 
            this.text_Services1DayrRestarHour.AcceptsTab = true;
            this.text_Services1DayrRestarHour.Location = new System.Drawing.Point(325, 186);
            this.text_Services1DayrRestarHour.Name = "text_Services1DayrRestarHour";
            this.text_Services1DayrRestarHour.Size = new System.Drawing.Size(64, 21);
            this.text_Services1DayrRestarHour.TabIndex = 45;
            // 
            // label_Services1DayrRestart
            // 
            this.label_Services1DayrRestart.AutoSize = true;
            this.label_Services1DayrRestart.Location = new System.Drawing.Point(195, 191);
            this.label_Services1DayrRestart.Name = "label_Services1DayrRestart";
            this.label_Services1DayrRestart.Size = new System.Drawing.Size(11, 12);
            this.label_Services1DayrRestart.TabIndex = 44;
            this.label_Services1DayrRestart.Text = "0";
            // 
            // button_Services1DayrRestart
            // 
            this.button_Services1DayrRestart.Location = new System.Drawing.Point(40, 186);
            this.button_Services1DayrRestart.Name = "button_Services1DayrRestart";
            this.button_Services1DayrRestart.Size = new System.Drawing.Size(128, 23);
            this.button_Services1DayrRestart.TabIndex = 43;
            this.button_Services1DayrRestart.Text = "每天定时重启";
            this.button_Services1DayrRestart.UseVisualStyleBackColor = true;
            this.button_Services1DayrRestart.Click += new System.EventHandler(this.button_Services1DayrRestart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(548, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 42;
            this.label5.Text = "后启动";
            // 
            // text_Services1Count
            // 
            this.text_Services1Count.Location = new System.Drawing.Point(445, 130);
            this.text_Services1Count.Name = "text_Services1Count";
            this.text_Services1Count.Size = new System.Drawing.Size(64, 21);
            this.text_Services1Count.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "计划";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "设置";
            // 
            // text_Services1Count0
            // 
            this.text_Services1Count0.Location = new System.Drawing.Point(326, 130);
            this.text_Services1Count0.Name = "text_Services1Count0";
            this.text_Services1Count0.Size = new System.Drawing.Size(64, 21);
            this.text_Services1Count0.TabIndex = 38;
            // 
            // label_Services1WaitStart
            // 
            this.label_Services1WaitStart.AutoSize = true;
            this.label_Services1WaitStart.Location = new System.Drawing.Point(193, 138);
            this.label_Services1WaitStart.Name = "label_Services1WaitStart";
            this.label_Services1WaitStart.Size = new System.Drawing.Size(11, 12);
            this.label_Services1WaitStart.TabIndex = 37;
            this.label_Services1WaitStart.Text = "0";
            // 
            // button_Services1WaitStart
            // 
            this.button_Services1WaitStart.Location = new System.Drawing.Point(38, 133);
            this.button_Services1WaitStart.Name = "button_Services1WaitStart";
            this.button_Services1WaitStart.Size = new System.Drawing.Size(128, 23);
            this.button_Services1WaitStart.TabIndex = 36;
            this.button_Services1WaitStart.Text = "退出后延时重启";
            this.button_Services1WaitStart.UseVisualStyleBackColor = true;
            this.button_Services1WaitStart.Click += new System.EventHandler(this.button_Services1WaitStart_Click);
            // 
            // button_Services1stop
            // 
            this.button_Services1stop.Location = new System.Drawing.Point(566, 50);
            this.button_Services1stop.Name = "button_Services1stop";
            this.button_Services1stop.Size = new System.Drawing.Size(61, 30);
            this.button_Services1stop.TabIndex = 35;
            this.button_Services1stop.Text = "停止";
            this.button_Services1stop.UseVisualStyleBackColor = true;
            this.button_Services1stop.Click += new System.EventHandler(this.button_Services1stop_Click);
            // 
            // button_Services1start
            // 
            this.button_Services1start.Location = new System.Drawing.Point(499, 50);
            this.button_Services1start.Name = "button_Services1start";
            this.button_Services1start.Size = new System.Drawing.Size(61, 30);
            this.button_Services1start.TabIndex = 34;
            this.button_Services1start.Text = "启动";
            this.button_Services1start.UseVisualStyleBackColor = true;
            this.button_Services1start.Click += new System.EventHandler(this.button_Services1start_Click);
            // 
            // label_Services1Status
            // 
            this.label_Services1Status.AutoSize = true;
            this.label_Services1Status.Location = new System.Drawing.Point(370, 59);
            this.label_Services1Status.Name = "label_Services1Status";
            this.label_Services1Status.Size = new System.Drawing.Size(29, 12);
            this.label_Services1Status.TabIndex = 33;
            this.label_Services1Status.Text = "运行";
            // 
            // text_App1path
            // 
            this.text_App1path.Location = new System.Drawing.Point(127, 86);
            this.text_App1path.Name = "text_App1path";
            this.text_App1path.Size = new System.Drawing.Size(634, 21);
            this.text_App1path.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "服务状态";
            // 
            // text_Services1name
            // 
            this.text_Services1name.Location = new System.Drawing.Point(128, 54);
            this.text_Services1name.Name = "text_Services1name";
            this.text_Services1name.Size = new System.Drawing.Size(134, 21);
            this.text_Services1name.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "服务1";
            // 
            // button_Services1Check
            // 
            this.button_Services1Check.Location = new System.Drawing.Point(283, 50);
            this.button_Services1Check.Name = "button_Services1Check";
            this.button_Services1Check.Size = new System.Drawing.Size(61, 30);
            this.button_Services1Check.TabIndex = 28;
            this.button_Services1Check.Text = "检查状态";
            this.button_Services1Check.UseVisualStyleBackColor = true;
            this.button_Services1Check.Click += new System.EventHandler(this.button_Services1Check_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormServiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.text_Now);
            this.Controls.Add(this.text_Services1DayRestartDT);
            this.Controls.Add(this.label_timer);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.text_Services1DayrRestarCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.text_Services1DayrRestarMinute);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.text_Services1DayrRestarHour);
            this.Controls.Add(this.label_Services1DayrRestart);
            this.Controls.Add(this.button_Services1DayrRestart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_Services1Count);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_Services1Count0);
            this.Controls.Add(this.label_Services1WaitStart);
            this.Controls.Add(this.button_Services1WaitStart);
            this.Controls.Add(this.button_Services1stop);
            this.Controls.Add(this.button_Services1start);
            this.Controls.Add(this.label_Services1Status);
            this.Controls.Add(this.text_App1path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_Services1name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Services1Check);
            this.Name = "FormServiceControl";
            this.Text = "FormServiceControl";
            this.Load += new System.EventHandler(this.FormServiceControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_Now;
        private System.Windows.Forms.TextBox text_Services1DayRestartDT;
        private System.Windows.Forms.Label label_timer;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.TextBox text_Services1DayrRestarCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_Services1DayrRestarMinute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox text_Services1DayrRestarHour;
        private System.Windows.Forms.Label label_Services1DayrRestart;
        private System.Windows.Forms.Button button_Services1DayrRestart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_Services1Count;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_Services1Count0;
        private System.Windows.Forms.Label label_Services1WaitStart;
        private System.Windows.Forms.Button button_Services1WaitStart;
        private System.Windows.Forms.Button button_Services1stop;
        private System.Windows.Forms.Button button_Services1start;
        private System.Windows.Forms.Label label_Services1Status;
        private System.Windows.Forms.TextBox text_App1path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_Services1name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Services1Check;
        private System.Windows.Forms.Timer timer1;
    }
}