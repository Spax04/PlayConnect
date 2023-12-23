using Chat.Models.Models;

namespace Chat.DAL.Interfaces
{
    public interface IChatterRepository
    {
        Task<Chatter> CreateChatterAsync(Guid chatterId, string name);
        Task<Chatter> GetChatterAsync(Guid chatterId);
        Task<Chatter> GetOrCreateChatterAsync(Guid chaterId, string name);
        Task<IEnumerable<Chatter>> GetChattersAreOnlineAsync(Guid selChatterId);

    }
}
