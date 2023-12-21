using Northwind.Core.Contracts;
using Northwind.Core.Exceptions;

namespace Northwind.Core.Repositories
{
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Returns all items of the collection. Be careful -esspecially with entity set which can become big over time. 
        /// </summary>
        /// <remarks>
        /// In this sandbox, I make my live a easier, by allowing load-all functions for many entities. In case of time and motivation, these will be replaced with more dedicated services/ repository functions.
        /// Usually, such kind of method only targets reference data where the number of records is quite limited/ low. 
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> GetAllAsync<T>(this IRepository<T> repository, CancellationToken cancellationToken)
            where T : class, ICacheable
        {
            var set = repository.Queryable;
            var result = await set.ToListAsync(cancellationToken);

            return result;
        }

        /// <summary>
        /// Returns the item by its code.
        /// </summary>
        /// <param name="code">The code to be used as the identifier. Note that no leading or trailing spaces should/ will result in errors (trivial common trouble)</param>
        /// <exception cref="DataNotFoundException"/>
        public static T GetByCode<T>(this IRepository<T> repository, string code) where T : class, IWithCode
        {
            Check.IsNotNull(repository, nameof(repository));
            Check.IsCode(code, nameof(code));

            var item = repository.Queryable.Where(i => i.Code == code.Trim()).SingleOrDefault();

            if (item == null)
            {
                throw DataNotFoundException.NewForCode<T>(code);
            }
            else
            {
                return item!;
            }
        }

        /// <summary>
        /// Returns the item by its code.
        /// </summary>
        /// <param name="code">The code to be used as the identifier. Note that no leading or trailing spaces should/ will result in errors (trivial common trouble)</param>
        /// <exception cref="DataNotFoundException"/>
        public static async Task<T> GetByCodeAsync<T>(this IRepository<T> repository, string code, CancellationToken cancellationToken) where T : class, IWithCode
        {
            Check.IsNotNull(repository, nameof(repository));
            Check.IsCode(code, nameof(code));

            var item = await repository.Queryable.Where(i => i.Code == code.Trim()).SingleOrDefaultAsync(cancellationToken);

            if (item == null)
            {
                throw DataNotFoundException.NewForCode<T>(code);
            }
            else
            {
                return item!;
            }
        }

        /// <summary>
        /// Returns the item by its id.
        /// </summary>
        /// <exception cref="DataNotFoundException"/>
        public static T GetById<T> (this IRepository<T> repository, int id) where T : class, IWithId
        {
            Check.IsNotNull(repository, nameof(repository));
            Check.IsId(id, nameof(id));

            var item = repository.Queryable.Where(i => i.Id == id).SingleOrDefault();

            if (item == null)
            {
                throw DataNotFoundException.NewForId<T>(id);
            }
            else
            {
                return item!;
            }
        }

        /// <summary>
        /// Returns the item by its id.
        /// </summary>
        /// <exception cref="DataNotFoundException"/>
        public static Task<T> GetByIdAsync<T>(this IRepository<T> repository, int id, CancellationToken cancellationToken) where T : class, IWithId
        {
            Check.IsNotNull(repository, nameof(repository));
            Check.IsId(id, nameof(id));

            var item = repository.Queryable.Where(i => i.Id == id).SingleOrDefaultAsync(cancellationToken);

            if (item == null)
            {
                throw DataNotFoundException.NewForId<T>(id);
            }
            else
            {
                return item!;
            }
        }
    }
}
