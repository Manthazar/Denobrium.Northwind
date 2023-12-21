using Northwind.TestSystem.ReferenceData;

namespace Northwind.Sql.Repositories.Tests
{
    [TestClass]
    public class ReferenceDataTests : TestBase
    {
        [TestMethod]
        public void ReferenceData_BuildAll()
        {
            new ReferenceDataBuilder().BuildAll();
        }
    }
}
