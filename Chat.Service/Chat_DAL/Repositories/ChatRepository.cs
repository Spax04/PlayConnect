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
    public class ConnectionRepository : IChatRepository
    {
        private DataContext _context;
        public ConnectionRepository(DataContext context)
        {
            _context = context;
        }

        // FINISHED
        public Connection CreateConnection(string connectionId, Guid chatterId, DateTime startedAt)
        {
            Connection newConnection = new Connection
            {
                ConnectionId = connectionId,
                ChatterId = chatterId,
                StartedAt = startedAt,
                IsClosed = false
            };
            _context!.Connections!.Add(newConnection);
            _context!.SaveChanges();

            return newConnection;
        }
        public async Task<Connection> CreateChatConnectionAsync(string chatId, Guid chatterId, DateTime startedAt) => await Task.Run(() => CreateConnection(chatId,  chatterId,   startedAt));

        // FINISHED

        public bool CheckReconnectConnection( Guid chatterId)
        {
            var connection = _context.Connections.FirstOrDefault(c => c.ChatterId == chatterId);

            if(connection == null)
            {
                return false;
            }
            _context.Connections.Remove(connection);
            _context.SaveChanges();
            return true;
        }

        // FINISHED
        private Connection GetConnectionById(string chatId)
        {
            var chat = _context!.Connections!.FirstOrDefault(c => c.ConnectionId == chatId);
            if(chat == null)
                throw new ArgumentException("Not Found");

            return new Connection
            {
                ConnectionId = chat.ConnectionId,
                ChatterId = chat.ChatterId!,
                IsClosed= chat.IsClosed,
                StartedAt = chat.StartedAt,
                EndedAt = chat.EndedAt
            };
        }
        public async Task<Connection> GetConnectionByIdAsync(string chatId) => await Task.Run(() => GetConnectionById(chatId));

        // FINISHED
        private IEnumerable<Connection> GetAllChatsByUserId(Guid chatterId)
        {

            var allConnections = _context!.Connections!.Where(c => c.ChatterId == chatterId).ToList();

            return allConnections;               
        }
        public async Task<IEnumerable<Connection>> GetAllConnectionsByUserIdAsync(Guid chatterId) => await Task.Run(() => GetAllChatsByUserId(chatterId));


        public void CloseConnectionAsync(string connectionId, DateTime endedAt)
        {
            var connection = _context?.Connections?.Find(connectionId);
            if (connection == null)
               throw new ArgumentException("Not Found");

            connection.IsClosed = true;
            connection.EndedAt = endedAt;
            _context!.SaveChanges();
        }

        public void CloseAllConnections()
        {
            foreach(var chat in _context!.Connections!)
            {
                if (!chat.IsClosed)
                {
                    chat.IsClosed = true;
                    chat.EndedAt = DateTime.Now;
                }
            }
            _context.SaveChanges();
        }

        public Task<Connection> GetChatByIdAsync(string chatId)
        {
            throw new NotImplementedException();
        }
    }
}
