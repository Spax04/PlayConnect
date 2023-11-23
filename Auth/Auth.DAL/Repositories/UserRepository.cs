using Auth.DAL.Authorization.Utilits.Interfaces;
using Auth.DAL.Data;
using Auth.DAL.Interfaces;
using Auth.Models.Dto.Responses;
using Auth.Models.Helpers;
using Auth.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Auth.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;
        private readonly IConfiguration _config;
        private IJwtUtilits _jwtUtilits;
        private ICountryRepository _countryRepository;
        private IUserService _userService;
        public UserRepository(
            DataContext context,
            IConfiguration config,
            IJwtUtilits jwtUtilits,
            ICountryRepository countryRepository,
            IUserService userService

            )
        {
            _userService = userService;
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

        //! Need to improve this function
        public async Task<FriendshipResponse> GetFriendsByUserIdAsync(Guid userId)
        {
            IEnumerable<Friendship> friendships = await _context.Friendships.Where(u => (u.SenderId == userId) || (u.RecieverId == userId)).ToListAsync();

            // Friends in freind list (accepted)
            IEnumerable<Guid> usersFriendshipAccepted1 = friendships.Where(u => u.SenderId == userId && u.IsAccepted == true).Select(u => u.RecieverId).ToList();
            IEnumerable<Guid> usersFriendshipAccepted2 = friendships.Where(u => u.RecieverId == userId && u.IsAccepted == true).Select(u => u.SenderId).ToList();

            // Friends that sent request but reciver still not applied
            IEnumerable<Guid> usersFriendshipPanding = friendships.Where(u => u.RecieverId == userId && u.IsAccepted == false).Select(u => u.SenderId).ToList();

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
            Response isOnlineResponse;
            List<OtherUserResponse> friends = new List<OtherUserResponse>();
            List<OtherUserResponse> pendingFriends = new List<OtherUserResponse>();

            foreach (var user in friendsList)
            {
                if (user != null)
                {
                    country = countries.Where(c => c.Id == user.CountryId).First();
                    isOnlineResponse = await _userService.IsUserOnline(user.UserId.ToString());
                    friends.Add(new OtherUserResponse()
                    {
                        UserId = user.UserId.ToString(),
                        Username = user.Username,
                        Email = user.Email,
                        Token = _jwtUtilits.CreateToken(user),
                        Coins = user.Coins,
                        IsFriend = true,
                        IsConnected = isOnlineResponse.isSucceed,
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
                    isOnlineResponse = await _userService.IsUserOnline(user.UserId.ToString());
                    pendingFriends.Add(new OtherUserResponse()
                    {
                        UserId = user.UserId.ToString(),
                        Username = user.Username,
                        Email = user.Email,
                        Token = _jwtUtilits.CreateToken(user),
                        Coins = user.Coins,
                        IsFriend = false,
                        IsConnected = isOnlineResponse.isSucceed,
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
                        IsConnected = false,
                        IsRequested = await AreFriendshipRequestedAsync(id, user.UserId),
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

        public async Task<Response> DeleteFriendshipAsync(Guid user1, Guid user2)
        {
            Friendship friendship = await _context.Friendships!.Where(f => ((f.SenderId == user1 && f.RecieverId == user2) || (f.SenderId == user2 && f.RecieverId == user1)) && f.IsAccepted == true).FirstOrDefaultAsync();
            _context.Friendships.Remove(friendship);
            if (await Save())
            {
                return new Response(true);
            }
            return new Response(false);
        }

        public async Task<bool> AreFriendshipRequestedAsync(Guid sender, Guid reciver)
        {
            Friendship friendship = await _context.Friendships!.Where(f => (f.SenderId == sender && f.RecieverId == reciver) && f.IsAccepted == false).FirstOrDefaultAsync();

            if (friendship == null)
            {
                return false;
            }

            return true;

        }

        public async Task<bool> UploadUserImage(IFormFile image, Guid userId)
        {
            User user = await _context.Users!.FindAsync(userId);

            if (user == null)
            {
                throw new Exception("Error! User not found!");
            }
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);

                user.UserImage = memoryStream.ToArray();

            }
            return await Save();
        }
    }
}
