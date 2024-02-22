using Game.DAL.Interfaces;
using Game.Models.Models;
using Game.Models.Tic_Tac_Toe;
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

        public async Task<bool> RecognizeAndSaveGameMoveAsync(Guid gameTypeId, string gameMove)
        {
            GameType gameType = await _gameRepository.GetGameTypeByIdAsync(gameTypeId);

            switch (gameType.Name)
            {
                case "Tic Tac Toe":

                    try
                    {

                        TicTacToeMove ticTacToeMove = JsonConvert.DeserializeObject<TicTacToeMove>(gameMove);
                        return await _gameRepository.SaveTicTacToeMove(ticTacToeMove);
                    }
                    catch (Exception ex)
                    {
                        await Console.Out.WriteLineAsync(ex.Message);
                    }
                    break;

                case "Battleship":
                    break;
                case "Checkers":
                    break;
                default:
                    break;
            }

            throw new NotImplementedException();
        }


    }
}
