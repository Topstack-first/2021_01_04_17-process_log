using System;
namespace LogMonitor
{
    [Serializable]
    class Settings
    {
        public string logMonitorPath = "";
        public string emailTo = "";
        public string emailFrom = "";
        public string emailSubject = "";
        public string emailServerIP = "";
        public string logSelfFilePath = "";
        public string process1Name = "";
        public string process2Name = "";
        public string process3Name = "";
        public string process1Path = "";
        public string process2Path = "";
        public string process3Path = "";
        public DateTime lastParseTime = DateTime.Now;
        public DateTime nextParseTime = DateTime.Now.AddSeconds(15);
        public int parseInterval = 15;
        public DateTime licenseExpiryDate = DateTime.Now;
        public DateTime resetDateTime = DateTime.Parse("22:00:00 01/10/2021");
        public DateTime stopDateTimeFrom = DateTime.Parse("02:00:00 01/09/2021");
        public DateTime stopDateTimeTo = DateTime.Parse("23:00:00 01/10/2021");

        public string curParseFileName = "";
        public int curParseLineNum = 1;
    }
}
