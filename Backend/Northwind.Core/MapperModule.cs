using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Northwind.Core
{
    public static class MapperModule
    {
        public static IMapper Mapper { get; private set; } = null!;

        /// <summary>
        /// Automatically adds the automap profiles for the determined configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSingletonMapper(this IServiceCollection services)
        {
            Check.IsNotNull(services, nameof(services));

            var provider = services.BuildServiceProvider();
            var mappingConfig = provider.GetRequiredService<IConfigurationProvider>();
            var mapper = mappingConfig.CreateMapper();

            Mapper = mapper;

            return services;
        }
    }
}
