using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Exceptions;
using Northwind.Core.Models;
using Northwind.Core.Repositories;
using Northwind.Sql.Repositories;
using Northwind.TestSystem.Builders;

namespace Northwind.Tests.Repositories
{
    [TestClass]
    public class SqlRepositoryTests : TestBase
    {
        [TestMethod]
        public async Task SqlRepository_GetAllAsync_WhenEmpty()
        {
            var dbContext = Services.GetRequiredService<NorthwindDbContext>();
            var repository = new SqlRepository<Category>(dbContext);
            
            var all = await repository.GetAllAsync();
            var given = all.ToList();

            given.Should().NotBeNull();
            given.Should().BeEmpty();
        }

        [TestMethod]
        public async Task SqlRepository_GetAllAsync_WhenMany()
        {
            var dbContext = Services.GetRequiredService<NorthwindDbContext>();
            var repository = new SqlRepository<Category>(dbContext);
            new CategoryBuilder().WithName("Foo").Build();
            new CategoryBuilder().WithName("Bar").Build();

            var all = await repository.GetAllAsync();
            var given = all.ToList();

            given.Should().NotBeNull();
            given.Should().NotBeEmpty();
            given.Should().HaveCount(2);
            given.Should().Contain(c=> c.CategoryName == "Foo");
            given.Should().Contain(c => c.CategoryName == "Bar");
        }

        [TestMethod]
        public async Task SqlRepository_GetByIdAsync_Ok()
        {
            var dbContext = Services.GetRequiredService<NorthwindDbContext>();
            var repository = new SqlRepository<Category>(dbContext);
            var expected = new CategoryBuilder().WithName("Foo").Build();
            
            var given = await repository.GetByIdAsync(expected.Id);

            given.Should().NotBeNull();
            given.Id.Should().Be(expected.Id);
            given.CategoryName.Should().Be(expected.CategoryName);
        }

        [TestMethod]
        [ExpectedException(typeof(DataNotFoundException))]
        public async Task SqlRepository_GetByIdAsync_WhenIdIsWrong()
        {
            var dbContext = Services.GetRequiredService<NorthwindDbContext>();
            var repository = new SqlRepository<Category>(dbContext);

            var given = await repository.GetByIdAsync(124);
        }

        [TestMethod]
        public void SqlRepository_GetById_Ok()
        {
            var dbContext = Services.GetRequiredService<NorthwindDbContext>();
            var repository = new SqlRepository<Category>(dbContext);
            var expected = new CategoryBuilder().WithName("Foo").Build();

            var given = repository.GetById(expected.Id);

            given.Should().NotBeNull();
            given.Id.Should().Be(expected.Id);
            given.CategoryName.Should().Be(expected.CategoryName);
        }

        [TestMethod]
        [ExpectedException(typeof(DataNotFoundException))]
        public void SqlRepository_GetById_WhenIdIsWrong()
        {
            var dbContext = Services.GetRequiredService<NorthwindDbContext>();
            var repository = new SqlRepository<Category>(dbContext);

            var given = repository.GetById(124);
        }
    }
}
