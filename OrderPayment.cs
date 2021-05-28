using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Capita.Comm
{
    public static class OrderPayment
    {
        [FunctionName("OrderPayment")]
        public static void Run([QueueTrigger("queue1", Connection = "AzureWebJobsStorage")]Order myQueueItem, ILogger logger)
        {
            logger?.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
