using AutoMapper;
using Backgammon_Backend.Data;
using Backgammon_Backend.Services.Service_Interfaces;
using Identity_DAL.Authorization.Interfaces;
using Identity_DAL.AuthorizationUtilits.Interfaces;
using Identity_Models.Authentication;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Users;
using Identity_Models.Users.Dto.Registration;
using Microsoft.Extensions.Configuration;

namespace Backgammon_Backend.Services
{
    public class AuthRepository : IAuthRepository
    {
        private DataContext _context;
        private readonly IConfiguration _config;
        private IJwtUtilits _jwtUtilits;
        private readonly IMapper _mapper;
        private IHashUtilits _hashUtilits;
        public AuthRepository(
            DataContext context,
            IConfiguration config,
            IJwtUtilits jwtUtilits,
            IMapper mapper,
            IHashUtilits hashUtilits
            )
        {
            _context = context;
            _config = config;
            _jwtUtilits = jwtUtilits;
            _mapper = mapper;
            _hashUtilits = hashUtilits;
        }

        // Registaration layer
        private Response Registration(RegistrationRequest request)
        {
            if (request == null)
                return new FailedResponse("Request is null");

            if (_context.Users!.Any(x => x.Email == request.Email))
                return new FailedResponse($"Email {request.Email} is taken");

            _hashUtilits.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User();
            user.Username = request.Username;
            user.Email = request.Email;
            user.ImgUrl = "";
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users!.Add(user);
            _context.SaveChanges();

            RegistrationResponse response = new RegistrationResponse()
            {
                Token = _jwtUtilits.CreateToken(user)
            };

            return response;
        }
        public Task<Response> RegisterationAsync(RegistrationRequest request) => Task.Run(() => Registration(request));


        // Login layer
        private Response Login(AuthenticationRequest request)
        {
            User user = _context.Users.FirstOrDefault(user => user.Email == request.Email);

            if (user == null)
            {
                return new FailedResponse($"User with username {request.Email} doesn't exist");
            }


            if (!_hashUtilits.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new FailedResponse($"Wrong password");
            }

            AuthenticationResponse response = new AuthenticationResponse()
            {
                Token = _jwtUtilits.CreateToken(user)
            };


            //response.RefreshToken = _jwtUtilits.RefreshToken();
            return response;
        }

        public Task<Response> LoginAsync(AuthenticationRequest request) => Task.Run(() => Login(request));


        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }
    }
}
