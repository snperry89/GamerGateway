using GamerGateway.Data;
using GamerGateway.Models;
using GamerGateway.Models.Game;
using GamerGateway.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GamerGateway.Controllers
{
    public class GameController : Controller
    {
        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }

        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            var model = service.GetGameList();

            return View(model);
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


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameDetailsById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGameEntry(int id)
        {
            var service = CreateGameService();

            service.DeleteGame(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}