using Auth.DAL.Interfaces;
using Auth.Models.Dto.Requests;
using Auth.Models.Dto.Responses;
using Auth.Models.Helpers;
using Auth.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
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

    }
}
