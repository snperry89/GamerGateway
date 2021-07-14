using GamerGateway.Data;
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
                    GameId = review.GameId,
                    GameName = review.Game.Name
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
                    Select(r => new ReviewListItem
                    {
                        ReviewId = r.ReviewId,
                        Rating = r.Rating,
                        Comment = r.Comment,
                        CreatedUtc = r.CreatedUtc,
                        ModifiedUtc = r.ModifiedUtc,
                        GameId = r.GameId,
                        GameName = r.Game.Name
                    });

                return query.ToArray();
            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var review = ctx.Reviews.Single(r => r.ReviewId == model.ReviewId);
                review.ReviewId = model.ReviewId;
                review.Rating = model.Rating;
                review.Comment = model.Comment;
                review.ModifiedUtc = DateTimeOffset.Now;
                review.GameId = model.GameId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
