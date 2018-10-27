
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Utilities;

namespace WebApi
{
    public static class Test
    {
        [FunctionName("Test")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var x = ContentEncoder.Generate(
                "This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, This is a test, ",
                "C5");

            ;

            return new OkObjectResult("MOO");
        }
    }
}
