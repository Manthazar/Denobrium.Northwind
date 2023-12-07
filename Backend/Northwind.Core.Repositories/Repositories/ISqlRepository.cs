namespace Northwind.Sql.Repositories
{
    public interface ISqlRepository<T>
    {
        /// <summary>
        /// Returns a query able collection of the items.
        /// </summary>
        internal IQueryable<T> Queryable { get; }
    }
}
