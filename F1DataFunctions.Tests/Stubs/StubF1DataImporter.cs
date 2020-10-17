using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace F1DataFunctions.Tests.Stubs
{
    class StubF1DataImporter : IF1DataImporter
    {
        public string ImportAllDataZipFilePath { get; private set; }
        public int ImportAllData_CallCount { get; private set; }
        public (DateTimeOffset runDateTime, DateTimeOffset sourceFileModified) LogDataImportArgs { get; private set; }
        public DateTimeOffset PreviousSourceFileModified { get; }

        public StubF1DataImporter(DateTimeOffset previousSourceFileModified)
            => PreviousSourceFileModified = previousSourceFileModified;

        public Task<DateTimeOffset> GetLastImportSourceFileModifiedAsync() => Task.FromResult(PreviousSourceFileModified);
        public Task ImportAllDataFromCSVZipAsync(string zipFilePath)
        {
            ImportAllDataZipFilePath = zipFilePath;
            ImportAllData_CallCount++;
            return Task.CompletedTask;
        }

        public Task LogDataImport(DateTimeOffset runDatetime, DateTimeOffset sourceFileModified)
        {
            LogDataImportArgs = (runDatetime, sourceFileModified);
            return Task.CompletedTask;
        }
    }
}
