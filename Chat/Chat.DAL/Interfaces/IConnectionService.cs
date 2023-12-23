namespace Chat.DAL.Interfaces
{
    public interface IConnectionService
    {
        Task<bool> CheckReconnectConnectionAsync(Guid chatterId);
        Task CloseConnectionAsync(string ChatId);
        Task CloseAllConnectionsAsync();
        Task<bool> ConnectChatterAsync(Guid chatterId, string chatId);
        Task<bool> DisconnectChatterAsync(Guid chatter, string chatId);
    }
}
