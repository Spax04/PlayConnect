using Identity_Models.Helpers;
using Identity_Models.Users;
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
    }
}
