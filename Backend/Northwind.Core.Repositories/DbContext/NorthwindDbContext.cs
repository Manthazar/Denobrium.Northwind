using Northwind.Core.Models;
using Northwind.Sql.ModelBuilders;

namespace Northwind.Sql.Repositories
{
    public partial class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
        }

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
            : base(options)
        {
        }

        #region Db Set Accessors

        /*
         * Below, default db set accessors can be found. Using the Repository pattern though (which is NOT
         * necessarily the natural/ correct thing to do with EF, these sets won't be required).
         * 
         */

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Shipper> Shippers { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Territory> Territories { get; set; } = null!;

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        /// <remarks>
        /// The builder configuration is extracted into 
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ReferenceDataModelBuilder.BuildInto(modelBuilder);
            CoreModelBuilder.BuildInto(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
