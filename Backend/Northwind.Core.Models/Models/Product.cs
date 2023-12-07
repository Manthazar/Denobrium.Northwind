using Northwind.Core.Contracts;

namespace Northwind.Core.Models
{
    public partial class Product : IWithId
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        /// <summary>
        /// The number of products per unit (i.e. box). A customer can only order entire units
        /// </summary>
        /// <example>
        /// 12 - 550 ml bottles - you cannot order 1 bottle only.
        /// </example>
        public string? QuantityPerUnit { get; set; }

        /// <summary>
        /// The price of a unit
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// The number of units in stock.
        /// </summary>
        public short? UnitsInStock { get; set; }

        /// <summary>
        /// The number of units ordered.
        /// </summary>
        public short? UnitsOnOrder { get; set; }

        /// <summary>
        /// The number of units ordered from supplier.
        /// </summary>
        public short? ReorderLevel { get; set; }

        /// <summary>
        /// Indicates whether the product is available from the supplier or not.
        /// </summary>
        public bool IsDiscontinued { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
