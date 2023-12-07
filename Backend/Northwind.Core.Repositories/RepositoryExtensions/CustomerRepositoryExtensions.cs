using Northwind.Core.Models;

namespace Northwind.Core.Repositories
{
    public static class CustomerRepositoryExtensions
    {
        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<Customer>> GetAllAsync(this IRepository<Customer> repository, CancellationToken cancellationToken)
        {
            Guard.IsNotNull(repository, nameof(repository));

            var set = repository.Queryable;
            var result = await set.ToListAsync(cancellationToken);

            return result;
        }
    }
}
