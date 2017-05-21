using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tripper.Contracts.Search;
using Tripper.Implementation.Search;
using Tripper.Models.DataAccess;
using Tripper.Models.TripSearch;
using Booking.Implementation;

namespace Tripper.Controllers.Dashboard
{
    public class BookingSearchController : Controller
    {
        private ISearchService _searchService;

        public BookingSearchController()
        {
            _searchService = new SearchService();
        }

        [HttpPost]
        public JsonResult GetHotelsByTripDescription(CreateSessionViewModel viewModel)
        {
            var bookingFacade = new BookingFacade();
            DateTime date1 = new DateTime(2017, 06, 11);
            DateTime date2 = new DateTime(2017, 06, 20);
            var model = bookingFacade.FindHotels(viewModel.DestinationPlace, date1, date2, Booking.Implementation.Enums.ArrivingMethod.Aeroplane);

            var data = JsonConvert.SerializeObject(model);

            var json = Json(data, JsonRequestBehavior.AllowGet);

            return json;
        }
    }
}