using Chat.Models.Models;

namespace Chat.DAL.Interfaces
{
    public interface IConnectionRepository
    {
        Task<Connection> CreateConnectionAsync(string connectionId, Guid chatterId);
        Task<IEnumerable<Connection>> GetAllConnectionsByUserIdAsync(Guid chatterId);
        Task<Connection> GetChatByIdAsync(string connectionId);
        Task<Connection> GetConnectionByUserIdAsync(Guid userId);



    }
}
