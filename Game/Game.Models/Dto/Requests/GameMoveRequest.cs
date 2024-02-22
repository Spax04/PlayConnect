namespace Game.Models.Dto.Requests
{
    public class GameMoveRequest
    {
        public string GameSessionId { get; set; }
        public string GameTypeId { get; set; }
        public string SenderId { get; set; }
        public string GameMove { get; set; }
    }
}
