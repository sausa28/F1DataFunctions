using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace F1DataFunctions
{
    internal class F1DataImporter
    {
        private readonly string _dbConnectionString;

        private readonly Dictionary<string, string> _filesToTables
            = new Dictionary<string, string>
            {
                ["races.csv"] = "staging.races",
                ["circuits.csv"] = "staging.circuits",
                ["constructor_results.csv"] = "staging.constructorResults",
                ["constructor_standings.csv"] = "staging.constructorStandings",
                ["constructors.csv"] = "staging.constructors",
                ["driver_standings.csv"] = "staging.driverStandings",
                ["drivers.csv"] = "staging.drivers",
                ["lap_times.csv"] = "staging.lapTimes",
                ["pit_stops.csv"] = "staging.pitStops",
                ["qualifying.csv"] = "staging.qualifying",
                ["results.csv"] = "staging.results",
                ["seasons.csv"] = "staging.seasons",
                ["status.csv"] = "staging.status"
            };

        public F1DataImporter(string dbConnectionString) => _dbConnectionString = dbConnectionString;

        public async Task ImportAllDataFromCSVZip(string zipFilePath)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "f1db_csv");
            var tempDir = new DirectoryInfo(tempPath);
            foreach (FileInfo file in tempDir.EnumerateFiles()) { file.Delete(); }

            ZipFile.ExtractToDirectory(zipFilePath, tempDir.FullName);

            foreach (FileInfo csvFile in tempDir.EnumerateFiles())
            {
                await ImportCsvFileToTable(csvFile.FullName, _filesToTables[csvFile.Name]);
            }
        }

        internal async Task ImportCsvFileToTable(string csvFile, string tableName)
        {
            if (!File.Exists(csvFile))
                throw new FileNotFoundException("Could not find csv file", csvFile);

            DataTable data = await new CsvReader().LoadCsvToDataTableAsync(csvFile);

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.OpenAsync();
                using var bulkCopy = new SqlBulkCopy(connection);

                var command = connection.CreateCommand();
                command.CommandText = $"TRUNCATE TABLE {tableName}";
                await command.ExecuteNonQueryAsync();

                bulkCopy.DestinationTableName = tableName;

                await bulkCopy.WriteToServerAsync(data);
            }
        }
    }
}
