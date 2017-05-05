using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Skyscanner.Contracts.Places;
using Skyscanner.Contracts.Settings;
using Skyscanner.Contracts.Settings.Countries;
using Skyscanner.Contracts.Settings.Currencies;
using Skyscanner.Contracts.Settings.Locales;
using Tripper.Contracts.Search;
using Tripper.Implementation.Search;
using Tripper.Models.TripSearch;

namespace Tripper.Controllers.Dashboard
{
    public class SearchController : Controller
    {
        private ISearchService _searchService;

        public SearchController()
        {
            _searchService = new SearchService();
        }

        [HttpGet]
        public async Task<JsonResult> GetAvailableCultures()
        {
            var partialUrl = "reference/v1.0/locales?";

            var locales = await _searchService.GetFromUrl<LocalesWrapper>(partialUrl);

            var json = Json(locales.Locales, JsonRequestBehavior.AllowGet);

            return json;
        }

        [HttpGet]
        public async Task<JsonResult> GetAvailableCurrencies()
        {
            var partialUrl = "reference/v1.0/currencies?";

            var currencies = await _searchService.GetFromUrl<CurrenciesWrapper>(partialUrl);

            var json = Json(currencies.Currencies, JsonRequestBehavior.AllowGet);
            
            return json;
        }

        [HttpGet]
        public async Task<JsonResult> GetAvailableCountries(string locale)
        {
            var partialUrl = string.Format(CultureInfo.CurrentCulture, @"/reference/v1.0/countries/{0}?", locale);

            var countries = await _searchService.GetFromUrl<CountriesWrapper>(partialUrl);

            var json = Json(countries.Countries, JsonRequestBehavior.AllowGet);

            return json;
        }

        [HttpGet]
        public async Task<JsonResult> GetAutosuggestedPlace(string query)
        {
            var defaultLocale = "en-US";
            var defaultCurrency = "USD";
            var defaultMarket = "US";

            var partialUrl = string.Format(CultureInfo.CurrentCulture, $"autosuggest/v1.0/{defaultMarket}/{defaultCurrency}/{defaultLocale}?query={query}&");

            var places = await _searchService.GetFromUrl<PlacesWrapper>(partialUrl);

            var json = Json(places.Places, JsonRequestBehavior.AllowGet);

            return json;
        }

        [HttpPost]
        public JsonResult GetItinerariesByTripDescription(CreateSessionViewModel viewModel)
        {


            return Json(new {});
        }
    }
}