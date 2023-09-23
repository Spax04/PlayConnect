using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Identity_Models.Users
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        public string? Email { get; set; }
        public string ImgUrl { get; set; } = string.Empty;


    }
}
