using Microsoft.Extensions.DependencyInjection;
using Northwind.Modules;
using Northwind.TestSystem.Extensions;
using System.Data.Common;

namespace Northwind.TestSystem.Engine
{
    internal class TestEngine : IDisposable
    {
        private static TestEngine current = new ();

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
        }

        public void Dispose()
        {
            scope?.Dispose();
        }

        /// <summary>
        /// Resets the test engine and makes it ready for the next test
        /// </summary>
        internal static void Reset()
        {
            current?.Dispose();

            current = new TestEngine();
            current.Run();
        }

     

        internal IServiceProvider Services => serviceProvider;

        internal static TestEngine Current => current;

        internal DbConnection? Connection { get; set; }
    }
}
