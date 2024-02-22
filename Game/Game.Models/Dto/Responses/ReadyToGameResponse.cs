namespace Game.Models.Dto.Responses
{
    public class ReadyToGameResponse
    {
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Message { get; set; }
        public bool IsPlayer { get; set; }
    }
}
