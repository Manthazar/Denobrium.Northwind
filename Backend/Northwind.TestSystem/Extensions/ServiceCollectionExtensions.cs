using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Configuration;
using Northwind.Core.Services;
using Northwind.Sql.Repositories;
using Northwind.TestSystem.Engine;
using Northwind.TestSystem.Mocks;

namespace Northwind.TestSystem.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationMocks(this IServiceCollection services)
        {
            var configurationProvider = new TestConfigurationProvider();

            services.AddSingleton<INorthwindConfigurationProvider>(configurationProvider);
            services.AddSingleton<NorthwindBackendConfiguration>(configurationProvider.Configuration);

            return services;
        }

        public static IServiceCollection AddSqLiteContext(this IServiceCollection services)
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            // The unit of work within a unit test context is always the unit test.
            // That said, we need to ensure that any db context is going to use our db connection.

            TestEngine.Current.Connection = new SqliteConnection("Filename=:memory:");
            TestEngine.Current.Connection.Open();

            services.AddDbContextFactory<NorthwindDbContext>(options => options.UseSqlite(TestEngine.Current.Connection), ServiceLifetime.Scoped);

            return services;
        }
    }
}
