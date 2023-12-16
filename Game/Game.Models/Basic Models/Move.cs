using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Models
{
    public class Move
    {
        public Guid Id { get; set; }
        public Guid GameSessionId { get; set; }
        public int MoveNumber { get; set; }
        public string MoveDetails { get; set; }

        [ForeignKey("GameSessionId")]
        public virtual GameSession GameSession { get; set; }
    }
}
