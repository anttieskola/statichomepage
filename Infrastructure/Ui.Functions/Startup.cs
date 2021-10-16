using Configuration;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(Ui.Functions.Startup))]

namespace Ui.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging(configure =>
            {
                configure.ClearProviders();
                configure.AddApplicationInsights("");
            });
            builder.Services.AddScoped<IConfigurationClient, ConfigurationClient>();
        }
    }
}
