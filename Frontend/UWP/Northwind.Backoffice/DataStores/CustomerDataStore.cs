using Northwind.BackOffice.Data;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Northwind.Backoffice.DataStores
{
    internal class CustomerDataStore
    {
        public async Task<IEnumerable<CustomerInfo>> GetAllAsync ()
        {
            var httpClient = App.GetApiClient();
            var response = await httpClient.GetFromJsonAsync<List<CustomerInfo>>("/Customers");

            return response;
        }
    }
}
