using Game.DAL.Data;
using Game.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Game.DAL.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly DataContext _context;
        private IPlayerRepository _playerRepository;
        private IConnectionRepository _connectionRepository;
        public ConnectionService(DataContext context, IPlayerRepository playerRepository, IConnectionRepository connectionRepository)
        {
            _context = context;
            _playerRepository = playerRepository;
            _connectionRepository = connectionRepository;
        }

        public async Task<bool> ConnectPlayerAsync(Guid playerId, string connectionId)
        {
            // var reconect = _chatRepo.CheckReconnectConnection(chatterId);
            var player = await _playerRepository.GetPlayerAsync(playerId);

            if (player == null)
                return false;

            await _connectionRepository.CreateConnectionAsync(connectionId, playerId);
            await SetPlayerConnectedAsync(playerId);

            return true;
        }

        public async Task SetPlayerConnectedAsync(Guid playerId)
        {
            var player = await _context!.Players!.Where(c => c.Id == playerId).FirstOrDefaultAsync();
            if (player == null)
                throw new ArgumentException("Not Found");

            player.InGame = true;
            await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> DisconnectPlayerAsync(Guid playerId, string connectionId)
        {
            bool isClosed = await CloseConnectionAsync(connectionId, DateTime.Now);
            var connections = await _connectionRepository.GetAllConnectionsByPlayerId(playerId);
            if (!connections.Any(c => !c.IsClosed))
            {
                return await SetPlayerDisconnectedAsync(playerId);
            }
            return false;
        }

        public async Task<bool> CloseConnectionAsync(string connectionId, DateTime endedAt)
        {
            var connection = await _context.Connections.FindAsync(connectionId);
            if (connection == null)
                throw new ArgumentException("Not Found");

            connection.IsClosed = true;
            connection.EndedAt = endedAt;
            return await Save();
        }

        public async Task<bool> SetPlayerDisconnectedAsync(Guid playerId)
        {
            var chatter = await _context!.Players!.FindAsync(playerId);
            if (chatter == null)
                throw new ArgumentException("Not Found");

            chatter.InGame = false;
            return await Save();
        }
    }
}
