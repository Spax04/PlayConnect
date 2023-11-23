using Chat.Models.Helpers;
using Chat.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DAL.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessageAsync(Guid senderId, Guid RecipientId, string newMessage);
        Task SetMessageReceivedAsync(Guid messageId);
        Task<IEnumerable<Message>> UserMessagesBetween(Guid user1,Guid user2);
    }
}
