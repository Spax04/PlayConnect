using Game.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models.Tic_Tac_Toe
{
    public class TicTacToeMove : Move
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
