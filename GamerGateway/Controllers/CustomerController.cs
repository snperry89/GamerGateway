using GamerGateway.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamerGateway.Services;
using Microsoft.AspNet.Identity;
using GamerGateway.Data;

namespace GamerGateway.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        private CustomerService CreateCustomerService()
        {
            // Get current loggged in user
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }

        // GET: Customer
        public ActionResult Index()
        {
            //var model = new CustomerListItem[0];
            //return View(model);
            return View(CreateCustomerService().GetCustomerList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Customer";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateCustomerService().CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding an customer");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var customer = CreateCustomerService().GetCustomerDetailsById(id);
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = CreateCustomerService().GetCustomerDetailsById(id);
            return View(new CustomerEdit
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                ZipCode = customer.ZipCode
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (CreateCustomerService().UpdateCustomer(model))
            {
                TempData["Save Result"] = "Customer updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error updating customer");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerDetailsById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomerEntry(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Your customer was deleted";

            return RedirectToAction("Index");
        }
    }
}