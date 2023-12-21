using Northwind.Core;
using Northwind.Core.Models;

namespace Northwind.TestSystem.Builders
{
    internal class RegionBuilder : EntityBuilder<Region>
    {
        public RegionBuilder WithDescription(string description)
        {
            Check.IsNotNullOrWhiteSpace(description, nameof(description));

            Data.Description = description;

            return this;
        }
    }
}
