using Identity_Models.Authentication;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Identity_DAL.Interfaces
{
    public interface IAuthRepository
    {
        Task<Response> RegisterationAsync(RegistrationRequest request);
        Task<Response> LoginAsync(AuthenticationRequest request);
        IEnumerable<User> GetAllUsers();
    }
}
