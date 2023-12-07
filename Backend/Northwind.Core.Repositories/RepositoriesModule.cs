using Microsoft.Extensions.DependencyInjection;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Sql.Repositories;

namespace Northwind.Modules
{
    public static class RepositoriesModule
    {
        public static void AddRepositories(this IServiceCollection services, string sqlConnectionString)
        {
            Guard.IsNotNull(services, nameof(services));
            Guard.IsNotNullOrEmpty(sqlConnectionString, nameof(sqlConnectionString));

            services.AddScoped<ISqlRepository<Category>, SqlRepository<Category>>();
            services.AddScoped<ISqlRepository<Customer>, SqlRepository<Customer>>();
            services.AddScoped<ISqlRepository<Employee>, SqlRepository<Employee>>();
            services.AddScoped<ISqlRepository<Product>, SqlRepository<Product>>();

            services.AddDbContext<NorthwindDbContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);

            }, contextLifetime: ServiceLifetime.Scoped, optionsLifetime: ServiceLifetime.Singleton);
        }
    }
}
