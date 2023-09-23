using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Models.Models
{
    public class Chatter
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsConnected { get; set; }
        public DateTime LastSeen { get; set; }
        public virtual ICollection<Connection>? Connections { get; set; }
    }
}
