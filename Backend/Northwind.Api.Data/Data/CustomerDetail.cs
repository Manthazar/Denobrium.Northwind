namespace Northwind.Api.Data
{
    /// <summary>
    /// The data object is primarily a (full) detail object of customer.
    /// </summary>
    public record CustomerDetail
    {
        /// <remarks>
        /// It makes little sense to expose a numeric identifier as a numeric identifier on API level because you cannot do anything with it you can normally do with numerics (add/ multiple/ divide/ sum etc).
        /// Hence we convert them to strings which would also help cases, in which we change our mind and want to represent the id in other (non-numeric) way.
        /// </remarks>
        public string Id { get; set; } = null!;
        public string Code { get; set; } = null!;


        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
    }
}
