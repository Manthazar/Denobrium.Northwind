namespace Northwind.BackOffice.Data
{
    /// <summary>
    /// The info data object is a blended data object for a particular use cases having the root Customer (there may be several info type objects for several use cases).
    /// </summary>
    public class CustomerInfo
    {
        public string CustomerId { get; set; }

        public string CustomerCode { get; set; }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
