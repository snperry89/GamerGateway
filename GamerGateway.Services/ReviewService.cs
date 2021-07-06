﻿using GamerGateway.Data;
using GamerGateway.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Services
{
    public class ReviewService
    {
        private readonly Guid _userId;

        public ReviewService(Guid userId)
        {
            _userId = userId;
        }

        public ReviewDetail GetReviewDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var review = ctx.Reviews.Single(r => r.ReviewId == id);
                return new ReviewDetail
                {
                    ReviewId = review.ReviewId,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    CreatedUtc = review.CreatedUtc,
                    ModifiedUtc = review.ModifiedUtc,
                    GameId = review.GameId
                };
            }
        }

        public bool CreateReview(ReviewCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newReview = new Review()
                {
                    Rating = model.Rating,
                    Comment = model.Comment,
                    CreatedUtc = DateTimeOffset.Now,
                    GameId = model.GameId
                };

                ctx.Reviews.Add(newReview);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReviewListItem> GetReviewList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Reviews.
                    //
                    //.Where(r => r.OwnerId == _userId)
                    Select(r => new ReviewListItem
                    {
                        ReviewId = r.ReviewId,
                        Rating = r.Rating,
                        Comment = r.Comment,
                        CreatedUtc = r.CreatedUtc,
                        GameId = r.GameId
                    });

                return query.ToArray();
            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var review = ctx.Reviews.Single(g => g.ReviewId == model.ReviewId);
                review.Rating = model.Rating;
                review.Comment = model.Comment;
                review.CreatedUtc = DateTimeOffset.Now;
                review.GameId = model.GameId;

                return ctx.SaveChanges() == 1;
            }
        }

        // Testing Delete
        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId /*&& e.OwnerId == _userId*/);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}