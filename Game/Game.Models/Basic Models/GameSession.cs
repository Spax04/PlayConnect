using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game.Models.Models
{
    public class GameSession
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HostId { get; set; }
        public Guid GuestId { get; set; }

        [ForeignKey("HostId")]
        public Player? Host { get; set; }

        [ForeignKey("GuestId")]
        public virtual Player? Guest { get; set; }

        public bool IsFinished { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ICollection<Move> Moves { get; set; }

    }
}
