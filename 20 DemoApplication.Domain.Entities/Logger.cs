using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication.Domain.Entities
{
    public static class Logger
    {
        public static void Message(string message)
        {
            Exception ex = string.IsNullOrEmpty(message) ? new Exception() : new Exception(message);

            Error error = new Error(ex);
                       
            ErrorLog.GetDefault(null).Log(error);
        }
        public static void Log(string message)
        {
            if (System.Web.HttpContext.Current != null)
            {
                Log(System.Web.HttpContext.Current, message);
                return;
            }

            Message(message);
        }

        public static void Log(System.Web.HttpContext context, string message)
        {
            ErrorSignal.FromContext(context).Raise(new Exception(message));
        }

        public static void Log(Exception ex)
        {
            Log(GetExceptionMessage(ex));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="ex">Exception</param>
        public static void Log(System.Web.HttpContext context, Exception ex)
        {
            Log(context, GetExceptionMessage(ex));
        }

        private static string GetExceptionMessage(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ex.Message);
            sb.AppendLine();
            sb.AppendLine("Source : " + ex.Source);
            string innerException = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
            sb.AppendLine("Inner Exception : " + innerException);
            sb.AppendLine("StackTrace : " + ex.StackTrace);
            sb.AppendLine("Target Site : " + ex.TargetSite);
            return sb.ToString();
        }
    }
}
