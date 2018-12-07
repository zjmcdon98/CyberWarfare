using ClassWarfare.Models;
using CyberWarfare.Services;
using Microsoft.AspNet.Identity;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CountryService(userId);
            var model = service.GetCountries();

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CountryService(userId);

            service.CreateCountry(model);

            return RedirectToAction("Index");
        }
    }
}
