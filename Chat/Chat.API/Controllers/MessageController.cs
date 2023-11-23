using Chat.DAL.Repositories.Interfaces;
using Chat.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Chat.API.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetMessageHistory(string chatterId1, string chatterId2)
        {

            if ((chatterId1 == null || chatterId1.IsNullOrEmpty()) || (chatterId2 == null || chatterId2.IsNullOrEmpty()))
            {
                return BadRequest("Chatter id is null");

            }

            if (!Guid.TryParse(chatterId1, out var chatterId1Guid) || !Guid.TryParse(chatterId2, out var chatterId2Guid))
            {
                return BadRequest("Chatter id is not correct");
            }

            IEnumerable<Message> messagesHistory = await _messageRepository.UserMessagesBetween(chatterId1Guid, chatterId2Guid);

            return Ok(messagesHistory);
        }
    }
}
