using Chat.DAL.Data;
using Chat.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly DataContext _context;
        private IChatterRepository _chatterRepository;
        private IConnectionRepository _connectionRepository;
        private IChatterService _chatterService;

        public ConnectionService
        (
            DataContext context,
            IChatterRepository chatterRepository,
            IConnectionRepository connectionRepository,
            IChatterService chatterService
        )
        {
            _context = context;
            _chatterRepository = chatterRepository;
            _connectionRepository = connectionRepository;
            _chatterService = chatterService;
        }
        public async Task<bool> CheckReconnectConnectionAsync(Guid chatterId)
        {
            var connection = await _context.Connections.FirstOrDefaultAsync(c => c.ChatterId == chatterId);

            if (connection == null)
            {
                return false;
            }
            _context.Connections.Remove(connection);
            return await Save(); ;
        }

        public async Task CloseConnectionAsync(string connectionId)
        {
            var connection = await _context.Connections.FindAsync(connectionId);
            if (connection == null)
                throw new ArgumentException("Not Found");

            connection.IsClosed = true;
            connection.EndedAt = DateTime.Now;
            await Save();
        }

        public async Task CloseAllConnectionsAsync()
        {
            await foreach (var chat in _context!.Connections!)
            {
                if (!chat.IsClosed)
                {
                    chat.IsClosed = true;
                    chat.EndedAt = DateTime.Now;
                }
            }
            await Save();
        }

        public async Task<bool> ConnectChatterAsync(Guid chatterId, string connectionId)
        {
            // var reconect = _chatRepo.CheckReconnectConnection(chatterId);
            var chatter = await _chatterRepository.GetChatterAsync(chatterId);

            if (chatter == null)
                return false;

            await _connectionRepository.CreateConnectionAsync(connectionId, chatterId);
            await _chatterService.SetChetterConnectedAsync(chatterId);

            return true;
        }


        public async Task<bool> DisconnectChatterAsync(Guid chatter, string connectionId)
        {
            await CloseConnectionAsync(connectionId);
            var connections = await _connectionRepository.GetAllConnectionsByUserIdAsync(chatter);
            if (!connections.Any(c => !c.IsClosed))
            {
                await _chatterService.SetChetterDisconnectedAsync(chatter);
                return true;
            }
            return false;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
