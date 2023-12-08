namespace Northwind.Core.Configuration
{
    public class NorthwindApiConfiguration
    {
        /// <summary>
        /// The country name of the warehouse of this instance of Northwind Trades.
        /// </summary>
        public string WarehouseCountry { get; set; } = "Germany";

        public string SqlConnectionString { get; set; } = string.Empty;

        public bool EnablePrettyJsonFormatting => false;

        public bool SendJsonNullvalues => false;
    }
}
