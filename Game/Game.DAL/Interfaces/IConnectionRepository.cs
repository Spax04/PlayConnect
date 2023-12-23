using Game.Models.Models;

namespace Game.DAL.Interfaces
{
    public interface IConnectionRepository
    {
        Task<Connection> CreateConnectionAsync(string connection, Guid playerId);
        Task<IEnumerable<Connection>> GetAllConnectionsByPlayerId(Guid playerId);
    }
}
