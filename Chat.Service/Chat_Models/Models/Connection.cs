using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat_Models.Models
{
    public class Connection
    {
        [Key]
        public string ConnectionId { get; set; }
        public Guid ChatterId { get; set; }
        public bool IsClosed { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }

        [ForeignKey("ChatterId")]
        public virtual Chatter? Chatter { get; set; }
        public virtual ICollection<Message>? Messages { get; set; }

    }
}