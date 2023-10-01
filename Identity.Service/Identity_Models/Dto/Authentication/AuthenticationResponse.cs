using Identity_Models.Helpers;

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

    }
}
