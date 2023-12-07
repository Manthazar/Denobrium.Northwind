using Northwind.Core.Repositories;

namespace Northwind.Sql.Repositories
{
    /// <summary>
    /// Represents an sql based repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISqlRepository<T> : IRepository<T> where T : class
    {
        DbContext Context { get; }
    }
}
