using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GamerGateway.Data.Game;

namespace GamerGateway.Models
{
    public class GameCreate
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public GamingConsole GameConsole { get; set; }
        public decimal Price { get; set; }
    }
}
