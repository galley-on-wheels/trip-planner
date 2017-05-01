using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skyscanner.Contracts.Settings;
using Skyscanner.Contracts.Settings.Countries;
using Skyscanner.Contracts.Settings.Currencies;
using Skyscanner.Contracts.Settings.Locales;

namespace Tripper.Controllers.Dashboard
{
    public class SearchController : Controller
    {
        private const string apiKey = "ia505394478393365424493565918448";
        private const string apiEndpoint = "http://partners.api.skyscanner.net/apiservices/";

        [NonAction]
        public async Task<T> GetFromUrl<T>(string partialUrl) where T: class
        {
            var httpClient = new HttpClient();

            var url = string.Format(CultureInfo.CurrentCulture, @"{0}{1}?apiKey={2}", apiEndpoint, partialUrl, apiKey);

            var response = await httpClient.GetAsync(url);

            string responseBody = await response.Content.ReadAsStringAsync();

            var resultingObj = JsonConvert.DeserializeObject<T>(responseBody);

            return resultingObj;
        }

        [HttpGet]
        public async Task<JsonResult> GetAvailableCultures()
        {
            var partialUrl = "reference/v1.0/locales";

            var locales = await GetFromUrl<LocalesWrapper>(partialUrl);

            var json = Json(locales.Locales, JsonRequestBehavior.AllowGet);

            return json;
        }

        [HttpGet]
        public async Task<JsonResult> GetAvailableCurrencies()
        {
            var partialUrl = "reference/v1.0/currencies";

            var currencies = await GetFromUrl<CurrenciesWrapper>(partialUrl);

            var json = Json(currencies.Currencies, JsonRequestBehavior.AllowGet);

            return json;
        }

        [HttpGet]
        public async Task<JsonResult> GetAvailableCountries(string locale)
        {
            var partialUrl = string.Format(CultureInfo.CurrentCulture, @"/reference/v1.0/countries/{0}", locale);

            var countries = await GetFromUrl<CountriesWrapper>(partialUrl);

            var json = Json(countries.Countries, JsonRequestBehavior.AllowGet);

            return json;
        }
    }
}