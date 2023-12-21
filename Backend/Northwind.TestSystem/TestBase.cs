
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

        [TestCleanup]
        public void OnCleanUp()
        {
            TestEngine.CleanUp();
        }

#pragma warning disable CA1822 // Mark members as static
        protected IServiceProvider Services => TestEngine.Current.Services;
#pragma warning restore CA1822 // Mark members as static
    }
}