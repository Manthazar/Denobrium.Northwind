namespace Northwind.Api.Data
{
    /// <summary>
    /// The info data object is a blended data object for a particular use cases having the root Customer (there may be several info type objects for several use cases).
    /// </summary>
    public class CustomerInfo
    {
        /// <remarks>
        /// It makes little sense to expose a numeric identifier as a numeric identifier on API level because you cannot do anything with it you can normally do with numerics (add/ multiple/ divide/ sum etc).
        /// Hence we convert them to strings which would also help cases, in which we change our mind and want to represent the id in other (non-numeric) way.
        /// </remarks>
        public string CustomerId { get; set; } = null!;

        public string CustomerCode { get; set; } = null!;


        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
