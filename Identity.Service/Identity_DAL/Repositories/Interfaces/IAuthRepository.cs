using Identity_Models.Authentication;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Backgammon_Backend.Services.Service_Interfaces
{
    public interface IAuthRepository
    {
        Task<Response> RegisterationAsync(RegistrationRequest request);
        Task<Response> LoginAsync(AuthenticationRequest request);
        IEnumerable<User> GetAllUsers();
    }
}
