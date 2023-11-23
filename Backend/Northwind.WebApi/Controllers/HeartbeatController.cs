using Microsoft.AspNetCore.Mvc;
using Northwind.Core.Models;
using Northwind.Core.Repositories.Repositories;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartbeatController : NorthwindController
    {
        private readonly IServiceProvider serviceProvider;

        public HeartbeatController (IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof (serviceProvider));
        }

        [HttpGet("ping")]
        public string Ping()
        {
            return "Pong";
        }

        [HttpGet("siblings/ping")]
        public async Task<string> SegmentPing(CancellationToken cancellationToken)
        {
            var repository = serviceProvider.GetService<ISqlRepository<Category>>();
            var items = await repository!.GetAllAsync(cancellationToken);

            return items.Any() ? "Pong" : "Zonk";
        }
    }
}
