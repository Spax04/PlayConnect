using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity_DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countrys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countrys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Coins = table.Column<int>(type: "INTEGER", nullable: false),
                    CountryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Countrys_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countrys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    FriendshipId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SenderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecieverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsAccepted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.FriendshipId);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_RecieverId",
                        column: x => x.RecieverId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("00256718-0645-452f-b892-b7748d4d04bb"), "QA", "Qatar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("002c149d-d7cd-475a-b2f6-ab451eb9e41f"), "FI", "Finland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("04be5b0a-981e-4901-b13a-6ab1c3270c41"), "MW", "Malawi" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("08c995e3-1697-4d35-8330-94c9d030dfbd"), "SY", "Syria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("08e40902-f09a-440b-95d8-c7f74af5e4cb"), "SI", "Slovenia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0980b42e-6508-4535-a966-3d9f769796c5"), "BG", "Bulgaria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0a8d4ca8-8786-4e09-94c2-7e25ce8b34bc"), "GT", "Guatemala" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0ad65b8d-c346-4436-908e-099b2fde81c0"), "UY", "Uruguay" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0b0b3450-e584-4764-b445-fe2d44fed022"), "DO", "Dominican Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0c8634e2-7b8d-4c19-a213-09e6cfdecc85"), "PA", "Panama" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0dc3d79f-acfb-4756-8096-0887fa5e676e"), "LR", "Liberia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0f6c60e0-aaab-491c-9f34-2feed260f4b7"), "PW", "Palau" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("110c1777-a954-427c-926f-06051aab2640"), "GM", "Gambia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1186054b-1e31-4cd8-88a3-f61529d6d545"), "NR", "Nauru" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("18011210-dfd6-401e-aa28-d52ec782c6aa"), "CU", "Cuba" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("18112fa9-10ec-4919-9187-281e635b8c06"), "IT", "Italy" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1898dbf3-c1eb-4050-a953-552bb97f34ed"), "VC", "Saint Vincent and the Grenadines" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("18c4dcbd-8640-4a8e-8478-140535d8f4b8"), "AF", "Afghanistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("19464ce6-cd5f-4f88-b192-107c51479316"), "CL", "Chile" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1b56e461-cb9b-4186-927d-50b3c2d0d57c"), "GD", "Grenada" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1c919bc4-b019-43b4-9bb9-da249306f6a4"), "RW", "Rwanda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1f220f4a-7ffb-4802-b7c8-b9fe029ffa47"), "BA", "Bosnia and Herzegovina" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("200b8d48-0893-4072-acaf-d96acd446566"), "BS", "Bahamas" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2026bb6c-aa79-4203-946c-3907ed37eb43"), "ST", "Sao Tome and Principe" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("202f6c75-46a0-4b04-91b1-401438cb31d1"), "BW", "Botswana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("206c3a29-e323-4976-bb42-ffadd136d4da"), "LS", "Lesotho" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("22a61788-7f0d-4736-b2eb-89cd2d5335be"), "UZ", "Uzbekistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2483a5c4-baa1-4594-9d59-345a376cd3b6"), "AT", "Austria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("26711de2-5ea3-491c-bb0c-e5538950c5ae"), "LA", "Laos" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("29d8cfc7-2cfb-4a27-a784-11cd9989bdce"), "NZ", "New Zealand" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("29fe781e-1989-44b6-b10f-08a67db2aff5"), "ZA", "South Africa" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2a81010a-bfea-43b3-9ef4-b10a475940af"), "CA", "Canada" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2b91492c-5f44-4048-bdc7-424427cd70b5"), "SV", "El Salvador" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2c220c1d-e4f0-4931-b6c9-1f86082881a8"), "TO", "Tonga" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2e68c194-eba2-44b4-ba14-1c7274c043b5"), "HT", "Haiti" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2e885738-1981-4e1f-a814-0a9268468639"), "CR", "Costa Rica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2fa1ac81-890d-46c7-ad15-c445936acac6"), "TZ", "Tanzania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3013fbf4-de55-4309-a913-521337b6a47b"), "MM", "Myanmar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("30386db6-64b7-4c7b-8a4f-9b328ee0d560"), "GE", "Georgia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("31e612fc-33c9-4062-a789-9d9e4ba6ef6f"), "VE", "Venezuela" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("33517525-1bcc-461c-a753-03334b95e347"), "IR", "Iran" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("33a8c1bc-e976-4bf0-81cb-de00150e6ad9"), "IE", "Ireland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("368d2e22-7594-4107-bfdc-85a75647ba1f"), "FR", "France" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("384aec82-5dab-4397-9076-9dee2d75ea3b"), "AO", "Angola" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("386b45ca-3060-4e19-892a-22acb3ace47a"), "NL", "Netherlands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("39c60555-351f-40a5-8f22-8f0882f00e67"), "PY", "Paraguay" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3a5161da-0007-4d05-bbf3-4d50141d5b97"), "GY", "Guyana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3c744cfe-99f2-4266-bbd6-df94d03f34fe"), "MK", "North Macedonia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3d9bb8bc-d4cb-4758-8601-3c6483295a19"), "KM", "Comoros" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3e93e919-3194-473e-b2bb-f0a7be99289d"), "YE", "Yemen" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3e9aebce-1fad-4376-96d1-165fc5416897"), "VU", "Vanuatu" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("435f64d0-b1c0-4734-9e12-1909bcd45fb2"), "MN", "Mongolia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("46628149-0121-41bd-9b53-24486ba1bd12"), "MT", "Malta" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("46d871c5-9681-4317-b927-aa78e4ef8356"), "CH", "Switzerland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("475b1af4-5774-4187-bf53-7d4813b301bd"), "TR", "Turkey" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("494d2331-8364-40ea-ae87-09b0dcf5c444"), "GR", "Greece" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4d44c1f1-ec76-4f1a-9090-cf680d88ee03"), "KI", "Kiribati" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4db0cf4a-3f17-4017-afcf-941c6f30fc59"), "MA", "Morocco" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4f0720c3-e3cb-4457-8d0a-47b332baa551"), "KN", "Saint Kitts and Nevis" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("500ef857-be6f-41e2-8ede-471573f7b2f7"), "GA", "Gabon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("50750ab2-1bbd-4446-8745-fb32c9a27db8"), "KE", "Kenya" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("51780af8-e55f-4a47-9951-1c7ae1f2e3d1"), "CG", "Congo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("54aa0887-f5a6-43c7-af04-b9c8e46d8bb6"), "MY", "Malaysia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("54d6424b-aee2-442a-a756-4dad51d8a773"), "DM", "Dominica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("54d833ff-b826-4b7f-b24d-115a589a74fd"), "TN", "Tunisia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("550a4cdf-a5e1-4a85-a484-a3f2e08bf243"), "IQ", "Iraq" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5770bcc1-7eb1-4127-a640-f53d8b6630ed"), "NO", "Norway" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("57c3001d-bb10-4017-8ecd-ac7027c44e95"), "BT", "Bhutan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("57f78ec0-058b-4f94-a122-97e1e8751d17"), "ML", "Mali" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5827ee0d-fd4f-4476-8482-5abbec399041"), "ZM", "Zambia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("59052215-0e18-40ff-a238-c760350be706"), "SK", "Slovakia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("590aea67-1560-43a6-9c45-4fb84663ca97"), "US", "United States" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5947c494-0db1-403c-9279-057a68590685"), "SC", "Seychelles" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("59fd20e3-1f82-471b-a621-0c815f8860df"), "FM", "Micronesia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5a368985-9374-4599-93ed-670736cb7996"), "GQ", "Equatorial Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5a43bfd2-b76a-4e10-b3ec-f9d44f8e99dc"), "KZ", "Kazakhstan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5acd97b2-c322-4de1-988a-7f268c9350fa"), "GN", "Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5b42422f-20db-4e87-9fff-1a5f87e379b0"), "BR", "Brazil" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5cdb9d5f-2a53-412e-97dd-1149bfdb18ab"), "WS", "Samoa" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5d1d2625-95c5-40a3-b37e-43c7ff101ce0"), "BF", "Burkina Faso" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5de4ce15-dd45-48c9-b0fa-ba2d8b17d733"), "GW", "Guinea-Bissau" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5df6461d-b0be-4f14-9d42-b7d370e83aed"), "LK", "Sri Lanka" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("602bc458-2596-4105-bf90-6fbaf525fc04"), "AZ", "Azerbaijan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("61b599bf-d512-483a-91f0-702a2b953182"), "EE", "Estonia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("62ba217f-496d-4d55-bf07-d61fa06dbf0e"), "SR", "Suriname" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("665a991d-b96d-4eec-9d42-b387616c6d2d"), "SA", "Saudi Arabia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("665c321b-5ebf-492d-b1d4-be698c879b2a"), "AE", "United Arab Emirates" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("66de0e91-2d02-480f-82f5-9112a36aa8f6"), "TW", "Taiwan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("68a85cf1-ac4f-49bc-99f1-79fd9631c7e0"), "SB", "Solomon Islands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6d864aae-6787-4d53-9c9a-b1f1d3a2d862"), "JP", "Japan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6dec78a0-772c-4d23-8d3b-b40c71490f94"), "DZ", "Algeria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7071d3d6-b4cf-400a-a888-d43eac718d36"), "AR", "Argentina" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7077875f-6bd8-42ad-bbc3-e3c79762591b"), "CD", "Democratic Republic of the Congo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("71d5cdf9-5ee6-4a0c-b0a1-5faa8426f090"), "LY", "Libya" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("72925270-4819-491e-970a-db8daa07d742"), "DJ", "Djibouti" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("740641dc-a154-458b-8263-0a398d91fbd3"), "NE", "Niger" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("762e9d7d-75f6-478f-bfb8-20b874d297ae"), "TL", "East Timor" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("767ab7b2-2ffa-4af6-bb07-cf40d64a4b94"), "EG", "Egypt" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("78e4806c-04a7-481b-9894-26db9d9b5f2f"), "SL", "Sierra Leone" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7a131a0e-c101-4461-898b-ebc7c097a444"), "SO", "Somalia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7a33fd3c-2637-4b2a-92fb-e34cfb5e6010"), "NP", "Nepal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7a797905-c5da-46d0-ad80-85c51c903b42"), "CO", "Colombia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7a98444b-6e62-4789-9508-69cd1f6664d0"), "MZ", "Mozambique" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7dc4cd88-167b-4578-8d61-56260b4df1fb"), "JM", "Jamaica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7ee6dad1-f3cd-41e2-ba83-23accf48f3f9"), "SD", "Sudan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8014daef-10e5-4703-8d8c-7a54cc16eaaa"), "BJ", "Benin" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8065eced-3562-4888-8da3-5cb91197dde7"), "VA", "Vatican City" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("80ca4c44-a2c7-4ba5-b4ce-da93b28c057b"), "NG", "Nigeria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8275479a-5ebe-40d9-9a49-a4aaffdb71fe"), "DK", "Denmark" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("82b4c627-9baf-4aed-8de0-b44b91a111be"), "ES", "Spain" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("866b084c-8615-4289-b315-4ccd57d6bd25"), "DE", "Germany" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("88277c30-4e55-4204-b138-6b8e2149a805"), "TG", "Togo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("890aecd2-28c1-482d-bd7a-aadbe92a6325"), "KW", "Kuwait" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8c43616c-c7a1-4130-aa7b-be329fc67d8a"), "BN", "Brunei" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9163826e-bf38-482e-8025-afb03ca71dab"), "BH", "Bahrain" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("933fe465-655f-4b66-96df-e3fd1c591d90"), "BI", "Burundi" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("97b62cc1-3f46-408e-a240-6bd875f8a85a"), "IL", "Israel" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("98598d6c-02bd-41e4-8ab6-6cab266635fa"), "MC", "Monaco" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9dc91d9c-f0de-4ba7-a2c0-76134e1f5e91"), "LU", "Luxembourg" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a184fb5e-512c-47a5-8659-6d933137e197"), "BD", "Bangladesh" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a2d0d92a-5035-4f67-8e23-e782dc02c519"), "MV", "Maldives" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a32e845c-de98-4858-a50b-8978eef4418d"), "TH", "Thailand" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a45efe3d-d3e9-4c01-8ecc-68d5a57c0652"), "ET", "Ethiopia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a6dd67c6-660e-4489-accd-769643c0e5a0"), "FJ", "Fiji" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a8a77514-e35b-4ceb-9260-9761c647e484"), "MD", "Moldova" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a8ff0ec2-720c-4e91-a2d5-50cd96cedbb2"), "HU", "Hungary" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ac02a0f9-7f30-4135-9079-23d6c210858c"), "MU", "Mauritius" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ac687e1e-5f63-4cbc-952b-dfbca6a55b12"), "SE", "Sweden" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ad353a6f-9520-4c5b-a871-beb77e46726c"), "AM", "Armenia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ae2b8fab-d23b-4c31-bdb5-2817dcfef5e6"), "SN", "Senegal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ae3b87ec-2cef-4909-9a38-e0fa841ea1bb"), "TT", "Trinidad and Tobago" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ae8d0f26-3d41-4bef-bc0a-b9ead2990e7a"), "KP", "North Korea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("aede2370-d8b6-4843-9c74-572a1d9db33b"), "CM", "Cameroon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b1a89353-2d8d-4888-8f4e-a4f27dd2eca7"), "TV", "Tuvalu" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b206b614-2921-4370-b7a7-c6941ec3729f"), "RS", "Serbia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b2482610-2660-45d9-b7c0-e60e37171906"), "AU", "Australia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b290e371-5142-4aad-8ad3-62e9d4a6c493"), "LI", "Liechtenstein" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b3ecd218-2982-424e-ad9e-04827b6eee8b"), "PE", "Peru" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b48884aa-341d-4391-9bce-80e11a0a4261"), "NI", "Nicaragua" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b53ab50a-6dbe-45c6-af56-41f8c169d817"), "CN", "China" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b708cc86-419c-4459-a00c-999c160ed80e"), "KR", "South Korea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bb3d0e6c-0b89-4b4a-802e-290bbbe6ad9f"), "CY", "Cyprus" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bbe682f8-f906-4cb7-9786-ab25a3f18a80"), "BY", "Belarus" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bc2ea00f-d7c7-4e9a-9b8f-7de6668f31a1"), "PL", "Poland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bd9bfe5b-1c89-450e-82f0-75ba956abed2"), "ER", "Eritrea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bf2804b6-4c77-4f5d-94ef-dd8ae2347cbe"), "ME", "Montenegro" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bf6d09ad-d34e-4efd-a69f-84fcfe18aefe"), "MG", "Madagascar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bfb34f0d-cf01-444b-bc72-b349a1c8778f"), "UA", "Ukraine" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bfc3943f-c380-4c9d-9b8b-988bd67d9bc0"), "SZ", "Swaziland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c06d7815-9ed1-408d-8450-4bf4972b9d80"), "UG", "Uganda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c1783504-a546-4387-a8e1-10a50303efed"), "LC", "Saint Lucia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c1c1c6cc-7d26-4021-a461-85b60820b7cb"), "IN", "India" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c244c58c-8566-4414-b5b7-6e8dd635bc90"), "MX", "Mexico" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c2fe3fa6-9e2f-49bb-850a-36b675f2d47a"), "IS", "Iceland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c382a078-e9e5-41d1-9bae-784a786b92b8"), "NA", "Namibia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c4bc93b3-576a-4dc9-8159-c5bd271b5434"), "BZ", "Belize" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c4c115d4-84e8-412f-a0f4-74624f912fbe"), "HN", "Honduras" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c82d16d0-a60a-43c5-9f77-1650035c0481"), "AD", "Andorra" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c8ce5200-c03e-4564-8ac2-33a09aa5665d"), "LB", "Lebanon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cbfe7c46-4bba-483e-875a-df96c656b1c3"), "CI", "Ivory Coast" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ccd75e46-623d-42e9-bade-2e9be172628e"), "SG", "Singapore" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cf16cf70-abcb-4721-b96a-87fff648457f"), "TD", "Chad" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d06002b1-4ae2-4c33-a0ce-0f83663405dd"), "CZ", "Czech Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d442cb0b-0061-4c84-84f3-3e08ed353b20"), "CF", "Central African Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d558138b-06c7-49bb-94a5-a3dd30f6cd49"), "BB", "Barbados" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d59088c7-9863-4f72-8868-b2fb7f8165a9"), "CV", "Cabo Verde" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d5c3bbc8-6482-4c98-9a2f-4fe1221c7bf5"), "RO", "Romania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d62b3695-63b3-4120-a977-c31967c1544d"), "AG", "Antigua and Barbuda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d740ce42-6877-4979-a4fa-cd6b630b12b1"), "JO", "Jordan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d74b7d27-d8fc-416f-82fa-e8f877d4346f"), "LV", "Latvia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d762f85f-3360-46e5-86c7-4ae7922999b1"), "MR", "Mauritania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d79d19d4-71f2-4cc4-b92a-20e07132e3aa"), "VN", "Vietnam" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d8b9ee70-2932-4f57-95fd-353c83a672bf"), "SM", "San Marino" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dbe3ea26-7d90-41b3-9fec-961f7fae4e05"), "RU", "Russia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dc8a5bd6-81b1-47ee-b1c7-caba98969f0e"), "KH", "Cambodia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e2a35270-f478-4975-abae-893a34d2f144"), "PG", "Papua New Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e2f85626-1e7e-462b-b1f3-bf220df7d6a6"), "OM", "Oman" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e4eafdf5-aa15-466e-a3ab-c3a4020a1073"), "KG", "Kyrgyzstan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e6110b41-383d-4524-82b9-bb0d6f58a73a"), "MH", "Marshall Islands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e9412f5d-4dab-49c7-9a84-e30c2503c2f6"), "GB", "United Kingdom" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ea5f5391-8ad3-4056-83f0-2b5fd79fdc6b"), "BE", "Belgium" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ecc76640-b267-48a6-86eb-ce614999a6ee"), "AL", "Albania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ee5ff0a7-8d6e-415f-bc33-1693054fee6c"), "XK", "Kosovo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f04f3267-2405-4df9-bba9-53498f634140"), "EC", "Ecuador" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f0618d17-d37f-421e-a228-ae49c266d19f"), "LT", "Lithuania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f236fcd9-7ccf-43a7-b4a9-8ea38cdc10a6"), "GH", "Ghana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f2d31f82-da84-42d2-b4eb-1f662a1cb215"), "BO", "Bolivia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f2d35091-62ae-46a9-a659-872765e3f3b3"), "SS", "South Sudan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f36a86a3-f586-4ebf-a694-c541234793b5"), "TJ", "Tajikistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f544f363-78f1-47af-b3f0-7ea184bda461"), "PK", "Pakistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fa518907-07fe-4f49-9196-0abca14f1b0b"), "PH", "Philippines" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fb5f8a20-f2dc-462e-8f84-fe56b4b02798"), "TM", "Turkmenistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fc784679-cc77-493d-bdc0-054378ed39a7"), "ZW", "Zimbabwe" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fe19ec9c-7ea2-4bfe-8c30-6197ac9460fc"), "PT", "Portugal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fecbaff2-f536-4df8-b225-fa26f7e61750"), "ID", "Indonesia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ffb82461-0d36-49dc-9b2e-a252202609a0"), "HR", "Croatia" });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_RecieverId",
                table: "Friendships",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_SenderId",
                table: "Friendships",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countrys");
        }
    }
}
