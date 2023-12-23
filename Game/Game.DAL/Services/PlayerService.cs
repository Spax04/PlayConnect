using Game.DAL.Data;
using Game.DAL.Interfaces;
using Game.Models.Models;

namespace Game.DAL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly DataContext _context;
        public PlayerService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> IsPlayerExistAsync(Guid playerId)
        {
            Player player = await _context.Players!.FindAsync(playerId);

            return player != null ? true : false;
        }
    }
}
