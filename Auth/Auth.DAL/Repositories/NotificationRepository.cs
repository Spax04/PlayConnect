using Auth.DAL.Data;
using Auth.DAL.Interfaces;
using Auth.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.DAL.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private DataContext _context;
        public NotificationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Notification> CreateNewNotificationAsync(Guid userId, string message, string link, string iconLink)
        {
            Notification notification = new Notification()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Message = message,
                IconLink = iconLink,
                Link = link,
            };

            await _context.Notifications.AddAsync(notification);

            if (await Save())
            {
                return notification;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteNotificationAsync(Guid notificationId)
        {
            Notification notification = await _context.Notifications.FindAsync(notificationId);

            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                return await Save();
            }
            else { return false; }
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsByUserIdAsync(Guid userId)
        {
            return await _context.Notifications.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
