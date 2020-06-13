namespace ServerMonitor
{
    partial class FormPython2
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
            this.button1 = new System.Windows.Forms.Button();
            this.text_data2 = new System.Windows.Forms.TextBox();
            this.text_data1 = new System.Windows.Forms.TextBox();
            this.label_result1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.text_pyname = new System.Windows.Forms.TextBox();
            this.label_result2 = new System.Windows.Forms.Label();
            this.text_pyexe = new System.Windows.Forms.TextBox();
            this.text_result2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_data2
            // 
            this.text_data2.Location = new System.Drawing.Point(255, 74);
            this.text_data2.Name = "text_data2";
            this.text_data2.Size = new System.Drawing.Size(114, 21);
            this.text_data2.TabIndex = 4;
            // 
            // text_data1
            // 
            this.text_data1.Location = new System.Drawing.Point(63, 74);
            this.text_data1.Name = "text_data1";
            this.text_data1.Size = new System.Drawing.Size(103, 21);
            this.text_data1.TabIndex = 3;
            // 
            // label_result1
            // 
            this.label_result1.AutoSize = true;
            this.label_result1.Location = new System.Drawing.Point(80, 119);
            this.label_result1.Name = "label_result1";
            this.label_result1.Size = new System.Drawing.Size(53, 12);
            this.label_result1.TabIndex = 5;
            this.label_result1.Text = "计算结果";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(571, 217);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 50);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // text_pyname
            // 
            this.text_pyname.Location = new System.Drawing.Point(63, 244);
            this.text_pyname.Name = "text_pyname";
            this.text_pyname.Size = new System.Drawing.Size(477, 21);
            this.text_pyname.TabIndex = 7;
            this.text_pyname.Text = "E:\\mysoft\\py\\WindowsApplication2\\WindowsApplication2\\K-Means1.py";
            // 
            // label_result2
            // 
            this.label_result2.AutoSize = true;
            this.label_result2.Location = new System.Drawing.Point(61, 280);
            this.label_result2.Name = "label_result2";
            this.label_result2.Size = new System.Drawing.Size(53, 12);
            this.label_result2.TabIndex = 8;
            this.label_result2.Text = "计算结果";
            // 
            // text_pyexe
            // 
            this.text_pyexe.Location = new System.Drawing.Point(63, 217);
            this.text_pyexe.Name = "text_pyexe";
            this.text_pyexe.Size = new System.Drawing.Size(477, 21);
            this.text_pyexe.TabIndex = 9;
            this.text_pyexe.Text = "C:\\Program Files (x86)\\Microsoft Visual Studio\\Shared\\Python37_64\\python.exe";
            // 
            // text_result2
            // 
            this.text_result2.BackColor = System.Drawing.SystemColors.Info;
            this.text_result2.Location = new System.Drawing.Point(65, 304);
            this.text_result2.Multiline = true;
            this.text_result2.Name = "text_result2";
            this.text_result2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_result2.Size = new System.Drawing.Size(611, 121);
            this.text_result2.TabIndex = 10;
            // 
            // FormPython2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.text_result2);
            this.Controls.Add(this.text_pyexe);
            this.Controls.Add(this.label_result2);
            this.Controls.Add(this.text_pyname);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label_result1);
            this.Controls.Add(this.text_data2);
            this.Controls.Add(this.text_data1);
            this.Controls.Add(this.button1);
            this.Name = "FormPython2";
            this.Text = "FormPython2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox text_data2;
        private System.Windows.Forms.TextBox text_data1;
        private System.Windows.Forms.Label label_result1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox text_pyname;
        private System.Windows.Forms.Label label_result2;
        private System.Windows.Forms.TextBox text_pyexe;
        private System.Windows.Forms.TextBox text_result2;
    }
}