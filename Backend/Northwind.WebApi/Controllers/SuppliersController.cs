using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Data;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Core.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : NorthwindController
    {

        public SuppliersController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet()]
        public async Task<IEnumerable<SupplierInfo>> GetManyAsync(CancellationToken cancellationToken)
        {
            var repository = Services.GetRequiredService<IRepository<Supplier>>();
            var products = await repository.GetManyAsync(cancellationToken);
            var result = products.ToSetOf<SupplierInfo>();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<SupplierInfo> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            Guard.IsBigger(0, id, nameof(id));

            var repository = Services.GetRequiredService<IRepository<Supplier>>();
            var customer = await repository.GetByIdAsync(id, cancellationToken);
            var result = customer.To<SupplierInfo>();

            return result;
        }
    }
}
