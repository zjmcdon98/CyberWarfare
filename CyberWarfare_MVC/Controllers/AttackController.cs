using ClassWarfare.Models;
using CyberWarfare.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace CyberWarfare_MVC.Controllers
{
    [Authorize]
    public class AttackController : Controller
    {
        // GET
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AttackService(userId);
            var model = service.GetAttacks();
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttackCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAttackService();

            if (service.CreateAttack(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAttackService();
            var model = svc.GetAttackById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAttackService();
            var detail = service.GetAttackById(id);
            var model =
                new AttackEdit
                {
                    AttackId = detail.AttackId,
                    Success = detail.Success,
                    Date = detail.Date,
                    Time = detail.Time,
                    AttackType = detail.AttackType
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AttackEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.AttackId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAttackService();

            if (service.UpdateAttack(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        private AttackService CreateAttackService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AttackService(userId);
            return service;
        }
    }
}


