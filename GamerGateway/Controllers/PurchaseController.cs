using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerGateway.Controllers
{
    public class PurchaseController : Controller
    {
        private PurchaseService CreatePurchaseService()
        {
            // Get current loggged in user
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            return service;
        }

        // GET: Purchase
        public ActionResult Index()
        {
            //
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            var model = service.GetPurchaseList();

            return View(model);
            //return View(CreateGameService().GetGameList());
        }

        // GET: Purchase
        public ActionResult Create()
        {
            ViewBag.Title = "New Purchase";
            return View();
        }


    }
}