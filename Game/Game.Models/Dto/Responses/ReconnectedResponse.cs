namespace Game.Models.Dto.Responses
{
    public class ReconnectedResponse
    {
        public Guid GameSessionId { get; set; }
        public Guid GameTypeId { get; set; }
        public int GameLevel { get; set; }
        public double GamePoints { get; set; }
        public Guid PlayerId { get; set; }
    }
}
