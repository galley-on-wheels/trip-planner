using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tripper.Contracts.Search;

namespace Tripper.Implementation.Search
{
    public class SearchService : ISearchService
    {
        private const string ApiKey = "ia505394478393365424493565918448";
        private const string ApiEndpoint = "http://partners.api.skyscanner.net/apiservices/";

        public async Task<T> GetFromUrl<T>(string partialUrl) where T : class
        {
            var httpClient = new HttpClient();

            var url = string.Format(CultureInfo.CurrentCulture, @"{0}{1}apiKey={2}", ApiEndpoint, partialUrl, ApiKey);

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await httpClient.GetAsync(url);

            string responseBody = await response.Content.ReadAsStringAsync();

            var resultingObj = JsonConvert.DeserializeObject<T>(responseBody);

            return resultingObj;
        }

        public async Task<string> GetLocationHeader(string subUrl, IEnumerable<KeyValuePair<string, string>> kvPairs, string bodyString, string ipAddress)
        {
            var httpClient = new HttpClient();

            var url = string.Format(CultureInfo.CurrentCulture, @"{0}{1}", ApiEndpoint, subUrl);

            (kvPairs as List<KeyValuePair<string, string>>).Add(new KeyValuePair<string, string>("apikey", ApiKey));

            string _ContentType = "application/x-www-form-urlencoded";

            //HttpContent _Body = new FormUrlEncodedContent(kvPairs);

            bodyString += $"&apikey={ApiKey}";

            // var response = httpClient.PostAsync(url, _Body).Result;
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            ipAddress = "195.177.74.50";

            request.Content = new StringContent(bodyString, Encoding.UTF8, _ContentType);
            request.Headers.Add("X-Forwarded-For", ipAddress);
            //request.Headers.Add("Content-Type", _ContentType);

            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var responseHeaderValues = response.Headers.GetValues("Location");

            return responseHeaderValues.FirstOrDefault();
        }
    }
}
