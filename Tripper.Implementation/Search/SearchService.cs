using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
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

            var response = await httpClient.GetAsync(url);

            string responseBody = await response.Content.ReadAsStringAsync();

            var resultingObj = JsonConvert.DeserializeObject<T>(responseBody);

            return resultingObj;
        }
    }
}
