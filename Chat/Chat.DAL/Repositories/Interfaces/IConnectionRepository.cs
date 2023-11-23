using Chat.Models.Helpers;
using Chat.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DAL.Repositories.Interfaces
{
    public interface IConnectionRepository
    {
        Task<Connection> CreateConnectionAsync(string chatId, Guid chatterId);
        Task<IEnumerable<Connection>> GetAllConnectionsByUserIdAsync(Guid chatterId);
        Task<Connection> GetChatByIdAsync(string connectionId);       
        Task<Connection> GetConnectionByUserIdAsync(Guid userId);       
        void CloseConnectionAsync(string ChatId, DateTime endedAt);
        void CloseAllConnections();
        bool CheckReconnectConnection(Guid chatterId);

    }
}
