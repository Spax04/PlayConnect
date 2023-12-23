using Chat.Models.Models;

namespace Chat.DAL.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessageAsync(Guid senderId, Guid RecipientId, string newMessage);
        Task<IEnumerable<Message>> GetUserMessagesBetween(Guid user1, Guid user2);
    }
}
