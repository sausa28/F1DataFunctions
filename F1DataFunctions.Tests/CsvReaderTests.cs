using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace F1DataFunctions.Tests
{
    public class CsvReaderTests
    {
        [Fact]
        public async Task CanLoadCsvToDataTable()
        {
            // Assemble
            string csvFile = Path.Combine(Environment.CurrentDirectory, "seasons.csv");
            var csvReader = new CsvReader();

            // Act
            DataTable datatable = await csvReader.LoadCsvToDataTableAsync(csvFile);

            // Assert
            Assert.Equal(2, datatable.Columns.Count);
            Assert.Equal(71, datatable.Rows.Count);
            Assert.Equal("https://en.wikipedia.org/wiki/2009_Formula_One_season", datatable.Rows[0]["url"]);
            Assert.Equal(DBNull.Value, datatable.Rows[1]["url"]);
            Assert.Equal("https://en.wikipedia.org/wiki/2007,_Formula_One_season", datatable.Rows[2]["url"]);            
        }
    }
}
