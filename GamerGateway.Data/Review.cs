using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int? GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        public virtual string GameName { get; set; }

        // Make Decimal with one point
        [Required]
        [Range(0, 5, ErrorMessage = "The Rating must be between 0-5")]
        public int Rating { get; set; }

        public string Comment { get; set; }

        [Required]
        [Display(Name = "Review Date")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
