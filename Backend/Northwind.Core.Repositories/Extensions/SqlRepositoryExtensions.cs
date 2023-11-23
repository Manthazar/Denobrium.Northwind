using Northwind.Core.Exceptions;
using Northwind.Core.Models;
using Northwind.Core.Repositories.Repositories;

namespace Northwind.Core.Repositories
{
    public static class SqlRepositoryExtensions
    {
        /// <summary>
        /// Returns the item by its code.
        /// </summary>
        /// <param name="code">The code to be used as the identifier. Note that no leading or trailing spaces should/ will result in errors (trivial common trouble)</param>
        /// <exception cref="DataNotFoundException"/>
        public static T GetByCode<T>(this ISqlRepository<T> repository, string code) where T : IWithCode
        {
            Guard.IsNotNull(repository, nameof(repository));
            Guard.IsCode(code, nameof(code));

            var item = repository.Items.Where(i => i.Code == code.Trim()).SingleOrDefault();

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
        public static async Task<T> GetByCodeAsync<T>(this ISqlRepository<T> repository, string code, CancellationToken cancellationToken) where T : IWithCode
        {
            Guard.IsNotNull(repository, nameof(repository));
            Guard.IsCode(code, nameof(code));

            var item = await repository.Items.Where(i => i.Code == code.Trim()).SingleOrDefaultAsync(cancellationToken);

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
        public static T GetById<T> (this ISqlRepository<T> repository, int id) where T : IWithId
        {
            Guard.IsNotNull(repository, nameof(repository));
            Guard.IsId(id, nameof(id));

            var item = repository.Items.Where(i => i.Id == id).SingleOrDefault();

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

            var item = repository.Items.Where(i => i.Id == id).SingleOrDefaultAsync(cancellationToken);

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
