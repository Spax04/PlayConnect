using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Models.Models
{
    public class GameResult
    {
        public Guid GameId { get; set; }
        public Guid WinnerId { get; set; }
        public Guid LosserId { get; set; }
    }
}
