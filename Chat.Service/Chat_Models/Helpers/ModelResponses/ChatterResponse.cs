using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Models.Helpers.ModelResponses
{
    public class ChatterResponse : Response
    {
        public ChatterResponse() : base(true)
        {
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsConnected { get; set; }
        public DateTime LastSeen { get; set; }
    }
}
