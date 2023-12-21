namespace Northwind.Backofficce.ApiClient.Data
{
    public class SupplierInfo

    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }


        /// <summary>
        /// An encoded string of the homepage with dash (#) as separator
        /// </summary>
        /// <example>
        /// Name of link#http#
        /// </example>
        /// <seealso cref="https://github.com/Manthazar/Denobrium.Northwind/issues/42"/>
        public string HomePage { get; set; }
    }
}
