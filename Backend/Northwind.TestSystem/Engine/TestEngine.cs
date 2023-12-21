using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Core;
using Northwind.Modules;
using Northwind.Sql.Repositories;
using Northwind.TestSystem.Extensions;
using System.Data.Common;

namespace Northwind.TestSystem.Engine
{
    public class TestEngine : IDisposable
    {
        private static TestEngine current = new();

        private IServiceScope scope = null!;
        private IServiceProvider serviceProvider = null!;

        private void Run()
        {
            var services = new ServiceCollection();

            services.AddConfigurationMocks();
            services.AddRepositories();
            services.AddSqLiteContext();

            this.scope = services.BuildServiceProvider().CreateScope();
            this.serviceProvider = scope.ServiceProvider;

            ConfigurationModule.ActivateTestContext();

            EnsureDatabaseCreated();
        }

        private void EnsureDatabaseCreated()
        {
            var dbContext = serviceProvider.GetRequiredService<NorthwindDbContext>();
            var createScript = dbContext.Database.GenerateCreateScript();

            dbContext.Database.EnsureCreated();
        }

        private void InnerDispose() => scope?.Dispose();

        void IDisposable.Dispose() => InnerDispose();

        public IServiceProvider Services
        {
            get
            {
                return serviceProvider ?? throw new InvalidOperationException("The test system is not initialized. Did you use TestBase?");
            }
        }

        /// <summary>
        /// The good clean up function which is called on health test exit.
        /// </summary>
        /// <remarks>
        /// Skipped by mstest on unhealth test exit.
        /// </remarks>
        internal static void CleanUp()
        {
            current?.InnerDispose();
        }

        /// <summary>
        /// Resets the test engine and makes it ready for the next test
        /// </summary>
        internal static void Reset()
        {
            current?.InnerDispose();

            current = new TestEngine();
            current.Run();
        }

        public static TestEngine Current => current;

        internal DbConnection? Connection { get; set; }
    }
}
