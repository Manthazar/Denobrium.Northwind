using Northwind.Core;

namespace Northwind.Sql.Repositories
{
    internal class SqlRepository<T> : ISqlRepository<T> where T : class
    {
        private readonly NorthwindDbContext dbContext;

        public SqlRepository (NorthwindDbContext dbContext)
        {
            Guard.IsNotNull(dbContext, nameof (dbContext));

            this.dbContext = dbContext;
        }

        public DbContext Context => dbContext;

        public IQueryable<T> Queryable => dbContext.Set<T>();
    }
}
