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
        //[Display(nameof(GameId))]
        public int GameId { get; set; }

        //[ForeignKey(nameof(GameId))]
        //public virtual List<Game> Games { get; set; }

        [Required]
        public int Rating { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Review Date")]
        public DateTimeOffset? ReviewDate { get; set; }
    }
}
