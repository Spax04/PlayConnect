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
        Task<Connection> CreateConnectionAsync(string connection, Guid playerId);
    }
}
