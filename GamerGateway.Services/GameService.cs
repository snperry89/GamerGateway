﻿using GamerGateway.Data;
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

        public GameDetail GetGameDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx.Games.Single(g => g.Id == id);
                return new GameDetail
                {
                    GameId = game.Id,
                    Name = game.Name,
                    GameConsole = game.GameConsole,
                    Price = game.Price
                };
            }
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

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx.Games.Single(g => g.Id == model.GameId);
                game.Name = model.Name;
                game.GameConsole = model.GameConsole;
                game.Price = model.Price;

                return ctx.SaveChanges() == 1;
            }

        }
    }
}
