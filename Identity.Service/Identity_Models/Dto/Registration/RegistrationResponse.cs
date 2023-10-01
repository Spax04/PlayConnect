using Identity_Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_Models.Users.Dto.Registration
{
    public class RegistrationResponse : Response
    {
        public RegistrationResponse() : base(true) {}
        public string? UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
