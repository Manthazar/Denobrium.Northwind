using Microsoft.Extensions.Configuration;

namespace Northwind.Core.Configuration
{
    /// <summary>
    /// A simplisitic version of a configuration object (working on all platforms).
    /// </summary>
    /// <remarks>
    /// In case real-time updates are thing here (i.e. without restart), we may want to use a child of <see cref="ConfigurationSection"/> and binding to the source.
    /// </remarks>
    public class NorthwindBackendConfiguration
    {
        /// <summary>
        /// The name of the section within the (json) configuration file(s).
        /// </summary>
        /// <remarks>
        /// May not apply to all configuration frameworks.
        /// </remarks>
        public const string SectionName = "Northwind";

        /// <summary>
        /// The country name of the warehouse of this instance of Northwind Trades.
        /// </summary>
        public string WarehouseCountry { get; set; } = "Germany";

        public DataStoreOptions DataStores { get; set; } = new();

        public class DataStoreOptions
        {
            public string SqlConnectionString { get; set; } = string.Empty;
        }

        /// <summary>
        /// Api/ serialization related options (mostly for troubleshooting and performance purposes).
        /// </summary>
        public SerializationOptions Serialization { get; set; } = new ();

        public class SerializationOptions
        {
            public bool EnablePrettyJsonFormatting { get; set; } = false;

            public bool SendJsonNullvalues { get; set; } = false;
        }
    }
}
