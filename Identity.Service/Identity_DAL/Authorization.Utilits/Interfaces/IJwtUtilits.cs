using Identity_Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_DAL.Authorization.Interfaces
{
    public interface IJwtUtilits
    {
        public string CreateToken(User user);
        public string CreateRefreshToken(Guid userId, string tokenId);
        public bool VerifyToken(string token);
    }
}
