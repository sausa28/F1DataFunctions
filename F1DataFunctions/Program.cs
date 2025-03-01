using F1DataFunctions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Hosting;

namespace F1DataFunctions
{
    public static class Program
    {
        public static void Main()
        {
            var builder = Host.CreateApplicationBuilder();
            Configure(builder);
            builder.Build().Run();
        }

        private static void Configure(IHostApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<IF1APIClient, ErgastF1APIClient>();
            builder.Services.AddTransient<IF1DataImporter>(DataImporterFactory);
        }

        private static F1DataImporter DataImporterFactory(IServiceProvider serviceProvider)
        {
            var config = serviceProvider.GetRequiredService<IConfiguration>();
            string connectionString = config["formula1dbConnectionString"] ?? throw new ArgumentNullException("formula1dbConnectionString");
            return new F1DataImporter(connectionString);
        }
    }
}
