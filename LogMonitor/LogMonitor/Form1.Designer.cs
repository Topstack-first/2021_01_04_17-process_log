
namespace LogMonitor
{
    partial class LogMonitorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogMonitorForm));
            this.btn_logpath = new System.Windows.Forms.Button();
            this.tb_logpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_emailTo = new System.Windows.Forms.TextBox();
            this.tb_emailFrom = new System.Windows.Forms.TextBox();
            this.tb_emailSubject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_serverIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_parseInterval = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_process1 = new System.Windows.Forms.TextBox();
            this.tb_process2 = new System.Windows.Forms.TextBox();
            this.tb_process3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lb_lastParseTime = new System.Windows.Forms.Label();
            this.lb_nextParseTime = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_selfLogPath = new System.Windows.Forms.TextBox();
            this.btn_pause = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.dtp_licenseExpiredDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_stopFrom = new System.Windows.Forms.DateTimePicker();
            this.dtp_stopTo = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtp_reset = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tb_process1Path = new System.Windows.Forms.TextBox();
            this.tb_process2Path = new System.Windows.Forms.TextBox();
            this.tb_process3Path = new System.Windows.Forms.TextBox();
            this.btn_process1Path = new System.Windows.Forms.Button();
            this.btn_process2Path = new System.Windows.Forms.Button();
            this.btn_process3Path = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_selfLogPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_parseInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_logpath
            // 
            this.btn_logpath.Location = new System.Drawing.Point(597, 19);
            this.btn_logpath.Name = "btn_logpath";
            this.btn_logpath.Size = new System.Drawing.Size(75, 30);
            this.btn_logpath.TabIndex = 1;
            this.btn_logpath.Text = "Browse";
            this.btn_logpath.UseVisualStyleBackColor = true;
            this.btn_logpath.Click += new System.EventHandler(this.OnBrowseLogMonitorPath);
            // 
            // tb_logpath
            // 
            this.tb_logpath.Location = new System.Drawing.Point(151, 20);
            this.tb_logpath.Name = "tb_logpath";
            this.tb_logpath.PlaceholderText = "Input Log Directory Path";
            this.tb_logpath.Size = new System.Drawing.Size(424, 29);
            this.tb_logpath.TabIndex = 1;
            this.tb_logpath.TextChanged += new System.EventHandler(this.OnLogMonitorPathChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log Path :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email To :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Email From :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Email Subject :";
            // 
            // tb_emailTo
            // 
            this.tb_emailTo.Location = new System.Drawing.Point(151, 54);
            this.tb_emailTo.Name = "tb_emailTo";
            this.tb_emailTo.PlaceholderText = "Input Destination Email Address";
            this.tb_emailTo.Size = new System.Drawing.Size(424, 29);
            this.tb_emailTo.TabIndex = 1;
            this.tb_emailTo.TextChanged += new System.EventHandler(this.OnEmailToChanged);
            // 
            // tb_emailFrom
            // 
            this.tb_emailFrom.Location = new System.Drawing.Point(151, 88);
            this.tb_emailFrom.Name = "tb_emailFrom";
            this.tb_emailFrom.PlaceholderText = "Input Source Email Address";
            this.tb_emailFrom.Size = new System.Drawing.Size(424, 29);
            this.tb_emailFrom.TabIndex = 1;
            this.tb_emailFrom.TextChanged += new System.EventHandler(this.OnEmailFromChanged);
            // 
            // tb_emailSubject
            // 
            this.tb_emailSubject.Location = new System.Drawing.Point(151, 122);
            this.tb_emailSubject.Name = "tb_emailSubject";
            this.tb_emailSubject.PlaceholderText = "Input Email Subject";
            this.tb_emailSubject.Size = new System.Drawing.Size(424, 29);
            this.tb_emailSubject.TabIndex = 1;
            this.tb_emailSubject.TextChanged += new System.EventHandler(this.OnEmailSubjectChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Server IP(SMTP) :";
            // 
            // tb_serverIP
            // 
            this.tb_serverIP.Location = new System.Drawing.Point(151, 156);
            this.tb_serverIP.Name = "tb_serverIP";
            this.tb_serverIP.PlaceholderText = "Input Server IP (SMTP)";
            this.tb_serverIP.Size = new System.Drawing.Size(424, 29);
            this.tb_serverIP.TabIndex = 1;
            this.tb_serverIP.TextChanged += new System.EventHandler(this.OnEmailServerChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Parse Interval :";
            // 
            // nud_parseInterval
            // 
            this.nud_parseInterval.Location = new System.Drawing.Point(219, 406);
            this.nud_parseInterval.Name = "nud_parseInterval";
            this.nud_parseInterval.Size = new System.Drawing.Size(131, 29);
            this.nud_parseInterval.TabIndex = 2;
            this.nud_parseInterval.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nud_parseInterval.ValueChanged += new System.EventHandler(this.OnParseIntervalChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(368, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "seconds";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Process1(Terminal) :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "Process2(Gateway) :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 308);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "Process3(Process watcher) :";
            // 
            // tb_process1
            // 
            this.tb_process1.Location = new System.Drawing.Point(219, 236);
            this.tb_process1.Name = "tb_process1";
            this.tb_process1.PlaceholderText = "xyz";
            this.tb_process1.Size = new System.Drawing.Size(153, 29);
            this.tb_process1.TabIndex = 1;
            this.tb_process1.TextChanged += new System.EventHandler(this.OnProcess1NameChanged);
            // 
            // tb_process2
            // 
            this.tb_process2.Location = new System.Drawing.Point(219, 270);
            this.tb_process2.Name = "tb_process2";
            this.tb_process2.PlaceholderText = "xyz";
            this.tb_process2.Size = new System.Drawing.Size(153, 29);
            this.tb_process2.TabIndex = 1;
            this.tb_process2.TextChanged += new System.EventHandler(this.OnProcess2NameChanged);
            // 
            // tb_process3
            // 
            this.tb_process3.Location = new System.Drawing.Point(219, 304);
            this.tb_process3.Name = "tb_process3";
            this.tb_process3.PlaceholderText = "xyz";
            this.tb_process3.Size = new System.Drawing.Size(153, 29);
            this.tb_process3.TabIndex = 1;
            this.tb_process3.TextChanged += new System.EventHandler(this.OnProcess3NameChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 347);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 21);
            this.label14.TabIndex = 1;
            this.label14.Text = "Last Parse Time :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 377);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 21);
            this.label15.TabIndex = 1;
            this.label15.Text = "Next Parse Time :";
            // 
            // lb_lastParseTime
            // 
            this.lb_lastParseTime.AutoSize = true;
            this.lb_lastParseTime.Location = new System.Drawing.Point(219, 347);
            this.lb_lastParseTime.Name = "lb_lastParseTime";
            this.lb_lastParseTime.Size = new System.Drawing.Size(92, 21);
            this.lb_lastParseTime.TabIndex = 1;
            this.lb_lastParseTime.Text = "1 / 1 / 2021 00:00:00";
            // 
            // lb_nextParseTime
            // 
            this.lb_nextParseTime.AutoSize = true;
            this.lb_nextParseTime.Location = new System.Drawing.Point(219, 377);
            this.lb_nextParseTime.Name = "lb_nextParseTime";
            this.lb_nextParseTime.Size = new System.Drawing.Size(92, 21);
            this.lb_nextParseTime.TabIndex = 1;
            this.lb_nextParseTime.Text = "1 / 1 / 2021 00:00:00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 196);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 21);
            this.label18.TabIndex = 1;
            this.label18.Text = "Self Log Path :";
            // 
            // tb_selfLogPath
            // 
            this.tb_selfLogPath.Location = new System.Drawing.Point(151, 191);
            this.tb_selfLogPath.Name = "tb_selfLogPath";
            this.tb_selfLogPath.PlaceholderText = "Input Logging file path";
            this.tb_selfLogPath.Size = new System.Drawing.Size(424, 29);
            this.tb_selfLogPath.TabIndex = 1;
            this.tb_selfLogPath.TextChanged += new System.EventHandler(this.OnLogSelfFilePathChanged);
            // 
            // btn_pause
            // 
            this.btn_pause.Location = new System.Drawing.Point(76, 562);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(164, 30);
            this.btn_pause.TabIndex = 1;
            this.btn_pause.Text = "Pause Monitor";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.OnPauseMonitor);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 444);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(146, 21);
            this.label19.TabIndex = 1;
            this.label19.Text = "License Expiry Date:";
            // 
            // dtp_licenseExpiredDate
            // 
            this.dtp_licenseExpiredDate.CustomFormat = "";
            this.dtp_licenseExpiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_licenseExpiredDate.Location = new System.Drawing.Point(219, 442);
            this.dtp_licenseExpiredDate.Name = "dtp_licenseExpiredDate";
            this.dtp_licenseExpiredDate.Size = new System.Drawing.Size(131, 29);
            this.dtp_licenseExpiredDate.TabIndex = 3;
            // 
            // dtp_stopFrom
            // 
            this.dtp_stopFrom.CustomFormat = "HH:mm  dddd  ";
            this.dtp_stopFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_stopFrom.Location = new System.Drawing.Point(219, 519);
            this.dtp_stopFrom.Name = "dtp_stopFrom";
            this.dtp_stopFrom.Size = new System.Drawing.Size(177, 29);
            this.dtp_stopFrom.TabIndex = 3;
            this.dtp_stopFrom.ValueChanged += new System.EventHandler(this.OnStopDateFromChanged);
            // 
            // dtp_stopTo
            // 
            this.dtp_stopTo.CustomFormat = "HH:mm  dddd  ";
            this.dtp_stopTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_stopTo.Location = new System.Drawing.Point(450, 519);
            this.dtp_stopTo.Name = "dtp_stopTo";
            this.dtp_stopTo.Size = new System.Drawing.Size(181, 29);
            this.dtp_stopTo.TabIndex = 3;
            this.dtp_stopTo.ValueChanged += new System.EventHandler(this.OnStopDateToChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(155, 523);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 21);
            this.label16.TabIndex = 1;
            this.label16.Text = "From :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(413, 523);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 21);
            this.label17.TabIndex = 1;
            this.label17.Text = "To :";
            // 
            // dtp_reset
            // 
            this.dtp_reset.CustomFormat = "HH:mm  dddd";
            this.dtp_reset.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_reset.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtp_reset.Location = new System.Drawing.Point(219, 480);
            this.dtp_reset.Name = "dtp_reset";
            this.dtp_reset.Size = new System.Drawing.Size(177, 29);
            this.dtp_reset.TabIndex = 3;
            this.dtp_reset.ValueChanged += new System.EventHandler(this.OnResetDateChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 521);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 21);
            this.label20.TabIndex = 1;
            this.label20.Text = "Inactive Period:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 482);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 21);
            this.label21.TabIndex = 1;
            this.label21.Text = "Reset Date:";
            // 
            // tb_process1Path
            // 
            this.tb_process1Path.Location = new System.Drawing.Point(381, 236);
            this.tb_process1Path.Name = "tb_process1Path";
            this.tb_process1Path.PlaceholderText = "Input Process1 Path";
            this.tb_process1Path.Size = new System.Drawing.Size(211, 29);
            this.tb_process1Path.TabIndex = 1;
            this.tb_process1Path.TextChanged += new System.EventHandler(this.OnProcess1PathChanged);
            // 
            // tb_process2Path
            // 
            this.tb_process2Path.Location = new System.Drawing.Point(381, 270);
            this.tb_process2Path.Name = "tb_process2Path";
            this.tb_process2Path.PlaceholderText = "Input Process2 Path";
            this.tb_process2Path.Size = new System.Drawing.Size(211, 29);
            this.tb_process2Path.TabIndex = 1;
            this.tb_process2Path.TextChanged += new System.EventHandler(this.OnProcess2PathChanged);
            // 
            // tb_process3Path
            // 
            this.tb_process3Path.Location = new System.Drawing.Point(381, 304);
            this.tb_process3Path.Name = "tb_process3Path";
            this.tb_process3Path.PlaceholderText = "Input Process3 Path";
            this.tb_process3Path.Size = new System.Drawing.Size(211, 29);
            this.tb_process3Path.TabIndex = 1;
            this.tb_process3Path.TextChanged += new System.EventHandler(this.OnProcess3PathChanged);
            // 
            // btn_process1Path
            // 
            this.btn_process1Path.Location = new System.Drawing.Point(608, 235);
            this.btn_process1Path.Name = "btn_process1Path";
            this.btn_process1Path.Size = new System.Drawing.Size(62, 30);
            this.btn_process1Path.TabIndex = 1;
            this.btn_process1Path.Text = "Path";
            this.btn_process1Path.UseVisualStyleBackColor = true;
            this.btn_process1Path.Click += new System.EventHandler(this.OnBrowseProcess1Path);
            // 
            // btn_process2Path
            // 
            this.btn_process2Path.Location = new System.Drawing.Point(608, 269);
            this.btn_process2Path.Name = "btn_process2Path";
            this.btn_process2Path.Size = new System.Drawing.Size(62, 30);
            this.btn_process2Path.TabIndex = 1;
            this.btn_process2Path.Text = "Path";
            this.btn_process2Path.UseVisualStyleBackColor = true;
            this.btn_process2Path.Click += new System.EventHandler(this.OnBrowseProcess2Path);
            // 
            // btn_process3Path
            // 
            this.btn_process3Path.Location = new System.Drawing.Point(608, 303);
            this.btn_process3Path.Name = "btn_process3Path";
            this.btn_process3Path.Size = new System.Drawing.Size(62, 30);
            this.btn_process3Path.TabIndex = 1;
            this.btn_process3Path.Text = "Path";
            this.btn_process3Path.UseVisualStyleBackColor = true;
            this.btn_process3Path.Click += new System.EventHandler(this.OnBrowseProcess3Path);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(263, 562);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 30);
            this.button4.TabIndex = 1;
            this.button4.Text = "Start Process";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnStartProcess);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(443, 562);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(164, 30);
            this.button5.TabIndex = 1;
            this.button5.Text = "Restart Process";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OnRestartProcess);
            // 
            // btn_selfLogPath
            // 
            this.btn_selfLogPath.Location = new System.Drawing.Point(595, 191);
            this.btn_selfLogPath.Name = "btn_selfLogPath";
            this.btn_selfLogPath.Size = new System.Drawing.Size(75, 30);
            this.btn_selfLogPath.TabIndex = 1;
            this.btn_selfLogPath.Text = "Browse";
            this.btn_selfLogPath.UseVisualStyleBackColor = true;
            this.btn_selfLogPath.Click += new System.EventHandler(this.OnBrowseLogSelfFilePath);
            // 
            // LogMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 601);
            this.Controls.Add(this.dtp_stopTo);
            this.Controls.Add(this.dtp_reset);
            this.Controls.Add(this.dtp_stopFrom);
            this.Controls.Add(this.dtp_licenseExpiredDate);
            this.Controls.Add(this.nud_parseInterval);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_process3Path);
            this.Controls.Add(this.btn_process2Path);
            this.Controls.Add(this.btn_process1Path);
            this.Controls.Add(this.btn_selfLogPath);
            this.Controls.Add(this.btn_logpath);
            this.Controls.Add(this.tb_process3);
            this.Controls.Add(this.tb_process2);
            this.Controls.Add(this.tb_process3Path);
            this.Controls.Add(this.tb_process2Path);
            this.Controls.Add(this.tb_process1Path);
            this.Controls.Add(this.tb_process1);
            this.Controls.Add(this.tb_selfLogPath);
            this.Controls.Add(this.tb_serverIP);
            this.Controls.Add(this.tb_emailSubject);
            this.Controls.Add(this.tb_emailFrom);
            this.Controls.Add(this.tb_emailTo);
            this.Controls.Add(this.tb_logpath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_nextParseTime);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lb_lastParseTime);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 760);
            this.MinimumSize = new System.Drawing.Size(700, 640);
            this.Name = "LogMonitorForm";
            this.Text = "LogMonitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnLogMonitorClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nud_parseInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_logpath;
        private System.Windows.Forms.TextBox tb_logpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_emailTo;
        private System.Windows.Forms.TextBox tb_emailFrom;
        private System.Windows.Forms.TextBox tb_emailSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_serverIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nud_parseInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_process1;
        private System.Windows.Forms.TextBox tb_process2;
        private System.Windows.Forms.TextBox tb_process3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lb_lastParseTime;
        private System.Windows.Forms.Label lb_nextParseTime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_selfLogPath;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtp_licenseExpiredDate;
        private System.Windows.Forms.DateTimePicker dtp_stopFrom;
        private System.Windows.Forms.DateTimePicker dtp_stopTo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtp_reset;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tb_process1Path;
        private System.Windows.Forms.TextBox tb_process2Path;
        private System.Windows.Forms.TextBox tb_process3Path;
        private System.Windows.Forms.Button btn_process1Path;
        private System.Windows.Forms.Button btn_process2Path;
        private System.Windows.Forms.Button btn_process3Path;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_selfLogPath;
    }
}

