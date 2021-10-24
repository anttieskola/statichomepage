using Configuration;
using Microsoft.Extensions.DependencyInjection;
using TableStorage;

namespace VisitorDataApplication
{
    public static class VisitorDataApplicationExtensions
    {
        /// <summary>
        /// Add VisitorDataApplication's dependency injections
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddVisitorDataApplication(this IServiceCollection services)
        {
            services.AddScoped<IVisitorDataApplication, VDApp>();
            services.AddScoped<IStorageVisitorData, TableStorageVisitorData>();
            if (!services.Any(s => s.ServiceType == typeof(IConfigurationClient)))
            {
#if DEBUG
                services.AddScoped<IConfigurationClient, DummyConfigurationClient>();
#else
                services.AddScoped<IConfigurationClient, ConfigurationClient>();
#endif
            }
            return services;
        }
    }
}
