using System.ComponentModel.DataAnnotations.Schema;

namespace Game.Models.Models
{
    public class GameResult
    {
        public Guid Id { get; set; }
        public Guid GameSessionId { get; set; }
        public Guid GamePlayerStatsId { get; set; }
        public bool IsWinner { get; set; }
        public int Score { get; set; }

        [ForeignKey("GameSessionId")]
        public virtual GameSession GameSession { get; set; }

        [ForeignKey("GamePlayerStatsId")]
        public virtual GamePlayerStat GamePlayerStats { get; set; }

    }
}
