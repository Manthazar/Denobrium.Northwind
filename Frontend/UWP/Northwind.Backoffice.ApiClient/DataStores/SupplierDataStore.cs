using Northwind.Backofficce.ApiClient.Data;
using Northwind.Backofficce.ApiClient.DataStores;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.DataStores
{
    public sealed class SupplierDataStore : RestDataStore
    {
        public async Task<IEnumerable<SupplierInfo>> GetAllAsync (CancellationToken cancellation)
        {
            var response = await GetAsync<List<SupplierInfo>>("Suppliers", cancellation);

            return response;
        }
    }
}
