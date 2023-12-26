using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Dto.Requests
{
    public class UpdateSessionTimeRequest
    {
        public string SessionId { get; set; }
        public bool isStarted { get; set; }
    }
}
