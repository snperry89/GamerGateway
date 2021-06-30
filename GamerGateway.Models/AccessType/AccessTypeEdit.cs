using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Models.AccessType
{
    public class AccessTypeEdit
    {
        public int AccessTypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
