using Northwind.Core;
using Northwind.Core.Models;

namespace Northwind.TestSystem.Builders
{
    public sealed class CategoryBuilder : EntityBuilder<Category>
    {
        public CategoryBuilder WithName(string name)
        {
            Check.IsNotNullOrWhiteSpace(name, nameof(name));

            Data.CategoryName = name;

            return this;
        }

        public CategoryBuilder WithDescription (string description)
        {
            Check.IsNotNullOrWhiteSpace(description, nameof(description));

            Data.Description = description;

            return this;
        }
    }
}
