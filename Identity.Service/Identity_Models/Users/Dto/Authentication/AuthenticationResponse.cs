using Identity_Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_Models.Authentication
{
    public class AuthenticationResponse : Response
    {
        public AuthenticationResponse() : base(true)
        {
        }

        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        
    }
}
