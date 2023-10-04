using AutoMapper;
using Backgammon_Backend.Data;
using Backgammon_Backend.Services.Service_Interfaces;
using Identity_DAL.Authorization.Interfaces;
using Identity_DAL.AuthorizationUtilits.Interfaces;
using Identity_DAL.Repositories.Interfaces;
using Identity_Models.Authentication;
using Identity_Models.DTO.Registration;
using Identity_Models.Helpers;
using Identity_Models.Models;
using Identity_Models.Users.Dto.Registration;
using Microsoft.EntityFrameworkCore;
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
        private ICountryRepository _countryRepository;
        public AuthRepository(
            DataContext context,
            IConfiguration config,
            IJwtUtilits jwtUtilits,
            IMapper mapper,
            IHashUtilits hashUtilits,
            ICountryRepository countryRepository
            )
        {
            _context = context;
            _config = config;
            _jwtUtilits = jwtUtilits;
            _mapper = mapper;
            _hashUtilits = hashUtilits;
            _countryRepository = countryRepository;
        }

        // Registaration layer
        public async Task<Response> RegisterationAsync(RegistrationRequest request)
        {
            if (request == null)
                return new FailedResponse("Request is null");

            if (_context.Users!.Any(x => x.Email == request.Email))
                return new FailedResponse($"Email {request.Email} is taken");

            _hashUtilits.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Country country;
            if (Guid.TryParse(request.CountryId, out Guid countryId))
            {
                country = await _countryRepository.GetCountryAsync(countryId);
                if (country == null)
                {
                    return new FailedResponse($"Country with this id does not exist");
                }

            }
            else
            {
                return new FailedResponse($"Country id is not correct");
            }



            User user = new User();
            user.Username = request.Username;
            user.Email = request.Email;
            user.ImgUrl = "";
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Coins = 0;
            user.CountryId = countryId;




            await _context.SaveChangesAsync();

            RegistrationResponse response = new RegistrationResponse()
            {
                UserId = user.UserId.ToString(),
                Username = user.Username,
                Email = user.Email,
                Token = _jwtUtilits.CreateToken(user),
                Coins = 0,
                Country = new Country()
                {
                    Id = country.Id,
                    Code = country.Code,
                    Name = country.Name
                }
            };

            return response;
        }
        // public Task<Response> RegisterationAsync(RegistrationRequest request) => Task.Run(() => Registration(request));


        // Login layer
        public async Task<Response> LoginAsync(AuthenticationRequest request)
        {

            User user = await _context.Users!.FirstOrDefaultAsync(user => user.Email == request.Email);

            if (user == null)
            {
                return new FailedResponse($"User with username {request.Email} doesn't exist");
            }


            Country country = await _countryRepository.GetCountryAsync(user.CountryId);

            if (!_hashUtilits.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new FailedResponse($"Wrong password");
            }

            AuthenticationResponse response = new AuthenticationResponse()
            {
                UserId = user.UserId.ToString(),
                Username = user.Username,
                Email = user.Email,
                Token = _jwtUtilits.CreateToken(user),
                Coins = user.Coins,
                Country = new Country()
                {
                    Id = country.Id,
                    Code = country.Code,
                    Name = country.Name
                }
            };

            return response;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }
    }
}
