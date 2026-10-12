using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBackLog
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _repository;

        public GamesService(IGamesRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<GameResponseDTO> GetAll()
        {
            return _repository.GetAll().Select(ToReadDTO);
        }

        public GameResponseDTO? GetById(int id)
        {
            Game? check = _repository.GetById(id);

            if(check == null)
            {
                return null;
            }

            return ToReadDTO(check);
        }

        public GameResponseDTO? Create(CreateGameDTO dto)
        {
            bool check = _repository.GetAll().Any(g => g.Title.ToLower() == dto.Title.ToLower());

            if (check)
            {
                return null;
            }

            Game game = new Game();

            game.Title = dto.Title;
            game.Platform = dto.Platform;
            game.Genre = dto.Genre;
            game.ReleaseYear = dto.ReleaseYear;
            game.HoursPlayed = dto.HoursPlayed;
            game.Rating = dto.Rating;
            game.PricePaid = dto.PricePaid;
            game.Status = "Backlog";
            game.AddedAt = DateTime.UtcNow;

            Game created = _repository.Create(game);

            return ToReadDTO(created);
        }

        public GameResponseDTO Update(int id, Game gameUpdate)
        {

            Game? update = _repository.GetById(id);

            if (update == null)
            {
                return null;
            }

            update.Title = gameUpdate.Title;
            update.Platform = gameUpdate.Platform;
            update.Genre = gameUpdate.Genre;
            update.ReleaseYear = gameUpdate.ReleaseYear;
            update.HoursPlayed = gameUpdate.HoursPlayed;
            update.Rating = gameUpdate.Rating;
            update.PricePaid = gameUpdate.PricePaid;

            return ToReadDTO(update);
        }

        public bool Delete(int id)
        {
            Game? game = _repository.GetById(id);

            if (game == null)
            {
                return false;
            }

            _repository.Delete(id);

            return true;
        }

        public GameResponseDTO Patch(int id, Game game)
        {
            Game? patch = _repository.Patch(id, game);

            if (patch == null)
            {
                return null;
            }

            return ToReadDTO(patch);

        }

        //Helper
        private static GameResponseDTO ToReadDTO(Game game)
        {
            GameResponseDTO outputDTO = new GameResponseDTO();

            outputDTO.Id = game.Id;
            outputDTO.Title = game.Title;
            outputDTO.Platform = game.Platform;
            outputDTO.Genre = game.Genre;
            outputDTO.ReleaseYear = game.ReleaseYear;
            outputDTO.HoursPlayed = game.HoursPlayed;
            outputDTO.Rating = game.Rating;
            outputDTO.PricePaid = game.PricePaid;
            outputDTO.Status = game.Status;
            outputDTO.AddedAt = game.AddedAt;

            outputDTO.YearsSinceRelease = DateTime.UtcNow.Year - game.ReleaseYear;

            return outputDTO;

        }
    }
}