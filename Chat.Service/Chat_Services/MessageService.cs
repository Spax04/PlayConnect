using Chat_DAL.Repositories.interfaces;
using Chat_Models.Models;
using Chat_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Services
{
    public class MessageService : IMessageService
    {
        readonly IMessageRepository _messageRepo;
        public MessageService(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }
        public async Task<Message> AddMessage(Guid senderId, Guid recipientId, string newMessage, DateTime sentAt)
        {
            var message = await _messageRepo.CreateMessageAsync(senderId, recipientId, newMessage, sentAt);
            return message;
        }

        public async Task<IEnumerable<Message>> GetConversation(Guid chatter1Id, Guid chatter2Id)
        {
            var chatter1Messages = await _messageRepo.GetMessagesAsync(chatter1Id, chatter2Id);
            var chatter2Messages = await _messageRepo.GetMessagesAsync(chatter2Id, chatter1Id);

            var orderedConversation = chatter1Messages.Concat(chatter2Messages).ToList();
            return orderedConversation;
        }

        public async Task<Message> GetMessage(Guid messageId, Guid recipientId)
        {
            var message = await _messageRepo.GetMessageAsync(messageId);
            if (message.RecipientId != recipientId)
                return null;

            return message;
        }

        public async Task SetAsRecived(Guid messageId, Guid recipientId, DateTime recivedAt)
        {
            var message = await _messageRepo.GetMessageAsync(messageId);
            if (message.RecipientId != recipientId)
                return;

            await _messageRepo.SetMessageReceivedAsync(messageId, recivedAt);
        }
    }
}
