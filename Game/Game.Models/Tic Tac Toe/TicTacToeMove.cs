using Game.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game.Models.Tic_Tac_Toe
{
    public class TicTacToeMove : Move
    {
        [Column(TypeName = "json")]
        public string MoveHistoryJson { get; set; }


    }
}
