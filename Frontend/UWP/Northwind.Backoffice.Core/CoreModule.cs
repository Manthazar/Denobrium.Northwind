using Autofac;
using System;

namespace Northwind.Backoffice
{
    public static class CoreModule
    {
        private static IContainer container;

        public static IContainer Container
        {
            get => container;
            set => RegisterContainer(value);
        }

        private static void RegisterContainer(IContainer container)
        {
            Guard.IsNotNull(container, nameof(container));

            if (Container != null) { throw new InvalidOperationException("A second container must not be registered. Are you messing with the bootstrapper?"); }

            CoreModule.container = container;
        }
    }
}
