using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.DAL.Migrations
{
    public partial class fix2 : Migration
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
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    UserImage = table.Column<byte[]>(type: "BLOB", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    IconLink = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("016d8b24-3ac3-492e-8c49-b19527f66637"), "PA", "Panama" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("023e182c-1bc9-4fec-97eb-f6944fe043a0"), "IN", "India" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0254fb3f-bbf7-45db-a860-aef4ef64adc0"), "EC", "Ecuador" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("02b8efae-8ab7-4a4e-82b8-f46a5682b859"), "MC", "Monaco" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0306feba-193f-4251-9a20-7e7ecc9e207f"), "SM", "San Marino" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("05f758d0-788d-47ef-a195-f1a984836235"), "JO", "Jordan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0742ef81-6e6d-4171-97c6-2abebac182e7"), "XK", "Kosovo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("09029b1f-4b6c-4a79-afc2-a6a19c33caaf"), "GM", "Gambia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0acc9eae-79b0-42e9-a5ff-8cd04274e46d"), "UG", "Uganda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0bc6fabc-550e-4449-aad6-0bbfc719d608"), "MN", "Mongolia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0c0537f1-36d3-4e05-acfb-5ab8de111216"), "DZ", "Algeria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0c6dad0f-6d72-45ec-a471-c8d45c34dc57"), "ID", "Indonesia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0d4eb002-d091-4a78-b5b7-f19d0ead16b4"), "MV", "Maldives" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0d960056-679c-4710-97c1-0cc4ccd1ff79"), "KN", "Saint Kitts and Nevis" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0da0415f-46f5-46b2-b287-f4aaa60f9b14"), "GH", "Ghana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0fa2ede7-22b8-4594-bbdc-66a40946278f"), "PE", "Peru" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0fb76a28-d38d-490e-b36d-e39cbefd3035"), "DK", "Denmark" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0fc9f8b5-59a8-46a3-a834-1ce892011cff"), "BE", "Belgium" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("10525995-93bb-407d-8942-9fbcb6821c77"), "GT", "Guatemala" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("12fe46a7-7cea-4c9d-ab6c-243150fd7efe"), "CH", "Switzerland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1510a94b-56cf-4948-9d37-147d8587737b"), "SI", "Slovenia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("163a3a35-f7a7-411b-b7c8-e0adbd15aadd"), "IE", "Ireland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("16dfd0d3-19b9-438b-9d98-4b0debc37767"), "BH", "Bahrain" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("17139f8b-ddfe-4623-88a2-bba60a00f39d"), "TR", "Turkey" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1ce8bb73-ec60-476c-afcc-dd66206f1dcd"), "KR", "South Korea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("22f9b039-d6b5-4ea8-98eb-eb6806bf836a"), "KE", "Kenya" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2385e661-eee9-478a-ab15-c2b66ee91323"), "YE", "Yemen" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2613ab91-797d-4bbd-aa68-ae86a6c6674b"), "ZA", "South Africa" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("275c370c-cf0c-4339-9e19-25417e9dd572"), "VN", "Vietnam" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2954dd7d-90f6-4f05-b431-73b84e4cca79"), "TZ", "Tanzania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2970ec51-4bbc-47e8-b3aa-fb0bec098015"), "SV", "El Salvador" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2a0a19cd-8c08-423b-ac96-8ec7733defa6"), "LU", "Luxembourg" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2ccf16e4-9dfc-4e7d-8719-3111f9efe9f7"), "MG", "Madagascar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2f260ee8-8719-4cf4-80cb-27e49b7cd0b4"), "DO", "Dominican Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3223edde-8106-42e1-a8db-6a037e17e933"), "AZ", "Azerbaijan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3228b6fc-6a2e-45f5-a8e2-2fca115243b4"), "BJ", "Benin" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("344dd832-85f4-475c-9ba8-ce41e167c4a6"), "JP", "Japan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("34b935a7-3f77-4005-8df9-8a7dc27f11f4"), "CN", "China" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3a8a9e23-0af8-4540-8c31-ec1c2e4a4639"), "SL", "Sierra Leone" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3be94490-b629-4f91-adb8-d1ddf1e1e6df"), "GB", "United Kingdom" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3da34636-9ccd-4caf-aded-4d61bbe8f4fd"), "NI", "Nicaragua" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3f08e5bd-5bbf-4cf0-85e8-adf2b4cefa1d"), "TV", "Tuvalu" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3fe6191e-0beb-4fe3-b983-569a0191b534"), "NO", "Norway" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("41bc91e2-3820-4e3f-a809-cf1b96dba324"), "BT", "Bhutan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4226b064-06fd-43de-a5ac-1485c4ddd089"), "HR", "Croatia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("42d7ef45-9b5e-4ab3-b2ab-130e16cd45d2"), "SB", "Solomon Islands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("433b33f9-736e-4ccc-9bcc-e5a4ae3676a7"), "BS", "Bahamas" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("45f668ed-83a8-4286-8656-e72812e91f7a"), "ZM", "Zambia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4764530a-2965-4b48-9b6e-68e20d36eb91"), "RU", "Russia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4881ac96-35f8-4630-a859-b9782f751060"), "GN", "Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("49399363-0ba8-4ca9-bcc8-cf7f2885a526"), "BF", "Burkina Faso" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("49a06ccd-c0fe-48a2-9f25-006516edd9df"), "MD", "Moldova" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("49e1b7c4-dbbb-4501-95fb-9d1c00915ed5"), "MH", "Marshall Islands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4ba77a6c-a3d2-4f5d-8131-1a99adebaae1"), "CY", "Cyprus" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4cb7ff4c-5242-419d-a545-5391dad35978"), "SO", "Somalia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4cd47fca-b693-4590-8db5-e03b98dbcf97"), "MA", "Morocco" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4db5beee-0613-43d5-b019-e4ce0c94fcac"), "CV", "Cabo Verde" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("504ea9dc-0341-49e2-99bc-7972590e584a"), "UZ", "Uzbekistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5247474f-793e-41c5-8dbd-005a020b9722"), "EE", "Estonia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("53ccafe5-4440-4996-913c-face7bdfc933"), "SY", "Syria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("53d4c151-8268-436b-bb9b-c6a878e34c08"), "MT", "Malta" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("55882c60-a18b-44b3-b4f7-7aca055e026d"), "TG", "Togo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5625745e-604f-400b-93fb-e842bc2d43a0"), "AU", "Australia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("569a25e4-3df8-40e7-b0e5-e41dd526ee60"), "EG", "Egypt" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("573248e0-fb06-4cc8-9994-68edf177c86d"), "TJ", "Tajikistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("57b29522-904e-47db-83c4-d8c08908b126"), "LY", "Libya" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("580cf5af-4f7b-4dd9-953d-4d085d34da21"), "AO", "Angola" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("59786a6b-41be-4c74-a245-d24ab98094e3"), "IS", "Iceland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("59ab13c3-97c8-4115-a195-ca381e1d7471"), "SA", "Saudi Arabia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("59c37593-3253-4ef6-8847-caceec08d2dc"), "SE", "Sweden" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5d71badc-9ea8-45c7-8e0a-1fac61a98fb1"), "UY", "Uruguay" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5fe258ae-be15-431e-a0eb-d0b84aa14143"), "NR", "Nauru" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("60fab896-e47f-47e6-8103-03fd58fb18fb"), "WS", "Samoa" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("62743c5c-13e9-4058-915a-a0cfdaa289aa"), "TO", "Tonga" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6476cea6-8bbc-4303-84d5-0a638e94d6e4"), "PW", "Palau" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("67b8e1d2-a668-47d2-a11b-6083e3f94009"), "DM", "Dominica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("69d9936d-0ff3-49ec-94a4-89822052483b"), "CM", "Cameroon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6ba78be0-f9ae-4b70-9513-eefaf0cbbf99"), "AL", "Albania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6d017f45-1ee5-40ec-86f4-adeb0866caf7"), "ST", "Sao Tome and Principe" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6d5c7ff2-9c98-4823-8e88-cb50b3e4bee2"), "GW", "Guinea-Bissau" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("700c5bdd-cd7a-4225-8fff-3ccffb6b8347"), "SK", "Slovakia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("70572cb1-32d8-42cd-ad6c-0d077ed9628c"), "CI", "Ivory Coast" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("715a31e6-13d5-4d89-bb9b-2a1f02b341e4"), "TM", "Turkmenistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("71748fff-96c8-4656-a140-9b58ae181195"), "FJ", "Fiji" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7220a5e4-7f29-4f80-9965-d2d72e1e90dc"), "PT", "Portugal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("73535048-ef94-41fb-af93-7db372f7d11e"), "AM", "Armenia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("76420fe7-26ca-4bbb-80ef-74fdb1ba169c"), "BI", "Burundi" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("78db7135-cfe0-4412-bc3f-411e80108a13"), "MX", "Mexico" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("799f2eab-f94f-4967-bf6d-44d30de6dae5"), "PH", "Philippines" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7bb05b13-a46e-4b9b-8e35-8119cea71e08"), "IT", "Italy" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7e519fde-10e9-47df-834c-471ed87a385b"), "NP", "Nepal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7f139d99-547e-4bef-9561-f5c5df848071"), "CF", "Central African Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8134bf85-256f-4a8d-8512-ac86317f6b36"), "MU", "Mauritius" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("81e9a5bb-5cf8-4df8-91f8-57d7961e0125"), "CA", "Canada" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8260d86f-669d-4224-944f-538e624550c6"), "AR", "Argentina" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("827fdf81-94b0-4d70-b76f-625cb7f3edb4"), "CZ", "Czech Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("83cbb6c8-52b0-4a72-9ee1-cd7391b3bede"), "HU", "Hungary" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("84b1d361-e8c0-44be-9643-ce25f8739458"), "LV", "Latvia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("856dd149-c285-4548-be01-1f1d58ec0a17"), "RO", "Romania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("87703806-d779-4c36-8891-ab7355a295cb"), "BZ", "Belize" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("879dac91-14ab-4670-a728-044bad38f15c"), "MZ", "Mozambique" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("88039e45-df14-4765-b239-e2b44c374e7b"), "MK", "North Macedonia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("889f9438-0ced-4066-ba65-133ef7c28a5f"), "CL", "Chile" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("89319628-d523-4a10-9955-4fed113df36f"), "NE", "Niger" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8d037b84-8164-402a-9983-277643f172c3"), "ME", "Montenegro" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8e633a27-5fe2-4bca-8375-cfabae0d2a4a"), "RS", "Serbia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("925439e5-43f8-483d-bbf1-a59c1317c9fc"), "LB", "Lebanon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("93d112cc-5af6-4090-a5d5-1196a366c01d"), "AD", "Andorra" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("93f3607e-3cb8-4da4-8ddf-88c9454a66e9"), "AE", "United Arab Emirates" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("94188736-bd60-4003-bdcc-6d5cb5579983"), "TN", "Tunisia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("95d0f453-8b5d-4cc7-a1ea-34afdc8217d4"), "BO", "Bolivia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("99ebda29-1fea-4c14-a565-f7e593c34951"), "PG", "Papua New Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9afada4c-8deb-4a28-8a01-da84c4a23103"), "SD", "Sudan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9b8c2c69-c915-4bb2-95dd-f417523a13af"), "LI", "Liechtenstein" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9ed0bcba-43b5-427c-a6b2-5b9db05bfbe9"), "ML", "Mali" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a0bb51fa-4ce4-4b65-b4e0-31339b1d4ec0"), "LA", "Laos" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a0eaf04f-f717-4405-9bb5-62bb2291926f"), "PK", "Pakistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a381ed83-0064-461a-b7fb-42761f121a40"), "FM", "Micronesia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a4d5000e-dbe0-4400-9d73-ef92b55220e6"), "GD", "Grenada" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a5e8a658-f4dd-4a1d-94b4-9ae6dfd40569"), "MY", "Malaysia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a5f08839-5403-4f04-be9a-a3a8db941d2e"), "MM", "Myanmar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a7a73652-2607-4044-b985-027ed4328aca"), "HT", "Haiti" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a7cc3913-22be-4f9a-b6a3-6ac885d1c8a4"), "AT", "Austria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ab6b8dab-8889-4ac3-98fc-1b8482e56746"), "PL", "Poland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("abfbd69c-48a6-46a6-9f49-793922274736"), "VC", "Saint Vincent and the Grenadines" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ad36273d-dbf0-4e66-8894-8bda940d6bd0"), "AG", "Antigua and Barbuda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ae040777-13a0-4d06-a07f-d3a8b7ce492e"), "SS", "South Sudan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ae4318c1-83a7-4d99-8c57-7b16c3e500c6"), "SR", "Suriname" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b41dd650-5233-4196-8fda-3bffddebecef"), "LK", "Sri Lanka" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b68cf697-4006-4d88-9cbb-55e6cabb5480"), "GA", "Gabon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b7c7bd02-826a-434c-bebf-a47737d7d9d6"), "HN", "Honduras" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b96051eb-d163-4282-9ac3-f62c01009457"), "TL", "East Timor" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b9fefd95-e386-41f7-b87d-d0a81cf320dc"), "QA", "Qatar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bc17dc15-ff30-4d90-8bae-d5ffe5126c5b"), "KG", "Kyrgyzstan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bda2bf16-8cc5-4bc3-a441-4d84b66bd83a"), "BD", "Bangladesh" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bdd6744b-9c46-477c-859d-699110b0c45d"), "DE", "Germany" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("be298f2f-4ce2-4448-8ba2-aa33e1506d3b"), "CR", "Costa Rica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c0d8bc9f-b5e4-4c73-aaff-842268d000d2"), "CU", "Cuba" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c0e0fd92-7b72-4912-9abf-1b4fc772f2c8"), "TH", "Thailand" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c13e04a7-b91b-47f9-aad1-2c511ad5bbed"), "VE", "Venezuela" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c2b2f5c7-6984-4c86-8003-bfdeaed8a11d"), "TT", "Trinidad and Tobago" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c3897635-27a4-485d-b632-62db20a65292"), "SG", "Singapore" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c3e71909-d990-43c7-87f4-d9db78eed94e"), "SC", "Seychelles" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c4e10f04-7abd-4ba9-89c7-b4d8b666bc91"), "BW", "Botswana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c530008b-1e14-4af4-bffc-b22b1b7738da"), "KH", "Cambodia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c8702dde-e61c-4e5d-8ae0-6feca2c4301e"), "KW", "Kuwait" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c87559b4-a192-46cd-9026-f4c3c09968e1"), "KZ", "Kazakhstan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c965a25d-5252-497f-bb62-7c53a5cb94bf"), "ES", "Spain" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ca05323c-b699-414e-9b1a-8b94dff8557f"), "BR", "Brazil" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ca5fcb4c-506e-43c7-a6a8-ad7144dfe48d"), "KI", "Kiribati" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ca9c1f0a-be13-46a1-b2e9-18475c2e8de2"), "TD", "Chad" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("caa1cd55-1a9d-47f8-97c9-cf9a68edb927"), "NG", "Nigeria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cafd31b3-0c16-4d20-9758-4068778c1e4d"), "KM", "Comoros" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cc344bde-d830-4627-8aef-fec1ddd623a4"), "LC", "Saint Lucia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cc82c597-e192-415c-8833-1956764588d0"), "LS", "Lesotho" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cce68efd-f2e4-4387-affe-7b2d6669ad17"), "VA", "Vatican City" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cd534993-8c86-4831-b6ed-2bfd6179a644"), "ET", "Ethiopia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cef0d136-9077-4fb1-85b2-ad519e4be903"), "PY", "Paraguay" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d0569788-1e84-4256-b995-e9b032fd3c35"), "BN", "Brunei" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d105cd68-8c1e-41cc-8758-706bbbb8eb57"), "US", "United States" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d3720b96-b4df-4efd-a0fb-b83c4cec0eb3"), "RW", "Rwanda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d44732a4-a8d4-4738-b9b4-53d593eb6309"), "CG", "Congo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d5729a38-51f7-40b0-b7f1-89c61485ecaa"), "LT", "Lithuania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d655bca4-d615-4b9f-ae88-ba74247d6ae6"), "BB", "Barbados" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d700cb49-204c-4a31-97ef-1302e0244bcb"), "BA", "Bosnia and Herzegovina" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d71c5b34-d29f-4036-a333-9d92e1cd56fa"), "FI", "Finland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d84cb0a5-2b18-461a-bad9-f003d2299d50"), "SZ", "Swaziland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d8ab25fd-8eca-4c24-bc83-37136ec93533"), "NL", "Netherlands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d8d4cd19-a6c7-410a-aa4a-3351e1e2b0c4"), "GY", "Guyana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d8dd622c-1e51-49e4-a935-186a5c46b4f9"), "NZ", "New Zealand" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d90764da-7cb2-4990-b5db-669f9e19e850"), "DJ", "Djibouti" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dacf4c5c-a1dd-4768-a510-a230024cfc6e"), "ER", "Eritrea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dd8306b1-9739-49f9-ac3c-5ea354a492c9"), "BY", "Belarus" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("de14d547-7f09-4642-8caf-518c2f8b3034"), "KP", "North Korea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dfa86c2b-0742-49ed-ab4a-7a25ed8c1c05"), "IQ", "Iraq" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e4aac013-df75-4523-8c06-9351d86dc9c1"), "MW", "Malawi" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e4bef3dc-fb21-4dc9-9ce6-221aa7f89cad"), "GQ", "Equatorial Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e567a7b9-953e-4f4b-956c-9dbf03bf1f2e"), "TW", "Taiwan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e84ba78f-3ece-430a-bd0e-5796b8e42aa7"), "ZW", "Zimbabwe" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ea7c81b4-6c4f-4a7a-83e5-cf3402724f12"), "BG", "Bulgaria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("eb3642b7-e463-4819-a6db-001a20651023"), "VU", "Vanuatu" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("eebf03e2-c681-44f6-bcd0-b9f339ba1559"), "MR", "Mauritania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f164ea7c-41d1-4f49-a08a-2be356bca34e"), "IR", "Iran" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f275763b-bdc9-445e-aaa6-a9e6d3d0d8ff"), "JM", "Jamaica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f46772a4-e5d7-4772-9811-bbecf746e60d"), "SN", "Senegal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f5817a51-c695-44af-9fae-0faa91865a9e"), "UA", "Ukraine" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f6d8f2b0-bd9b-4396-89e8-a33e514e1651"), "CD", "Democratic Republic of the Congo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f8c868b8-4498-4cba-a1ee-cd8710a15679"), "LR", "Liberia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fa1142fb-0e6d-490b-af1e-2709ccba4089"), "GR", "Greece" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fb6c9894-46b1-41bc-8757-b557b5dbe050"), "CO", "Colombia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fbe1aae9-6ed2-4933-9431-46c5a3cc46af"), "FR", "France" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fc0cb8d3-fe36-4e67-ba8d-d9200ab38698"), "GE", "Georgia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fc71c4a0-5532-49d8-8864-702bd719d712"), "NA", "Namibia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fcdb8db2-f1ed-4aa0-b072-ac522377073d"), "IL", "Israel" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fd0df0ce-1c87-40f5-802a-91be812cc694"), "OM", "Oman" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fdee5e4e-4d81-437d-81b1-a21c29e5c5c1"), "AF", "Afghanistan" });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_RecieverId",
                table: "Friendships",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_SenderId",
                table: "Friendships",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

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
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countrys");
        }
    }
}
