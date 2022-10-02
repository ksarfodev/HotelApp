using HotelAppLibrary.Data;
using HotelAppLibrary.Databases;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Xml.Linq;

[assembly: FunctionsStartup(typeof(HotelApp.AzureFunction.Startup))]

namespace HotelApp.AzureFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<ISqliteDataAccess,SqliteDataAccess>();

            builder.Services.AddTransient<IDatabaseData, SqliteData>();

        }
    }
}
