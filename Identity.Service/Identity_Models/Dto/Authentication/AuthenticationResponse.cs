using Identity_Models.Helpers;
using Identity_Models.Models;

namespace Identity_Models.Authentication
{
    public class AuthenticationResponse : Response
    {
        public AuthenticationResponse() : base(true) { }
        public string? UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public int Coins { get; set; }
        public Country Country { get; set; }

    }
}
