namespace Game.Models.Dto.Responses
{
    public class InviteResponse
    {
        public string? HostId { get; set; }
        public string? GuestId { get; set; }
        public string GameTypeId {  get; set; }
        public bool IsAccepted { get; set; }
    }
}
