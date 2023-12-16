using Game.DAL.Data;
using Game.DAL.Interfaces;
using Game.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DAL.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly DataContext _context;
        public ConnectionService(DataContext context)
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

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
