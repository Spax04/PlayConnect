using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Models.Models
{
    public class Solider
    {
        public int Point { get; set; }
        public int SpikeId { get; set; }
        public int NumOfSteps { get; set; }
        public bool Active { get; set; } = true;
        public PlayerColor Color { get; set; }

        public Solider()
        {
            Point = 1;
            Active = true;
        }
    }

    public enum PlayerColor
    {
        Black,
        White,
        NoColor
    };
}
