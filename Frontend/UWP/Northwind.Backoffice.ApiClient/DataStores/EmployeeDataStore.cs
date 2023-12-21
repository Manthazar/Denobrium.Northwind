using Northwind.Backoffice.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backoffice.DataStores
{
    public sealed class EmployeeDataStore : RestDataStore
    {
        public async Task<IEnumerable<EmployeeInfo>> GetAllAsync (CancellationToken cancellation)
        {
            var response = await GetAsync<List<EmployeeInfo>>("Employees", cancellation);

            return response;
        }
    }
}
