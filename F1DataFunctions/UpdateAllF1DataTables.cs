using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace F1DataFunctions
{
    public static class UpdateAllF1DataTables
    {
        [FunctionName("UpdateAllF1DataTables")]
        public static void Run([TimerTrigger("0 0 20 * * Sun")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
