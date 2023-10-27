using Identity_Models.Dto.Responses;
using Identity_Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_DAL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ChatterResponse>> GetFriendsAreOnline(string userId);
        Task<Response> IsUserOnline(string userId);
    }
}
