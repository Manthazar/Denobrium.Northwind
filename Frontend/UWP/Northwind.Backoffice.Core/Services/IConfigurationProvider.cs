using Northwind.Backoffice.Configuration;

namespace Northwind.Backoffice.Services
{
    public interface IConfigurationProvider
    {
        NorthwindBackofficeConfig Config { get; }
    }
}