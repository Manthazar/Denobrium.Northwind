using System;
using System.Collections.Generic;

namespace Northwind.Core.Models
{
    /// <remarks>
    /// The invoice item within Northwind strats off as a database view which appears strange since it cannot have any status or workflows attached to it... <see cref="https://github.com/Manthazar/Denobrium.Northwind/issues/8"/>
    /// </remarks>
    public partial class Invoice
    {
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
        public string? CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string Salesperson { get; set; } = null!;
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipperName { get; set; } = null!;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public decimal? ExtendedPrice { get; set; }
        public decimal? Freight { get; set; }
    }
}
