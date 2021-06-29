using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Data
{

    public class Game
    {
        // .Net will automatically detect this is primary key
        public int Id { get; set; }
        public string Name { get; set; }
        public enum GamingConsole { PC, PS5, XboxSeriesX, Switch }
        public GamingConsole GameConsole { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        //public virtual List<Review> Reviews { get; set; }
    }
}
