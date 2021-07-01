using GamerGateway.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamerGateway.Services;
using Microsoft.AspNet.Identity;

namespace GamerGateway.Controllers
{
    public class OrderController : Controller
    {
        private OrderService CreateOrderService()
        {
            // Get current loggged in user
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrderService(userId);
            return service;
        }

        // GET: Order
        public ActionResult Index()
        {
            var model = new OrderListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Order";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateOrderService().CreateOrder(model))
            {
                TempData["SaveResult"] = "Game added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding a game");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var order = CreateOrderService().GetOrderDetailsById(id);
            return View(order);
        }

        public ActionResult Edit(int id)
        {
            var order = CreateOrderService().GetOrderDetailsById(id);
            return View(new OrderEdit
            {
                OrderId = order.OrderId,
                FirstName = order.FirstName,
                LastName = order.LastName,
                Address = order.Address,
                City = order.City,
                State = order.State,
                ZipCode = order.ZipCode
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OrderId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (CreateOrderService().UpdateOrder(model))
            {
                TempData["Save Result"] = "Order updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding a game");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateOrderService();
            var model = svc.GetOrderDetailsById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderEntry(int id)
        {
            var service = CreateOrderService();

            service.DeleteOrder(id);

            TempData["SaveResult"] = "Your order was deleted";

            return RedirectToAction("Index");
        }
    }
}