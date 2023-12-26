using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Dto.Requests
{
    public class NewGameRequest
    {
        public string HostId { get; set; }
        public string GuestId { get; set; }
    }
}
