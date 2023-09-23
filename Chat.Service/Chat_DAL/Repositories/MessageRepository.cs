using Chat_DAL.Data;
using Chat_DAL.Repositories.interfaces;
using Chat_Models.Helpers;
using Chat_Models.Helpers.ModelResponses;
using Chat_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        readonly DataContext _context;
        public MessageRepository(DataContext context)
        {
            _context= context;
        }

        // FINISHED
        private Message CreateMessage(Guid senderId, Guid recipientId, string newMessage, DateTime sentAt)
        {

            if (newMessage == null)
                throw new ArgumentException("Not Found");

            var Message = new Message
            {
                SenderId = senderId,
                RecipientId = recipientId,
                NewMessage = newMessage,
                SentAt = sentAt
            };
            _context!.Messages!.Add(Message);
            _context.SaveChanges();

            return Message;
        }
        public async Task<Message> CreateMessageAsync( Guid senderId, Guid RecipientId, string newMessage, DateTime SentAt) => await Task.Run(() => CreateMessage(senderId, RecipientId, newMessage, SentAt));

        // FINISHED
        private Message GetMessage(Guid messageId)
        {
            var message = _context!.Messages!.Find(messageId);
            if (message == null)
                throw new ArgumentException("Not Found");

            return new Message
            {
                MessageeID = message.MessageeID,
                SenderId = message.SenderId,
                RecipientId = message.RecipientId,
                NewMessage = message.NewMessage,
                SentAt = message.SentAt
            };
        }
        public async Task<Message> GetMessageAsync(Guid messageId) => await Task.Run(() => GetMessage(messageId));
        // FINISHED
        public Task<IEnumerable<Message>> GetMessagesAsync(Guid senderId, Guid recipientId)
        {
            return Task.FromResult<IEnumerable<Message>>(_context!.Messages!.Where(message => message.SenderId == senderId && message.RecipientId == recipientId).Select(m => new Message
            {
                MessageeID = m.MessageeID,
                SenderId = m.SenderId,
                RecipientId = m.RecipientId,
                NewMessage = m.NewMessage,
                IsReceived = m.IsReceived,
                SentAt = m.SentAt,
                ReceivedAt = m.ReceivedAt
            }).ToList());
        }

        // FINISHED
        public async Task SetMessageReceivedAsync(Guid messageId, DateTime recivedAt) 
        {
            var message = await _context!.Messages!.FindAsync(messageId);
            if (message == null)
                throw new ArgumentException("Not Found");

            message.IsReceived = true;
            message.ReceivedAt = recivedAt;
            await _context.SaveChangesAsync();
        }
    }
}
