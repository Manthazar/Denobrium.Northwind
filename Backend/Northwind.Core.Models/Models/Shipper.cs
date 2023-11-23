using System;
using System.Collections.Generic;

namespace Northwind.Core.Models
{
    public partial class Shipper : IWithId
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
