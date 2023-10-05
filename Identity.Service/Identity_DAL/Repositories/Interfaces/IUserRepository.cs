using Identity_Models.Dto.Responses;
using Identity_Models.Helpers;

namespace Identity_DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Response> GetUserByIdAsync(string userID);

        Task<IEnumerable<OtherUserResponse>> GetFriendsByUserIdAsync(Guid userId);
        Task<IEnumerable<OtherUserResponse>> GetUsersByUsernameAsync(Guid id, string username);
        Task<bool> CreateFriendshipAsync(Guid userid1, Guid userid2);
        Task<bool> AreFriendsAsync(Guid user1, Guid user2);

    }
}
