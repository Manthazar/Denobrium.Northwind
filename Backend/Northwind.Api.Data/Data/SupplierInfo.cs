namespace Northwind.Api.Data
{
    public record SupplierInfo
    {
        public string Id { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; } = null!;

        public string? ContactTitle { get; set; } = null!;

        public string? Phone { get; set; }
        public string? Fax { get; set; }

        /// <summary>
        /// An encoded string of the homepage with dash (#) as separator
        /// </summary>
        /// <example>
        /// Name of link#http#
        /// </example>
        public string? HomePage { get; set; }
    }
}
