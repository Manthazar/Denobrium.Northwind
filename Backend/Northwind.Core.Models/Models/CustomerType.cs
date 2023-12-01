using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Core.Models
{
    public partial class CustomerType
    {
        public string CustomerTypeCode { get; set; } = null!;
        public string? Description { get; set; }

        //public virtual ICollection<Customer>? Customers { get; set; }
    }
}
