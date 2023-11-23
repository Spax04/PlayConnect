using AutoMapper;
using Auth.DAL.Data;
using Auth.DAL.Interfaces;
using Auth.Models.Dto.Requests;
using Auth.Models.Helpers;
using Auth.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Auth.DAL.Authorization.Utilits.Interfaces;
using Auth.Models.Dto.Responses;

namespace Auth.DAL.Repositories
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

            if (await _context.Users!.AnyAsync(x => x.Email == request.Email))
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
            user.UserId = Guid.NewGuid();
            user.Username = request.Username;
            user.Email = request.Email;
            user.UserImage = null;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Coins = 0;
            user.CountryId = countryId;


            await _context.Users!.AddAsync(user);

            await _context.SaveChangesAsync();

            UserResponse response = new UserResponse()
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

            UserResponse response = new UserResponse()
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
