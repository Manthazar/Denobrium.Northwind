using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Core.Models
{
    public partial class CustomerType
    {
        public string CustomerTypeCode { get; set; } = null!;
        public string? Description { get; set; }

        /// <summary>
        /// Gets the customer types of this customer.
        /// </summary>
        /// <remarks>
        /// In sql, this is represented through a link table. 
        /// </remarks>
        public virtual ICollection<Customer>? Customers { get; set; }

        /// <summary>
        /// Internal link table navigation so that model builder can maintain potential migrations of it.
        /// </summary>
        //internal virtual ICollection<CustomerCustomerType>? CustomerTypeLinks { get; set; }
    }
}
