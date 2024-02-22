using Game.Models.Models;

namespace Game.DAL.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player> GetOrCreatePlayerAsync(Guid playerId);
        Task<Player> CreatePlayerAsync(Guid playerId);
        Task<Player> GetPlayerAsync(Guid playerId);
        Task<bool> Save();
    }
}
