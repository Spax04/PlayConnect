using Game.Service.Models.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Models.Models.Player
{
    public class Player
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string ConnectionId { get; set; }
        public List<DbGameResult> GameHistory { get; set; }

        public Player(Guid id, string userName, string connectionId, List<DbGameResult> games)
        {
            Id = id;
            UserName = userName;
            ConnectionId = connectionId;
            GameHistory = games;
        }
    }
    
}
