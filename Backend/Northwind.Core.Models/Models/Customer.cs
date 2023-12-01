namespace Northwind.Core.Models
{
    public partial class Customer : IWithCode
    {
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

        public virtual ICollection<Order>? Orders { get; set; }

        /// <summary>
        /// Gets the customer types.
        /// </summary>
        /// <remarks>
        /// In sql, this is represented through a link table. 
        /// </remarks>
        //public virtual ICollection<CustomerDemographic>? CustomerTypes { get; set; }
    }
}
