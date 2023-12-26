using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Dto.Responses
{
    public class InviteResponse
    {
        public string? FriendId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
