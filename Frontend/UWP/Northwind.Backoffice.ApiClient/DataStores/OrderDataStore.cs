using Northwind.Backoffice.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.DataStores
{
    public class OrderDataStore : RestDataStore
    {
        public async Task<IEnumerable<OrderInfo>> GetAllAsync(CancellationToken cancellation)
        {
            var response = await GetAsync<List<OrderInfo>>("Orders", cancellation);

            return response;
        }
    }
}
