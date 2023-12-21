using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Data;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Core.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : NorthwindController
    {
        public CustomersController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet()]
        public async Task<IEnumerable<CustomerInfo>> GetAll(CancellationToken cancellationToken)
        {
            var repository = Services.GetRequiredService<IRepository<Customer>>();
            var items = await repository.GetAllAsync(cancellationToken);
            var result = items.ToSetOf<CustomerInfo>();

            return result;
        }

        [HttpGet("{code}")]
        public async Task<CustomerDetail> GetByCode(string code, CancellationToken cancellationToken)
        {
            Check.IsCode(code, nameof(code));

            var repository = Services.GetRequiredService<IRepository<Customer>>();
            var customer = await repository.GetByCodeAsync(code, cancellationToken);
            var result = customer.To<CustomerDetail>();

            return result;
        }
    }
}
