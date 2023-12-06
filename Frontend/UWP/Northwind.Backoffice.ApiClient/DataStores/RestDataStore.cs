using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Backofficce.ApiClient.DataStores
{
    /// <summary>
    /// Base class for REST based web requests within this app. Also serves as a circuit breaker on transient errors.
    /// </summary>
    public abstract class RestDataStore
    {
        /// <summary>
        /// Performs a get request to the provided resource.
        /// </summary>
        protected async Task<T> GetAsync<T>(string resource, CancellationToken cancellation)
        {
            var httpClient = NorthwindApiClientModule.GetApiClient();

            try
            {
                var requestUri = $"{httpClient.BaseAddress}/{resource}";
                var response = await httpClient.GetFromJsonAsync<T>(requestUri, cancellation);

                return response;
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
