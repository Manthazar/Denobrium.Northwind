using Northwind.Core.Models;

namespace Northwind.Sql.ModelBuilders
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
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");

                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Code);

                entity.Property(e => e.Id).HasColumnName("CustomerID");
                entity.Property(e => e.Code).HasMaxLength(5).HasColumnName("CustomerCode").IsFixedLength();

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

                // The below is demonstrating the direct loading of one to  many relations while skipping the link table (CustomerCustomerType)
                entity.HasMany(d => d.CustomerTypes)
                    .WithMany(p => p.Customers)
                    .UsingEntity<CustomerCustomerType>(
                        l => l.HasOne<CustomerType>().WithMany().HasForeignKey(l=> l.CustomerTypeCode).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerType_CustomerTypes"),
                        r => r.HasOne<Customer>().WithMany().HasPrincipalKey(r=> r.Code).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerType_Customers"),
                        e =>
                        {
                            e.ToTable("CustomerCustomerTypes");
                            e.HasKey("CustomerCode", "CustomerTypeCode").IsClustered(false);

                            e.Property(e=> e.CustomerCode).HasMaxLength(5).HasColumnName("CustomerCode").IsFixedLength();
                            e.Property(e=> e.CustomerTypeCode).HasMaxLength(10).HasColumnName("CustomerTypeCode").IsFixedLength();
                    });
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");

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

                // The below is demonstrating the direct loading of one to  many relations while skipping the link table (EmployeeTerritory)
                entity.HasMany(d => d.Territories)
                    .WithMany(p => p.Employees)
                    .UsingEntity<EmployeeTerritory>(
                        l => l.HasOne<Territory>().WithMany().HasPrincipalKey(e=> e.Code).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeeTerritories_Territories"),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey(e=> e.EmployeeID).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeeTerritories_Employees"),
                        e =>
                        {
                            e.ToTable("EmployeeTerritories");
                            e.HasKey("EmployeeID", "TerritoryCode").IsClustered(false);

                            e.Property(e => e.TerritoryCode).HasMaxLength(20);

                            e.HasIndex(e => e.EmployeeID);
                            e.HasIndex(e => e.TerritoryCode);
                        });
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToView("Invoices");

                entity.HasNoKey();

                entity.Property(e => e.Address).HasMaxLength(60);
                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.Country).HasMaxLength(15);
                entity.Property(e => e.CustomerId).HasMaxLength(5).HasColumnName("CustomerID").IsFixedLength();

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
                entity.ToTable("Orders");

                entity.Property(e => e.Id).HasColumnName("OrderID");
                entity.Property(e => e.CustomerCode).HasMaxLength(5).HasColumnName("CustomerCode").IsFixedLength();
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.Freight).HasColumnType("money").HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");
                entity.Property(e => e.RequiredDate).HasColumnType("datetime");
                entity.Property(e => e.ShipAddress).HasMaxLength(60);
                entity.Property(e => e.ShipCity).HasMaxLength(15);
                entity.Property(e => e.ShipCountry).HasMaxLength(15);
                entity.Property(e => e.ShipName).HasMaxLength(40);
                entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
                entity.Property(e => e.ShipRegion).HasMaxLength(15);
                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasIndex(e => e.CustomerCode, "CustomerCode");
                entity.HasIndex(e => e.CustomerCode, "CustomersOrders");
                entity.HasIndex(e => e.EmployeeId, "EmployeeID");
                entity.HasIndex(e => e.EmployeeId, "EmployeesOrders");
                entity.HasIndex(e => e.OrderDate, "OrderDate");
                entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");
                entity.HasIndex(e => e.ShippedDate, "ShippedDate");
                entity.HasIndex(e => e.ShipVia, "ShippersOrders");

                // Example of a navigation property  which uses a principal key instead of the primary key.
                // Note that the principle key must still remain unique, i.e. one to many relations on principal keys are not supported.
                // These navigations must then be included into the query.
                entity.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasPrincipalKey(c => c.Code)
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
                entity.ToTable("Order Details");

                entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK_Order_Details");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.NumberOfUnits).HasColumnName("Quantity").HasDefaultValueSql("((1))");
                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasIndex(e => e.OrderId, "OrderID");
                entity.HasIndex(e => e.OrderId, "OrdersOrder_Details");
                entity.HasIndex(e => e.ProductId, "ProductID");
                entity.HasIndex(e => e.ProductId, "ProductsOrder_Details");

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
                entity.ToTable("Products");

                entity.Property(e => e.Id).HasColumnName("ProductID");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.ProductName).HasMaxLength(40);
                entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
                entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");
                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
                entity.Property(e => e.IsDiscontinued).HasColumnName("Discontinued");

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
         
            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("Shippers");

                entity.Property(e => e.Id).HasColumnName("ShipperID");
                entity.Property(e => e.CompanyName).HasMaxLength(40);
                entity.Property(e => e.Phone).HasMaxLength(24);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Suppliers");

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
        }
    }
}
