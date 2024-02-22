namespace Game.Models.Dto.Requests
{
    public class ReadyToGameRequest
    {
        public string GameSessionId { get; set; }
        public string PlayerName { get; set; }
        public string PlayerId { get; set; }
        public bool IsPlayer { get; set; }
    }
}
