namespace Northwind.Core.Repositories.Repositories
{
    internal class SqlRepository<T> : ISqlRepository<T> where T : class
    {
        private readonly NorthwindContext dbContext;

        public SqlRepository (NorthwindContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var set = dbContext.Set<T>();
            var result = await set.ToListAsync(cancellationToken);

            return result;
        }
    }
}
