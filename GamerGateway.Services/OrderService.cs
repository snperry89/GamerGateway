using GamerGateway.Data;
using GamerGateway.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Services
{
    public class OrderService
    {
        public OrderDetail GetOrderDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var order = ctx.Orders.Single(g => g.OrderId == id);
                return new OrderDetail
                {
                    OrderId = order.OrderId,
                    FirstName = order.FirstName,
                    LastName = order.LastName,
                    Address = order.Address,
                    City = order.City,
                    State = order.State,
                    ZipCode = order.ZipCode
                };
            }
        }

        public bool CreateOrder(OrderCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newOrder = new Order()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode
                };

                ctx.Orders.Add(newOrder);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderListItem> GetOrderList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Orders.Select(g => new OrderListItem
                {
                    OrderId = g.OrderId,
                    FullName = g.FullName,
                });

                return query.ToArray();
            }
        }

        public bool UpdateOrder(OrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var order = ctx.Orders.Single(g => g.OrderId == model.OrderId);
                order.OrderId = model.OrderId;
                order.FirstName = model.FirstName;
                order.LastName = model.LastName;
                order.Address = model.Address;
                order.City = model.City;
                order.State = model.State;
                order.ZipCode = model.ZipCode;

                return ctx.SaveChanges() == 1;
            }
        }

        // Testing Delete
        public bool DeleteOrder(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == orderId /*&& e.OwnerId == _userId*/);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
