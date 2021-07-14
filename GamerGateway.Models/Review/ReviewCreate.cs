using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Models.Review
{
    public class ReviewCreate
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        public int Rating { get; set; }

        public string Comment { get; set; }

    }
}
