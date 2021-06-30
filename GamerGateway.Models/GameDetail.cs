using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GamerGateway.Data.Game;

namespace GamerGateway.Services
{
    public class GameDetail
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public GamingConsole GameConsole { get; set; }
        public decimal Price { get; set; }
    }
}
