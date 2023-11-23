using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Auth.Models.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        [JsonIgnore]
        public byte[]? PasswordHash { get; set; }
        [JsonIgnore]
        public byte[]? PasswordSalt { get; set; }
        public string? Email { get; set; }
        public byte[]? UserImage { get; set; }
        public int Coins { get; set; }

        public Guid CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country? Country { get; set; }

        [JsonIgnore]
        public List<Friendship>? Friendships1 { get; set; } // User1 in friendships
        [JsonIgnore]
        public List<Friendship>? Friendships2 { get; set; } // User2 in friendships
    }
}
