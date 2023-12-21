using Northwind.Core.Configuration;
using Northwind.Core.Services;

namespace Northwind.TestSystem.Mocks
{
    internal class TestConfigurationProvider : INorthwindConfigurationProvider
    {
        public TestConfigurationProvider()
        {
            Configuration = new NorthwindBackendConfiguration();
        }

        public NorthwindBackendConfiguration Configuration { get; }
    }
}
