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
        [Fact]
        public async Task CanLoadRacesToDb()
        {
            // Assemble
            var importer = new F1DataImporter(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=formula1db");
            string racesFile = Path.Combine(Environment.CurrentDirectory, "races.csv");

            // Act
            await importer.ImportCsvFileToTable(racesFile, "dbo.races");
        }

        [Fact]
        public async Task CanLoadInAllFiles()
        {
            // Assemble
            var importer = new F1DataImporter(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=formula1db");
            string zipFilePath = @"D:\Downloads\f1db_csv.zip";

            // Act
            await importer.ImportAllDataFromCSVZip(zipFilePath);
        }
    }
}
