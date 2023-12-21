using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Configuration;
using Northwind.Core.Services;
using Northwind.TestSystem.Mocks;

namespace Northwind.TestSystem.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationMocks(this IServiceCollection services)
        {
            var configurationProvider = new NorthwindConfigurationProviderMock();

            services.AddSingleton<INorthwindConfigurationProvider>(configurationProvider);
            services.AddSingleton<NorthwindBackendConfiguration>(configurationProvider.Configuration);

            return services;
        }

        public static IServiceCollection AddSqLiteContext(this IServiceCollection services)
        {
            return services;
        }
    }
}
