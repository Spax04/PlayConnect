using System.ComponentModel.DataAnnotations.Schema;

namespace Game.Models.Models
{
    public class Move
    {
        public Guid Id { get; set; }
        public Guid GameSessionId { get; set; }
        public int MoveNumber { get; set; }
        public Guid GameTypeId { get; set; }
        public string MoveHistoryJson { get; set; }

        [ForeignKey("GameTypeId")]
        public GameType GameType { get; set; }

        [ForeignKey("GameSessionId")]
        public virtual GameSession GameSession { get; set; }
    }
}
