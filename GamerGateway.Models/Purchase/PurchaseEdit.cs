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
        public int OrderId { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        // You want to be able to enter 0 when editing quantity purchased...
        //[Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]

        public int Quantity { get; set; }
    }
}
