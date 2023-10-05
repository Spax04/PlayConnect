using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity_Models.Models
{
    public class Friendship
    {
        [Key]
        public Guid FriendshipId { get; set; }

        [ForeignKey("User1")]
        public Guid User1Id { get; set; }
        public User User1 { get; set; }
        public bool User1Accepted { get; set; }

        [ForeignKey("User2")]
        public Guid User2Id { get; set; }
        public User User2 { get; set; }
        public bool User2Accepted { get; set; }

    }
}
