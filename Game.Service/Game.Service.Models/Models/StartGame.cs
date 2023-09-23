using Game.Service.Models.Models.Board;

namespace Game.Service.Models.Models
{
    public class StartGame
    {
        public Guid GameId { get; set; }
        public Guid PlayerOne { get; set; }
        public Guid PlayerTwo { get; set; }
        public RollCubes WhoStarts { get; set; }
        public RollCubes GameCubes { get; set; }
        public BackgammonBoard Board { get; set; }
    }
}
