using Chat_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Services.Interfaces
{
    public interface IMessageService
    {
        Task<Message> AddMessage(Guid senderId, Guid RecipientId, string NewMessage, DateTime SentAt);
        Task<Message> GetMessage(Guid messageId, Guid recipientId);
        Task SetAsRecived(Guid messageId, Guid recipientId, DateTime recivedAt);
        Task<IEnumerable<Message>> GetConversation(Guid chatter1Id, Guid chatter2Id);
    }
}
