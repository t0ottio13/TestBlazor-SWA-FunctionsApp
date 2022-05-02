using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using CommonData;
using System.Collections.Generic;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<TestItem> items = new List<TestItem>
            {
                new TestItem
                {
                    Id = 1,
                    Name = "Test1",
                    Descripsion = "Test Des1",
                    Status = true,
                },

                new TestItem
                {
                    Id=1,
                    Name = "Test2",
                    Descripsion = "Test Dec2",
                    Status= true,
                }
            };
            return new OkObjectResult(items);
        }
    }
}
