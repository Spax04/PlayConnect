using Chat.DAL.Data;
using Chat.DAL.Interfaces;
using Chat.Models.Models;

namespace Chat.DAL.Repositories
{
    public class ChatterRepository : IChatterRepository
    {
        private readonly DataContext _context;
        private IChatterService _chatterService;
        public ChatterRepository(DataContext chatterContext, IChatterService chatterService)
        {
            _context = chatterContext;
            _chatterService = chatterService;
        }
        // FINISHED
        public async Task<Chatter> CreateChatterAsync(Guid chatterId, string name)
        {
            var newChatter = new Chatter()
            {
                Id = chatterId,
                Name = name,
                IsConnected = false
            };
            _context.Chatters!.Add(newChatter);
            _context.SaveChangesAsync();

            return newChatter;
        }

        public async Task<Chatter> GetOrCreateChatterAsync(Guid chatterId, string name)
        {
            if (!(await _chatterService.IsChatterExistAsync(chatterId)))
            {
                await CreateChatterAsync(chatterId, name);
            }

            return await GetChatterAsync(chatterId);
        }

        public async Task<Chatter> GetChatterAsync(Guid chatterId)
        {
            var chatter = _context.Chatters!.Find(chatterId);
            if (chatter == null)
                throw new ArgumentException("Not Found");

            return new Chatter
            {
                Id = (Guid)chatter!.Id!,
                Name = chatter.Name,
                IsConnected = true
            };

        }

        // Return all chatter who's connected exept self user
        public async Task<IEnumerable<Chatter>> GetChattersAreOnlineAsync(Guid chatterId)
        {
            return _context!.Chatters!.Where(x => x.IsConnected == true && x.Id != chatterId).ToList();
        }
    }
}
