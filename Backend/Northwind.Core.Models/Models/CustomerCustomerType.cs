namespace Northwind.Core.Models
{
    public partial class CustomerCustomerType
    {
        public string CustomerId { get; set; } = null!;

        public string CustomerTypeId { get; set; } = null!;

        //public virtual ICollection<Customer>? Customers { get; set; }

        //public virtual ICollection<CustomerDemographic>? CustomerTypes { get; set; }
    }
}
