using Game.DAL.Data;
using Game.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DAL.Services
{
    public class PlayerService
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
