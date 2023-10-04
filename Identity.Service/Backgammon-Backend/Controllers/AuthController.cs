using Backgammon_Backend.Services.Service_Interfaces;
using Identity_Models.Authentication;
using Identity_Models.Dto.Registration;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Models;
using Identity_Models.Users.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }


        [HttpPost("register"), AllowAnonymous]
        public async Task<ActionResult<Response>> Register(RegistrationRequest request)
        {
            if (request == null)
                return BadRequest("User input error");

            Response response;
            try
            {
                 response = await _authRepository.RegisterationAsync(request);
            }
            catch(Exception ex)
            {
                return BadRequest("Error on trying to registre new user: " + ex);
            }
           
            return Ok(response);
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<UserResponse>> Login( AuthenticationRequest request)
        {
            if (request == null)
                return BadRequest("User input error");
            UserResponse authResponse;
            try
            {
                authResponse = (UserResponse)await _authRepository.LoginAsync(request);
            }
            catch
            {
                return BadRequest("User input error");
            }



            return Ok(authResponse);
        }



        [HttpGet("getTest")]
        public ActionResult<IEnumerable<User>> Get()
        {

            return Ok(_authRepository.GetAllUsers());
        }

    }
}
