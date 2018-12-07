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
        // GET
        public ActionResult Index()
        {
            var model = new CountryListItem[0];
            return View(model);
        }

        // Get
        public ActionResult Create()
        {
            return View();
        }

        //Post
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}