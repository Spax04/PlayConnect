using Chat.Models.Helpers;
using Chat.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Services.Interfaces
{
    public interface IConnectionService
    {
        Task<Chatter> GetOrAddChatterAsync(Guid chaterId, string name);
        Task<DateTime> GetLastSeenAsync(Guid chatterId);
        Task<Chatter> GetChatterAsync(Guid chatterId);
        Task<bool> ConnectChatterAsync(Guid chatterId, string chatId);
        Task<bool> DisconnectChatterAsync(Guid chatter, string chatId);
        Task<IEnumerable<Chatter>> GetChattersAsync(Guid chatId);
        void CloseAllConnectionsAsync();
    }
}
