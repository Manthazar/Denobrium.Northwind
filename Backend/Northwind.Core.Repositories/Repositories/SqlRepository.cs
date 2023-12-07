using Northwind.Sql.Repositories;

namespace Northwind.Sql.Repositories
{
    internal class SqlRepository<T> : ISqlRepository<T> where T : class
    {
        private readonly NorthwindDbContext dbContext;

        public SqlRepository (NorthwindDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        IQueryable<T> ISqlRepository<T>.Queryable => dbContext.Set<T>();
    }
}
