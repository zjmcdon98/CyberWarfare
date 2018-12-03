using ClassWarfare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberWarfare_MVC.Controllers
{
    [Authorize]
    public class AttackController : Controller
    {
        // GET
        public ActionResult Index()
        {
            var model = new AttackListItem[0];
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }
    }
}