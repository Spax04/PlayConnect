using Chat.DAL.Data;
using Chat.DAL.Repositories.Interfaces;
using Chat.Models.Helpers;
using Chat.Models.Helpers.ModelResponses;
using Chat.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        public async Task<Connection> GetConnectionByIdAsync(string chatId)
        {
            var chat = await _context!.Connections!.FirstOrDefaultAsync(c => c.ConnectionId == chatId);
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

        public async Task<Connection> GetConnectionByUserIdAsync(Guid userId)
        {
            Connection connection = await _context.Connections!.Where(c => c.ChatterId == userId && c.IsClosed == false).FirstOrDefaultAsync();

            return connection;
        }
    }
}
