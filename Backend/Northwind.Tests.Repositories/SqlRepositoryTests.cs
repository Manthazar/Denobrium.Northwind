using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Models;
using Northwind.Sql.Repositories;

namespace Northwind.Tests.Repositories
{
    [TestClass]
    public class SqlRepositoryTests : TestBase
    {
        [TestMethod]
        public void SqlRepository_GetAll ()
        {
            var dbContext = Services.GetRequiredService<NorthwindDbContext>();
            var repository = new SqlRepository<Category>(dbContext);
        }
    }
}
