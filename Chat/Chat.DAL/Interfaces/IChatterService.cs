using Chat.Models.Helpers;

namespace Chat.DAL.Interfaces
{
    public interface IChatterService
    {
        Task<bool> IsChatterExistAsync(Guid chatterId);
        Task<Response> IsChatterConnectedAsync(Guid chatterId);
        Task SetChetterConnectedAsync(Guid cahatterId);
        Task SetChetterDisconnectedAsync(Guid cahatterId);
    }
}
