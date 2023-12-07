namespace Northwind.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Returns a query able collection of the items.
        /// </summary>
        internal IQueryable<T> Queryable { get; }
    }
}
