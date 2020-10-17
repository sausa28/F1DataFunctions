using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace F1DataFunctions.Tests.Stubs
{
    class StubF1APIClient : IF1APIClient
    {
        private readonly string _testZipPath;
        private readonly DateTimeOffset _lastModified;

        public int DownloadCSVZip_CallCount { get; private set; }

        public StubF1APIClient(string testZipPath, DateTimeOffset lastModified)
        {
            _testZipPath = testZipPath;
            _lastModified = lastModified;
        }

        public Task<DateTimeOffset> DownloadCSVZipAsync(string targetFilePath)
        {
            File.Copy(_testZipPath, targetFilePath, true);
            DownloadCSVZip_CallCount++;
            return Task.FromResult(_lastModified);
        }
    }
}
