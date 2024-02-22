using System.ComponentModel.DataAnnotations.Schema;

namespace Game.Models.Models
{
    public class GameResult
    {
        public Guid Id { get; set; }
        public Guid GameSessionId { get; set; }
        public Guid GamePlayerStatsId { get; set; }
        public Guid GameTypeId { get; set; }
        public Guid PlayerId { get; set; }
        public Guid OpponentId { get; set; }
        public bool IsWinner { get; set; }
        public DateTime PlayedAt { get; set; }

        [ForeignKey("GameSessionId")]
        public virtual GameSession GameSession { get; set; }

        [ForeignKey("GamePlayerStatsId")]
        public virtual GamePlayerStat GamePlayerStats { get; set; }

        [ForeignKey("GameTypeId")]
        public virtual GameType GameType { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Winner { get; set; }

        [ForeignKey("OpponentId")]
        public virtual Player Loser { get; set; }

    }
}
