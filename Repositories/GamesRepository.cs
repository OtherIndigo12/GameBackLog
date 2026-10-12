using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameBackLog
{
    public class GamesRepository : IGamesRepository
    {
        private readonly AppDbContext _db;

        public GamesRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Game> GetAll()
        {
            return _db.Games.ToList();
        }

        public Game? GetById(int id)
        {
            return _db.Games.FirstOrDefault(g => g.Id == id);
        }

        public Game Create(Game game)
        {
            _db.Games.Add(game);
            _db.SaveChanges();
            return game;
        }

        public Game Update(Game game)
        {
            _db.SaveChanges();
            return game;
        }

        public bool Delete(int id)
        {
            var game = _db.Games.Find(id);
            if (game == null)
            {
                return false;
            }

            _db.Games.Remove(game);
            _db.SaveChanges();
            return true;
        }

        public Game Patch(int id, Game game)
        {
            var patch = _db.Games.Find(id);

            if (patch == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(game.Status))
            {
                patch.Status = game.Status;
            }
            
            _db.SaveChanges();
            return patch;
            
        }

    }
}