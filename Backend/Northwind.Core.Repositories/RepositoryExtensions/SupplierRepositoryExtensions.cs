using Northwind.Core.Models;

namespace Northwind.Core.Repositories
{
    public static class SupplierRepositoryExtensions
    {
        /// <summary>
        /// Returns all products.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Supplier>> GetManyAsync(this IRepository<Supplier> repository, CancellationToken cancellationToken)
        {
            Check.IsNotNull(repository, nameof(repository));

            var query = repository.Queryable;
            var items = await query.ToListAsync(cancellationToken);

            return items;
        }
    }
}

