using Auth.Models.Dto.Responses;
using Auth.Models.Helpers;
using Microsoft.AspNetCore.Http;

namespace Auth.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<Response> GetUserByIdAsync(string userID);
        Task<FriendshipResponse> GetFriendsByUserIdAsync(Guid userId);
        Task<IEnumerable<OtherUserResponse>> GetUsersByUsernameAsync(Guid id, string username);
        Task<bool> CreateFriendshipAsync(Guid userid1, Guid userid2);
        Task<bool> AreFriendsAsync(Guid user1, Guid user2);
        Task<bool> AcceptFriendshipAsync(Guid user1, Guid user2);
        Task<Response> DeleteFriendshipAsync(Guid user1,Guid user2);
        Task<bool> AreFriendshipRequestedAsync(Guid sender, Guid reciver);
        Task<bool> UploadUserImage(IFormFile image, Guid userId);


    }
}
