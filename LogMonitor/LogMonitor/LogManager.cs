using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace LogMonitor
{
    class LogManager
    {
        public Settings settings;
        private string criteriaAccountWasTimeout = "account was Timeout";
        private string criteriaCannotBeCanceled = "cannot be cancelled";
        private string criteriaWorkstationHasBeenLost = "Workstation has been lost";
        private string criteriaWorkstationHasBeenRestored = "Workstation has been restored";
        private string criteriaCouldNotConnectToTWS = "Couldn't connect to TWS";
        private string criteriaLicenseExpired = "License Expired";
        private string criteriaFailedToCancelPNL = "Failed to cancel PNL(not subscribed)";
        private string criteriaStartConnectingToIBGatewayOrTws = "Start connecting to IBGateway or Tws";
        private string criteriaCannotSetMillisecondTimer = "cannot set millisecond timer";
        private string criteriaNotLoginToMetatraderAccountYet = "Not Login to metatrader account yet";
        private string criteriaExpiration = "Expiration: ";

        private Queue<DateTime> queueWorkstationHasBeenLost = new Queue<DateTime>();
        private Queue<DateTime> queueCouldNotConnectToTWS = new Queue<DateTime>();
        private Queue<DateTime> queueStartConnectingToIBGatewayOrTws = new Queue<DateTime>();
        private bool enabledLogMonitor = true;
        private TimeSpan process1TotalProcessorTime = new TimeSpan();
        private TimeSpan process2TotalProcessorTime = new TimeSpan();
        private TimeSpan process3TotalProcessorTime = new TimeSpan();
        private int process1HighCpuCount = 0;
        private int process2HighCpuCount = 0;
        private int process3HighCpuCount = 0;
        public void initialize()
        {
            deserialize();
        }
        public void serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"settings.data", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, settings);
            stream.Close();
        }
        
        public void deserialize()
        {
            if(File.Exists(@"settings.data"))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(@"settings.data", FileMode.Open, FileAccess.Read);
                settings = (Settings)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {
                settings = new Settings();
            }
        }
        public bool isEnabled()
        {
            return enabledLogMonitor;
        }
        public void setEnabled(bool enabled)
        {
            enabledLogMonitor = enabled;
        }
        public void parseLog()
        {
            settings.nextParseTime = DateTime.Now.AddSeconds(settings.parseInterval);
            string logPath = settings.logMonitorPath;
            string currentDateLogFileName = DateTime.Now.ToString("yyyyMMdd")+ ".log";
            string yesterdayLogFileName = DateTime.Now.AddDays(-1).ToString("yyyyMMdd")+".log";
            
            if (currentDateLogFileName == settings.curParseFileName)
            {
                //today reading
                if (File.Exists(logPath + "/" + currentDateLogFileName))
                {
                    settings.curParseLineNum = parseLogFile(logPath + "/" + currentDateLogFileName, settings.curParseLineNum);
                }
            }
            else if(yesterdayLogFileName == settings.curParseFileName)
            {
                //from yesterday to today
                if(File.Exists(logPath+"/"+yesterdayLogFileName))
                {
                    settings.curParseLineNum = parseLogFile(logPath+"/"+yesterdayLogFileName,settings.curParseLineNum);
                }
                if(File.Exists(logPath+"/"+currentDateLogFileName))
                {
                    settings.curParseFileName = currentDateLogFileName;
                    settings.curParseLineNum = parseLogFile(logPath + "/" + currentDateLogFileName, 0);
                }
            }
            else
            {
                //first reading
                if(File.Exists(logPath+"/"+currentDateLogFileName))
                {
                    settings.curParseFileName = currentDateLogFileName;
                    settings.curParseLineNum = parseLogFile(logPath + "/" + currentDateLogFileName, 0);
                }
            }
            if (DateTime.Now.Subtract(settings.lastParseTime).TotalMinutes > 15)
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + "no log message: there is no any log in 15 minutes: ");
                killProcess(settings.process1Name);
                settings.lastParseTime = DateTime.Now;
            }
            checkHighProcesses();
        }
        private int parseLogFile(string fullFilePath,int startLineNum)
        {
            using (var fs = new FileStream(fullFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs, Encoding.Default))
            {
                for (int i = 1; i < startLineNum; i++)
                {
                    sr.ReadLine();
                }
                if(!sr.EndOfStream)
                {
                    settings.lastParseTime = DateTime.Now;
                }
                while(!sr.EndOfStream)
                {
                    string logLine = sr.ReadLine();
                    startLineNum++;

                    parseLine(logLine);
                }
            }
            return startLineNum;
        }
        private void parseLine(string line)
        {
            if(line.Contains(criteriaAccountWasTimeout))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy")+" message found: " + criteriaAccountWasTimeout);
                closeProcess(settings.process1Name);
            }
            else if(line.Contains(criteriaCannotBeCanceled))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message found: " + criteriaCannotBeCanceled);
                closeProcess(settings.process1Name);
            }
            else if(line.Contains(criteriaLicenseExpired))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message found: " + criteriaLicenseExpired);
                emailNoticeLicenseExpired();
            }
            else if(line.Contains(criteriaFailedToCancelPNL))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message found: " + criteriaFailedToCancelPNL);
                closeProcess(settings.process1Name);
                closeProcess(settings.process2Name);
            }
            else if(line.Contains(criteriaCannotSetMillisecondTimer))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message found: " + criteriaCannotSetMillisecondTimer);
                killProcess(settings.process1Name);
            }
            else if(line.Contains(criteriaNotLoginToMetatraderAccountYet))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message found: " + criteriaNotLoginToMetatraderAccountYet);
                closeProcess(settings.process1Name);
            }
            else if(line.Contains(criteriaWorkstationHasBeenLost))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message found: " + criteriaWorkstationHasBeenLost);
                while (queueWorkstationHasBeenLost.Count > 0)
                {
                    DateTime temp = queueWorkstationHasBeenLost.ToArray()[0];
                    if(DateTime.Now.Subtract(temp).TotalMinutes >= 3)
                    {
                        queueWorkstationHasBeenLost.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
                queueWorkstationHasBeenLost.Enqueue(DateTime.Now);

                if(queueWorkstationHasBeenLost.Count > 10)
                {
                    queueWorkstationHasBeenLost.Clear();
                    closeProcess(settings.process2Name);
                }
            }
            else if(line.Contains(criteriaWorkstationHasBeenRestored))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message found: " + criteriaWorkstationHasBeenRestored);
                queueWorkstationHasBeenLost.Clear();
            }
            else if(line.Contains(criteriaCouldNotConnectToTWS))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message found: " + criteriaCouldNotConnectToTWS);
                while (queueCouldNotConnectToTWS.Count > 0)
                {
                    DateTime temp = queueCouldNotConnectToTWS.ToArray()[0];
                    if (DateTime.Now.Subtract(temp).TotalMinutes >= 10)
                    {
                        queueCouldNotConnectToTWS.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
                queueCouldNotConnectToTWS.Enqueue(DateTime.Now);
                if (queueCouldNotConnectToTWS.Count > 4)
                {
                    queueCouldNotConnectToTWS.Clear();
                    killProcess(settings.process2Name);
                }
            }
            else if(line.Contains(criteriaStartConnectingToIBGatewayOrTws))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message found: " + criteriaStartConnectingToIBGatewayOrTws);
                while (queueStartConnectingToIBGatewayOrTws.Count > 0)
                {
                    DateTime temp = queueStartConnectingToIBGatewayOrTws.ToArray()[0];
                    if (DateTime.Now.Subtract(temp).TotalMinutes >= 3)
                    {
                        queueStartConnectingToIBGatewayOrTws.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
                queueStartConnectingToIBGatewayOrTws.Enqueue(DateTime.Now);
                if (queueStartConnectingToIBGatewayOrTws.Count > 3)
                {
                    queueStartConnectingToIBGatewayOrTws.Clear();
                    killProcess(settings.process2Name);
                }
            }
            else if(line.Contains(criteriaExpiration))
            {
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message found: " + criteriaExpiration);
                //show expiration date time
                int index = line.IndexOf(criteriaExpiration);
                string str = line.Substring(index);
                str = str.Replace(criteriaExpiration, "");
                DateTime myDate;
                if (DateTime.TryParse(str, out myDate))
                {
                    settings.licenseExpiryDate = myDate;
                }
            }
        }
        private void closeProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                int processId = process.Id;
                process.CloseMainWindow();
                process.Close();
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " close process '"+processName+"': "+processId );
            }
        }
        private void killProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                int processId = process.Id;
                process.Kill();
                process.WaitForExit();
                process.Dispose();
                printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " kill process '" + processName + "': " + processId);
            }
        }
        private void emailNoticeLicenseExpired()
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(settings.emailFrom);
                message.To.Add(new MailAddress(settings.emailTo));
                message.Subject = "License Expired Notification";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "License Expired";
                smtp.Port = 587;
                smtp.Host = settings.emailServerIP; //for gmail host  
                smtp.Send(message);

            }
            catch (Exception) { }
        }
        public void printLog(string logStr)
        {
            if (!File.Exists(settings.logSelfFilePath) && settings.logSelfFilePath != "")
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(settings.logSelfFilePath))
                {
                    sw.WriteLine(logStr);
                }
            }
            else if(File.Exists(settings.logSelfFilePath))
            {
                using (StreamWriter sw = File.AppendText(settings.logSelfFilePath))
                {
                    sw.WriteLine(logStr);
                }
            }
        }
        public void startProcesses()
        {
            printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message: start all processes");
            if (Process.GetProcessesByName(settings.process1Name).Length == 0 )
            {
                Process.Start(settings.process1Path);
            }
            if (Process.GetProcessesByName(settings.process2Name).Length == 0)
            {
                Process.Start(settings.process2Path);
            }
            if (Process.GetProcessesByName(settings.process3Name).Length == 0)
            {
                Process.Start(settings.process3Path);
            }
        }
        public void restartProcesses()
        {
            printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message: restarting all processes");
            closeProcess(settings.process1Name);
            closeProcess(settings.process2Name);
            closeProcess(settings.process3Name);
            startProcesses();
        }
        public void reset()
        {
            printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message: reset");
            closeProcess(settings.process1Name);
            closeProcess(settings.process2Name);
        }
        private void checkHighProcesses()
        {
            Process[] processes1 = Process.GetProcessesByName(settings.process1Name);
            if(processes1.Length > 0)
            {
                Process process = processes1[0];
                double CPUUsage = (process.TotalProcessorTime.TotalMilliseconds - process1TotalProcessorTime.TotalMilliseconds) / (settings.parseInterval * 1000) / Convert.ToDouble(Environment.ProcessorCount);
                if(CPUUsage > 0.25)
                {
                    process1HighCpuCount++;
                }
                else
                {
                    process1HighCpuCount = 0;
                }
                if(process1HighCpuCount > 3)
                {
                    printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message: high cpu usage than 25% \""+ settings.process1Name + "\"");
                    closeProcess(settings.process1Name);
                }
                process1TotalProcessorTime = process.TotalProcessorTime;
            }
            Process[] processes2 = Process.GetProcessesByName(settings.process2Name);
            if (processes2.Length > 0)
            {
                Process process = processes2[0];
                double CPUUsage = (process.TotalProcessorTime.TotalMilliseconds - process2TotalProcessorTime.TotalMilliseconds) / (settings.parseInterval * 1000) / Convert.ToDouble(Environment.ProcessorCount);
                if (CPUUsage > 0.25)
                {
                    process2HighCpuCount++;
                }
                else
                {
                    process2HighCpuCount = 0;
                }
                if (process2HighCpuCount > 3)
                {
                    printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message: high cpu usage than 25% \"" + settings.process2Name + "\"");
                    closeProcess(settings.process2Name);
                }
                process2TotalProcessorTime = process.TotalProcessorTime;
            }
            Process[] processes3 = Process.GetProcessesByName(settings.process3Name);
            if (processes3.Length > 0)
            {
                Process process = processes3[0];
                double CPUUsage = (process.TotalProcessorTime.TotalMilliseconds - process3TotalProcessorTime.TotalMilliseconds) / (settings.parseInterval * 1000) / Convert.ToDouble(Environment.ProcessorCount);
                if (CPUUsage > 0.25)
                {
                    process3HighCpuCount++;
                }
                else
                {
                    process3HighCpuCount = 0;
                }
                if (process3HighCpuCount > 3)
                {
                    printLog(DateTime.Now.ToString("HH:mm:ss MM/dd/yyyy") + " message: high cpu usage than 25% \"" + settings.process3Name + "\"");
                    closeProcess(settings.process3Name);
                }
                process3TotalProcessorTime = process.TotalProcessorTime;
            }
            
        }
    }
}
