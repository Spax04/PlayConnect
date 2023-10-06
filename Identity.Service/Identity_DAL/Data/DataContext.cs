using Identity_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Backgammon_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<User>? Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Country> Countrys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Friendship>()
                .HasKey(f => f.FriendshipId);

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.Sender)
                .WithMany(u => u.Friendships1)
                .HasForeignKey(f => f.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.Reciever)
                .WithMany(u => u.Friendships2)
                .HasForeignKey(f => f.RecieverId)
                .OnDelete(DeleteBehavior.Restrict);

            var countries = new List<Country>{
                new Country { Id = Guid.NewGuid(), Code = "AF", Name = "Afghanistan" },
                new Country { Id = Guid.NewGuid(), Code = "AL", Name = "Albania" },
                new Country { Id = Guid.NewGuid(), Code = "DZ", Name = "Algeria" },
                new Country { Id = Guid.NewGuid(), Code = "AD", Name = "Andorra" },
                new Country { Id = Guid.NewGuid(), Code = "AO", Name = "Angola" },
                new Country { Id = Guid.NewGuid(), Code = "AG", Name = "Antigua and Barbuda" },
                new Country { Id = Guid.NewGuid(), Code = "AR", Name = "Argentina" },
                new Country { Id = Guid.NewGuid(), Code = "AM", Name = "Armenia" },
                new Country { Id = Guid.NewGuid(), Code = "AU", Name = "Australia" },
                new Country { Id = Guid.NewGuid(), Code = "AT", Name = "Austria" },
                new Country { Id = Guid.NewGuid(), Code = "AZ", Name = "Azerbaijan" },
                new Country { Id = Guid.NewGuid(), Code = "BS", Name = "Bahamas" },
                new Country { Id = Guid.NewGuid(), Code = "BH", Name = "Bahrain" },
                new Country { Id = Guid.NewGuid(), Code = "BD", Name = "Bangladesh" },
                new Country { Id = Guid.NewGuid(), Code = "BB", Name = "Barbados" },
                new Country { Id = Guid.NewGuid(), Code = "BY", Name = "Belarus" },
                new Country { Id = Guid.NewGuid(), Code = "BE", Name = "Belgium" },
                new Country { Id = Guid.NewGuid(), Code = "BZ", Name = "Belize" },
                new Country { Id = Guid.NewGuid(), Code = "BJ", Name = "Benin" },
                new Country { Id = Guid.NewGuid(), Code = "BT", Name = "Bhutan" },
                new Country { Id = Guid.NewGuid(), Code = "BO", Name = "Bolivia" },
                new Country { Id = Guid.NewGuid(), Code = "BA", Name = "Bosnia and Herzegovina" },
                new Country { Id = Guid.NewGuid(), Code = "BW", Name = "Botswana" },
                new Country { Id = Guid.NewGuid(), Code = "BR", Name = "Brazil" },
                new Country { Id = Guid.NewGuid(), Code = "BN", Name = "Brunei" },
                new Country { Id = Guid.NewGuid(), Code = "BG", Name = "Bulgaria" },
                new Country { Id = Guid.NewGuid(), Code = "BF", Name = "Burkina Faso" },
                new Country { Id = Guid.NewGuid(), Code = "BI", Name = "Burundi" },
                new Country { Id = Guid.NewGuid(), Code = "CV", Name = "Cabo Verde" },
                new Country { Id = Guid.NewGuid(), Code = "KH", Name = "Cambodia" },
                new Country { Id = Guid.NewGuid(), Code = "CM", Name = "Cameroon" },
                new Country { Id = Guid.NewGuid(), Code = "CA", Name = "Canada" },
                new Country { Id = Guid.NewGuid(), Code = "CF", Name = "Central African Republic" },
                new Country { Id = Guid.NewGuid(), Code = "TD", Name = "Chad" },
                new Country { Id = Guid.NewGuid(), Code = "CL", Name = "Chile" },
                new Country { Id = Guid.NewGuid(), Code = "CN", Name = "China" },
                new Country { Id = Guid.NewGuid(), Code = "CO", Name = "Colombia" },
                new Country { Id = Guid.NewGuid(), Code = "KM", Name = "Comoros" },
                new Country { Id = Guid.NewGuid(), Code = "CG", Name = "Congo" },
                new Country { Id = Guid.NewGuid(), Code = "CR", Name = "Costa Rica" },
                new Country { Id = Guid.NewGuid(), Code = "HR", Name = "Croatia" },
                new Country { Id = Guid.NewGuid(), Code = "CU", Name = "Cuba" },
                new Country { Id = Guid.NewGuid(), Code = "CY", Name = "Cyprus" },
                new Country { Id = Guid.NewGuid(), Code = "CZ", Name = "Czech Republic" },
                new Country { Id = Guid.NewGuid(), Code = "CD", Name = "Democratic Republic of the Congo" },
                new Country { Id = Guid.NewGuid(), Code = "DK", Name = "Denmark" },
                new Country { Id = Guid.NewGuid(), Code = "DJ", Name = "Djibouti" },
                new Country { Id = Guid.NewGuid(), Code = "DM", Name = "Dominica" },
                new Country { Id = Guid.NewGuid(), Code = "DO", Name = "Dominican Republic" },
                new Country { Id = Guid.NewGuid(), Code = "TL", Name = "East Timor" },
                new Country { Id = Guid.NewGuid(), Code = "EC", Name = "Ecuador" },
                new Country { Id = Guid.NewGuid(), Code = "EG", Name = "Egypt" },
                new Country { Id = Guid.NewGuid(), Code = "SV", Name = "El Salvador" },
                new Country { Id = Guid.NewGuid(), Code = "GQ", Name = "Equatorial Guinea" },
                new Country { Id = Guid.NewGuid(), Code = "ER", Name = "Eritrea" },
                new Country { Id = Guid.NewGuid(), Code = "EE", Name = "Estonia" },
                new Country { Id = Guid.NewGuid(), Code = "ET", Name = "Ethiopia" },
                new Country { Id = Guid.NewGuid(), Code = "FJ", Name = "Fiji" },
                new Country { Id = Guid.NewGuid(), Code = "FI", Name = "Finland" },
                new Country { Id = Guid.NewGuid(), Code = "FR", Name = "France" },
                new Country { Id = Guid.NewGuid(), Code = "GA", Name = "Gabon" },
                new Country { Id = Guid.NewGuid(), Code = "GM", Name = "Gambia" },
                new Country { Id = Guid.NewGuid(), Code = "GE", Name = "Georgia" },
                new Country { Id = Guid.NewGuid(), Code = "DE", Name = "Germany" },
                new Country { Id = Guid.NewGuid(), Code = "GH", Name = "Ghana" },
                new Country { Id = Guid.NewGuid(), Code = "GR", Name = "Greece" },
                new Country { Id = Guid.NewGuid(), Code = "GD", Name = "Grenada" },
                new Country { Id = Guid.NewGuid(), Code = "GT", Name = "Guatemala" },
                new Country { Id = Guid.NewGuid(), Code = "GN", Name = "Guinea" },
                new Country { Id = Guid.NewGuid(), Code = "GW", Name = "Guinea-Bissau" },
                new Country { Id = Guid.NewGuid(), Code = "GY", Name = "Guyana" },
                new Country { Id = Guid.NewGuid(), Code = "HT", Name = "Haiti" },
                new Country { Id = Guid.NewGuid(), Code = "HN", Name = "Honduras" },
                new Country { Id = Guid.NewGuid(), Code = "HU", Name = "Hungary" },
                new Country { Id = Guid.NewGuid(), Code = "IS", Name = "Iceland" },
                new Country { Id = Guid.NewGuid(), Code = "IN", Name = "India" },
                new Country { Id = Guid.NewGuid(), Code = "ID", Name = "Indonesia" },
                new Country { Id = Guid.NewGuid(), Code = "IR", Name = "Iran" },
                new Country { Id = Guid.NewGuid(), Code = "IQ", Name = "Iraq" },
                new Country { Id = Guid.NewGuid(), Code = "IE", Name = "Ireland" },
                new Country { Id = Guid.NewGuid(), Code = "IL", Name = "Israel" },
                new Country { Id = Guid.NewGuid(), Code = "IT", Name = "Italy" },
                new Country { Id = Guid.NewGuid(), Code = "CI", Name = "Ivory Coast" },
                new Country { Id = Guid.NewGuid(), Code = "JM", Name = "Jamaica" },
                new Country { Id = Guid.NewGuid(), Code = "JP", Name = "Japan" },
                new Country { Id = Guid.NewGuid(), Code = "JO", Name = "Jordan" },
                new Country { Id = Guid.NewGuid(), Code = "KZ", Name = "Kazakhstan" },
                new Country { Id = Guid.NewGuid(), Code = "KE", Name = "Kenya" },
                new Country { Id = Guid.NewGuid(), Code = "KI", Name = "Kiribati" },
                new Country { Id = Guid.NewGuid(), Code = "XK", Name = "Kosovo" },
                new Country { Id = Guid.NewGuid(), Code = "KW", Name = "Kuwait" },
                new Country { Id = Guid.NewGuid(), Code = "KG", Name = "Kyrgyzstan" },
                new Country { Id = Guid.NewGuid(), Code = "LA", Name = "Laos" },
                new Country { Id = Guid.NewGuid(), Code = "LV", Name = "Latvia" },
                new Country { Id = Guid.NewGuid(), Code = "LB", Name = "Lebanon" },
                new Country { Id = Guid.NewGuid(), Code = "LS", Name = "Lesotho" },
                new Country { Id = Guid.NewGuid(), Code = "LR", Name = "Liberia" },
                new Country { Id = Guid.NewGuid(), Code = "LY", Name = "Libya" },
                new Country { Id = Guid.NewGuid(), Code = "LI", Name = "Liechtenstein" },
                new Country { Id = Guid.NewGuid(), Code = "LT", Name = "Lithuania" },
                new Country { Id = Guid.NewGuid(), Code = "LU", Name = "Luxembourg" },
                new Country { Id = Guid.NewGuid(), Code = "MK", Name = "North Macedonia" },
                new Country { Id = Guid.NewGuid(), Code = "MG", Name = "Madagascar" },
                new Country { Id = Guid.NewGuid(), Code = "MW", Name = "Malawi" },
                new Country { Id = Guid.NewGuid(), Code = "MY", Name = "Malaysia" },
                new Country { Id = Guid.NewGuid(), Code = "MV", Name = "Maldives" },
                new Country { Id = Guid.NewGuid(), Code = "ML", Name = "Mali" },
                new Country { Id = Guid.NewGuid(), Code = "MT", Name = "Malta" },
                new Country { Id = Guid.NewGuid(), Code = "MH", Name = "Marshall Islands" },
                new Country { Id = Guid.NewGuid(), Code = "MR", Name = "Mauritania" },
                new Country { Id = Guid.NewGuid(), Code = "MU", Name = "Mauritius" },
                new Country { Id = Guid.NewGuid(), Code = "MX", Name = "Mexico" },
                new Country { Id = Guid.NewGuid(), Code = "FM", Name = "Micronesia" },
                new Country { Id = Guid.NewGuid(), Code = "MD", Name = "Moldova" },
                new Country { Id = Guid.NewGuid(), Code = "MC", Name = "Monaco" },
                new Country { Id = Guid.NewGuid(), Code = "MN", Name = "Mongolia" },
                new Country { Id = Guid.NewGuid(), Code = "ME", Name = "Montenegro" },
                new Country { Id = Guid.NewGuid(), Code = "MA", Name = "Morocco" },
                new Country { Id = Guid.NewGuid(), Code = "MZ", Name = "Mozambique" },
                new Country { Id = Guid.NewGuid(), Code = "MM", Name = "Myanmar" },
                new Country { Id = Guid.NewGuid(), Code = "NA", Name = "Namibia" },
                new Country { Id = Guid.NewGuid(), Code = "NR", Name = "Nauru" },
                new Country { Id = Guid.NewGuid(), Code = "NP", Name = "Nepal" },
                new Country { Id = Guid.NewGuid(), Code = "NL", Name = "Netherlands" },
                new Country { Id = Guid.NewGuid(), Code = "NZ", Name = "New Zealand" },
                new Country { Id = Guid.NewGuid(), Code = "NI", Name = "Nicaragua" },
                new Country { Id = Guid.NewGuid(), Code = "NE", Name = "Niger" },
                new Country { Id = Guid.NewGuid(), Code = "NG", Name = "Nigeria" },
                new Country { Id = Guid.NewGuid(), Code = "KP", Name = "North Korea" },
                new Country { Id = Guid.NewGuid(), Code = "NO", Name = "Norway" },
                new Country { Id = Guid.NewGuid(), Code = "OM", Name = "Oman" },
                new Country { Id = Guid.NewGuid(), Code = "PK", Name = "Pakistan" },
                new Country { Id = Guid.NewGuid(), Code = "PW", Name = "Palau" },
                new Country { Id = Guid.NewGuid(), Code = "PA", Name = "Panama" },
                new Country { Id = Guid.NewGuid(), Code = "PG", Name = "Papua New Guinea" },
                new Country { Id = Guid.NewGuid(), Code = "PY", Name = "Paraguay" },
                new Country { Id = Guid.NewGuid(), Code = "PE", Name = "Peru" },
                new Country { Id = Guid.NewGuid(), Code = "PH", Name = "Philippines" },
                new Country { Id = Guid.NewGuid(), Code = "PL", Name = "Poland" },
                new Country { Id = Guid.NewGuid(), Code = "PT", Name = "Portugal" },
                new Country { Id = Guid.NewGuid(), Code = "QA", Name = "Qatar" },
                new Country { Id = Guid.NewGuid(), Code = "RO", Name = "Romania" },
                new Country { Id = Guid.NewGuid(), Code = "RU", Name = "Russia" },
                new Country { Id = Guid.NewGuid(), Code = "RW", Name = "Rwanda" },
                new Country { Id = Guid.NewGuid(), Code = "KN", Name = "Saint Kitts and Nevis" },
                new Country { Id = Guid.NewGuid(), Code = "LC", Name = "Saint Lucia" },
                new Country { Id = Guid.NewGuid(), Code = "VC", Name = "Saint Vincent and the Grenadines" },
                new Country { Id = Guid.NewGuid(), Code = "WS", Name = "Samoa" },
                new Country { Id = Guid.NewGuid(), Code = "SM", Name = "San Marino" },
                new Country { Id = Guid.NewGuid(), Code = "ST", Name = "Sao Tome and Principe" },
                new Country { Id = Guid.NewGuid(), Code = "SA", Name = "Saudi Arabia" },
                new Country { Id = Guid.NewGuid(), Code = "SN", Name = "Senegal" },
                new Country { Id = Guid.NewGuid(), Code = "RS", Name = "Serbia" },
                new Country { Id = Guid.NewGuid(), Code = "SC", Name = "Seychelles" },
                new Country { Id = Guid.NewGuid(), Code = "SL", Name = "Sierra Leone" },
                new Country { Id = Guid.NewGuid(), Code = "SG", Name = "Singapore" },
                new Country { Id = Guid.NewGuid(), Code = "SK", Name = "Slovakia" },
                new Country { Id = Guid.NewGuid(), Code = "SI", Name = "Slovenia" },
                new Country { Id = Guid.NewGuid(), Code = "SB", Name = "Solomon Islands" },
                new Country { Id = Guid.NewGuid(), Code = "SO", Name = "Somalia" },
                new Country { Id = Guid.NewGuid(), Code = "ZA", Name = "South Africa" },
                new Country { Id = Guid.NewGuid(), Code = "KR", Name = "South Korea" },
                new Country { Id = Guid.NewGuid(), Code = "SS", Name = "South Sudan" },
                new Country { Id = Guid.NewGuid(), Code = "ES", Name = "Spain" },
                new Country { Id = Guid.NewGuid(), Code = "LK", Name = "Sri Lanka" },
                new Country { Id = Guid.NewGuid(), Code = "SD", Name = "Sudan" },
                new Country { Id = Guid.NewGuid(), Code = "SR", Name = "Suriname" },
                new Country { Id = Guid.NewGuid(), Code = "SZ", Name = "Swaziland" },
                new Country { Id = Guid.NewGuid(), Code = "SE", Name = "Sweden" },
                new Country { Id = Guid.NewGuid(), Code = "CH", Name = "Switzerland" },
                new Country { Id = Guid.NewGuid(), Code = "SY", Name = "Syria" },
                new Country { Id = Guid.NewGuid(), Code = "TW", Name = "Taiwan" },
                new Country { Id = Guid.NewGuid(), Code = "TJ", Name = "Tajikistan" },
                new Country { Id = Guid.NewGuid(), Code = "TZ", Name = "Tanzania" },
                new Country { Id = Guid.NewGuid(), Code = "TH", Name = "Thailand" },
                new Country { Id = Guid.NewGuid(), Code = "TG", Name = "Togo" },
                new Country { Id = Guid.NewGuid(), Code = "TO", Name = "Tonga" },
                new Country { Id = Guid.NewGuid(), Code = "TT", Name = "Trinidad and Tobago" },
                new Country { Id = Guid.NewGuid(), Code = "TN", Name = "Tunisia" },
                new Country { Id = Guid.NewGuid(), Code = "TR", Name = "Turkey" },
                new Country { Id = Guid.NewGuid(), Code = "TM", Name = "Turkmenistan" },
                new Country { Id = Guid.NewGuid(), Code = "TV", Name = "Tuvalu" },
                new Country { Id = Guid.NewGuid(), Code = "UG", Name = "Uganda" },
                new Country { Id = Guid.NewGuid(), Code = "UA", Name = "Ukraine" },
                new Country { Id = Guid.NewGuid(), Code = "AE", Name = "United Arab Emirates" },
                new Country { Id = Guid.NewGuid(), Code = "GB", Name = "United Kingdom" },
                new Country { Id = Guid.NewGuid(), Code = "US", Name = "United States" },
                new Country { Id = Guid.NewGuid(), Code = "UY", Name = "Uruguay" },
                new Country { Id = Guid.NewGuid(), Code = "UZ", Name = "Uzbekistan" },
                new Country { Id = Guid.NewGuid(), Code = "VU", Name = "Vanuatu" },
                new Country { Id = Guid.NewGuid(), Code = "VA", Name = "Vatican City" },
                new Country { Id = Guid.NewGuid(), Code = "VE", Name = "Venezuela" },
                new Country { Id = Guid.NewGuid(), Code = "VN", Name = "Vietnam" },
                new Country { Id = Guid.NewGuid(), Code = "YE", Name = "Yemen" },
                new Country { Id = Guid.NewGuid(), Code = "ZM", Name = "Zambia" },
                new Country { Id = Guid.NewGuid(), Code = "ZW", Name = "Zimbabwe" },
            };


            modelBuilder.Entity<Country>().HasData(countries);

            /*   public Guid UserId { get; set; }
          public string? Username { get; set; }
          [JsonIgnore]
          public byte[] PasswordHash { get; set; }
          [JsonIgnore]
          public byte[] PasswordSalt { get; set; }
          public string? Email { get; set; }
          public string ImgUrl { get; set; } = string.Empty;
          public int Coins { get; set; }

          public Guid CountryId { get; set; }
          [ForeignKey("CountryId")]
          public Country Country { get; set; }

          [JsonIgnore]
          public List<Friendship> Friendships1 { get; set; } // User1 in friendships
          [JsonIgnore]
          public List<Friendship> Friendships2 { get; set; } // User2 in friendships*/

        }
    }
}
