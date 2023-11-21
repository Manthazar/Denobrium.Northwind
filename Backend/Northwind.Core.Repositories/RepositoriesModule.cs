﻿using Microsoft.Extensions.DependencyInjection;
using Northwind.Core;
using Northwind.Core.Repositories;

namespace Northwind.Modules
{
    public static class RepositoriesModule
    {
        public static void AddRepositories(this IServiceCollection services, string sqlConnectionString)
        {
            Guard.IsNotNull(services, nameof(services));
            Guard.IsNotNullOrEmpty(sqlConnectionString, nameof(sqlConnectionString));

            services.AddDbContext<NorthwindContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);

            }, contextLifetime: ServiceLifetime.Scoped, optionsLifetime: ServiceLifetime.Singleton);
        }
    }
}
