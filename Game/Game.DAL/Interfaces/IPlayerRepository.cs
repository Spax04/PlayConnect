using Game.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DAL.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player> GetOrCreatePlayerAsync(Guid playerId);
        Task<Player> CreatePlayerAsync(Guid playerId);
        Task<Player> GetPlayerAsync(Guid playerId);
    }
}
