using Northwind.Api.Data;
using Northwind.Core;
using Northwind.Core.Configuration;
using Northwind.Core.Models;
using Northwind.Core.Repositories;

namespace Northwind.Api.Services
{
    public sealed class OrderService
    {
        private readonly IRepository<Order> repository;
        private readonly NorthwindApiConfiguration configuration;

        public OrderService(IRepository<Order> repository, NorthwindApiConfiguration configuration)
        {
            Guard.IsNotNull(repository, nameof(repository));

            this.repository = repository;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<OrderInfo>> GetManyAsync(CancellationToken cancellationToken = default)
        {
            var orders = await repository.GetManyAsync(OrderRepositoryIncludeOptions.WithCustomer, cancellationToken);
            var orderMap = orders.ToDictionary(k => k.Id);
            var orderInfos = orders.ToSetOf<OrderInfo>();

            foreach (var orderInfo in orderInfos)
            {
                var order = orderMap[orderInfo.InternalId];
                orderInfo.IsInternationalShipment = String.Equals(orderInfo.ShipCountry, configuration.WarehouseCountry, StringComparison.OrdinalIgnoreCase);
            }

            return orderInfos;
        }
    }
}
