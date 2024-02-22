using Game.Models.Dto.Requests;
using Game.Models.Models;

namespace Game.DAL.Interfaces
{
    public interface IGameRepository
    {
        Task CreateGameTypeAsync(GameTypeCreateRequest gameType);
        Task<IEnumerable<GameType>> GetGameTypesAsync();
        Task<GameType> GetGameTypeByIdAsync(Guid gameTypeId);
        Task<GameSession> CreateGameSessionAsync(Guid hostId, Guid guestId);
        Task<bool> UpdateSessionTimeAsync(Guid gameSessionId, bool isStart);  // If 'isStart' is true,that means game just startet,if 'isStart' false,that means game is finished
        Task<bool> SaveGameMoveAsync(Move move);
        Task<GamePlayerStat> GetGamePlayerStatByPlayerAndGameIdAsync(Guid playerId, Guid gameTypeId);
        Task<GamePlayerStat> CreateGamePlayerStats(Guid gameTypeId, Guid playerId);
        Task<bool> UpdateGamePlayerStatsAsync(Guid playerId, Guid gameTypeId, int lvl, double points);
        Task<bool> CreateGameResultAsync(Guid sessionId,Guid gamePlayerStats,Guid gameTypeId,Guid playerId, Guid opponentId,bool isWinner);
        Task<GameResult> GetGameResultBySessionIdAsync(Guid sessionId);
        Task<bool> Save();



    }
}
