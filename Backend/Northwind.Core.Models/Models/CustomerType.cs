using System.ComponentModel.DataAnnotations.Schema;
using Northwind.Core.Contracts;

namespace Northwind.Core.Models
{
    public partial class CustomerType : IReferenceData, IWithCode
    {
        public string Code { get; set; } = null!;
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
