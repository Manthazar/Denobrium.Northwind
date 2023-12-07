using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Data;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Sql.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : NorthwindController
    {
        private readonly IServiceProvider serviceProvider;

        public ProductsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        [HttpGet()]
        public async Task<IEnumerable<ProductInfo>> GetManyAsync(CancellationToken cancellationToken)
        {
            var repository = serviceProvider.GetRequiredService<ISqlRepository<Product>>();
            var products = await repository.GetAllAsync(cancellationToken);
            var result = products.ToSetOf<ProductInfo>();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ProductInfo> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            Guard.IsBigger(0, id, nameof(id));

            var repository = serviceProvider.GetRequiredService<ISqlRepository<Product>>();
            var customer = await repository.GetByIdAsync(id, cancellationToken);
            var result = customer.To<ProductInfo>();

            return result;
        }
    }
}
