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
        public RegistrationResponse() : base(true)
        {
        }

        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
