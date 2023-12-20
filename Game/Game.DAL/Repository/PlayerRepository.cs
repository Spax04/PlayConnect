using Game.DAL.Data;
using Game.DAL.Interfaces;
using Game.Models.Models;

namespace Game.DAL.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
       private readonly DataContext _context;
        private IPlayerService _playerService;
        public PlayerRepository(DataContext context, IPlayerService playerService)
        {
            _context = context;
            _playerService = playerService;
        }

        public async Task<Player?> CreatePlayerAsync(Guid playerId)
        {
            Player player = new Player() { Id = playerId, InGame = false };
            _context.Players.Add(player);

            if (await Save())
            {
                return player;
            }

            return null;
        }

        public async Task<Player> GetOrCreatePlayerAsync(Guid playerId)
        {
            if (!(await _playerService.IsPlayerExistAsync(playerId)))
            {
                await CreatePlayerAsync(playerId);
            }
            return await GetPlayerAsync(playerId);
        }

        public async Task<Player> GetPlayerAsync(Guid playerId) => await _context.Players!.FindAsync(playerId);

       

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
