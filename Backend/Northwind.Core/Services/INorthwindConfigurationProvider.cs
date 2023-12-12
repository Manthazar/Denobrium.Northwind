using Northwind.Core.Configuration;

namespace Northwind.Core.Services
{
    public interface INorthwindConfigurationProvider
    {
        NorthwindBackendConfiguration Configuration { get; }
    }
}
