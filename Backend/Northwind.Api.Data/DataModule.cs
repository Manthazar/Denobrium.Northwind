using Microsoft.Extensions.DependencyInjection;
using Northwind.Core;

namespace Northwind.Api.Data
{
    public static class DataModule
    {
        /// <summary>
        /// Registers the map profiles and other services of the api-data module.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataModuleComponents(this IServiceCollection collection)
        {
            Check.IsNotNull(collection, nameof(collection));

            collection.AddAutoMapper(typeof(DataModule).Assembly);

            return collection;
        }
    }
}
