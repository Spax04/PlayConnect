using Identity_DAL.Interfaces;
using Identity_Models.Dto.Requests;
using Identity_Models.Dto.Responses;
using Identity_Models.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{userId}/{username}")]
        [AllowAnonymous]
        public async Task<ActionResult<OtherUserResponse>> GetUsersByName(string userId, string username)
        {
            if (username == string.Empty || username == null)
                return BadRequest("Username in null");

            if (!Guid.TryParse(userId, out var id))
            {
                return BadRequest("Not correct user id!");
            }


            IEnumerable<OtherUserResponse> friends = await _userRepository.GetUsersByUsernameAsync(id, username);

            return Ok(friends);
        }

        [HttpGet("friends/{userId}")]
        public async Task<ActionResult<FriendshipResponse>> GetFriends(string userId)
        {
            if (userId == string.Empty || userId == null)
                return BadRequest("User id in null");

            if (!Guid.TryParse(userId, out var userIdDb))
            {
                return BadRequest("Not correct user id");
            }

            FriendshipResponse friends = await _userRepository.GetFriendsByUserIdAsync(userIdDb);

            return Ok(friends);
        }

        [HttpPost("friends/add/")]
        public async Task<ActionResult<bool>> CreateFriendship(FriendshipRequest friendshipRequest)
        {
            if (friendshipRequest == null)
                return BadRequest("Request body is null");

            if (!Guid.TryParse(friendshipRequest.UserId1, out var userId1Db) || !Guid.TryParse(friendshipRequest.UserId2, out var userId2Db))
                return BadRequest("Users id are not correct!");

            return await _userRepository.CreateFriendshipAsync(userId1Db, userId2Db);

        }

        [HttpPost("friends/accept/")]
        public async Task<ActionResult<bool>> AcceptFriendship(FriendshipRequest friendshipRequest)
        {
            if (friendshipRequest == null)
                return BadRequest("Request body is null");

            if (!Guid.TryParse(friendshipRequest.UserId1, out var userId1Db) || !Guid.TryParse(friendshipRequest.UserId2, out var userId2Db))
                return BadRequest("Users id are not correct!");

            return await _userRepository.AcceptFriendshipAsync(userId1Db, userId2Db);

        }

        [HttpDelete("friends/{userid1}/{userid2}")]
        public async Task<ActionResult<Response>> DeleteFriendship(string userid1,string userid2)
        {
            if (!Guid.TryParse(userid1, out var userId1Db) || !Guid.TryParse(userid2, out var userId2Db))
                return BadRequest("Users id are not correct!");

            return await _userRepository.DeleteFriendshipAsync(userId1Db, userId2Db);

        }
    }
}
