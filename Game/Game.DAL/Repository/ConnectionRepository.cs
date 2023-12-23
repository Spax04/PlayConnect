using Game.DAL.Data;
using Game.DAL.Interfaces;
using Game.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Game.DAL.Repository
{
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly DataContext _context;
        public ConnectionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Connection> CreateConnectionAsync(string connectionId, Guid playerId)
        {
            Connection newConnection = new Connection
            {
                ConnectionId = connectionId,
                PlayerId = playerId,
                StartedAt = DateTime.Now,
                IsClosed = false
            };
            _context!.Connections!.Add(newConnection);
            await Save();

            return newConnection;
        }

        public async Task<IEnumerable<Connection>> GetAllConnectionsByPlayerId(Guid playerId)
        {
            var allConnections = await _context!.Connections!.Where(c => c.PlayerId == playerId).ToListAsync();

            return allConnections;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
