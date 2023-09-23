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
    public class ChatterRepository : IChatterRepository
    {
        private readonly DataContext _context;
        public ChatterRepository(DataContext chatterContext)
        {
            _context = chatterContext;
        }
        // FINISHED
        private Chatter AddChatter(Guid chatterId, string name)
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
        public async Task<Chatter> AddChatterAsync(Guid chatterId, string name) => await Task.Run(() => AddChatter(chatterId, name));
        
        // FINISHED
        //

        public bool isChatterExistAsync(Guid chatterId)
        {
            var chatter = _context.Chatters!.Find(chatterId);
            if (chatter == null)
                return false;
            else
                return true;
        }

        private async Task<Chatter> GetChatter(Guid chatterId)
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
        public async Task<Chatter> GetChatterAsync(Guid chatterId) => await Task.Run(() => GetChatter(chatterId));

        // Return all chatter who's connected exept self user
        private IEnumerable<Chatter> GetChattersAreOnline(Guid chatterId)
        {
            return _context!.Chatters!.Where(x => x.IsConnected == true && x.Id != chatterId).ToList();
        }
        public async Task<IEnumerable<Chatter>> GetChattersAreOnlineAsync(Guid chatterId) => await Task.Run(() => GetChattersAreOnline(chatterId));

        // FINISHED

        public async Task SetConnectedAsync(Guid chatterId)
        {
            var chatter = await _context!.Chatters!.FindAsync(chatterId);
            if (chatter == null)
                throw new ArgumentException("Not Found");

            chatter.IsConnected = true;
            await _context.SaveChangesAsync();
        }

        // FINISHED

        public async Task SetDisconnectedAsync(Guid chatterId)
        {
            var chatter = await _context!.Chatters!.FindAsync(chatterId);
            if (chatter == null)
                throw new ArgumentException("Not Found");

            chatter.IsConnected = false;
            await _context.SaveChangesAsync();
        }


    }
}
