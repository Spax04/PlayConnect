namespace Game.DAL.Interfaces
{
    public interface IConnectionService
    {
        Task<bool> ConnectPlayerAsync(Guid playerId, string connectionId);
        Task<bool> CloseConnectionAsync(string ChatId, DateTime endedAt);
        Task SetPlayerConnectedAsync(Guid playerId);
        Task<bool> DisconnectPlayerAsync(Guid playerId, string connectionId);
        Task<bool> SetPlayerDisconnectedAsync(Guid playerId);
    }
}
