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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AttackService(userId);

            service.CreateAttack(model);

            return RedirectToAction("Index");
        }
    }
}