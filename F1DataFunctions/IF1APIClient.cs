using System;
using System.Threading.Tasks;

namespace F1DataFunctions
{
    public interface IF1APIClient
    {
        /// <summary>
        /// Download to specified target file. Returns the last modified date of the downloaded data.
        /// </summary>
        /// <param name="targetFilePath"></param>
        /// <returns></returns>
        Task<DateTimeOffset> DownloadCSVZipAsync(string targetFilePath);
    }
}