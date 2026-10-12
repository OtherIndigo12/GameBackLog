using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace GameBackLog
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _games;

        public GamesController(IGamesService games)
        {
            _games = games;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<GameResponseDTO>> GetAll()
        {
            var gamesList = _games.GetAll().ToList();
            return Ok(gamesList);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<GameResponseDTO> GetById(int id)
        {
            GameResponseDTO? gameCheck = _games.GetById(id);
            {
                if (gameCheck == null)
                {
                    return NotFound("There was no game found with this ID.....");
                }

                return Ok(gameCheck);
            }
            
        }

        [HttpPost("AddGame")]

        public ActionResult<GameResponseDTO> Create([FromBody] CreateGameDTO game)
        {
            GameResponseDTO? created = _games.Create(game);
 
            if (created == null)
            {
                return BadRequest("There seems to be something wrong here...");
            }

            return CreatedAtAction(nameof(GetById), new {id = created.Id}, created);
            
        }

        [HttpPut("Update/{id}")]

        public ActionResult<GameResponseDTO> Update(int id, [FromBody] Game game)
        {
            GameResponseDTO? exist = _games.GetById(id);

            if (exist == null)
            {
                return NotFound("This Game does not exist...");
            }

            GameResponseDTO updated = _games.Update(id, game);

            return Ok(updated);
        }

        [HttpDelete("Delete/{id}")]

        public IActionResult Delete(int id)
        {
            if(_games.GetById(id) == null)
            {
                return NotFound("This Game Does Not Exist");
            }

            _games.Delete(id);
            return NoContent();
        }

        [HttpPatch("Patch/{id}")]

        public ActionResult<UpdateStatusDTO> Patch(int id, [FromBody] Game game)
        {
            GameResponseDTO? patched = _games.Patch(id, game);

            if (patched == null)
            {
                return NotFound("This Game is not here.......");
            }

            return Ok(patched);
        }
    }
}