using Auth.Models.Dto.Requests;
using Auth.Models.Helpers;
using Auth.Models.Models;

namespace Auth.DAL.Interfaces
{
    public interface IAuthRepository
    {
        Task<Response> RegisterationAsync(RegistrationRequest request);
        Task<Response> LoginAsync(AuthenticationRequest request);
        IEnumerable<User> GetAllUsers();
    }
}
