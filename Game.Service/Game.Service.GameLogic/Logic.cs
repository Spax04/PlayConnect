using Game.Service.Models.Models;
using Game.Service.Models.Models.Board;
using Game.Service.Models.Models.Db;
using Game.Service.Models.Models.Player;

namespace Game.Service.GameLogic
{
    public class Logic
    {
        public Guid GameId { get; set; }
        public Guid PlayerOneId { get; set; }
        public string PlayerOneConnection { get; set; }
        public Guid PlayerTwoId { get; set; }
        public string PlayerTwoConnection { get; set; }
        public StartGame InitialGame { get; set; }
        public CubesToPlay CurrentCubes { get; set; }
        public Guid PlayersIdTurn { get; set; }
        public BoardSpike[] BoardSpikes { get; set; }

        public Logic(Guid gameId, Guid playerOneId, Guid playerTwoId, string connectionOne, string connectionTwo, BackgammonBoard board)
        {
            GameId = gameId;
            PlayerOneId= playerOneId;
            PlayerTwoId= playerTwoId;
            PlayerOneConnection= connectionOne;
            PlayerTwoConnection= connectionTwo;
            Board = board.GenerateStartingBoard();
        }
        
        public void InitWhoStarts(StartGame startGame)
        {
            CurrentCubes = new CubesToPlay(startGame.GameCubes);
            if (startGame.WhoStarts.FirstCube > startGame.WhoStarts.SecondCube)
                PlayersIdTurn = PlayerOneId;
            else
                PlayersIdTurn = PlayerTwoId;
        }
        public bool IsMoveOk(int targetSpike)
        {
            if (BoardSpikes[targetSpike].AvailableSpike)
                return true;
            return false;
        }
        //public bool IsEaten(PlayerColor player1, PlayerColor player2, int index)
        //{
        //    BoardSpike spike = BoardSpikes[index];
        //    if(player1 == PlayerColor.White)
        //    {
        //        if (spike.SolidersQuantity.Count < 2)
        //        {
        //            spike.SolidersQuantity.Remove(spike.SolidersQuantity[index]);
        //            spike.SolidersQuantity.
        //            return true;
        //        }
                    

        //    }
            

        //}
        

    }
}