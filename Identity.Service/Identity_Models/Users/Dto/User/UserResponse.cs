using Identity_Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_Models.Users.Dto.User
{
    public class UserResponse : Response
    {
        public UserResponse() : base(true)
        {
        }

        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
    }
}
