using Backgammon_Backend.Data;
using Identity_DAL.Authorization.Interfaces;
using Identity_DAL.Repositories.Interfaces;
using Identity_Models.Dto.Responses;
using Identity_Models.Helpers;
using Identity_Models.Models;
using Identity_Models.Users.Dto.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Identity_DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;
        private readonly IConfiguration _config;
        private IJwtUtilits _jwtUtilits;
        private ICountryRepository _countryRepository;
        public UserRepository(
            DataContext context,
            IConfiguration config,
            IJwtUtilits jwtUtilits,
            ICountryRepository countryRepository

            )
        {
            _context = context;
            _config = config;
            _jwtUtilits = jwtUtilits;
            _countryRepository = countryRepository;
        }

        public async Task<Response> GetUserByIdAsync(string userID)
        {
            if (!Guid.TryParse(userID, out var userIdDb))
            {
                return new FailedResponse("Id is not correct");
            }

            var user = await _context.Users!.FirstAsync(x => x.UserId == userIdDb);
            if (user == null)
            {
                return new FailedResponse("This user does not exist");
            }

            return new UserResponse()
            {
                UserId = user.UserId.ToString(),
                Username = user.Username,
                Email = user.Email,

            };


        }

        public async Task<IEnumerable<OtherUserResponse>> GetFriendsByUserIdAsync(Guid userId)
        {
            IEnumerable<User> usersOne = await _context.Friendships.Where(u => u.User1Id == userId).Select(u => u.User2).ToListAsync();
            IEnumerable<User> usersTwo = await _context.Friendships.Where(u => u.User2Id == userId).Select(u => u.User1).ToListAsync();
            IEnumerable<Country> countries = await _countryRepository.GetAllAsync();

            List<User> friendsList = new List<User>();
            friendsList.AddRange(usersOne);
            friendsList.AddRange(usersTwo);

            Country country;
            List<OtherUserResponse> friends = new List<OtherUserResponse>();

            foreach (var user in friendsList)
            {
                country = countries.Where(c => c.Id == user.CountryId).First();
                friends.Add(new OtherUserResponse()
                {
                    UserId = user.UserId.ToString(),
                    Username = user.Username,
                    Email = user.Email,
                    Token = _jwtUtilits.CreateToken(user),
                    Coins = user.Coins,
                    IsFriend = true,
                    Country = new Country()
                    {
                        Id = country.Id,
                        Code = country.Code,
                        Name = country.Name
                    }
                });
            }

            return friends;

        }

        public async Task<IEnumerable<OtherUserResponse>> GetUsersByUsernameAsync(Guid id, string username)
        {
            IEnumerable<User> users = await _context.Users!.Where(u => u.Username!.Contains(username)).ToListAsync();
            IEnumerable<Country> countries = await _countryRepository.GetAllAsync();

            Country country;
            List<OtherUserResponse> usersResponse = new List<OtherUserResponse>();

            foreach (var user in users)
            {
                country = countries.Where(c => c.Id == user.CountryId).First();

                usersResponse.Add(new OtherUserResponse()
                {
                    UserId = user.UserId.ToString(),
                    Username = user.Username,
                    Email = user.Email,
                    Token = _jwtUtilits.CreateToken(user),
                    Coins = user.Coins,
                    IsFriend = await AreFriendsAsync(id, user.UserId),
                    Country = new Country()
                    {
                        Id = country.Id,
                        Code = country.Code,
                        Name = country.Name
                    }
                });
            }

            return usersResponse;
        }

        public async Task<bool> AreFriendsAsync(Guid user1, Guid user2)
        {
            var friendship = await _context.Friendships.Where(u => (u.User1Id == user1 && u.User2Id == user2) || (u.User1Id == user2 && u.User2Id == user1)).FirstOrDefaultAsync();
            return friendship == null ? false : true;
        }

        public async Task<bool> CreateFriendshipAsync(Guid userid1, Guid userid2)
        {
            var areAlreadyFriends = await AreFriendsAsync(userid1, userid2);

            Friendship newFrinedship = new Friendship()
            {
                User1Id = userid1,
                User1Accepted = true,
                User2Id = userid2,
                User2Accepted = false
            };

            await _context.Friendships!.AddAsync(newFrinedship);

            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
