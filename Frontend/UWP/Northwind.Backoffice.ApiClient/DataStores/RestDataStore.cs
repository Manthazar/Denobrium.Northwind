using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backofficce.ApiClient.DataStores
{
    /// <summary>
    /// Base class for REST based web requests within this app. Also serves as a circuit breaker on transient errors.
    /// </summary>
    public abstract class RestDataStore
    {
        private readonly JsonSerializerSettings settings;

        public RestDataStore()
        {
            settings = SerializerOptions.NorthwindApiSerializerOptions;
        }

        /// <summary>
        /// Performs a get request to the provided resource.
        /// </summary>
        protected async Task<T> GetAsync<T>(string resource, CancellationToken cancellation)
        {
            var httpClient = NorthwindApiClientModule.GetApiClient();

            try
            {
                var requestUri = $"{httpClient.BaseAddress}/{resource}";

                var response = await httpClient.GetStringAsync(requestUri); // no support of cancellation in this .net version?
                var result = JsonConvert.DeserializeObject<T>(response, settings);

                return result;
            } 
            catch (HttpRequestException ex)
            {
                // Weirdo, UWP exception has no details which we could actually make use of.
                Console.WriteLine($"ERROR: WebClient returned error: {httpClient.BaseAddress}{resource}");
                Console.WriteLine($"ERROR-MESSAGE: {ex.Message}");

                throw;
            }
        }
    }
}
