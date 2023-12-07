using Microsoft.Extensions.DependencyInjection;
using Northwind.Api.Services;

namespace Northwind.Api
{
    public static class ApiServicesModule
    {
        /// <summary>
        /// Adds the services on the API layer.
        /// </summary>
        /// <remarks>
        /// The services on API layer are those which know API objects and domain objects. 
        /// Typically only perform simple transformations such as aggregations.
        /// </remarks>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            /* That here is a bit controversal. Following the books we should always create an interface.
             * 
             * However, in these cases I learned that
             * - we practically NEVER have more than one implementation
             * - we actually don't need to mock them anyway (for unit testing) (we mock away app boundaries, such as sql/web repositories or queues).
            
             This allows the conclusion that an abstraction here is just unnecessary overhead, hence the simple type map...
            */

            services.AddScoped<OrderService, OrderService>();

            return services;
        }
    }
}
