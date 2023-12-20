using Game.DAL.Data;
using Game.DAL.Interfaces;
using Game.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Game.DAL.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly DataContext _context;
        private IPlayerRepository _playerRepository;
        private IConnectionRepository _connectionRepository;
        public ConnectionService(DataContext context, IPlayerRepository playerRepository,IConnectionRepository connectionRepository)
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

        public Task<bool> DisconnectPlayerAsync(Guid playerId, string connectionId)
        {
            _chatRepo.CloseConnectionAsync(connectionId, DateTime.Now);
            var connections = await _chatRepo.GetAllConnectionsByUserIdAsync(chatter);
            if (!connections.Any(c => !c.IsClosed))
            {
                await _chatterRepo.SetDisconnectedAsync(chatter);
                return true;
            }
            return false;
        }

        public Task CloseConnectionAsync(string ChatId, DateTime endedAt)
        {
            var connection = _context?.Connections?.Find(connectionId);
            if (connection == null)
                throw new ArgumentException("Not Found");

            connection.IsClosed = true;
            connection.EndedAt = endedAt;
            _context!.SaveChanges();
        }
    }
}
