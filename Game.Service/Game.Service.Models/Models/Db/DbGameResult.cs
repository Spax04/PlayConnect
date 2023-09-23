using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Models.Models.Db
{
    public class DbGameResult
    {
        public Guid GameId { get; set; }
        public Guid DbPlayerId { get; set; }
        public bool HasWon { get; set; }
        public Guid ComponentsID { get; set; }
    }
}
