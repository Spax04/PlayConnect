using AutoMapper;
using Backgammon_Backend.Data;
using Backgammon_Backend.Services.Service_Interfaces;
using Identity_DAL.Authorization.Interfaces;
using Identity_DAL.AuthorizationUtilits.Interfaces;
using Identity_Models.Authentication;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
            if(request == null)
                return new FailedResponse("Request is null");

            if (_context.Users.Any(x => x.Username == request.Username))
                return new FailedResponse($"Username {request.Username} is taken");

            _hashUtilits.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User();
            user.Username = request.Username;
            user.Email = request.Email;
            user.ImgUrl = request.ImgUrl;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return new SucceedResponse($"User with username {user.Username} was registred");
        }
        public Task<Response> RegisterationAsync(RegistrationRequest request) => Task.Run(()=> Registration(request));


        // Login layer
        private Response Login(AuthenticationRequest request)
        {
            User user = _context.Users.FirstOrDefault(user => user.Username == request.Username);

            if(user == null)
            {
                return new FailedResponse($"User wuth username {request.Username} doesn't exist");
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
