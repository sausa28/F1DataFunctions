using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace F1DataFunctions.Tests
{
    public class F1DataImporterTests
    {
        private static F1DataImporter CreateDataImporter() =>
                    new F1DataImporter(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=formula1db");

        [Fact]
        public async Task CanLoadRacesToDb()
        {
            // Assemble
            F1DataImporter importer = CreateDataImporter();
            string racesFile = Path.Combine(Environment.CurrentDirectory, "races.csv");

            // Act
            await importer.ImportCsvFileToTable(racesFile, "staging.races");
        }

        [Fact]
        public async Task CanLoadInAllFiles()
        {
            // Assemble
            F1DataImporter importer = CreateDataImporter();
            string zipFilePath = Path.Combine(Environment.CurrentDirectory, "f1db_test_csv.zip");

            // Act
            await importer.ImportAllDataFromCSVZipAsync(zipFilePath);
        }

        [Fact]
        public async Task CanGetMostRecentLogDatetime()
        {
            // Assemble
            F1DataImporter importer = CreateDataImporter();

            // Act
            DateTimeOffset lastModified = await importer.GetLastImportSourceFileModifiedAsync();
        }

        [Fact]
        public async Task CanLogImportToDatabase()
        {
            // Assemble
            F1DataImporter importer = CreateDataImporter();

            // Act
            await importer.LogDataImport(DateTimeOffset.Now, DateTimeOffset.Now);
        }
    }
}
