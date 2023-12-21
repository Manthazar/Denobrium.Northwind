namespace Northwind.Backoffice.Data
{
	/// <summary>
	/// Represents an informational data object for products. 
	/// </summary>
	public class ProductInfo
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string CategoryName { get; set; }

		public string SupplierCompanyName { get; set; }

		/// <summary>
		/// The quantity per unit of the product (i.e. number of bottles per unit or ml per bottle).
		/// </summary>
		public string QuanityPerUnit { get; set; }

		/// <summary>
		/// The number of units in stock.
		/// </summary>
		public short? UnitsInStock { get; set; }

		/// <summary>
		/// The number of units in order.
		/// </summary>
		public short? UnitsOnOrder { get; set; }

		/// <summary>
		/// Indicates whether the product is discontinued or not.
		/// </summary>
		/// <remarks>
		/// Note, that the supplier won't provide more units of discontinued products.
		/// </remarks>
		public bool IsDiscontinued { get; set; }
	}
}