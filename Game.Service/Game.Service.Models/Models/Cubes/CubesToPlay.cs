using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Service.Models.Models.Cubes;

namespace Game.Service.Models.Models
{
    public class CubesToPlay
    {
        public SingleCubeMove[] MovesToPlay { get; set; }
        public CubesToPlay(RollCubes cubes)
        {                   
            if (cubes.IsDouble())
            {
                MovesToPlay = new[] { new SingleCubeMove(), new SingleCubeMove(), new SingleCubeMove(), new SingleCubeMove() };
                foreach(var move in MovesToPlay)
                {
                    move.CubeNum = cubes.FirstCube;
                    move.IsPlayed = false;
                }
            }
            else
            {
                MovesToPlay = new[] { new SingleCubeMove(), new SingleCubeMove() };
                MovesToPlay[0].CubeNum = cubes.FirstCube;
                MovesToPlay[1].CubeNum = cubes.SecondCube;
                MovesToPlay[0].IsPlayed= false;
                MovesToPlay[1].IsPlayed = false;
            }
        }
        public void PlayingMove(int cubeNum)
        {
            foreach (var move in MovesToPlay)
            {
                if (move.CubeNum == cubeNum && move.IsPlayed == false)
                {
                    move.IsPlayed = true;
                    return;
                }
            }
        }
        public IEnumerable<int> GetAvalableMoves()
        {
            return MovesToPlay
                .Where(move => !move.IsPlayed)
                .Select(move => move.CubeNum);
        }
        public bool IsMoveAvalble(int cubeNum)
        {
            foreach (var move in MovesToPlay)
            {
                if (move.CubeNum == cubeNum && move.IsPlayed == false)
                    return true;
            }
            return false;
        }
    }
}
