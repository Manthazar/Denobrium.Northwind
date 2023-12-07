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
        public static void AddRepositories(this IServiceCollection services, string sqlConnectionString)
        {
            Guard.IsNotNull(services, nameof(services));
            Guard.IsNotNullOrEmpty(sqlConnectionString, nameof(sqlConnectionString));

            services.AddRepository<Category>();
            services.AddRepository<Customer>();
            services.AddRepository<Employee>();
            services.AddRepository<Product>();
            services.AddRepository<Supplier>();
            services.AddRepository<Order>();

            services.AddDbContext<NorthwindDbContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);

            }, contextLifetime: ServiceLifetime.Scoped, optionsLifetime: ServiceLifetime.Singleton);
        }

        private static void AddRepository<T> (this IServiceCollection services) where T : class
        {
            services.AddScoped<IRepository<T>, SqlRepository<T>>();
            services.AddScoped<ISqlRepository<T>, SqlRepository<T>>();
        }
    }
}
