using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Models.Purchase
{
    public class PurchaseEdit
    {
        public int PurchaseId { get; set; }

        [Required]
        public int? CustomerId { get; set; }

        [Required]
        public int? GameId { get; set; }

        [Required]
        public int Quantity { get; set; }


        public virtual string CustomerName { get; set; }
        public virtual string GameName { get; set; }

    }
}
