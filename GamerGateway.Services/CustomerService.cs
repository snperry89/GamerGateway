using GamerGateway.Data;
using GamerGateway.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public CustomerDetail GetCustomerDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer = ctx.Customers.Single(g => g.CustomerId == id);
                return new CustomerDetail
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    City = customer.City,
                    State = customer.State,
                    ZipCode = customer.ZipCode
                };
            }
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newCustomer = new Customer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode
                };

                try
                {
                    ctx.Customers.Add(newCustomer);

                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    Console.WriteLine(e.EntityValidationErrors);
                    Console.WriteLine( e.InnerException);
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.Data);
                }
                                             
                    return ctx.SaveChanges() == 1;
                                
            }
        }

        public IEnumerable<CustomerListItem> GetCustomerList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Customers.Select(o => new CustomerListItem
                {
                    CustomerId = o.CustomerId,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    Address = o.Address,
                    City = o.City,
                    State = o.State,
                    ZipCode = o.ZipCode
                });

                return query.ToArray();
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer = ctx.Customers.Single(g => g.CustomerId == model.CustomerId);
                customer.CustomerId = model.CustomerId;
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Address = model.Address;
                customer.City = model.City;
                customer.State = model.State;
                customer.ZipCode = model.ZipCode;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
