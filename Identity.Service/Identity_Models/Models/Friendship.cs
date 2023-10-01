using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_Models.Models
{
    public class Friendship
    {
        [Key]
        public Guid FriendshipId { get; set; }

        [ForeignKey("User1")]
        public Guid User1Id { get; set; }
        public User User1 { get; set; }

        [ForeignKey("User2")]
        public Guid User2Id { get; set; }
        public User User2 { get; set; }
    }
}
