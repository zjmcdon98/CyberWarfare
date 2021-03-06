﻿using ClassWarfare.Models;
using ClassWarfare.Services;
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
            var attackservice = CreateAttackService();
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttackCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAttackService();
            
            if (service.CreateAttack(model))
            {
                TempData["AttackSaveResult"] = "Your Attack was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Attack could not be added.");

            return View(model);
        }

        //Get
        public ActionResult Details(int id)
        {
            var svc = CreateAttackService();
            var model = svc.GetAttackById(id);

            return View(model);
        }

        //Get
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

        //Post
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
                TempData["AttackSaveResult"] = "Attack was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Attack could not be updated.");
            return View(model);
        }

        //Get
        public ActionResult Delete(int id)
        {
            var svc = CreateAttackService();
            var model = svc.GetAttackById(id);

            return View(model);
        }

        //Post
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAttackService();

            service.DeleteAttack(id);

            TempData["AttackSaveResult"] = "Attack was deleted.";

            return RedirectToAction("Index");
        }

        //Get
        public AttackService CreateAttackService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AttackService(userId);
            return service;
        }
    }
}


