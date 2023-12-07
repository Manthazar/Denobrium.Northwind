using Northwind.Core.Contracts;

namespace Northwind.Core.Models
{
    /// <summary>
    /// The order as placed by the customer. Noteably, by the provided data we cannot state when the order is actually completed or not.
    /// </summary>
    public partial class Order : IWithId
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string? CustomerCode { get; set; }

        public int? EmployeeId { get; set; }

        /// <summary>
        /// The date when the order was placed.
        /// </summary>
        /// <remarks>
        /// This cannot track time, except upon the silent agreement that all date times are utc.
        /// </remarks>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// The date at which the shipment should be completed (as per contract/ promisse).
        /// </summary>
        public DateTime? RequiredDate { get; set; }

        /// <summary>
        /// The date at which the shippment has begun.
        /// </summary>
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }

        /// <summary>
        /// The target country of the order.
        /// </summary>
        public string? ShipCountry { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Shipper? ShipViaNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
