using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CallCenter.RestService.Logging
{
    public class Logger : DelegatingHandler
    {
        private static readonly ILog logger = LogManager.GetLogger("RestAPI_Logger");

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // log request body
            string requestBody = await request.Content.ReadAsStringAsync();
            logger.Info(requestBody); 
            //DB'ye log yazma işlemleri

            var result = await base.SendAsync(request, cancellationToken);
            if (result.Content != null)
            {
                var responseBody = await result.Content.ReadAsStringAsync();
                logger.Info(responseBody);
                //DB'ye log yazma işlemleri
            }

            return result;
        }
    }
}