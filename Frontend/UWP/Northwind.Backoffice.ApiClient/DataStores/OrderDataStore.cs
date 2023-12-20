using Northwind.Backofficce.ApiClient.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backofficce.ApiClient.DataStores
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
