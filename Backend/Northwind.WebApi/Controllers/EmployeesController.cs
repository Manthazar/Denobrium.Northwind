using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Data;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Core.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : NorthwindController
    {
        public EmployeesController(IServiceProvider serviceProvider) : base (serviceProvider)
        {
        }

        [HttpGet()]
        public async Task<IEnumerable<EmployeeInfo>> GetAll(CancellationToken cancellationToken)
        {
            var repository = Services.GetRequiredService<IRepository<Employee>>();
            var items = await repository.GetManyAsync(includeOptions: EmployeeRepositoryIncludeOptions.WithManager, cancellationToken);

            var result = items.ToSetOf<EmployeeInfo>();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetById(int id, CancellationToken cancellationToken)
        {
            Guard.IsId(id, nameof(id));
            
            var repository = Services.GetRequiredService<IRepository<Employee>>();
            var customer = await repository.GetByIdAsync(id, cancellationToken);

            return customer;
        }
    }
}
