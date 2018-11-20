using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPW.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.Message = "FAQ page for users";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "OPWAPP contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Open OPWAPP Login page.";

            return View();
        }
    }
}