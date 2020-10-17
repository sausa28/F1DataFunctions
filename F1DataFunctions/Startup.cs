using F1DataFunctions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly:FunctionsStartup(typeof(Startup))]
namespace F1DataFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
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
