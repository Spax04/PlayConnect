using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Models.Models
{
    public class BoardSpike
    {
        public int Id { get; set; }
        public List<Solider> SolidersQuantity { get; set; } = new List<Solider>();
        public bool AvailableSpike { get; set; } = true;

        public BoardSpike(int id)
        {
            Id= id;
        }
    }
}
