using Microsoft.AspNetCore.Mvc;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Sql.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : NorthwindController
    {
        private readonly IServiceProvider serviceProvider;

        public EmployeesController(IServiceProvider serviceProvider) : base (serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        [HttpGet()]
        public async Task<IEnumerable<Employee>> GetAll(CancellationToken cancellationToken)
        {
            var repository = serviceProvider.GetService<ISqlRepository<Employee>>();
            var items = await repository!.GetAllAsync(cancellationToken);

            return items;
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetById(int id, CancellationToken cancellationToken)
        {
            Guard.IsId(id, nameof(id));
            
            var repository = serviceProvider.GetService<ISqlRepository<Employee>>();
            var customer = await repository!.GetByIdAsync(id, cancellationToken);

            return customer;
        }
    }
}
