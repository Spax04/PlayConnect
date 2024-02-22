using Game.DAL.Interfaces;
using Game.Models.Models;
using Newtonsoft.Json;

namespace Game.DAL.Services
{
    public class GameService : IGameService
    {
        IGameRepository _gameRepository { get; set; }
        public GameService(IGameRepository gameRepository)
        {

            _gameRepository = gameRepository;

        }
        public bool IsStartsFirst()
        {
            Random rnd = new Random();

            int r = rnd.Next(0, 2);

            return r == 0 ? false : true;
        }

        public async Task<Move> ConvertJsonToGameMoveAsync(Guid gameTypeId, string gameMove)
        {
            GameType gameType = await _gameRepository.GetGameTypeByIdAsync(gameTypeId);
            Move move = JsonConvert.DeserializeObject<Move>(gameMove);

            if(move == null)
            {

                throw new Exception();
                    }

            return move;
            
        }

       
    }
}
