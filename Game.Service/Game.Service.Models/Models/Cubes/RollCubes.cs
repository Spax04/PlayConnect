using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Models.Models
{
    public class RollCubes
    {
        public int FirstCube { get; set; }
        public int SecondCube { get; set; }

        public bool IsDouble()
        {
            if (FirstCube == SecondCube)
                return true;
            return false;
        }
    }
}
