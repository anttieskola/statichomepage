using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using VisitorDataApplication;

[assembly: FunctionsStartup(typeof(Ui.Functions.Startup))]

namespace Ui.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddVisitorDataApplication();
        }
    }
}
