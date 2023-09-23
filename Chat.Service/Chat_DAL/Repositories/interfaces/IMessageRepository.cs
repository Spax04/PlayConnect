using Chat_Models.Helpers;
using Chat_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_DAL.Repositories.interfaces
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessageAsync(Guid senderId, Guid RecipientId, string newMessage, DateTime SentAt);
        Task<IEnumerable<Message>> GetMessagesAsync(Guid senderId, Guid recipientId);
        Task SetMessageReceivedAsync(Guid messageId, DateTime recivedAt);
        Task<Message> GetMessageAsync(Guid messageId);
    }
}
