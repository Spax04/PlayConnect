using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Dto.Requests
{
    public class GameOverRequest
    {
        public string GameSessionId { get; set; }
        public string GameTypeId { get; set; }
        public string PlayerId { get; set; }
        public string OpponentId { get; set;}
        public int NewLevel { get; set; }
        public double NewPoints { get; set; }
        public bool IsWinner { get; set; }
    }
}
