﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Data
{

    public enum GameConsole { PC, PS5, XboxSeriesX, Switch }
    public class Game
    {
        // .Net will automatically detect this is primary key
        [Key]
        public int GameId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name="Game Name")]
        public string Name { get; set; }

        [Required]
        public GameConsole GameConsole { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }
        //public virtual List<Review> Reviews { get; set; }
    }
}
