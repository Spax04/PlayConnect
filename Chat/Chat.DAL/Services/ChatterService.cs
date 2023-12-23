using Chat.DAL.Data;
using Chat.DAL.Interfaces;
using Chat.Models.Helpers;
using Chat.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL.Services
{
    public class ChatterService : IChatterService
    {
        private readonly DataContext _context;

        public ChatterService(DataContext context)
        {
            _context = context;
        }


        public async Task<bool> IsChatterExistAsync(Guid chatterId)
        {
            Chatter chatter = await _context.Chatters!.Where(c => c.Id == chatterId).FirstOrDefaultAsync();
            return chatter == null ? false : true;
        }

        public async Task<Response> IsChatterConnectedAsync(Guid chatterId)
        {
            var chatter = await _context.Chatters!.Where(c => c.Id == chatterId).FirstOrDefaultAsync();
            if (chatter == null)
            {
                return new Response(false);
            }
            return chatter.IsConnected ? new Response(true) : new Response(false);
        }

        public async Task SetChetterConnectedAsync(Guid chatterId)
        {
            var chatter = await _context!.Chatters!.Where(c => c.Id == chatterId).FirstOrDefaultAsync();
            if (chatter == null)
                throw new ArgumentException("Not Found");

            chatter.IsConnected = true;
            await _context.SaveChangesAsync();
        }

        // FINISHED

        public async Task SetChetterDisconnectedAsync(Guid chatterId)
        {
            var chatter = await _context!.Chatters!.FindAsync(chatterId);
            if (chatter == null)
                throw new ArgumentException("Not Found");

            chatter.IsConnected = false;
            await _context.SaveChangesAsync();
        }
    }
}
