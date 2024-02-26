using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Dto.Responses
{
    public class ReconnectedResponse
    {
        public Guid GameSessionId { get; set; }
        public Guid GameTypeId { get; set; }
        public int GameLevel { get; set; }
        public double GamePoints { get; set; }
    }
}
