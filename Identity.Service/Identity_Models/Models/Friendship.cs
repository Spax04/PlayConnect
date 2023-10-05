using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity_Models.Models
{
    public class Friendship
    {
        [Key]
        public Guid FriendshipId { get; set; }

        [ForeignKey("Sender")]
        public Guid SenderId { get; set; }
        public User Sender { get; set; }

        [ForeignKey("Reciever")]
        public Guid RecieverId { get; set; }
        public User Reciever { get; set; }
        public bool IsAccepted { get; set; }

    }
}
