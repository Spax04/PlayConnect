namespace Chat.Models.Helpers.ModelResponses
{
    public class MessageReceivedResponse
    {
        public string MessageId { get; set; }
        public string ChatterId { get; set; }
        public bool Status { get; set; }
    }
}
