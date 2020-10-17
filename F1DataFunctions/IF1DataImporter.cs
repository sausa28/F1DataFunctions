using System;
using System.Threading.Tasks;

namespace F1DataFunctions
{
    public interface IF1DataImporter
    {
        Task<DateTimeOffset> GetLastImportSourceFileModifiedAsync();
        Task ImportAllDataFromCSVZipAsync(string zipFilePath);
        Task LogDataImport(DateTimeOffset runDatetime, DateTimeOffset sourceFileModified);
    }
}