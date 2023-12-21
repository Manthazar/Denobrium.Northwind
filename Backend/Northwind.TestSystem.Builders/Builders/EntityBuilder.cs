using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Sql.Repositories;
using Northwind.TestSystem.Engine;

namespace Northwind.TestSystem.Builders
{
    public abstract class EntityBuilder<T>
        where T : class, new()
    {
        private NorthwindDbContext? context;

        private NorthwindDbContext Context => context ??= TestEngine.Current.Services.GetRequiredService<NorthwindDbContext>();
            
        public EntityBuilder()
        {
            Data = new T();
        }

        /// <summary>
        /// Builds an object and attaches it into the context.
        /// </summary>
        /// <returns></returns>
        public T Build()
        {
            BuildInto(Context);

            return Data;
        }

        /// <summary>
        /// Builds an object which won't be a member of a context.
        /// </summary>
        /// <returns></returns>
        public T BuildUnattached()
        {
            BuildInto(null);

            return Data;
        }

        protected virtual void BuildInto(DbContext? dbContext = null)
        {
            dbContext?.Add(Data);
            dbContext?.SaveChanges();
        }

        protected T Data { get; }
    }
}
