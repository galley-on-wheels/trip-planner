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
            AccountInfo info1 = new AccountInfo
            {
                FirstName = "Taras",
                LastName = "Tarasiuk"
            };
            AccountInfo info2 = new AccountInfo
            {
                FirstName = "Maksym",
                LastName = "Tishkov"
            };
            List<AccountInfo> udemy = new List<AccountInfo> { info1, info2 };
            //List<Dictionary<string, string>> udemy = new List<Dictionary<string, string>>();
            //udemy.Add(new Dictionary<string, string>());
            //udemy[0].Add("name", "Taras");
            //udemy[0].Add("email", "tarasiuk.taras@gmail.com");
            //udemy[0].Add("notes", "Funny man");
            //udemy.Add(new Dictionary<string, string>());
            //udemy[1].Add("name", "Taras");
            //udemy[1].Add("email", "tarasiuk.taras@gmail.com");
            //udemy[1].Add("notes", "Funny man");
            string data = JsonConvert.SerializeObject(udemy);

            var json = Json(data, JsonRequestBehavior.AllowGet);

            return json;
        }
    }
}