﻿using ClassWarfare.Models;
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
                TempData["SaveResult"] = "Your Country was Added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Country could not be Added.");

            return View(model);
        }

        //Get
        public ActionResult Details(int id)
        {
            var svc = CreateCountryService();
            var model = svc.GetCountryById(id);

            return View(model);
        }

        //Get
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

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CountryEdit model)
        {
           if(!ModelState.IsValid) return View(model);

           if(model.CountryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch.");
                return View(model);
            }

            var service = CreateCountryService();

            if (service.UpdateCountry(model))
            {
                TempData["SaveResult"] = "The Country was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Country could not be updated.");
            return View(model);
        }

        [ActionName ("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCountryService();
            var model = svc.GetCountryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCountry(int id)
        {
            var service = CreateCountryService();

            service.DeleteCountry(id);

            TempData["SaveResult"] = "The Country was deleted";

            return RedirectToAction("Index");
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
