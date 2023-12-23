using Chat.DAL.Data;
using Chat.DAL.Interfaces;
using Chat.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        readonly DataContext _context;
        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Message> CreateMessageAsync(Guid senderId, Guid recipientId, string newMessage)
        {
            if (newMessage == null)
                throw new ArgumentException("Not Found");

            var Message = new Message
            {
                SenderId = senderId,
                RecipientId = recipientId,
                NewMessage = newMessage,
                SentAt = DateTime.Now
            };
            await _context!.Messages!.AddAsync(Message);

            if (!(await Save()))
            {
                throw new ArgumentException("On Data Base save error");
            }
            return Message;
        }



        public async Task<IEnumerable<Message>> GetUserMessagesBetween(Guid user1, Guid user2)
        {
            IEnumerable<Message> messages = await _context.Messages!
                .Where(m => (m.RecipientId == user1 && m.SenderId == user2) || (m.RecipientId == user2 && m.SenderId == user1))
                .ToListAsync();

            return messages;

        }


        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
