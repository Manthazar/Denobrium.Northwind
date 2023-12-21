using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Data;
using Northwind.Api.Services;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Core.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : NorthwindController
    {

        public OrdersController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet()]
        public async Task<IEnumerable<OrderInfo>> GetManyAsync(CancellationToken cancellationToken)
        {
            var repository = Services.GetRequiredService<OrderService>();
            var result = await repository.GetManyAsync(cancellationToken);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<OrderInfo> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            Check.IsBigger(0, id, nameof(id));

            var repository = Services.GetRequiredService<IRepository<Order>>();
            var customer = await repository.GetByIdAsync(id, cancellationToken);
            var result = customer.To<OrderInfo>();

            return result;
        }
    }
}
