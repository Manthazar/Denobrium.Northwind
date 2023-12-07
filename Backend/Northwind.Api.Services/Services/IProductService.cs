using Northwind.Api.Data;
using Northwind.Core.Models;

namespace Northwind.Api.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Returns products matching the default criteria.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductInfo>> GetManyAsync(CancellationToken cancellationToken = default); 
    }
}
