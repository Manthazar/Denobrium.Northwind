using Microsoft.AspNetCore.Mvc;
using Northwind.Core;
using Northwind.Core.Contracts;
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
        public async Task<IEnumerable<Employee>> GetAll(CancellationToken cancellationToken)
        {
            var repository = Services.GetService<IRepository<Employee>>();
            var items = await repository!.GetAllAsync(cancellationToken);

            return items;
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetById(int id, CancellationToken cancellationToken)
        {
            Guard.IsId(id, nameof(id));
            
            var repository = Services.GetService<IRepository<Employee>>();
            var customer = await repository!.GetByIdAsync(id, cancellationToken);

            return customer;
        }
    }
}
