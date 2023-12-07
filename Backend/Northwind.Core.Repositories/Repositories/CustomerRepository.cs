using Northwind.Core.Models;
using Northwind.Sql.Repositories;

namespace Northwind.Sql.Repositories
{
    public static class CustomerRepository
    {
        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<Customer>> GetAllAsync(this ISqlRepository<Customer> repository, CancellationToken cancellationToken)
        {
            var set = repository.Queryable;
            var result = await set.ToListAsync(cancellationToken);

            return result;
        }
    }
}
