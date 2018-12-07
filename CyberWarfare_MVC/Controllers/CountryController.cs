using ClassWarfare.Models;
using CyberWarfare.Models;
using CyberWarfare.Services;
using Microsoft.AspNet.Identity;
using System;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCountryService();

            if (service.CreateCountry(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        //Get
        public ActionResult Details(int id)
        {
            var svc = CreateCountryService();
            var model = svc.GetCountryById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCountryService();
            var detail = service.GetCountryById(id);
            var model =
                new CountryEdit
                {
                    CountryId = detail.CountryId,
                    CountryName = detail.CountryName,
                    CountryTech = detail.CountryTech,
                    DipRelations = detail.DipRelations,
                    StaffAmount = detail.StaffAmount,
                    CountryBudget = detail.CountryBudget
                };
            return View(model);
        }

        //Get
        private CountryService CreateCountryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CountryService(userId);
            return service;
        }
    }
}
