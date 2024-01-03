using Game.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Dto.Requests
{
    public class InviteRequest
    {
        public string? FriendId { get; set; }
        public GameType GameType { get; set; }
    }
}
