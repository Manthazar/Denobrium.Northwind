using Microsoft.Extensions.DependencyInjection;

namespace Northwind.Core.Domain
{
    public static  class CoreDomainModule
    {
        public static IServiceCollection AddCoreDomainServices(this IServiceCollection services)
        {
            Check.IsNotNull(services, nameof(services));

            return services;
        }
    }
}
