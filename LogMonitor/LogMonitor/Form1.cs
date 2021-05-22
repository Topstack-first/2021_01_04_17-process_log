using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogMonitor
{
    public partial class LogMonitorForm : Form
    {
        private LogManager logManager = new LogManager();
        private Timer timer = new Timer();
        private int pauseSeconds = 0;
        public LogMonitorForm()
        {
            InitializeComponent();
            
            initialize();
        }
        private void testInit()
        {
            logManager.settings.curParseLineNum = 1;
        }

        private void initialize()
        {
            logManager.initialize();
            
            //testInit();

            //settings info to ui
            this.tb_logpath.Text = logManager.settings.logMonitorPath;
            this.tb_emailFrom.Text = logManager.settings.emailFrom;
            this.tb_emailTo.Text = logManager.settings.emailTo;
            this.tb_emailSubject.Text = logManager.settings.emailSubject;
            this.tb_serverIP.Text = logManager.settings.emailServerIP;
            this.tb_selfLogPath.Text = logManager.settings.logSelfFilePath;
            this.tb_process1.Text = logManager.settings.process1Name;
            this.tb_process2.Text = logManager.settings.process2Name;
            this.tb_process3.Text = logManager.settings.process3Name;
            this.tb_process1Path.Text = logManager.settings.process1Path;
            this.tb_process2Path.Text = logManager.settings.process2Path;
            this.tb_process3Path.Text = logManager.settings.process3Path;
            this.nud_parseInterval.Value = logManager.settings.parseInterval;
            this.dtp_licenseExpiredDate.Value = logManager.settings.licenseExpiryDate;
            this.dtp_reset.Value = logManager.settings.resetDateTime;
            this.dtp_stopFrom.Value = logManager.settings.stopDateTimeFrom;
            this.dtp_stopTo.Value = logManager.settings.stopDateTimeTo;
            this.lb_lastParseTime.Text = logManager.settings.lastParseTime.ToString("dd/MM/yyyy HH:mm:ss");
            this.lb_nextParseTime.Text = logManager.settings.nextParseTime.ToString("dd/MM/yyyy HH:mm:ss");

            timer.Tick += new EventHandler(this._timer_Elapsed);
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Start();
        }
        private void _timer_Elapsed(object sender, EventArgs e)
        {
            //check reset condition
            if (DateTime.Now.ToString("HH:mm:ss dddd") == logManager.settings.resetDateTime.ToString("HH:mm:ss dddd"))
            {
                logManager.reset();
            }

            //check inactive period
            double periodSeconds = logManager.settings.stopDateTimeTo.Subtract(logManager.settings.stopDateTimeFrom).TotalSeconds;
            double curAndStopSeconds = DateTime.Now.Subtract(logManager.settings.stopDateTimeFrom).TotalSeconds;
            double secondsOfWeek = 7 * 24 * 3600;
            if(curAndStopSeconds % secondsOfWeek < periodSeconds)
            {
                return;
            }
            

            if (pauseSeconds <= 0)
            {
                if(!logManager.isEnabled())
                {
                    logManager.setEnabled(true);
                    this.btn_pause.Text = "Pause Monitor";
                }
            }
            else
            {
                pauseSeconds--;
            }

            if(logManager.isEnabled())
            {
                //monitor actions
                if(logManager.settings.nextParseTime <= DateTime.Now)
                {
                    logManager.parseLog();
                    try {
                        this.lb_lastParseTime.Text = logManager.settings.lastParseTime.ToString("dd/MM/yyyy HH:mm:ss");
                        this.lb_nextParseTime.Text = logManager.settings.nextParseTime.ToString("dd/MM/yyyy HH:mm:ss");
                    }
                    catch(Exception)
                    {

                    }
                    
                }
                
            }
        }
        private void OnLogMonitorPathChanged(object sender, EventArgs e)
        {
            logManager.settings.logMonitorPath = ((TextBox)sender).Text;
        }

        private void OnEmailToChanged(object sender, EventArgs e)
        {
            logManager.settings.emailTo = ((TextBox)sender).Text;
        }

        private void OnEmailFromChanged(object sender, EventArgs e)
        {
            logManager.settings.emailFrom = ((TextBox)sender).Text;
        }
        private void OnEmailServerChanged(object sender, EventArgs e)
        {
            logManager.settings.emailServerIP = ((TextBox)sender).Text;
        }
        private void OnEmailSubjectChanged(object sender, EventArgs e)
        {
            logManager.settings.emailSubject = ((TextBox)sender).Text;
        }

        private void OnLogSelfFilePathChanged(object sender, EventArgs e)
        {
            logManager.settings.logSelfFilePath = ((TextBox)sender).Text;
        }

        private void OnProcess1NameChanged(object sender, EventArgs e)
        {
            logManager.settings.process1Name = ((TextBox)sender).Text;
        }

        private void OnProcess2NameChanged(object sender, EventArgs e)
        {
            logManager.settings.process2Name = ((TextBox)sender).Text;
        }

        private void OnProcess3NameChanged(object sender, EventArgs e)
        {
            logManager.settings.process3Name = ((TextBox)sender).Text;
        }

        private void OnProcess1PathChanged(object sender, EventArgs e)
        {
            logManager.settings.process1Path = ((TextBox)sender).Text;
        }

        private void OnProcess2PathChanged(object sender, EventArgs e)
        {
            logManager.settings.process2Path = ((TextBox)sender).Text;
        }

        private void OnProcess3PathChanged(object sender, EventArgs e)
        {
            logManager.settings.process3Path = ((TextBox)sender).Text;
        }

        private void OnParseIntervalChanged(object sender, EventArgs e)
        {
            logManager.settings.parseInterval = (int)((NumericUpDown)sender).Value;
        }

        private void OnResetDateChanged(object sender, EventArgs e)
        {
            logManager.settings.resetDateTime = ((DateTimePicker)sender).Value;
        }

        private void OnStopDateFromChanged(object sender, EventArgs e)
        {
            logManager.settings.stopDateTimeFrom = ((DateTimePicker)sender).Value;
        }

        private void OnStopDateToChanged(object sender, EventArgs e)
        {
            logManager.settings.stopDateTimeTo = ((DateTimePicker)sender).Value;
        }
        private string folderSelect(string defaultPath)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                dialog.SelectedPath = defaultPath;
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }

            }
            return defaultPath;
        }
        private string fileSelect(string defaultPath)
        {
            using (var dialog = new System.Windows.Forms.OpenFileDialog())
            {
                dialog.FileName = defaultPath;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = false;
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    return dialog.FileName;
                }

            }
            return defaultPath;
        }
        private void OnBrowseLogMonitorPath(object sender, EventArgs e)
        {
            this.tb_logpath.Text = this.folderSelect(this.tb_logpath.Text);
        }

        private void OnBrowseLogSelfFilePath(object sender, EventArgs e)
        {
            this.tb_selfLogPath.Text = this.fileSelect(this.tb_selfLogPath.Text);
        }

        private void OnBrowseProcess1Path(object sender, EventArgs e)
        {
            this.tb_process1Path.Text = this.fileSelect(this.tb_process1Path.Text);
        }

        private void OnBrowseProcess2Path(object sender, EventArgs e)
        {
            this.tb_process2Path.Text = this.fileSelect(this.tb_process2Path.Text);
        }

        private void OnBrowseProcess3Path(object sender, EventArgs e)
        {
            this.tb_process3Path.Text = this.fileSelect(this.tb_process3Path.Text);
        }

        private void OnPauseMonitor(object sender, EventArgs e)
        {
            if(this.btn_pause.Text == "Pause Monitor")
            {
                pauseSeconds = 10 * 60;
                logManager.setEnabled(false);
                this.btn_pause.Text = "Continue Monitor";
            }
            else
            {
                pauseSeconds = 0;
                logManager.setEnabled(true);
                this.btn_pause.Text = "Pause Monitor";
            }
        }

        private void OnStartProcess(object sender, EventArgs e)
        {
            logManager.startProcesses();
        }

        private void OnRestartProcess(object sender, EventArgs e)
        {
            logManager.restartProcesses();
        }

        private void OnLogMonitorClosed(object sender, FormClosedEventArgs e)
        {
            logManager.serialize();
        }


    }
}
