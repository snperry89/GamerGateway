using GamerGateway.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GamerGateway.Data.Game;

namespace GamerGateway.Models.Game
{
    public class GameListItem
    {
        public int GameId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public GameConsole GameConsole { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
