using Autofac;
using Northwind.Backoffice.Services;

namespace Northwind.Backoffice
{
    public static class ConfigurationModule
    {
        public static ContainerBuilder AddConfigurationServices(this ContainerBuilder builder)
        {
            Guard.IsNotNull(builder, nameof(builder));  

            builder.RegisterType<ConfigurationProvider>().As<IConfigurationProvider>().SingleInstance();

            return builder;
        }
    }
}
