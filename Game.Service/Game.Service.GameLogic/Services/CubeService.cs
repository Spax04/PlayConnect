using Game.Service.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.GameLogic.Services
{
    public class CubeService
    {
        readonly int minNum = 1;
        readonly int maxNum = 7;
        public RollCubes RollCubes { get; set; }
        Random rnd;
        public CubeService()
        {

        }
        public RollCubes Roll()
        {
            var first = rnd.Next(minNum, maxNum);
            RollCubes.FirstCube = first;
            var second = rnd.Next(minNum, maxNum);
            RollCubes.SecondCube = second;
            return RollCubes;
        }
    }
}
