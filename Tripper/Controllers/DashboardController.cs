using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tripper.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Blank()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View("Profile");
        }

        public ActionResult Settings()
        {
            return View();
        }
    }
}