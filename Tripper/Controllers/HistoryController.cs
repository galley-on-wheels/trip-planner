using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Skyscanner.Contracts.BrowseRoutes;
using Skyscanner.Contracts.BrowseRoutes.Expanded;
using Tripper.Implementation;
using Tripper.Models.TripSearch;

namespace Tripper.Controllers
{
    public class HistoryController : Controller
    {
        [HttpGet]
        public JsonResult GetHistoryRecords()
        {
            List<CreateSessionViewModel> userHistory = new List<CreateSessionViewModel>();

            if (User.Identity.IsAuthenticated)
            {
                var id = User.Identity.GetUserId();

                userHistory = HistoryService.GetHistoryRecords(id);
            }

            var json = Json(userHistory, JsonRequestBehavior.AllowGet);

            return json;
        }

        [HttpPost]
        public void RemoveHistory()
        {
            if (User.Identity.IsAuthenticated)
            {
                var id = User.Identity.GetUserId();

                HistoryService.RemoveHistory(id);
            }
        }
    }
}