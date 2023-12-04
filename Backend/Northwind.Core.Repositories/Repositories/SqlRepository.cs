using Northwind.Sql.Repositories;

namespace Northwind.Core.Repositories.Repositories
{
    internal class SqlRepository<T> : ISqlRepository<T> where T : class
    {
        private readonly NorthwindDbContext dbContext;

        public SqlRepository (NorthwindDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        IQueryable<T> ISqlRepository<T>.Items => dbContext.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var set = dbContext.Set<T>();
            var result = await set.ToListAsync(cancellationToken);

            return result;
        }
    }
}
