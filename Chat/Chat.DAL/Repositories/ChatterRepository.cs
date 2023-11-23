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
    public class ChatterRepository : IChatterRepository
    {
        private readonly DataContext _context;
        public ChatterRepository(DataContext chatterContext)
        {
            _context = chatterContext;
        }
        // FINISHED
        public async Task<Chatter> AddChatterAsync(Guid chatterId, string name)
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
        
        // FINISHED
        //

        public async Task<bool> IsChatterExistAsync(Guid chatterId)
        {
            Chatter chatter = await _context.Chatters!.Where(c => c.Id == chatterId).FirstOrDefaultAsync();
            return chatter == null? false : true;
        }

        public async Task<Response> IsChatterConnectedAsync(Guid chatterId)
        {
            var chatter = await _context.Chatters!.Where(c => c.Id == chatterId).FirstOrDefaultAsync();
            if(chatter == null)
            {
                return new Response(false);
            }
            return chatter.IsConnected? new Response(true) : new Response(false);
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

        // FINISHED

        public async Task SetConnectedAsync(Guid chatterId)
        {
            var chatter = await _context!.Chatters!.Where(c => c.Id == chatterId).FirstOrDefaultAsync();
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
