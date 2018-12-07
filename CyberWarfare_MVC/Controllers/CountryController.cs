using ClassWarfare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberWarfare_MVC.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            var model = new CountryListItem[0];
            return View(model);
        }
    }
}