namespace Chat_Models.Helpers.ModelResponses
{
    public class MessageResponse : Response
    {
        public MessageResponse() : base(true) { }

        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
        public string? NewMessage { get; set; }
        public bool IsReceived { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime ReceivedAt { get; set; }

    }
}
