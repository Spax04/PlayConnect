using Auth.Models.Helpers;
using Auth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Models.Dto.Responses
{
    public class OtherUserResponse : Response
    {
        public OtherUserResponse() : base(true)
        {

        }

        public string? UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public int Coins { get; set; }
        public bool IsFriend { get; set; }
        public bool IsRequested { get; set; }
        public bool IsConnected { get; set; }
        public Country Country { get; set; }
    }
}
