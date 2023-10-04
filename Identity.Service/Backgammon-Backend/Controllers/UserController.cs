using Backgammon_Backend.Services.Service_Interfaces;
using Identity_DAL.Repositories.Interfaces;
using Identity_Models.Dto.Responses;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Models;
using Identity_Models.Users;
using Identity_Models.Users.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Backgammon_Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{userId}/{username}")]
        [AllowAnonymous]
        public async Task<ActionResult<OtherUserResponse>> GetUsersByName(string userId,string username)
        {
            if (username == string.Empty || username == null)
                return BadRequest("Username in null");

            if(!Guid.TryParse(userId, out var id))
            {
                return BadRequest("Not correct user id!");
            }
            

            IEnumerable<OtherUserResponse> friends = await _userRepository.GetUsersByUsernameAsync(id,username);

            return Ok(friends);
        }

        [HttpGet("friends/{userId}")]
        public async Task<ActionResult<OtherUserResponse>> GetFriends(string userId)
        {
            if (userId == string.Empty || userId == null)
                return BadRequest("User id in null");
            
            if(!Guid.TryParse(userId,out var userIdDb))
            {
                return BadRequest("Not correct user id");
            }

            IEnumerable<OtherUserResponse> friends = await _userRepository.GetFriendsByUserIdAsync(userIdDb);

            return Ok(friends);
        }
    }
}
