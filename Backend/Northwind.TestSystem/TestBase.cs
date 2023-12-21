
using Northwind.TestSystem.Engine;

namespace Northwind.TestSystem
{
    public abstract class TestBase
    {
        [TestInitialize]
        public void OnInitialize ()
        {
            TestEngine.Reset();
        }
    }
}