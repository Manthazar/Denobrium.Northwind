using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Configuration;
using Northwind.Core.Services;

namespace Northwind.Core
{
    public static class ConfigurationModule
    {
        /// <summary>
        /// Adds the Northwind instance configuration into the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddNorthwindConfiguration(this IServiceCollection services, INorthwindConfigurationProvider configurationProvider)
        {
            services.AddSingleton<INorthwindConfigurationProvider>(configurationProvider);
            services.AddSingleton<NorthwindBackendConfiguration>(configurationProvider.Configuration);

            return services;
        }
    }
}
