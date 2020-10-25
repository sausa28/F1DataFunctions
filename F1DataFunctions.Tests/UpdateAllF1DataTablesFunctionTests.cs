using F1DataFunctions.Tests.Stubs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace F1DataFunctions.Tests
{
    public class UpdateAllF1DataTablesFunctionTests
    {
        [Fact]
        public async Task SkipsImportIfLastModifiedNotChanged()
        {
            // Assemble
            var lastModified = new DateTimeOffset(2020, 10, 17, 0, 0, 0, default);
            var dataImporter = new StubF1DataImporter(lastModified);
            var apiClient = new StubF1APIClient(Path.Combine(Environment.CurrentDirectory, "f1db_test_csv.zip"), lastModified);
            var function = new UpdateAllF1DataTablesFunction(dataImporter, apiClient);

            ILogger logger = NullLogger.Instance;

            // Act
            await function.RunAsync(default, logger);

            // Assert
            Assert.Equal(1, apiClient.GetLastModified_CallCount);
            Assert.Equal(0, apiClient.DownloadCSVZip_CallCount);
            Assert.Equal(0, dataImporter.ImportAllData_CallCount);
        }

        [Fact]
        public async Task ImportsIfLastModifiedIsMoreRecent()
        {
            // Assemble
            var previousLastModified = new DateTimeOffset(2020, 10, 11, 0, 0, 0, default);
            var newLastModified = new DateTimeOffset(2020, 10, 17, 0, 0, 0, default);
            var dataImporter = new StubF1DataImporter(previousLastModified);
            var apiClient = new StubF1APIClient(Path.Combine(Environment.CurrentDirectory, "f1db_test_csv.zip"), newLastModified);
            var function = new UpdateAllF1DataTablesFunction(dataImporter, apiClient);

            ILogger logger = NullLogger.Instance;

            // Act
            await function.RunAsync(default, logger);

            // Assert
            Assert.Equal(1, apiClient.DownloadCSVZip_CallCount);
            Assert.Equal(1, dataImporter.ImportAllData_CallCount);
        }

    }
}
