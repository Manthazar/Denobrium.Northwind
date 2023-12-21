using Northwind.Core.Models;

namespace Northwind.Core.Repositories
{
    /// <summary>
    /// The include options for orders.
    /// </summary>
    /// <remarks>
    /// Experience shows that shared repository methods _inherit_ more and more 'Include' directives the more widely they are used (for different use cases). 
    /// This can not only become a performance problem, but also a review problem: which actual includes are REALLY required?
    /// <para/>
    /// My solution to this problem is to let the caller decide, which *supported* includes should be provided. 
    /// That way, we keep the standard method wide enough for many use cases, but the performance remains optimal for each.
    /// Please also note that this mechanism does not exclude (highly) specialized repostiory methods.
    /// </remarks>
    public enum OrderRepositoryIncludeOptions
    {
        None = 0,
        WithCustomer = 1
    }

    public static class OrderRepositoryExtensions
    {
        /// <summary>
        /// Returns all orders.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Order>> GetManyAsync(this IRepository<Order> repository, OrderRepositoryIncludeOptions includeOptions = OrderRepositoryIncludeOptions.None, CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(repository, nameof(repository));

            var query = repository.Queryable;

            if (includeOptions.HasFlag(OrderRepositoryIncludeOptions.WithCustomer))
            {
                query = query.Include(o => o.Customer);
            }

            var items = await query.ToListAsync(cancellationToken);

            return items;
        }
    }
}

