namespace Northwind.Api.Data
{
    /// <summary>
    /// Represents an informational data object for products. 
    /// </summary>
    public record ProductInfo
    {
        public string Id { get; set; } = null!

        public string Name { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string SupplierCompanyName { get; set; } = null!;

        /// <summary>
        /// The quantity per unit of the product (i.e. number of bottles per unit or ml per bottle).
        /// </summary>
        public string? QuanityPerUnit { get; set; }

        /// <summary>
        /// The number of units in stock.
        /// </summary>
        public short? UnitsInStock { get; set; }

        /// <summary>
        /// The number of units in order.
        /// </summary>
        public short? UnitsOnOrder { get; set; }

        public bool IsDiscontinued {  get; set; }
    }
}
