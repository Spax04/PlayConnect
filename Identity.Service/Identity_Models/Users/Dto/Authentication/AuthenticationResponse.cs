using Identity_Models.Helpers;

namespace Identity_Models.Authentication
{
    public class AuthenticationResponse : Response
    {
        public AuthenticationResponse() : base(true) { }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }

    }
}
