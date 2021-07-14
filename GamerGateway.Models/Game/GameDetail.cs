using GamerGateway.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GamerGateway.Data.Game;

namespace GamerGateway.Models.Game
{
    public class GameDetail
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public GameConsole GameConsole { get; set; }
        public decimal Price { get; set; }
    }
}
