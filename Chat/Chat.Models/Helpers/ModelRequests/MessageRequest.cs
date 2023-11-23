namespace Chat.Models.Helpers.ModelRequests
{
    public class MessageRequest
    {
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
        public string NewMessage { get; set; }

    }
}
