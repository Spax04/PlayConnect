using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_Models.Dto.Responses
{
    public class ChatterResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsConnected { get; set; }
        public DateTime LastSeen { get; set; }
    }
}
