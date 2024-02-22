using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Models
{
    public class GamePlayerStat
    {
        public Guid Id { get; set; }
        public Guid GameTypeId { get; set; }
        public Guid PlayerId { get; set; }

        [ForeignKey("GameTypeId")]
        public GameType? GameType { get; set; }

        [ForeignKey("PlayerId")]
        public Player? Player { get; set; }
        public int Level { get; set; }
        public double Points { get; set; }

        public ICollection<GameResult> Results { get; set; }

    }
}
