using Chat_Models.Helpers;
using Chat_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_DAL.Repositories.interfaces
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
