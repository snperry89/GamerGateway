using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Data
{
    public class Purchase
    {

        // Checkbox add to order instead shopping cart view
        [Key]
        public int PurchaseId { get; set; }

        [Required]
        public int? OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        [Required]
        public int? GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]

        public int Quantity { get; set; }

        // 
        public virtual string GameName { get; set; }
        public virtual string CustomerName { get; set; }
    }
}
