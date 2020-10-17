using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace F1DataFunctions
{
    public class UpdateAllF1DataTablesFunction
    {
        private readonly IF1DataImporter _dataImporter;
        private readonly IF1APIClient _f1ApiClient;

        public UpdateAllF1DataTablesFunction(IF1DataImporter dataImporter, IF1APIClient f1ApiClient)
        {
            _dataImporter = dataImporter;
            _f1ApiClient = f1ApiClient;
        }

        [FunctionName("UpdateAllF1DataTables")]
        public async Task RunAsync([TimerTrigger("0 0 */2 * * *")]TimerInfo timerInfo, ILogger log)
        {
            try
            {
                log.LogInformation($"UpdateAllF1DataTables trigger function executed at: {DateTimeOffset.Now}");

                string tempFile = Path.GetTempFileName();

                log.LogInformation("Downloading zip file");
                DateTimeOffset lastModified = await _f1ApiClient.DownloadCSVZipAsync(tempFile);
                DateTimeOffset previousLastModified = await _dataImporter.GetLastImportSourceFileModifiedAsync();

                if (lastModified > previousLastModified)
                {
                    log.LogInformation("Importing CSVs to database");
                    await _dataImporter.ImportAllDataFromCSVZipAsync(tempFile);
                    await _dataImporter.LogDataImport(DateTimeOffset.Now, lastModified);
                }
                else
                {
                    log.LogInformation("No new data to import.");
                }

                log.LogInformation("Complete");
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error while updating F1 data");
                throw;
            }
        }
    }
}
