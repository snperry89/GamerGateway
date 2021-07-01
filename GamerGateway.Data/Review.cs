﻿using System;
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
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        // Make Decimal with one point
        [Required]
        public int Rating { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; }
    }
}