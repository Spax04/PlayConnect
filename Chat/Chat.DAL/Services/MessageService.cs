using Chat.DAL.Data;
using Chat.DAL.Interfaces;

namespace Chat.DAL.Services
{
    public class MessageService : IMessageService
    {
        private readonly DataContext _context;

        public MessageService(DataContext context)
        {
            _context = context;
        }



        public async Task SetMessageReceivedAsync(Guid messageId)
        {
            var message = await _context!.Messages!.FindAsync(messageId);
            if (message == null)
                throw new ArgumentException("Not Found");

            message.IsReceived = true;
            message.ReceivedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }
}
