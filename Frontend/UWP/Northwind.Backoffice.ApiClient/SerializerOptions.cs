using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Northwind.Backoffice.Configuration;

internal static class SerializerOptions
{
    private static readonly JsonSerializerSettings northwindSerializerOptions = CreateSettings();

    /// <summary>
    /// Defines the json serializer settings as per _agreed_ specs.
    /// <seealso cref="https://github.com/Manthazar/Denobrium.Northwind/issues/21"/>
    /// <seealso cref="https://github.com/Manthazar/Denobrium.Northwind/issues/22"/>
    /// </summary>
    /// <returns></returns>
    private static JsonSerializerSettings CreateSettings()
    {
        var configuration = new NorthwindBackofficeConfig(); // TODO: when some service location is implemented, use it here.

        var settings = new JsonSerializerSettings()
        {
            NullValueHandling = configuration.SendJsonNullvalues ? NullValueHandling.Include : NullValueHandling.Ignore,
            Formatting = configuration.EnablePrettyJsonFormatting ? Formatting.Indented : Formatting.None,
            DateFormatHandling = DateFormatHandling.IsoDateFormat, // The default format used by Json.NET is already the ISO 8601 standard: "2012-03-19T07:22Z" -so nothing to do here except for date only properties.
            FloatFormatHandling = FloatFormatHandling.DefaultValue,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            Converters = new JsonConverter[]
        {
            new StringEnumConverter() { NamingStrategy = new CamelCaseNamingStrategy (), AllowIntegerValues=false}
        },
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = true
                }
            }

            // note JSON.NET is case-insensitive by default.
        };

        return settings;
    }

    internal static JsonSerializerSettings NorthwindApiSerializerOptions => northwindSerializerOptions;
}