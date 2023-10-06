using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity_Models.Models
{
    public class Friendship
    {
        [Key]
        public Guid FriendshipId { get; set; }

        public Guid SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public Guid RecieverId { get; set; }
        [ForeignKey("RecieverId")]
        public User Reciever { get; set; }

        public bool IsAccepted { get; set; }

    }
}
