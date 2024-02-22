using Game.Models.Dto.Requests;
using Game.Models.Models;
using Game.Models.Tic_Tac_Toe;

namespace Game.DAL.Interfaces
{
    public interface IGameRepository
    {
        Task CreateGameTypeAsync(GameTypeCreateRequest gameType);
        Task<IEnumerable<GameType>> GetGameTypesAsync();
        Task<GameType> GetGameTypeByIdAsync(Guid gameTypeId);
        Task<GameSession> CreateGameSessionAsync(Guid hostId, Guid guestId);
        Task<bool> UpdateSessionTimeAsync(Guid gameSessionId, bool isStart);  // If 'isStart' is true,that means game just startet,if 'isStart' false,that means game is finished
        Task<bool> SaveTicTacToeMove(TicTacToeMove ticTacToeMove);
        Task<GamePlayerStat> GetGamePlayerStatByPlayerAndGameIdAsync(Guid playerId, Guid gameTypeId);
        Task<bool> Save();



    }
}
