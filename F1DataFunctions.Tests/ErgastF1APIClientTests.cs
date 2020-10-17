using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace F1DataFunctions.Tests
{
    public class ErgastF1APIClientTests
    {
        [Fact]
        public async Task CanDownloadCsv()
        {
            // Assemble
            var apiClient = new ErgastF1APIClient(new HttpClient());
            string temp = Path.GetTempFileName();

            // Act
            DateTimeOffset lastModified = await apiClient.DownloadCSVZipAsync(temp);

            // Assert
            var file = new FileInfo(temp);
            Assert.True(file.Length >= 5_000_000);
            Assert.True(lastModified >= new DateTimeOffset(2020, 10, 01, 0, 0, 0, default));
        }
    }
}
