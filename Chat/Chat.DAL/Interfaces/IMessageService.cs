namespace Chat.DAL.Interfaces
{
    public interface IMessageService
    {
        Task SetMessageReceivedAsync(Guid messageId);

    }
}
