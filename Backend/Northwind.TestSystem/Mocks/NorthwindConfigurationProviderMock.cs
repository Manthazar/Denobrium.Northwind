using Northwind.Core.Configuration;
using Northwind.Core.Services;

namespace Northwind.TestSystem.Mocks
{
    internal class NorthwindConfigurationProviderMock : INorthwindConfigurationProvider
    {
        public NorthwindConfigurationProviderMock()
        {
            Configuration = new NorthwindBackendConfiguration();
        }

        public NorthwindBackendConfiguration Configuration { get; }
    }
}
