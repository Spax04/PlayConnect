using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Models
{
    public class GameResult
    {
        public Guid Id { get; set; }
        public Guid GameSessionId { get; set; }
        public Guid GamePlayerStatsId { get; set; }

        [ForeignKey("GameSessionId")]
        public GameSession GameSession { get; set; }

        [ForeignKey("GamePlayerStatsId")]
        public GamePlayerStats GamePlayerStats { get; set; }
    }
}
