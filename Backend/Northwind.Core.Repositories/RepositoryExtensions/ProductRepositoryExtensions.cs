using Northwind.Core.Models;

namespace Northwind.Core.Repositories
{
    public static class ProductRepositoryExtensions
    {
        /// <summary>
        /// Returns all products.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Product>> GetAllAsync(this IRepository<Product> repository, CancellationToken cancellationToken)
        {
            Check.IsNotNull(repository, nameof(repository));

            var query = repository.Queryable
                                    .Include(p => p.Category)
                                    .Include(s => s.Supplier);

            var items = await query.ToListAsync(cancellationToken);

            return items;
        }
    }
}

