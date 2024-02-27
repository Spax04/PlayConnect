namespace Chat.Models.Helpers.Requests
{
    public class GroupMessageRequest
    {
        public string GameSessionId { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string Message { get; set; }
    }
}
