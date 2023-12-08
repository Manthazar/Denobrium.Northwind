using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Windows.System;

internal static class SerializerOptions
{
    private static readonly JsonSerializerSettings northwindSerializerOptions = new JsonSerializerSettings()
    {
        NullValueHandling = NullValueHandling.Ignore,
        Formatting = Formatting.None,
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

    internal static JsonSerializerSettings NorthwindApiSerializerOptions => northwindSerializerOptions;
}