using System;
using System.IO;
using System.Threading.Tasks;
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

        public async Task RunAsync(ILogger log)
        {
            try
            {
                log.LogInformation("Checking data last modified date");
                DateTimeOffset lastModified = await _f1ApiClient.GetDataLastModifiedAsync();
                DateTimeOffset previousLastModified = await _dataImporter.GetLastImportSourceFileModifiedAsync();

                if (lastModified > previousLastModified)
                {
                    string tempFile = Path.GetTempFileName();
                    log.LogInformation("Downloading CSV file");
                    await _f1ApiClient.DownloadCSVZipAsync(tempFile);
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
