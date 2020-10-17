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

        public ErgastF1APIClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<DateTimeOffset> DownloadCSVZipAsync(string targetFilePath)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://ergast.com/downloads/f1db_csv.zip");

            using (FileStream localFile = File.OpenWrite(targetFilePath))
            {
                await response.Content.CopyToAsync(localFile);
            }

            return response.Content.Headers.LastModified.Value;
        }
    }
}
