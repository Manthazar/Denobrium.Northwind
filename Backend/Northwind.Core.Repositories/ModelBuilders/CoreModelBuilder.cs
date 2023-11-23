using Northwind.Core.Models;

namespace Northwind.Core.Repositories.ModelBuilders
{
    /// <summary>
    /// This builder builds the EF model for the core tables/ entities. 
    /// </summary>
    internal static class CoreModelBuilder
    {
        /// <summary>
        /// Inactive code brick for reference purposes only. 
        /// </summary>
        /// <param name="builder"></param>
        internal static void BuildInto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("CategoryID");
                entity.Property(e => e.CategoryName).HasMaxLength(15);
                entity.Property(e => e.Description).HasColumnType("ntext");
                entity.Property(e => e.Picture).HasColumnType("image");

                entity.HasIndex(e => e.CategoryName, "CategoryName");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                // TODO: This should be renamed to customer code
                entity.Property(e => e.CustomerId).HasMaxLength(5).HasColumnName("CustomerID").IsFixedLength();
                
                entity.Property(e => e.Address).HasMaxLength(60);
                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.CompanyName).HasMaxLength(40);
                entity.Property(e => e.ContactName).HasMaxLength(30);
                entity.Property(e => e.ContactTitle).HasMaxLength(30);
                entity.Property(e => e.Country).HasMaxLength(15);
                entity.Property(e => e.Fax).HasMaxLength(24);
                entity.Property(e => e.Phone).HasMaxLength(24);
                entity.Property(e => e.PostalCode).HasMaxLength(10);
                entity.Property(e => e.Region).HasMaxLength(15);

                entity.HasIndex(e => e.City, "City");
                entity.HasIndex(e => e.CompanyName, "CompanyName");
                entity.HasIndex(e => e.PostalCode, "PostalCode");
                entity.HasIndex(e => e.Region, "Region");

                //entity.HasMany(d => d.CustomerTypes)
                //    .WithMany(p => p.Customers)
                //    .UsingEntity<Dictionary<string, object>>(
                //        "CustomerCustomerDemo",
                //        l => l.HasOne<CustomerDemographic>().WithMany().HasForeignKey("CustomerTypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerDemo"),
                //        r => r.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerDemo_Customers"),
                //        j =>
                //        {
                //            j.HasKey("CustomerId", "CustomerTypeId").IsClustered(false);

                //            j.ToTable("CustomerCustomerDemo");

                //            j.IndexerProperty<string>("CustomerId").HasMaxLength(5).HasColumnName("CustomerID").IsFixedLength();

                //            j.IndexerProperty<string>("CustomerTypeId").HasMaxLength(10).HasColumnName("CustomerTypeID").IsFixedLength();
                //        });
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("EmployeeID");

