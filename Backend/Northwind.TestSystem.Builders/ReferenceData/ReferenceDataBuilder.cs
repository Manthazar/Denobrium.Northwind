using Northwind.TestSystem.Builders;

namespace Northwind.TestSystem.ReferenceData
{
    public class ReferenceDataBuilder
    {
        public  ReferenceDataBuilder()
        {
        }
        public void BuildAll()
        {
            new RegionBuilder().WithDescription("Europe").Build();
            new RegionBuilder().WithDescription("Germany").Build();
            new RegionBuilder().WithDescription("France").Build();
            new RegionBuilder().WithDescription("Poland").Build();
        }
    }
}
