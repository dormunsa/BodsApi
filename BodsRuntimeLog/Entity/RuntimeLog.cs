using System;
using System.Collections.Generic;
using System.Text;

namespace BodsRuntimeLog.Entity
{
    // define log structure as it stored in db
    public class RuntimeLog
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Exception { get; set; }
        public string Log_level { get; set; }
        public string FileName { get; set; }
        public int NLine { get; set; }
        public int NColumn { get; set; }
        public string Method { get; set; }
        public string StackTrace { get; set; }
        public string Custom1 { get; set; }
        public string Custom2 { get; set; }
        public float BuildVersion { get; set; }

        public RuntimeLog() { }
        public RuntimeLog(DateTime time, string Exception, string Log_level, string FileName, int NLine, int NColumn, string Method, string StackTrace, string Custom1, string Custom2, float BuildVersion)
        {
            this.Time = time;
            this.Exception = Exception;
            this.Log_level = Log_level;
            this.FileName = FileName;
            this.NLine = NLine;
            this.NColumn = NColumn;
            this.Method = Method;
            this.StackTrace = StackTrace;
            this.Custom1 = Custom1;
            this.Custom2 = Custom2;
            this.BuildVersion = BuildVersion;

        }
    }
}
