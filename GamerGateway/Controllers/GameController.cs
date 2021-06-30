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

        public ActionResult Details(int id)
        {
            var game = CreateGameService().GetGameDetailsById(id);
            return View(game);
        }

        public ActionResult Edit(int id)
        {
            var game = CreateGameService().GetGameDetailsById(id);
            return View(new GameEdit
            {
                GameId = game.GameId,
                Name = game.Name,
                GameConsole = game.GameConsole,
                Price = game.Price
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (CreateGameService().UpdateGame(model))
            {
                TempData["Save Result"] = "Game updated";
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