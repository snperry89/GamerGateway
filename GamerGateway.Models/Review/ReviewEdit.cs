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

        [Required]
        public int GameId { get; set; }

        [Required]
        public int Rating { get; set; }

        public string Comment { get; set; }

        //[Required]
        //[Display(Name = "Review Date")]
        //public DateTimeOffset? ReviewDate { get; set; }
    }
}
