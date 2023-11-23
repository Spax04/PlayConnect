using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game.Models.Models
{
    public class GameSession
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }

        [ForeignKey("Player1Id")]
        public Player? Player1 { get; set; }

        [ForeignKey("Player2Id")]
        public Player? Player2 { get; set; }

        public bool IsFinished { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
