using GamerGateway.Data;
using GamerGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerGateway.Services
{
    public class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGame(GameCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newGame = new Game()
                {
                    Name = model.Name,
                    GameConsole = model.GameConsole,
                    Price = model.Price
                };

                ctx.Games.Add(newGame);
                return ctx.SaveChanges() == 1;
            }
        }
       
        public IEnumerable<GameListItem> GetGameList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Games.Select(g => new GameListItem
                {
                    GameId = g.Id,
                    Name = g.Name,
                    GameConsole = g.GameConsole,
                    Price = g.Price
                });

                return query.ToArray();
            }
        }
    }
}
