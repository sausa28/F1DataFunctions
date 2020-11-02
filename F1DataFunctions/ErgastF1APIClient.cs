using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace F1DataFunctions
{
    internal class ErgastF1APIClient : IF1APIClient
    {
        private readonly HttpClient _httpClient;
        private static readonly string CsvZipUrl = "http://ergast.com/downloads/f1db_csv.zip";

        public ErgastF1APIClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task DownloadCSVZipAsync(string targetFilePath)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(CsvZipUrl);

            using (FileStream localFile = File.OpenWrite(targetFilePath))
            {
                await response.Content.CopyToAsync(localFile);
            }
        }

        public async Task<DateTimeOffset> GetDataLastModifiedAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Head, CsvZipUrl);
            HttpResponseMessage response = await _httpClient.SendAsync(request);

            return response.Content.Headers.LastModified.Value;
        }
    }
}
