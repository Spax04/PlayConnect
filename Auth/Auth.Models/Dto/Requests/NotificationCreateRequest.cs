namespace Auth.Models.Dto.Requests
{
    public class NotificationCreateRequest
    {
        public string UserId { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public string IconLink { get; set; }
    }
}
