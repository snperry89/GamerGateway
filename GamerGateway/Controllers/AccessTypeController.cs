using GamerGateway.Models.AccessType;
using GamerGateway.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerGateway.Controllers
{
    public class AccessTypeController : Controller
    {
        // GET: AccessType
        public ActionResult Index()
        {
            return View(new AccessTypeService().GetAccessTypeList());
        }


        public ActionResult Create()
        {
            ViewBag.Title = "New AccessType";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccessTypeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (new AccessTypeService().CreateAccessType(model))
            {
                TempData["SaveResult"] = "AccessType added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding a game");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var accessType = new AccessTypeService().GetAccessTypeDetailsById(id);
            return View(accessType);
        }

        public ActionResult Edit(int id)
        {
            var accessType = new AccessTypeService().GetAccessTypeDetailsById(id);
            return View(new AccessTypeEdit
            {
                AccessTypeId = accessType.AccessTypeId,
                Name = accessType.Name,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AccessTypeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AccessTypeId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (new AccessTypeService().UpdateAccessType(model))
            {
                TempData["Save Result"] = "AccessType updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error updating access type");
            return View(model);
        }
    }
}