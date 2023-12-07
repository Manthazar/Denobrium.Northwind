using Northwind.Core;
using Northwind.Core.Models;

namespace Northwind.Sql.Repositories
{
    public static class ProductRepository
    {
        /// <summary>
        /// Returns all products.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Product>> GetAllAsync(this ISqlRepository<Product> repository, CancellationToken cancellationToken)
        {
            Guard.IsNotNull(repository, nameof(repository));

            var query = repository.Queryable
                                    .Include(p => p.Category)
                                    .Include(s => s.Supplier);

            var items = await query.ToListAsync(cancellationToken);

            return items;
        }
    }
}

