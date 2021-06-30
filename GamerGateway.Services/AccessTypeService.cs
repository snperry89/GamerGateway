using GamerGateway.Data;
using GamerGateway.Models.AccessType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Services
{
    public class AccessTypeService
    {
        public bool CreateAccessType(AccessTypeCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newAccessType = new AccessType()
                {
                    Name = model.Name,
                };

                ctx.AccessTypes.Add(newAccessType);
                return ctx.SaveChanges() == 1;
            }
        }

        public AccessTypeDetail GetAccessTypeDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var accessType = ctx.AccessTypes.Single(a => a.Id == id);
                return new AccessTypeDetail
                {
                    AccessTypeId = accessType.Id,
                    Name = accessType.Name,
                };
            }
        }
        public IEnumerable<AccessTypeListItem> GetAccessTypeList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.AccessTypes.Select(a => new AccessTypeListItem
                {
                    Name = a.Name
                });

                return query.ToArray();
            }
        }

        public bool UpdateAccessType(AccessTypeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var accessType = ctx.AccessTypes.Single(g => g.Id == model.AccessTypeId);
                accessType.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }

        }
    }
}
