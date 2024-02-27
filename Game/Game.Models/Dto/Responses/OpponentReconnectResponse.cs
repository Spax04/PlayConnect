namespace Game.Models.Dto.Responses
{
    public class OpponentReconnectResponse
    {
        public string SenderId { get; set; }
        public string GameSessionId { get; set; }
        public string GameHistory { get; set; }
        public int MoveNumber { get; set; }
        public bool IsMyTurn { get; set; }
        public string Participants { get; set; }
        public string OpponentSign { get; set; }
        public int GameTimer { get; set; }
    }
}
