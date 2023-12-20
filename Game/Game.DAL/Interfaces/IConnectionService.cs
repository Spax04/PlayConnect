using Game.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DAL.Interfaces
{
    public interface IConnectionService
    {
        Task<bool> ConnectPlayerAsync(Guid playerId, string connectionId);
        Task CloseConnectionAsync(string ChatId, DateTime endedAt);
        Task SetPlayerConnectedAsync(Guid playerId);
        Task<bool> DisconnectPlayerAsync(Guid playerId, string connectionId);
    }
}
