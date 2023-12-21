using Northwind.Backoffice.Configuration;

namespace Northwind.Backoffice.Services
{
    internal class ConfigurationProvider : IConfigurationProvider
    {
        public ConfigurationProvider()
        {
            Config = new NorthwindBackofficeConfig();

            ReadInto(Config);
        }

        /// <summary>
        /// Reads values from the application data settings
        /// </summary>
        /// <seealso cref="https://learn.microsoft.com/en-us/windows/uwp/get-started/settings-learning-track"/>
        /// <param name="config"></param>
        private void ReadInto(NorthwindBackofficeConfig config)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            if (localSettings.Values["backendApiUri"] is string uriString)
            {
                config.NorthwindApiBaseUri = uriString;
            }

            if (localSettings.Values["json.enableFormatting"] is bool enableFormatting)
            {
                config.EnablePrettyJsonFormatting = enableFormatting;
            }

            if (localSettings.Values["json.sendNullValues"] is bool sendNullValues)
            {
                config.SendJsonNullvalues = sendNullValues;
            }
        }

        public NorthwindBackofficeConfig Config { get; }
    }
}
