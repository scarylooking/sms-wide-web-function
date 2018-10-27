
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using WebApi.Models;
using System.Threading.Tasks;
using System;
using WebApi.DAL;

namespace WebApi
{
    public static class DnsFunction
    {
        [FunctionName("DnsFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            // 1. Instantiate dependencies
            var clockworkApi = new ClockworkApi();
            var dnsRepository = new DomainRepository();
            
            // 2. Get the request model
            var clockworkHook = ClockworkHookRequest.FromQueryString(req.Query);

            // 3. Decode the DNS Request
            // The DNS lookup path is in the clockworkHook message
            var dnsRequest = DnsRequest.FromContent(clockworkHook.Content);

            // 4. Handle the request
            if (dnsRequest.RequestType == DnsRequestType.Register)
            {
                // 3.1 If this is a registration, register the payload against the from number
                // await dnsRepository.Register(clockworkHook.From, dnsRequest.Payload);
            }
            else
            {
                if (dnsRequest?.Payload == "info.cern.ch")
                {
                    // 3.2 Send a text to the From address with the result
                    
                }
            }

            return new StatusCodeResult(200);
        }
    }
}
