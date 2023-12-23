using Chat.DAL.Data;
using Chat.DAL.Interfaces;
using Chat.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace Chat.DAL.Repositories
{
    public class ConnectionRepository : IConnectionRepository
    {
        private DataContext _context;
        public ConnectionRepository(DataContext context)
        {
            _context = context;
        }

        // FINISHED
        public async Task<Connection> CreateConnectionAsync(string connectionId, Guid chatterId)
        {
            Connection newConnection = new Connection
            {
                ConnectionId = connectionId,
                ChatterId = chatterId,
                StartedAt = DateTime.Now,
                IsClosed = false
            };
            _context!.Connections!.Add(newConnection);
            _context!.SaveChanges();

            return newConnection;
        }

        public async Task<Connection> GetConnectionByIdAsync(string chatId)
        {
            var chat = await _context!.Connections!.FirstOrDefaultAsync(c => c.ConnectionId == chatId);
            if (chat == null)
                throw new ArgumentException("Not Found");

            return new Connection
            {
                ConnectionId = chat.ConnectionId,
                ChatterId = chat.ChatterId!,
                IsClosed = chat.IsClosed,
                StartedAt = chat.StartedAt,
                EndedAt = chat.EndedAt
            };
        }

        public async Task<IEnumerable<Connection>> GetAllConnectionsByUserIdAsync(Guid chatterId)
        {

            var allConnections = await _context!.Connections!.Where(c => c.ChatterId == chatterId).ToListAsync();

            return allConnections;
        }

        public Task<Connection> GetChatByIdAsync(string chatId)
        {
            throw new NotImplementedException();
        }

        public async Task<Connection> GetConnectionByUserIdAsync(Guid userId)
        {
            Connection connection = await _context.Connections!.Where(c => c.ChatterId == userId && c.IsClosed == false).FirstOrDefaultAsync();

            return connection;
        }
    }
}
