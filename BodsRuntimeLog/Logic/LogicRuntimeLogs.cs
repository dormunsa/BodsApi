using BodsRuntimeLog.Data;
using BodsRuntimeLog.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BodsRuntimeLog.Logic
{
    public class LogicRuntimeLogs
    {
       // save log to db
        public static void SaveLog(RuntimeLog runTimeLog, bool sendEmail = true)
        {
            List<Task> TaskList = new List<Task>();

            try
            {
                DataRunTimeLogs.Insert(runTimeLog);
            }
            catch (Exception ex)
            {

            }

        }

       
    }
}
