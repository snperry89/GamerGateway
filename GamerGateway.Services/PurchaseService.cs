using GamerGateway.Data;
using GamerGateway.Models.Purchase;
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
                var purchase = ctx.Purchases.Single(g => g.PurchaseId == id);
                return new PurchaseDetail
                {
                    PurchaseId = purchase.PurchaseId,
                    OrderId = purchase.OrderId,
                    GameId = purchase.GameId,
                    Quantity = purchase.Quantity
                };
            }
        }

        public bool CreatePurchase(PurchaseCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newPurchase = new Purchase()
                {
                    OrderId = model.OrderId,
                    GameId = model.GameId,
                    Quantity = model.Quantity
                };

                ctx.Purchases.Add(newPurchase);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PurchaseListItem> GetPurchaseList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Purchases.Select(p => new PurchaseListItem
                {
                    PurchaseId = p.PurchaseId,
                    OrderId = p.OrderId,
                    GameId = p.GameId,
                    Quantity = p.Quantity
                });

                return query.ToArray();
            }
        }

        public bool UpdatePurchase(PurchaseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var purchase = ctx.Purchases.Single(g => g.PurchaseId == model.PurchaseId);
                purchase.OrderId = model.OrderId;
                purchase.GameId = model.GameId;
                purchase.Quantity = model.Quantity;

                return ctx.SaveChanges() == 1;
            }
        }

        // Testing Delete
        public bool DeletePurchase(int purchaseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Purchases
                        .Single(e => e.PurchaseId == purchaseId /*&& e.OwnerId == _userId)*/);

                ctx.Purchases.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
