using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace CallCenter.RestService.Logging
{
    public class ExceptionHandler : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var log = context.Exception.ToString();
            //DB'ye yazma işlemleri
        }
    }
}