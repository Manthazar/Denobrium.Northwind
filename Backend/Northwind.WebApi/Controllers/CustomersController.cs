using Microsoft.AspNetCore.Mvc;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Core.Repositories;
using Northwind.Core.Repositories.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IServiceProvider serviceProvider;

        public CustomersController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        [HttpGet()]
        public async Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken)
        {
            var repository = serviceProvider.GetService<ISqlRepository<Customer>>();
            var items = await repository!.GetAllAsync(cancellationToken);

            return items;
        }

        [HttpGet("{code}")]
        public async Task<Customer> GetByCode(string code, CancellationToken cancellationToken)
        {
            Guard.IsCode(code, nameof(code));

            var repository = serviceProvider.GetService<ISqlRepository<Customer>>();
            var customer = await repository!.GetByCodeAsync(code, cancellationToken);

            return customer;
        }
    }
}
