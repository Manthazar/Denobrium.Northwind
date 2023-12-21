using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Configuration;
using Northwind.Core.Services;

namespace Northwind.Core
{
    public static class ConfigurationModule
    {
        /// <summary>
        /// Determines whether the app is running in test context.
        /// </summary>
        public static bool IsInTestContext { get; private set; }

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

        /// <summary>
        /// Used by our framework to indicate that the
        /// </summary>
        internal static void ActivateTestContext() => IsInTestContext = true;
    }
}
