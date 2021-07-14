using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Models.Purchase
{
    public class PurchaseDetail
    {
        public int PurchaseId { get; set; }

        public int? CustomerId { get; set; }

        public int? GameId { get; set; }

        public int Quantity { get; set; }

        //
        public virtual string GameName { get; set; }
        public virtual string CustomerName { get; set; }
    }
}
