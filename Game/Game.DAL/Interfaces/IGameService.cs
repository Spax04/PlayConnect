using Game.Models.Models;

namespace Game.DAL.Interfaces
{
    public interface IGameService
    {

        bool IsStartsFirst();
        Task<Move> ConvertJsonToGameMoveAsync(Guid gameTypeId, string gameMove);
        Task<bool> SetGameSessionFinished(Guid sessionId);
    }
}
