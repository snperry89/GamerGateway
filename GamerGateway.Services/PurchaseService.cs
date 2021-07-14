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
                    CustomerId = purchase.CustomerId,
                    GameId = purchase.GameId,
                    Quantity = purchase.Quantity,
                    GameName = purchase.Game.Name,
                    CustomerName = purchase.Customer.FullName
                };
            }
        }

        public bool CreatePurchase(PurchaseCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newPurchase = new Purchase()
                {
                    CustomerId = model.CustomerId,
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
                    CustomerId = p.CustomerId,
                    GameId = p.GameId,
                    Quantity = p.Quantity,
                    CustomerName = p.Customer.FirstName,
                    GameName = p.Game.Name
                });

                return query.ToArray();
            }
        }

        public bool UpdatePurchase(PurchaseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var purchase = ctx.Purchases.Single(g => g.PurchaseId == model.PurchaseId);
                purchase.CustomerId = model.CustomerId;
                purchase.GameId = model.GameId;
                purchase.Quantity = model.Quantity;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePurchase(int purchaseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Purchases
                        .Single(e => e.PurchaseId == purchaseId);

                ctx.Purchases.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
