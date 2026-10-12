using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBackLog
{
    public interface IGamesService
    {
       IEnumerable<GameResponseDTO> GetAll();
       GameResponseDTO? GetById(int id);
       GameResponseDTO Create(CreateGameDTO game);
       GameResponseDTO Update(int id, Game game);
       bool Delete(int id);
       GameResponseDTO Patch(int id, Game game);


    }
}