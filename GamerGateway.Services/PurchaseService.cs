using GamerGateway.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Services
{
    public class PurchaseService
    {
        private readonly Guid _userId;

        public PurchaseService(Guid userId)
        {
            _userId = userId;
        }

        public PurchaseDetail GetPurchaseDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx.Purchases.Single(g => g.PurchaseId == id);
                return new PurchaseDetail
                {
                    PurchaseId = game.PurchaseId,
                    Name = game.Name,
                    PurchaseConsole = game.PurchaseConsole,
                    Price = game.Price
                };
            }
        }

        public bool CreatePurchase(PurchaseCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newPurchase = new Purchase()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    PurchaseConsole = model.PurchaseConsole,
                    Price = model.Price
                };

                ctx.Purchases.Add(newPurchase);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PurchaseListItem> GetPurchaseList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Purchases.Select(g => new PurchaseListItem
                {
                    PurchaseId = g.PurchaseId,
                    Name = g.Name,
                    PurchaseConsole = g.PurchaseConsole,
                    Price = g.Price
                });

                return query.ToArray();
            }
        }

        public bool UpdatePurchase(PurchaseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx.Purchases.Single(g => g.PurchaseId == model.PurchaseId);
                game.Name = model.Name;
                game.PurchaseConsole = model.PurchaseConsole;
                game.Price = model.Price;

                return ctx.SaveChanges() == 1;
            }
        }

        // Testing Delete
        public bool DeletePurchase(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Purchases
                        .Single(e => e.PurchaseId == gameId && e.OwnerId == _userId);

                ctx.Purchases.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
