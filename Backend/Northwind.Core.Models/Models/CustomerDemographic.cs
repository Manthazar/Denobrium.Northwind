using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Core.Models
{
    public partial class CustomerDemographic
    {
        public string CustomerTypeId { get; set; } = null!;
        public string? CustomerDesc { get; set; }

        public virtual ICollection<Customer>? Customers { get; set; }
    }
}
