using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBackLog
{
    public interface IGamesRepository
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Game Create(Game game);
        Game Update(Game game);
        bool Delete(int id);
        Game Patch(int id, Game game);
    }
}