using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Northwind.Core.Configuration;
using Newtonsoft.Json.Converters;
using System;

namespace Northwind.WebApi
{
    internal static class JsonHandlerModule
    {
        /// <summary>
        /// Configures the json component to _agreed_ standards.
        /// <seealso cref="https://github.com/Manthazar/Denobrium.Northwind/issues/21"/>
        /// <seealso cref="https://github.com/Manthazar/Denobrium.Northwind/issues/22"/>
        /// </summary>
        /// <remarks>
        /// We are NOT going to use system text json on server side since there is an incapability to write
        /// objects by their current type rather than their super type (i.e. a writing of 'vehicle' will skip all members of 'car').
        /// This will be a problem when products will receive dynamic members/ attributes by category.
        /// </remarks>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        internal static IMvcBuilder ConfigureJsonHandler(this IMvcBuilder services, NorthwindApiConfiguration configuration)
        {
            // note JSON.NET is case-insensitive by default.

            services.AddNewtonsoftJson(setup =>
             {
                 var settings = setup.SerializerSettings;
                 settings.NullValueHandling = configuration.SendJsonNullvalues ? NullValueHandling.Include : NullValueHandling.Ignore;
                 settings.Formatting = configuration.EnablePrettyJsonFormatting ? Formatting.Indented : Formatting.None;
                 settings.DateFormatHandling = DateFormatHandling.IsoDateFormat; // The default format used by Json.NET is already the ISO 8601 standard: "2012-03-19T07:22Z" -so nothing to do here except for date only properties.
                 settings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
                 settings.MissingMemberHandling = MissingMemberHandling.Ignore;
                 
                 settings.Converters = new JsonConverter[]
                 {
                    new StringEnumConverter() { NamingStrategy = new CamelCaseNamingStrategy (), AllowIntegerValues=false}
                 };

                 settings.ContractResolver = new DefaultContractResolver
                 {
                     NamingStrategy = new CamelCaseNamingStrategy
                     {
                         OverrideSpecifiedNames = true
                     }
                 };
            });

            return services;
        }
}
}
