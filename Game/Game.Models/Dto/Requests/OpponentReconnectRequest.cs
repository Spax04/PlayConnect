namespace Game.Models.Dto.Requests
{
    public class OpponentReconnectRequest
    {
        public string GameSessionId { get; set; }
        public string PlayerId { get; set; }
        public bool IsPlayer { get; set; }
    }
}