                entity.Property(e => e.Address).HasMaxLength(60);
                entity.Property(e => e.BirthDate).HasColumnType("datetime");
                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.Country).HasMaxLength(15);
                entity.Property(e => e.Extension).HasMaxLength(4);
                entity.Property(e => e.FirstName).HasMaxLength(10);
                entity.Property(e => e.HireDate).HasColumnType("datetime");
                entity.Property(e => e.HomePhone).HasMaxLength(24);
                entity.Property(e => e.LastName).HasMaxLength(20);
                entity.Property(e => e.Notes).HasColumnType("ntext");
                entity.Property(e => e.Photo).HasColumnType("image");
                entity.Property(e => e.PhotoPath).HasMaxLength(255);
                entity.Property(e => e.PostalCode).HasMaxLength(10);
                entity.Property(e => e.Region).HasMaxLength(15);
                entity.Property(e => e.Title).HasMaxLength(30);
                entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

                entity.HasIndex(e => e.LastName, "LastName");
                entity.HasIndex(e => e.PostalCode, "PostalCode");

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("FK_Employees_Employees");

                entity.HasMany(d => d.Territories)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeeTerritory",
                        l => l.HasOne<Territory>().WithMany().HasForeignKey("TerritoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeeTerritories_Territories"),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeeTerritories_Employees"),
                        j =>
                        {
                            j.HasKey("EmployeeId", "TerritoryId").IsClustered(false);

                            j.ToTable("EmployeeTerritories");

                            j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");

                            j.IndexerProperty<string>("TerritoryId").HasMaxLength(20).HasColumnName("TerritoryID");
                        });
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Invoices");

                entity.Property(e => e.Address).HasMaxLength(60);
                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.Country).HasMaxLength(15);
                entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                entity.Property(e => e.CustomerName).HasMaxLength(40);
                entity.Property(e => e.ExtendedPrice).HasColumnType("money");
                entity.Property(e => e.Freight).HasColumnType("money");
                entity.Property(e => e.OrderDate).HasColumnType("datetime");
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.PostalCode).HasMaxLength(10);
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.ProductName).HasMaxLength(40);
                entity.Property(e => e.Region).HasMaxLength(15);
                entity.Property(e => e.RequiredDate).HasColumnType("datetime");
                entity.Property(e => e.Salesperson).HasMaxLength(31);
                entity.Property(e => e.ShipAddress).HasMaxLength(60);
                entity.Property(e => e.ShipCity).HasMaxLength(15);
                entity.Property(e => e.ShipCountry).HasMaxLength(15);
                entity.Property(e => e.ShipName).HasMaxLength(40);
                entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
                entity.Property(e => e.ShipRegion).HasMaxLength(15);
                entity.Property(e => e.ShippedDate).HasColumnType("datetime");
                entity.Property(e => e.ShipperName).HasMaxLength(40);
                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("OrderID");
                entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");
                entity.Property(e => e.RequiredDate).HasColumnType("datetime");
                entity.Property(e => e.ShipAddress).HasMaxLength(60);
                entity.Property(e => e.ShipCity).HasMaxLength(15);
                entity.Property(e => e.ShipCountry).HasMaxLength(15);
                entity.Property(e => e.ShipName).HasMaxLength(40);
                entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
                entity.Property(e => e.ShipRegion).HasMaxLength(15);
                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasIndex(e => e.CustomerId, "CustomerID");
                entity.HasIndex(e => e.CustomerId, "CustomersOrders");
                entity.HasIndex(e => e.EmployeeId, "EmployeeID");
                entity.HasIndex(e => e.EmployeeId, "EmployeesOrders");
                entity.HasIndex(e => e.OrderDate, "OrderDate");
                entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");
                entity.HasIndex(e => e.ShippedDate, "ShippedDate");
                entity.HasIndex(e => e.ShipVia, "ShippersOrders");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Orders_Shippers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_Order_Details");

                entity.ToTable("Order Details");

                entity.HasIndex(e => e.OrderId, "OrderID");
                entity.HasIndex(e => e.OrderId, "OrdersOrder_Details");
                entity.HasIndex(e => e.ProductId, "ProductID");
                entity.HasIndex(e => e.ProductId, "ProductsOrder_Details");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");
                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Products");
            });


            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ProductID");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.ProductName).HasMaxLength(40);
                entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
                entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");
                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasIndex(e => e.CategoryId, "CategoriesProducts");
                entity.HasIndex(e => e.CategoryId, "CategoryID");
                entity.HasIndex(e => e.ProductName, "ProductName");
                entity.HasIndex(e => e.SupplierId, "SupplierID");
                entity.HasIndex(e => e.SupplierId, "SuppliersProducts");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");
                entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Products_Suppliers");
            });



            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("Region");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("RegionID");

                entity.Property(e => e.RegionDescription)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ShipperID");
                entity.Property(e => e.CompanyName).HasMaxLength(40);
                entity.Property(e => e.Phone).HasMaxLength(24);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("SupplierID");
                entity.Property(e => e.Address).HasMaxLength(60);
                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.CompanyName).HasMaxLength(40);
                entity.Property(e => e.ContactName).HasMaxLength(30);
                entity.Property(e => e.ContactTitle).HasMaxLength(30);
                entity.Property(e => e.Country).HasMaxLength(15);
                entity.Property(e => e.Fax).HasMaxLength(24);
                entity.Property(e => e.HomePage).HasColumnType("ntext");
                entity.Property(e => e.Phone).HasMaxLength(24);
                entity.Property(e => e.PostalCode).HasMaxLength(10);
                entity.Property(e => e.Region).HasMaxLength(15);

                entity.HasIndex(e => e.CompanyName, "CompanyName");
                entity.HasIndex(e => e.PostalCode, "PostalCode");
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.HasKey(e => e.TerritoryId)
                    .IsClustered(false);

                entity.Property(e => e.TerritoryId)
                    .HasMaxLength(20)
                    .HasColumnName("TerritoryID");

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.TerritoryDescription)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Territories_Region");
            });
        }
    }
}
