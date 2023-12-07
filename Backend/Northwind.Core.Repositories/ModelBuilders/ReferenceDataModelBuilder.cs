using Northwind.Core.Models;

namespace Northwind.Sql.ModelBuilders
{
    /// <summary>
    /// This builder builds the EF model for reference data items
    /// </summary>
    /// <remarks>
    /// Reference data items are rarely/ barely changing items, such as the type of the customer or list of categories. 
    /// <para/>
    /// One reason to keep them in a dedicated model builder is to enable including them into any (tailor) made data context. Into such db contexts, reference data items can be attached prior loading data -rather than included on loading which 
    /// can help performance significally. Note that the loading could be a result of a batch operation or originating from a different source than sql.
    /// <para/>It often makes sense to optimize this workflow since reference data items are almost guaranteed to participate in business rules.
    /// </remarks>
    internal static class ReferenceDataModelBuilder
    {
        /// <summary>
        /// Inactive code brick for reference purposes only. 
        /// </summary>
        /// <param name="builder"></param>
        internal static void BuildInto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");

                entity.Property(e => e.Id).HasColumnName("CategoryID");
                entity.Property(e => e.CategoryName).HasMaxLength(15);
                entity.Property(e => e.Description).HasColumnType("ntext");
                entity.Property(e => e.Picture).HasColumnType("image");

                entity.HasIndex(e => e.CategoryName, "CategoryName");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.ToTable("CustomerTypes");
                entity.HasKey(e => e.Code).IsClustered(false);

                entity.Property(e => e.Code).HasMaxLength(10).HasColumnName("CustomerTypeCode").IsFixedLength();
                entity.Property(e => e.Description).HasColumnType("ntext");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.HasKey(e => e.Id).IsClustered(false);
                
                entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("RegionID");
                entity.Property(e => e.Description).HasMaxLength(50).IsFixedLength();
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.ToTable("Territories");

                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Code);

                entity.Property(e => e.Id).HasColumnName("TerritoryID");
                entity.Property(e => e.Code).HasMaxLength(20).HasColumnName("TerritoryCode");
                entity.Property(e => e.RegionId).HasColumnName("RegionID");
                entity.Property(e => e.TerritoryDescription).HasMaxLength(50).IsFixedLength();

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Territories_Region");
            });
        }
    }
}
