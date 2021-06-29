using GamerGateway.Models;
using GamerGateway.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerGateway.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View(CreateGameService().GetGameList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Game";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateGameService().CreateGame(model))
            {
                TempData["SaveResult"] = "Game added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding a game");
            return View(model);
        }

        private GameService CreateGameService()
        {
            // Get current loggged in user
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }
    }
}