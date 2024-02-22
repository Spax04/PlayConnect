namespace Game.Models.Dto.Responses
{
    public class JoinToGameResponse
    {
        public string GameSessionId { get; set; }
        public string GameTypeId { get; set; }
        public string PlayerId { get; set; }
        public bool IsMyTurn { get; set; }
        public bool IsPlayer { get; set; }
        public int GameLevel { get; set; }
        public double GamePoints { get; set; }
    }
}
