using GamerGateway.Data;
using GamerGateway.Models.Purchase;
using GamerGateway.Services;
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
        private ApplicationDbContext _db = new ApplicationDbContext();


        private PurchaseService CreatePurchaseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            return service;
        }

        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PurchaseService(userId);
            var model = service.GetPurchaseList();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_db.Customers.ToList(), "CustomerId", "FullName");
            ViewBag.GameId = new SelectList(_db.Games.ToList(), "GameId", "Name");
            ViewBag.PurchaseId = new SelectList(_db.Purchases.ToList(), "PurchaseId", "Game");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseCreate model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CustomerId = new SelectList(_db.Customers.ToList(), "CustomerId", "FullName");
                ViewBag.GameId = new SelectList(_db.Games.ToList(), "GameId", "Name");
                ViewBag.PurchaseId = new SelectList(_db.Purchases.ToList(), "PurchaseId", "Game");
                return View(model);
            }
            if (CreatePurchaseService().CreatePurchase(model))
            {
                TempData["SaveResult"] = "Item added to cart";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding a purchase");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var purchase = CreatePurchaseService().GetPurchaseDetailsById(id);
            return View(purchase);
        }

        public ActionResult Edit(int id)
        {
            var purchase = CreatePurchaseService().GetPurchaseDetailsById(id);
            ViewBag.GameId = new SelectList(_db.Games.ToList(), "GameId", "Name");

            return View(new PurchaseEdit
            {
                PurchaseId = purchase.PurchaseId,
                GameId = purchase.GameId,
                CustomerId = purchase.CustomerId,
                Quantity = purchase.Quantity
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PurchaseEdit model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CustomerId = new SelectList(_db.Customers.ToList(), "CustomerId", "FullName");
                ViewBag.GameId = new SelectList(_db.Games.ToList(), "GameId", "Name");
                ViewBag.PurchaseId = new SelectList(_db.Purchases.ToList(), "PurchaseId", "Game");

                return View(model);
            }

            if (model.PurchaseId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (CreatePurchaseService().UpdatePurchase(model))
            {
                TempData["Save Result"] = "Purchase updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding a purchase");
            return View(model);
        }


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePurchaseService();
            var model = svc.GetPurchaseDetailsById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePurchaseEntry(int id)
        {
            var service = CreatePurchaseService();

            service.DeletePurchase(id);

            TempData["SaveResult"] = "Your purchase was deleted";

            return RedirectToAction("Index");
        }


    }
}