using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Models.Review
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }

        public int? GameId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Review Date")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
