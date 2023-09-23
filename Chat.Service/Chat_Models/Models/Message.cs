using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Models.Models
{
    public class Message
    {
        [Key]
        public Guid MessageeID { get; set; }
        public string ConnectionID { get; set; }
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
        public string? NewMessage { get; set; }
        public bool IsReceived { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime ReceivedAt { get; set; }


        [ForeignKey("ChatID")]
        public virtual Connection Connection { get; set; }

        [ForeignKey("SenderId")]
        public virtual Chatter Sender { get; set; }

        [ForeignKey("RecipientId")]
        public virtual Chatter Recipient { get; set; }
    }
}
