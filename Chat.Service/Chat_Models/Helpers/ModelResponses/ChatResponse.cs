using Chat_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Models.Helpers.ModelResponses
{
    public class ChatResponse : Response
    {
        public ChatResponse() : base(true)
        {
        }
        public Guid? ChatId { get; set; }
        //public List<Message>? ChatHistory { get; set; }
        //public string? NewMessage { get; set; }
        public Guid Chatter1Id { get; set; }
        public Guid Chatter2Id { get; set; }
        public bool IsClosed { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
    }
}
