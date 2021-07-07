using GamerGateway.Data;
using GamerGateway.Models.Review;
using GamerGateway.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamerGateway.Controllers
{
    public class ReviewController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        private ReviewService CreateReviewService()
        {
            // Get current loggged in user
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            return service;
        }

        // GET: Review
        public ActionResult Index()
        {
            //var model = new ReviewListItem[0];
            //return View(model);
            return View(CreateReviewService().GetReviewList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Review";
            ViewBag.GameId = new SelectList(_db.Games.ToList(), "GameId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateReviewService().CreateReview(model))
            {
                TempData["SaveResult"] = "Review added";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error adding an review");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var review = CreateReviewService().GetReviewDetailsById(id);
            return View(review);
        }

        public ActionResult Edit(int id)
        {
            var review = CreateReviewService().GetReviewDetailsById(id);
            return View(new ReviewEdit
            {
                ReviewId = review.ReviewId,
                GameId = review.GameId,
                Rating = review.Rating,
                Comment = review.Comment,
                //ReviewDate = review.ReviewDate
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
            if (model.ReviewId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (CreateReviewService().UpdateReview(model))
            {
                TempData["Save Result"] = "Review updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error updating review");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewDetailsById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReviewEntry(int id)
        {
            var service = CreateReviewService();

            service.DeleteReview(id);

            TempData["SaveResult"] = "Your review was deleted";

            return RedirectToAction("Index");
        }
    }
}