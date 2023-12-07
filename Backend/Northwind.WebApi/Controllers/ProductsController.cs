using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Data;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Core.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : NorthwindController
    {
        public ProductsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet()]
        public async Task<IEnumerable<ProductInfo>> GetManyAsync(CancellationToken cancellationToken)
        {
            var repository = Services.GetRequiredService<IRepository<Product>>();
            var products = await repository.GetAllAsync(cancellationToken);
            var result = products.ToSetOf<ProductInfo>();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ProductInfo> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            Guard.IsBigger(0, id, nameof(id));

            var repository = Services.GetRequiredService<IRepository<Product>>();
            var customer = await repository.GetByIdAsync(id, cancellationToken);
            var result = customer.To<ProductInfo>();

            return result;
        }
    }
}
