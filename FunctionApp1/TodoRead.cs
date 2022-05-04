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
    public static class TodoRead
    {
        [FunctionName("TodoRead")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: "DatabaseName",
                collectionName: "CollectionName",
                ConnectionStringSetting = "CosmosDBConnection"
                )] TodoItem todoItem,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (todoItem == null)
            {
                log.LogInformation($"ToDo item not found");
            }
            else
            {
                log.LogInformation($"Found ToDo item, Description={todoItem.Title}");
            }

            List<TodoItem> todos = new List<TodoItem>
            {
                new TodoItem
                {
                    Id = 1,
                    Title = "TestTodo1",
                    IsDone = false,
                },

                new TodoItem
                {
                    Id = 2,
                    Title = "TestTodo2",
                    IsDone = false,
                }
            };

            return new OkObjectResult(todos);
        }
    }
}
