using Game.Models.Dto.Requests;
using Game.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DAL.Interfaces
{
    public interface IGameRepository
    {
        Task CreateGameTypeAsync(GameTypeCreateRequest gameType);
        Task<IEnumerable<GameType>> GetGameTypesAsync();
        Task<GameSession> CreateGameSessionAsync(Guid hostId, Guid guestId);
        Task<bool> UpdateSessionTimeAsync(Guid gameSessionId,bool isStart); // If 'isStart' is true,that means game just startet,if 'isStart' false,that means game is finished

    }
}
