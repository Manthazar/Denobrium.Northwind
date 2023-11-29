using Microsoft.Extensions.DependencyInjection;
using Northwind.Core;

namespace Northwind.Api.Data
{
    public static class DataModule
    {
        public static IServiceCollection AddDataModuleComponents(this IServiceCollection collection)
        {
            Guard.IsNotNull(collection, nameof(collection));

            collection.AddAutoMapper(typeof(DataModule).Assembly);

            return collection;
        }
    }
}
