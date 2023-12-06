using Northwind.Backofficce.ApiClient.DataStores;
using Northwind.BackOffice.Data;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.DataStores
{
    public sealed class CustomerDataStore : RestDataStore
    {
        public async Task<IEnumerable<CustomerInfo>> GetAllAsync (CancellationToken cancellation)
        {
            var response = await GetAsync<List<CustomerInfo>>("Customers", cancellation);

            return response;
        }
    }
}
