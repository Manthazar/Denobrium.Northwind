using Microsoft.Extensions.Configuration;
using Northwind.Core.Configuration;

namespace Northwind.Core.Services.Internal
{
    public sealed class DefaultNorthwindConfigurationProvider : INorthwindConfigurationProvider
    {
        private readonly IConfigurationRoot root;
        private NorthwindBackendConfiguration? northwindConfig;

        public DefaultNorthwindConfigurationProvider(IConfigurationRoot root)
        {
            Guard.IsNotNull(root, nameof(root));

            this.root = root;
        }

        public NorthwindBackendConfiguration Configuration => GetConfiguration();

        private NorthwindBackendConfiguration GetConfiguration()
        {
            if (northwindConfig == null)
            {
                northwindConfig = root.GetSection(NorthwindBackendConfiguration.SectionName).Get<NorthwindBackendConfiguration>();
            }

            return northwindConfig!;
        }
    }
}
