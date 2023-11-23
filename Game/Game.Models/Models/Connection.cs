using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Models
{
    public class Connection
    {
        [Key]
        public string ConnectionId { get; set; }
        public Guid PlayerId { get; set; }
        public bool IsClosed { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player? Player { get; set; }
        public ICollection<GameRes>
    }
}
