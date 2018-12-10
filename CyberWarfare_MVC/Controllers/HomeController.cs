using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberWarfare_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The Cyber Attack Database Web App is a project that is always evolving over time.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact information for our main office.";

            return View();
        }
    }
}