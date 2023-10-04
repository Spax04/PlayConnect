using Identity_Models.Dto.Responses;
using Identity_Models.Helpers;
using Identity_Models.Users;
using Identity_Models.Users.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Response> GetUserByIdAsync(string userID);

        Task<IEnumerable<OtherUserResponse>> GetFriendsByUserIdAsync(Guid userId);
        Task<IEnumerable<OtherUserResponse>> GetUsersByUsernameAsync(Guid id,string username);

        Task<bool> AreFriends(Guid user1,Guid user2);

    }
}
