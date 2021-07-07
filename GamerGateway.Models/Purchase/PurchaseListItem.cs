using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Models.Purchase
{
    public class PurchaseListItem
    {
        public int PurchaseId { get; set; }

        [Required]
        public int? OrderId { get; set; }

        [Required]
        public int? GameId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]

        public int Quantity { get; set; }

        //

        [Display(Name = "Game Name")]
        public virtual string GameName { get; set; }
        [Display(Name = "Customer Name")]
        public virtual string CustomerName { get; set; }
    }
}
