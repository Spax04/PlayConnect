using Auth.DAL.Interfaces;
using Auth.Models.Dto.Requests;
using Auth.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationRepository _notificationRepository;
        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;

        }

        [HttpGet("{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllNotifications(string userId)
        {
            if (!Guid.TryParse(userId, out var id))
                return BadRequest("Not correct user id!");

            IEnumerable<Notification> notifications = await _notificationRepository.GetAllNotificationsByUserIdAsync(id);

            return Ok(notifications);
        }

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNotification(NotificationCreateRequest notificationCreateRequest)
        {
            if (!Guid.TryParse(notificationCreateRequest.UserId, out var id))
                return BadRequest("Not correct user id!");

            IEnumerable<Notification> notifications = await _notificationRepository.GetAllNotificationsByUserIdAsync(id);

            return Ok(notifications);
        }
    }
}
