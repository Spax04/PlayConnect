using Auth.Models.Models;

namespace Auth.DAL.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification> CreateNewNotificationAsync(Guid userId, string message, string link, string iconLink);
        Task<IEnumerable<Notification>> GetAllNotificationsByUserIdAsync(Guid userId);
        Task<bool> DeleteNotificationAsync(Guid notificationId);
        Task<bool> Save();
    }
}
