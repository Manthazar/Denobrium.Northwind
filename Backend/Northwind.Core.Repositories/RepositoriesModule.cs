using Microsoft.Extensions.DependencyInjection;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Core.Repositories;
using Northwind.Sql.Repositories;

namespace Northwind.Modules
{
    public static class RepositoriesModule
    {
        /// <summary>
        /// Adds the entity repositories in their default configurations.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sqlConnectionString"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddRepository<Category>();
            services.AddRepository<Customer>();
            services.AddRepository<Employee>();
            services.AddRepository<Product>();
            services.AddRepository<Supplier>();
            services.AddRepository<Order>();
        }

        /// <summary>
        /// Adds the entity repositories in their default configurations.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sqlConnectionString"></param>
        public static void AddDbContext(this IServiceCollection services, string sqlConnectionString)
        {
            Check.IsNotNull(services, nameof(services));

#if DEBUG
            Check.IsNotNullOrEmpty(sqlConnectionString, nameof(sqlConnectionString));
#else 
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                // Allowing this in non-dev so that the configuration service is starting up and can be used 
                // (otherwise the webapi collapses at this point)
                // Would be worth to log a warning though (which we don't do here in absense of a proper logging middleware.
                return;
            }
#endif

            services.AddDbContext<NorthwindDbContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);

            }, contextLifetime: ServiceLifetime.Scoped, optionsLifetime: ServiceLifetime.Singleton);
        }

        private static void AddRepository<T>(this IServiceCollection services) where T : class
        {
            services.AddScoped<IRepository<T>, SqlRepository<T>>();
            services.AddScoped<ISqlRepository<T>, SqlRepository<T>>();
        }
    }
}
