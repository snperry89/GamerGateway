using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GamerGateway.Data.Game;

namespace GamerGateway.Models
{
    //public enum Console { PC, PS5, XboxSeriesX, Switch }
    public class GameListItem
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public GamingConsole GameConsole { get; set; }
        public decimal Price { get; set; }
    }
}
