using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace F1DataFunctions.Tests
{
    public class F1DataImporterTests : IClassFixture<F1DatabaseFixture>
    {
        private readonly F1DatabaseFixture _fixture;

        private F1DataImporter CreateDataImporter() => new F1DataImporter(_fixture.ConnectionString);

        public F1DataImporterTests(F1DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

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
