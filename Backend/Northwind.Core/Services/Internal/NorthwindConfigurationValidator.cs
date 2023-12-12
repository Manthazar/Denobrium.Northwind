using FluentValidation;
using Northwind.Core.Configuration;

namespace Northwind.Core.Services.Internal
{
    /// <summary>
    /// Validator which validates the configuration object in order to pinpoint potentially missing or wrong configuration values.
    /// </summary>
    /// <remarks>
    /// Usually performed at startup and/ or after deployed as part of the CI
    /// </remarks>
    public sealed class NorthwindConfigurationValidator : AbstractValidator<NorthwindBackendConfiguration>
    {
        public NorthwindConfigurationValidator()
        {
            RuleSet("dataStoreConfiguration", () =>
            {
                RuleFor(c => c.DataStores).NotNull().SetValidator(new DataStoreSettingsValidator());
            });

            RuleSet("serializationOptions", () =>
            {
                RuleFor(c => c.Serialization).NotNull().SetValidator(new SerializationSettingsValidator());
            });


            RuleSet("backendOptions", () =>
            {
                RuleFor(c => c.WarehouseCountry).NotEmpty(); // TODO: we could invest a bit more brain power here to ensure that the value is a valid 'country'
            });
        }

        private class SerializationSettingsValidator : AbstractValidator<NorthwindBackendConfiguration.SerializationOptions>
        {
            public SerializationSettingsValidator()
            {
            }
        }

        private class DataStoreSettingsValidator : AbstractValidator<NorthwindBackendConfiguration.DataStoreOptions>
        {
            public DataStoreSettingsValidator()
            {

                RuleFor(c => c.SqlConnectionString).NotEmpty(); // TODO: we could test whether the connection string is actually valid.
            }
        }
    }
}
