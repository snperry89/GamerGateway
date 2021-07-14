using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Models.Review
{
    public class ReviewEdit
    {
        public int ReviewId { get; set; }

        public int? GameId { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Value must be between 0-5")]
        public int Rating { get; set; }

        public string Comment { get; set; }

    }
}
