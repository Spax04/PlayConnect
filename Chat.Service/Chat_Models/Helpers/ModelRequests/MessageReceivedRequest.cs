using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Models.Helpers.ModelRequests
{
    public class MessageReceivedRequest
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string MessageId { get; set; }
    }
}
