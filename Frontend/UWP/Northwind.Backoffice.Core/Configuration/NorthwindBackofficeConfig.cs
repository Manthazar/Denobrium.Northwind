namespace Northwind.Backoffice.Configuration
{
    /// <summary>
    /// Prototype of a configuration object for the client.
    /// </summary>
    public class NorthwindBackofficeConfig
    {
        /// <summary>
        /// The base url of the Northwind Api, i.e. "https://hereiam/api"
        /// </summary>
        public string NorthwindApiBaseUri => "https://localhost:7185/api";

        public bool EnablePrettyJsonFormatting => false;

        public bool SendJsonNullvalues => false;
    }
}
