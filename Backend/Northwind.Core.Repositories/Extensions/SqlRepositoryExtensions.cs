using Northwind.Core.Exceptions;
using Northwind.Core.Models;
using Northwind.Core.Repositories.Repositories;

namespace Northwind.Core.Repositories
{
    public static class SqlRepositoryExtensions
    {
        /// <summary>
        /// Returns the item by its id.
        /// </summary>
        /// <exception cref="DataNotFoundException"/>
        public static T GetById<T> (this ISqlRepository<T> repository, int id) where T : IWithId
        {
            Guard.IsNotNull(repository, nameof(repository));
            Guard.IsId(id, nameof(id));

            var item = repository.Query.Where(i => i.Id == id).SingleOrDefault();

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
        public static Task<T> GetByIdAsync<T>(this ISqlRepository<T> repository, int id, CancellationToken cancellationToken) where T : IWithId
        {
            Guard.IsNotNull(repository, nameof(repository));
            Guard.IsId(id, nameof(id));

            var item = repository.Query.Where(i => i.Id == id).SingleOrDefaultAsync(cancellationToken);

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
