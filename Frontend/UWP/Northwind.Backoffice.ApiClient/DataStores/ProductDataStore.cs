using Northwind.Backoffice.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.DataStores
{
    public sealed class ProductDataStore : RestDataStore
    {
        public async Task<IEnumerable<ProductInfo>> GetAllAsync (CancellationToken cancellation)
        {
            var response = await GetAsync<List<ProductInfo>>("Products", cancellation);

            return response;
        }
    }
}
