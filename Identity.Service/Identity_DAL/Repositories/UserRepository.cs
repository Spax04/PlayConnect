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

        public async Task<FriendshipResponse> GetFriendsByUserIdAsync(Guid userId)
        {
            IEnumerable<Friendship> friendships = await _context.Friendships.Where(u => (u.SenderId == userId) || (u.RecieverId == userId)).ToListAsync();

            IEnumerable<Guid> usersFriendshipAccepted1 = friendships.Where(u => u.SenderId == userId && u.IsAccepted == true).Select(u => u.RecieverId).ToList();
            IEnumerable<Guid> usersFriendshipAccepted2 = friendships.Where(u => u.RecieverId == userId && u.IsAccepted == true).Select(u => u.SenderId).ToList();

            List<Guid> usersFriendshipPanding = friendships.Where(u => u.RecieverId == userId && u.IsAccepted == false).Select(u => u.SenderId).ToList();

            // Users that Main user has been sended friendship request but request still is not accepted. Not in use now,maybe later
            // IEnumerable<User> usersFriendshipRequested = friendships.Where(u => u.SenderId == userId && u.IsAccepted == false).Select(u => u.Reciever).ToList(); 

            IEnumerable<Country> countries = await _countryRepository.GetAllAsync();

            List<User> friendsList = new List<User>();

            foreach (var id in usersFriendshipAccepted1)
            {
                friendsList.Add(await _context.Users!.Where(u => u.UserId == id).FirstOrDefaultAsync());
            }
            foreach (var id in usersFriendshipAccepted2)
            {
                friendsList.Add(await _context.Users!.Where(u => u.UserId == id).FirstOrDefaultAsync());
            }

            List<User> pendingList = new List<User>();
            foreach (var id in usersFriendshipPanding)
            {
                pendingList.Add(await _context.Users!.Where(u => u.UserId == id).FirstOrDefaultAsync());
            }


            Country country;
            List<OtherUserResponse> friends = new List<OtherUserResponse>();
            List<OtherUserResponse> pendingFriends = new List<OtherUserResponse>();

            foreach (var user in friendsList)
            {
                if (user != null)
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

            }

            foreach (var user in pendingList)
            {
                if (user != null)
                {
                    country = countries.Where(c => c.Id == user.CountryId).First();
                    pendingFriends.Add(new OtherUserResponse()
                    {
                        UserId = user.UserId.ToString(),
                        Username = user.Username,
                        Email = user.Email,
                        Token = _jwtUtilits.CreateToken(user),
                        Coins = user.Coins,
                        IsFriend = false,
                        Country = new Country()
                        {
                            Id = country.Id,
                            Code = country.Code,
                            Name = country.Name
                        }
                    });
                }
            }

            return new FriendshipResponse() { AcceptedFriends = friends, PendingFriends = pendingFriends };
        }

        public async Task<IEnumerable<OtherUserResponse>> GetUsersByUsernameAsync(Guid id, string username)
        {
            IEnumerable<User> users = await _context.Users!.Where(u => u.Username!.Contains(username)).ToListAsync();
            IEnumerable<Country> countries = await _countryRepository.GetAllAsync();

            Country country;
            List<OtherUserResponse> usersResponse = new List<OtherUserResponse>();

            foreach (var user in users)
            {
                if (user.UserId != id)
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
            }

            return usersResponse;
        }

        public async Task<bool> AreFriendsAsync(Guid user1, Guid user2)
        {
            var friendship = await _context.Friendships.Where(u => (u.SenderId == user1 && u.RecieverId == user2) || (u.SenderId == user2 && u.RecieverId == user1)).FirstOrDefaultAsync();
            if (friendship == null)
            {
                return false;
            }
            
            return friendship.IsAccepted;
        }

        public async Task<bool> CreateFriendshipAsync(Guid userid1, Guid userid2)
        {
            if (!await AreFriendsAsync(userid1, userid2))
            {

                Friendship newFrinedship = new Friendship()
                {
                    SenderId = userid1,
                    RecieverId = userid2,
                    IsAccepted = false
                };

                await _context.Friendships!.AddAsync(newFrinedship);

                return await Save();
            }

            return false;

        }

        public async Task<bool> AcceptFriendshipAsync(Guid user1, Guid user2)
        {
            Friendship friendship = await _context.Friendships!.Where(f => ((f.SenderId == user1 && f.RecieverId == user2) || (f.SenderId == user2 && f.RecieverId == user1)) && f.IsAccepted == false).FirstOrDefaultAsync();
            if (friendship != null)
            {
                friendship.IsAccepted = true;
                return await Save();
            }
            return false;
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

    }
}
