using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Configuration;

namespace Northwind.Core
{
    public static class ConfigurationModule
    {
        /// <summary>
        /// Adds the Northwind instance configuration into the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddNorthwindStoreConfiguration(this IServiceCollection services)
        {
            services.AddScoped<NorthwindApiConfiguration, NorthwindApiConfiguration>();

            return services;
        }
    }
}
