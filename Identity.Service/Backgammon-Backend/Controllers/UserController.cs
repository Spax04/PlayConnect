using Backgammon_Backend.Services.Service_Interfaces;
using Identity_DAL.Repositories.Interfaces;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Users;
using Identity_Models.Users.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Backgammon_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpGet("{token}")]
        public async Task<ActionResult<UserResponse>> Get(string token)
        {
            if (token == string.Empty || token == null)
                return BadRequest("User input error");

            //var testToken = Request.Cookies["jwt"];

            var tokenCheck = new JwtSecurityToken(token);
            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;


            return Ok(await _userRepository.GetUserByIdAsync(id));
        }
    }
}
