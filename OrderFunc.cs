using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Capita.Comm
{
    public static class OrderFunc
    {
        [FunctionName("OrderFunc")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] Order order,
            [Queue("queue1", Connection = "AzureWebJobsStorage")]  ICollector<Order> items,
            ILogger logger)
        {
            logger?.LogInformation($"Received order with  Id#{order?.Id}");
            
                items.Add(order);
            logger?.LogInformation("Added item to the queue");

            return new OkResult();
        }
    }
}
