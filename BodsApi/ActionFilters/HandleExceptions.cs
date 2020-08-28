using BodsRuntimeLog.Entity;
using BodsRuntimeLog.Logic;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BodsApi.ActionFilters
{
    public class HandleExceptions : ExceptionFilterAttribute
    {
       // every exception will land here insert log to db 
        public override void OnException(ExceptionContext context)
        {
            var Exception = context.Exception;
            StackFrame Stack = new StackFrame(true);

            RuntimeLog NewException = new RuntimeLog(
                DateTime.Now, Exception.Message, "Fatal", Stack.GetFileName()
             , Stack.GetFileLineNumber(), Stack.GetFileColumnNumber()
             , "OnException", Exception.StackTrace
             , (Exception.InnerException == null ? string.Empty : "InnerException Message -" + Exception.InnerException.Message) 
             , Exception.InnerException == null ? "" : " InnerException StackTrace - " + Exception.InnerException.StackTrace, 0);
            LogicRuntimeLogs.SaveLog(NewException);

        }
    }
}
