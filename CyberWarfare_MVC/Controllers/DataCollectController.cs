using CyberWarfare.Models;
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
    public class DataCollectController : Controller
    {
        // GET
        public ActionResult Index()
        {
            var service = CreateDataCollectService();
            var model = service.GetDataCollection();
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DataCollectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDataCollectService();

            if (service.CreateDataCollectItem(model))
            {
                TempData["SaveResult"] = "Your data was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "This data could not be created.");

            return View(model);
        }

        //Get
        public ActionResult Details(int id)
        {
            var svc = CreateDataCollectService();
            var model = svc.GetDataCollectById(id);

            return View(model);
        }

        //Get
        public ActionResult Edit(int id)
        {
            var service = CreateDataCollectService();
            var detail = service.GetDataCollectById(id);
            var model =
                new DataCollectEdit
                {
                    DataCollectItemId = detail.DataCollectItemId,
                    AttackId = detail.AttackId,
                    CountryId = detail.CountryId,
                    AttackName = detail.AttackName,
                    CountryName = detail.CountryName,
                    Success = detail.Success,
                    AttackType = detail.AttackType,
                    AttackingCountry = detail.AttackingCountry
                };
            return View(model);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DataCollectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DataCollectItemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDataCollectService();

            if (service.UpdateDataCollectItem(model))
            {
                TempData["SaveResult"] = "Your data was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your data could not be updated.");
            return View(model);
        }

        //Get
        public ActionResult Delete(int id)
        {
            var svc = CreateDataCollectService();
            var model = svc.GetDataCollectById(id);

            return View(model);
        }

        //Post
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateDataCollectService();

            service.DeleteDataCollectItem(id);

            TempData["SaveResult"] = "Your data was deleted.";

            return RedirectToAction("Index");
        }

        //Get
        public DataCollectService CreateDataCollectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DataCollectService(userId);
            return service;
        }
    }
}