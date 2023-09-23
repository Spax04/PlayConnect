using Backgammon_Backend.Services.Service_Interfaces;
using Identity_Models.Authentication;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Controllers
{
    [Route("api/[controller]")]
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

            return Ok(await _authRepository.RegisterationAsync(request));
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponse>> Login(AuthenticationRequest request)
        {
            if (request == null)
                return BadRequest("User input error");
            AuthenticationResponse authResponse;
            try
            {
                 authResponse = (AuthenticationResponse)await _authRepository.LoginAsync(request);
            }
            catch
            {
                return BadRequest("User input error");
            }
            
            Response.Cookies.Append("jwt", authResponse.Token!, new CookieOptions { HttpOnly = true });

            return Ok(await _authRepository.LoginAsync(request));
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
           Response.Cookies.Delete("jwt");

            return Ok( "Coockies was deleted");
        }

        [HttpGet("getTest")]
        public  ActionResult<IEnumerable<User>> Get()
        {

            return Ok( _authRepository.GetAllUsers());
        }

    }
}
