using Northwind.Api.Data;
using Northwind.Core;
using Northwind.Core.Models;
using Northwind.Sql.Repositories;

namespace Northwind.Api.Services.Internal
{
    internal class ProductService : IProductService
    {
        private readonly ISqlRepository<Product> repository;

        public ProductService(ISqlRepository<Product> repository)
        {
            Guard.IsNotNull(repository, nameof(repository));

            this.repository = repository;
        }

        public Task<IEnumerable<ProductInfo>> GetManyAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            /*
          * public string Name { get; set; } = null!;

            */
        }
    }
}
