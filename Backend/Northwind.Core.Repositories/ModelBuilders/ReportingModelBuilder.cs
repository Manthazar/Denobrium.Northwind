using Microsoft.EntityFrameworkCore;

namespace Northwind.Core.Repositories.ModelBuilders
{
    internal static class ReportingModelBuilder
    {
        /// <summary>
        /// Inactive code brick for reference purposes only. 
        /// </summary>
        /// <param name="builder"></param>
        internal static void BuildInto (ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AlphabeticalListOfProduct>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Alphabetical list of products");

            //    entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            //    entity.Property(e => e.CategoryName).HasMaxLength(15);
            //    entity.Property(e => e.ProductId).HasColumnName("ProductID");
            //    entity.Property(e => e.ProductName).HasMaxLength(40);
            //    entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            //    entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            //    entity.Property(e => e.UnitPrice).HasColumnType("money");
            //});

            //modelBuilder.Entity<CategorySalesFor1997>(entity =>
            //{
            //    entity.HasNoKey();
            //    entity.ToView("Category Sales for 1997");
            //    entity.Property(e => e.CategoryName).HasMaxLength(15);
            //    entity.Property(e => e.CategorySales).HasColumnType("money");
            //});

            //modelBuilder.Entity<CurrentProductList>(entity =>
            //{
            //    entity.HasNoKey();
            //    entity.ToView("Current Product List");

            //    entity.Property(e => e.ProductId)
            //        .ValueGeneratedOnAdd()
            //        .HasColumnName("ProductID");
            //    entity.Property(e => e.ProductName).HasMaxLength(40);
            //});

            //modelBuilder.Entity<CustomerAndSuppliersByCity>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Customer and Suppliers by City");

            //    entity.Property(e => e.City).HasMaxLength(15);

            //    entity.Property(e => e.CompanyName).HasMaxLength(40);

            //    entity.Property(e => e.ContactName).HasMaxLength(30);

            //    entity.Property(e => e.Relationship)
            //        .HasMaxLength(9)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CustomerDemographic>(entity =>
            //{
            //    entity.HasKey(e => e.CustomerTypeId)
            //        .IsClustered(false);

            //    entity.Property(e => e.CustomerTypeId)
            //        .HasMaxLength(10)
            //        .HasColumnName("CustomerTypeID")
            //        .IsFixedLength();

            //    entity.Property(e => e.CustomerDesc).HasColumnType("ntext");
            //});

            //modelBuilder.Entity<OrderDetailsExtended>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Order Details Extended");

            //    entity.Property(e => e.ExtendedPrice).HasColumnType("money");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.ProductId).HasColumnName("ProductID");

            //    entity.Property(e => e.ProductName).HasMaxLength(40);

            //    entity.Property(e => e.UnitPrice).HasColumnType("money");
            //});

            //modelBuilder.Entity<OrderSubtotal>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Order Subtotals");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.Subtotal).HasColumnType("money");
            //});

            //modelBuilder.Entity<OrdersQry>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Orders Qry");

            //    entity.Property(e => e.Address).HasMaxLength(60);

            //    entity.Property(e => e.City).HasMaxLength(15);

            //    entity.Property(e => e.CompanyName).HasMaxLength(40);

            //    entity.Property(e => e.Country).HasMaxLength(15);

            //    entity.Property(e => e.CustomerId)
            //        .HasMaxLength(5)
            //        .HasColumnName("CustomerID")
            //        .IsFixedLength();

            //    entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            //    entity.Property(e => e.Freight).HasColumnType("money");

            //    entity.Property(e => e.OrderDate).HasColumnType("datetime");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.PostalCode).HasMaxLength(10);

            //    entity.Property(e => e.Region).HasMaxLength(15);

            //    entity.Property(e => e.RequiredDate).HasColumnType("datetime");

            //    entity.Property(e => e.ShipAddress).HasMaxLength(60);

            //    entity.Property(e => e.ShipCity).HasMaxLength(15);

            //    entity.Property(e => e.ShipCountry).HasMaxLength(15);

            //    entity.Property(e => e.ShipName).HasMaxLength(40);

            //    entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

            //    entity.Property(e => e.ShipRegion).HasMaxLength(15);

            //    entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            //});


            //modelBuilder.Entity<ProductSalesFor1997>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Product Sales for 1997");

            //    entity.Property(e => e.CategoryName).HasMaxLength(15);

            //    entity.Property(e => e.ProductName).HasMaxLength(40);

            //    entity.Property(e => e.ProductSales).HasColumnType("money");
            //});

            //modelBuilder.Entity<ProductsAboveAveragePrice>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Products Above Average Price");

            //    entity.Property(e => e.ProductName).HasMaxLength(40);

            //    entity.Property(e => e.UnitPrice).HasColumnType("money");
            //});

            //modelBuilder.Entity<ProductsByCategory>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Products by Category");

            //    entity.Property(e => e.CategoryName).HasMaxLength(15);

            //    entity.Property(e => e.ProductName).HasMaxLength(40);

            //    entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            //});

            //modelBuilder.Entity<QuarterlyOrder>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Quarterly Orders");

            //    entity.Property(e => e.City).HasMaxLength(15);

            //    entity.Property(e => e.CompanyName).HasMaxLength(40);

            //    entity.Property(e => e.Country).HasMaxLength(15);

            //    entity.Property(e => e.CustomerId)
            //        .HasMaxLength(5)
            //        .HasColumnName("CustomerID")
            //        .IsFixedLength();
            //});

            //modelBuilder.Entity<SalesByCategory>(entity =>
            //{
            //    entity.HasNoKey();
            //    entity.ToView("Sales by Category");

            //    entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            //    entity.Property(e => e.CategoryName).HasMaxLength(15);
            //    entity.Property(e => e.ProductName).HasMaxLength(40);
            //    entity.Property(e => e.ProductSales).HasColumnType("money");
            //});

            //modelBuilder.Entity<SalesTotalsByAmount>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Sales Totals by Amount");

            //    entity.Property(e => e.CompanyName).HasMaxLength(40);
            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");
            //    entity.Property(e => e.SaleAmount).HasColumnType("money");
            //    entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<SummaryOfSalesByQuarter>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Summary of Sales by Quarter");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");
            //    entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            //    entity.Property(e => e.Subtotal).HasColumnType("money");
            //});

            //modelBuilder.Entity<SummaryOfSalesByYear>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Summary of Sales by Year");

            //    entity.Property(e => e.OrderId).HasColumnName("OrderID");

            //    entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            //    entity.Property(e => e.Subtotal).HasColumnType("money");
            //});
        }
    }
}
