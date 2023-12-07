namespace Northwind.Core.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        /// <summary>
        /// The price for a unit.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The number of units of this order position.
        /// </summary>
        /// <remarks>
        /// Compared to the database, this has been renamed from quanity to NumberOfUnits to reduce the confusion related to QuanityPerUnit -giving the impression that orders could be placed for single bottles etc...
        /// </remarks>
        public short NumberOfUnits { get; set; }

        /// <summary>
        /// The applicable discount on the price.
        /// </summary>
        public float Discount { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
