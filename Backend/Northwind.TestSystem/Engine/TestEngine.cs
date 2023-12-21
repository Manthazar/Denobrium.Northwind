
using Microsoft.Extensions.DependencyInjection;
using Northwind.Core;
using Northwind.Modules;
using Northwind.TestSystem.Extensions;

namespace Northwind.TestSystem.Engine
{
    internal class TestEngine
    {
        private static TestEngine current = new TestEngine();

        private ServiceProvider serviceProvider = null!;

        private void Run()
        {
            var services = new ServiceCollection();

            services.AddSingletonMapper();
            services.AddConfigurationMocks();
            services.AddRepositories();
            services.AddSqLiteContext();

            this.serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Resets the test engine and makes it ready for the next test
        /// </summary>
        internal static void Reset()
        {
            current = new TestEngine();
            current.Run();
        }

        internal IServiceProvider Services => serviceProvider;


        internal static TestEngine Current => current;
    }
}
