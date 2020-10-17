using System.Threading.Tasks;

namespace F1DataFunctions
{
    internal interface IF1APIClient
    {
        Task DownloadCSVZipAsync(string targetFilePath);
    }
}