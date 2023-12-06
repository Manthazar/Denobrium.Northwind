using System;
using System.Net.Http;
using Windows.Web.Http.Filters;

namespace Northwind.Backofficce.ApiClient
{
    internal class NorthwindApiClientModule
    {
        private static HttpClient apiClient;

        /// <summary>
        /// The HttpClient is recommended to be a single (by server). 
        /// </summary>
        /// <remarks>
        /// TODO: Implement some sort of dependency injection/ bootstrapping to streamline such initializations
        /// </remarks>
        /// <returns></returns>
        internal static HttpClient GetApiClient()
        {
            if (apiClient == null)
            {
                // Not supported in UWP/ .NET Standard version of the HttpClient, kept for later migration purposes
                //                var filter = new HttpBaseProtocolFilter();
                //#if DEBUG
                //                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
                //                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
                //                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
                //#endif
                //apiClient = new HttpClient(filter)
                //{
                //    // TODO: make this configurable.
                //    BaseAddress = new Uri("https://localhost:7185/api"),
                //};

                // This is not something we would do normally, in my little sandbox though, I do not have a CA available which could provide a root certificate and
                // I always end up in self-signed certificates (in the leaf) causing the error. 
                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = delegate { return true; },
                };

                apiClient = new HttpClient(handler)
                {
                    // TODO: make this configurable.
                    BaseAddress = new Uri("https://localhost:7185/api"),
                };
            }

            return apiClient;
        }
    }
}
