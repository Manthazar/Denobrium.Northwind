namespace Northwind.Core.Repositories.Repositories
{
    public interface ISqlRepository<T>
    {
        /// <summary>
        /// Returns a query able collection of the items.
        /// </summary>
        internal IQueryable<T> Items { get; }

        /// <summary>
        /// Returns all items of the underlying collection.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
