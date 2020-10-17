using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace F1DataFunctions
{
    internal class ErgastF1APIClient : IF1APIClient
    {
        private readonly HttpClient _httpClient;

        public ErgastF1APIClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task DownloadCSVZipAsync(string targetFilePath)
        {
            using (Stream zipFileStream = await _httpClient.GetStreamAsync("https://ergast.com/downloads/f1db_csv.zip"))
            using (FileStream localFile = File.OpenWrite(targetFilePath))
            {
                await zipFileStream.CopyToAsync(localFile);
            }
        }
    }
}
