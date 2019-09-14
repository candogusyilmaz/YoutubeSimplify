using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSimplify
{
    public class Logger
    {
        public Level DefaultLevel { get; set; }

        public enum Level
        {
            None,
            Info,
            Warning,
            Error
        }

        private static string CreateFileName()
        {
            var date = DateTime.Now;
            
            return string.Format("Log_{0:0000}{1:00}{2:00}-{3:00}{4:00}_{5}.log",
                date.Year, date.Month, date.Day, date.Hour, date.Minute, new Guid());
        }
    }

    public class LogMessage
    {
        public DateTime DateTime { get; set; }
        public Logger.Level Level { get; set; }
        public string Text { get; set; }
        public string CallingClass { get; set; }
        public string CallingMethod { get; set; }
        public int LineNumber { get; set; }
        
        public LogMessage(Logger.Level level, DateTime dateTime, string text, string callingClass, string callingMethod, int lineNumber)
        {
            Level = level;
            DateTime = dateTime;
            Text = text;
            CallingClass = callingClass;
            CallingMethod = callingMethod;
            LineNumber = lineNumber;
        }

        public override string ToString()
        {
            return string.Format("{0:dd.MM.yyyy HH:mm:ss}: {1} [line: {2} {3} -> {4}()]: {5}",
                            this.DateTime, this.Level, this.LineNumber, this.CallingClass,
                            this.CallingMethod, this.Text);
        }
    }
}
