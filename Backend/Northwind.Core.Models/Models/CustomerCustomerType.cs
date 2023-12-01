namespace Northwind.Core.Models
{
    public partial class CustomerCustomerType
    {
        public string CustomerCode { get; set; } = null!;

        public string CustomerTypeCode { get; set; } = null!;

        //public virtual ICollection<Customer>? Customers { get; set; }

        //public virtual ICollection<CustomerType>? CustomerTypes { get; set; }
    }
}
