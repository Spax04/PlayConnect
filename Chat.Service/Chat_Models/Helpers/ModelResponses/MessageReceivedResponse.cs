namespace Chat_Models.Helpers.ModelResponses
{
    public class MessageReceivedResponse
    {
        public string MessageId { get; set; }
        public string ReceiverId { get; set; }
        public bool Status { get; set; }
    }
}
