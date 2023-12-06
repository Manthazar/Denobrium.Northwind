using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Data.Data;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Core.Repositories;
using Northwind.Core.Repositories.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : NorthwindController
    {
        private readonly IServiceProvider serviceProvider;

        public CustomersController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        [HttpGet()]
        public async Task<IEnumerable<CustomerInfo>> GetAll(CancellationToken cancellationToken)
        {
            var repository = serviceProvider.GetService<ISqlRepository<Customer>>();
            var items = await repository!.GetAllAsync(cancellationToken);
            var result = items.ToSetOf<CustomerInfo>();

            return result;
        }

        [HttpGet("{code}")]
        public async Task<CustomerDetail> GetByCode(string code, CancellationToken cancellationToken)
        {
            Guard.IsCode(code, nameof(code));

            var repository = serviceProvider.GetService<ISqlRepository<Customer>>();
            var customer = await repository!.GetByCodeAsync(code, cancellationToken);
            var result = customer.To<CustomerDetail>();

            return result;
        }
    }
}
