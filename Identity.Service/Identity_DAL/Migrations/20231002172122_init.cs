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
                    User1Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    User2Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.FriendshipId);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_User1Id",
                        column: x => x.User1Id,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendships_Users_User2Id",
                        column: x => x.User2Id,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("015e3ccc-3ca6-4a1d-90d4-ea50468918bd"), "TT", "Trinidad and Tobago" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("01b94eec-1f5a-4a75-992c-da822e2f9b84"), "SE", "Sweden" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("01bd5247-4d4c-4064-ba38-ad18bc1ad92c"), "SO", "Somalia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0462132b-4e34-4efd-99f0-cedbb155acaa"), "DJ", "Djibouti" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("059b2b14-793f-4dae-a19c-068706364cd8"), "BI", "Burundi" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("05c0a7ef-a9e8-4bdb-99a2-632582d6ad45"), "TO", "Tonga" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0722de72-83d9-499a-a968-1014e3d88100"), "LK", "Sri Lanka" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("078a63b1-a1b8-4fcb-8021-4caf60f34982"), "LI", "Liechtenstein" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("09521deb-5be2-4c80-9510-5eb7c677d8cf"), "LY", "Libya" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0960cf41-2afb-41f1-85ee-6e573f6f54a6"), "TN", "Tunisia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0a5fb770-5607-4ff1-ac4d-f2418d575aa3"), "ML", "Mali" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0b1b8212-c7d6-447d-b342-99c322d3f5e2"), "GW", "Guinea-Bissau" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0c511fec-9b8e-466c-9b3e-2ed15f99e5cf"), "MY", "Malaysia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0c730c27-459f-43cc-8de7-eb6fa61df69b"), "GH", "Ghana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0cdf545d-82cb-4821-af40-9b71b3022d73"), "NE", "Niger" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0d5bbbe7-5c87-4406-930c-c8e3e3d5dcc7"), "EE", "Estonia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0d621fa1-e6d4-46d5-8c33-37b6d3866bb4"), "BE", "Belgium" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0db51aeb-872b-4399-b614-f7a3285e7e2f"), "OM", "Oman" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0f1d0d2b-e3ed-4b4b-b27f-b63a7bb1ffbd"), "CV", "Cabo Verde" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("12c092f8-2113-4769-b283-a62c7325ae17"), "BN", "Brunei" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("139f0701-4220-43b2-b3ef-8300fdb21961"), "ER", "Eritrea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("150175c8-28e3-424d-bc34-b7f395fa4a71"), "BW", "Botswana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("16ccf353-339e-41f3-8039-301b6a076ca6"), "VU", "Vanuatu" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1855c093-c94d-4657-bff9-a30e41d78747"), "SS", "South Sudan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1a6446e2-4bcd-4eef-86ad-3272fb8476b8"), "IQ", "Iraq" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1c0dd7d6-7efb-4de3-b454-236d4c0d79e3"), "VC", "Saint Vincent and the Grenadines" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("201e5dcc-24d4-4552-be85-90c6d8a25072"), "CD", "Democratic Republic of the Congo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("235362d1-e99c-4793-ae34-8a745c442ec7"), "AR", "Argentina" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("24f4b7c9-56ed-475e-abc2-28e6ef3600a5"), "LC", "Saint Lucia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("268d6cfa-d8ee-4c78-920c-997c8b9383a6"), "MT", "Malta" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("26be7e96-68e7-429c-a019-87bcbf737039"), "EG", "Egypt" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("26e33d10-4c32-480a-9395-73916a17276f"), "GM", "Gambia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("28b6e698-f70c-4465-ae30-e219fbe4f2a2"), "SR", "Suriname" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2b0429ad-590f-4bee-8fe1-32fa948f6dbc"), "SM", "San Marino" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2db0f22a-f09e-4678-bbe0-d64e60bbcc74"), "FM", "Micronesia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2f042b21-8b27-46a0-8672-c8a423d29357"), "BY", "Belarus" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2f111b83-35e4-4cbf-b1f5-d42effeeeb47"), "MZ", "Mozambique" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("30002a71-58b2-4488-9230-a0c835bd03eb"), "NG", "Nigeria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("30c05b94-7e9c-426b-80cb-a79dfc41e3ec"), "BB", "Barbados" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("313cc2e1-8ab9-487c-afeb-3066629bf6a9"), "UZ", "Uzbekistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("31c32ec4-d55d-4ee4-a98c-bfd0f688a3ff"), "BS", "Bahamas" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3887dfea-e873-47ea-b0fa-1dfcc1ddfbb9"), "BA", "Bosnia and Herzegovina" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("38f9c37c-e526-41f3-a69b-449cf6366b0b"), "QA", "Qatar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3929091b-28b0-4b54-9371-239e4b66ece2"), "RW", "Rwanda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("39a1e659-54cd-4973-a1f4-df6e9373e34a"), "IR", "Iran" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("39ad4dc5-8827-42f9-9434-ba514940690b"), "LA", "Laos" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("39dfdf7e-fdee-4518-8af4-cea4d1f3ce78"), "CM", "Cameroon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3a3a2217-1d0c-43cd-8347-86039a80d738"), "BO", "Bolivia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3b6d62a8-a9bc-4ba3-990c-2d19ef9248ea"), "BH", "Bahrain" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3df36860-fd45-4e0c-acf9-622ba5bb31d3"), "SD", "Sudan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3ff4e6e7-3841-410c-b716-70aa376a218d"), "IN", "India" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4377ca83-a9c6-4fb2-b86a-b1f6ece9d78b"), "SC", "Seychelles" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4450fcf4-d331-495c-a2b0-e9529d4d672b"), "MA", "Morocco" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("47da3ea3-be48-45ce-b858-67861fd3a4ac"), "MW", "Malawi" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("487a59ea-a45b-4eda-a89b-dbc49e62e3f3"), "SA", "Saudi Arabia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4ba978db-8ad6-474e-8d77-8afb65e3974a"), "ID", "Indonesia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4c0b8292-47a2-4826-ac76-939f158e9114"), "ZW", "Zimbabwe" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4ca19e5a-cf1c-4fda-8566-2819f84e60de"), "SI", "Slovenia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4ebb7900-4691-4fe7-8750-07e6d407e923"), "BT", "Bhutan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5051b074-b9a9-46bc-a40f-a4c354aa9552"), "AT", "Austria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("50a83f80-3655-40a2-a475-afbe24db1d01"), "NR", "Nauru" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("50b464dc-22a9-44b7-889c-da457735ac90"), "RS", "Serbia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("50d57734-5c36-43e5-a475-fb8bd211a01f"), "KM", "Comoros" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("53cb5eef-4515-45e3-b4b4-3f7fff271d6e"), "AF", "Afghanistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5826e189-01d1-46ab-9774-65e00574d559"), "AE", "United Arab Emirates" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5f3f7283-df27-47ae-98b1-4fc4302ff1bf"), "ZM", "Zambia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5f7934b1-c5ee-4859-9661-bbbee5b7aff8"), "CH", "Switzerland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("60cd7c0b-6e8e-4c69-95ba-b40f6b5a5393"), "CI", "Ivory Coast" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("62eb4737-186f-4a09-9ebd-607701113369"), "ST", "Sao Tome and Principe" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("640d705f-1257-4ec7-b69c-118f4c7cefb2"), "HN", "Honduras" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("64168c91-38fa-4e51-a9e9-418a56b1ff3a"), "HR", "Croatia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6a3e9d92-c973-4799-97b3-6ff627503e46"), "AL", "Albania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6a4a8add-8c8a-4a27-8c38-596f0e3b7993"), "DK", "Denmark" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6aa67903-75e4-433b-ac58-638f2a9707cd"), "IS", "Iceland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6c9d0c68-eb00-4901-bbca-ae6d6330b41e"), "KE", "Kenya" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("71941a6d-29cb-42c6-89e3-ca0622397edc"), "NP", "Nepal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7246b93d-fd6f-44bb-b45e-48b16c57bb79"), "KG", "Kyrgyzstan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("727af034-18e2-42c8-b96d-5bc5ccfa40ed"), "IL", "Israel" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("732f8f05-796f-4966-ad66-9815f8faeae9"), "PG", "Papua New Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("73767928-46c2-438a-98a2-85440641b54c"), "GN", "Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7412238d-3c41-4b30-a229-77c29a2e5c87"), "NA", "Namibia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("756c9bfa-ffd1-47f6-adb8-2122fdf9d5e6"), "ES", "Spain" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("75f1fcdb-609f-4729-928c-877ca0a7edb7"), "UG", "Uganda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("77edfad3-40f2-4bf9-9786-26e76b9e92a8"), "CG", "Congo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("78e00ae6-6092-4b77-8337-8f9c1317995f"), "UA", "Ukraine" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("790e7bc3-36c6-4022-bdeb-f0db7c730b05"), "KP", "North Korea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7b03e37b-618b-4d32-966a-24a6ced0dc53"), "SL", "Sierra Leone" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7c566f95-60bc-43f7-889b-49c059ccf72f"), "TD", "Chad" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7c91e7b1-4f1d-4e07-9f22-96583c8ccb21"), "KI", "Kiribati" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7e66f41e-051b-4ef7-b05f-0cc8d85f37d1"), "CZ", "Czech Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7f3064f8-a541-419a-b8dc-bcafb8542e2c"), "GR", "Greece" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7fe883f3-2289-422a-8797-958f4b1c76d3"), "PK", "Pakistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("80b3e4ed-a7be-4e45-be56-a0fb86828a1b"), "TW", "Taiwan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("815e244d-9c37-4cb5-b993-56d80fd19211"), "DO", "Dominican Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("82bcf0f6-760a-4bfd-b080-96a17dafc03a"), "PY", "Paraguay" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8481ad95-0e57-4c9f-8731-df2d44acb595"), "DM", "Dominica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("85802fd0-e281-4165-a74b-0fa793baaddf"), "SZ", "Swaziland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("85a14c12-340f-4d65-aa0f-998ee1dc5779"), "CR", "Costa Rica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("89082e5f-27df-4dab-ad7a-ad3ecd1de762"), "WS", "Samoa" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8920398d-f7ff-46c7-a030-b6756269353b"), "FJ", "Fiji" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("89cb2d36-fe50-4f6b-990a-4674ae2922de"), "SB", "Solomon Islands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8b0043c4-e31c-43ac-b7d7-f3c6d48180f3"), "PT", "Portugal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8ca86f0b-eeb9-4b16-a43c-0e4dc775964b"), "KN", "Saint Kitts and Nevis" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8cd5401a-a9e0-4fe4-9e96-bf0bc2cd51aa"), "RU", "Russia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8d804ccf-dba5-4fb8-a2a4-5546bb9d4408"), "AZ", "Azerbaijan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8e991626-2978-470d-93f7-e7eb95b85a13"), "IT", "Italy" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8f49f625-2a53-428a-9216-8c4fbb22979f"), "MD", "Moldova" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8fca7d6a-9e6c-4e03-9f0e-51241ff56a15"), "MC", "Monaco" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("91210d9d-62b9-4962-a4d1-d13f64cfffc1"), "GT", "Guatemala" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("97d9a390-c8e8-4844-946b-5ec7dd97735d"), "SK", "Slovakia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("980f5a71-3be8-4e80-8ac5-d70b5c4c5c96"), "SY", "Syria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("986165ea-bae2-4d87-b056-36b8cd8e1b7b"), "MH", "Marshall Islands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9863157a-2b4b-436b-9683-22d6a1c2ddd5"), "BD", "Bangladesh" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9a549cf2-6031-4653-bd11-c3bed172d09f"), "NL", "Netherlands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9a73121b-50be-4efa-98bf-714ac247cc61"), "CY", "Cyprus" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9a9c057e-9718-47dc-87b2-17d631bf2fd3"), "TG", "Togo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9cef34c3-25e6-485e-baf8-9adf246ce701"), "MK", "North Macedonia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9da79f09-ac0d-426c-956b-1596f503691c"), "NZ", "New Zealand" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9e4b69ea-d65f-4f16-8aec-f47c3cbea439"), "PH", "Philippines" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9e59be87-b4d3-4e53-8130-5b3120e52e74"), "MG", "Madagascar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a14708c3-3ed1-4cfe-a070-9246654b6e0d"), "TH", "Thailand" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a17679df-0dfb-49be-8ccc-56a014a706c3"), "CU", "Cuba" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a1e2e20c-35c5-4194-9dd6-a6133044f3fa"), "JO", "Jordan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a28011db-f99f-4e7d-a4fe-abb92074d207"), "BZ", "Belize" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a2997a60-58a2-470f-b5b1-86cba082223c"), "FI", "Finland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a3e7f2a5-22d2-450c-8bcd-ce647ad98b92"), "LB", "Lebanon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a5ac83df-0a2b-40ec-963c-9b8be6d84bf1"), "AG", "Antigua and Barbuda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("aa8474d1-e7dc-49c5-bfda-89959e65b1b5"), "TM", "Turkmenistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ad40310a-c006-4fdb-8464-c7f4b0cef68a"), "MV", "Maldives" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ae4f898a-ed20-4120-a428-37af7c3bfd79"), "RO", "Romania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("af3f8748-2d73-46de-afb2-2582e653eb05"), "DZ", "Algeria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b0090dda-1b93-44f3-8d15-85613ad9211d"), "LU", "Luxembourg" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b07287ad-d53c-495d-a2e2-cf9053a640b7"), "VA", "Vatican City" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b1c79815-62bc-4500-a6cd-19be8a969077"), "BJ", "Benin" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b24c845a-f083-46eb-8f51-91aba86bfd6f"), "CO", "Colombia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b2654f53-841c-4313-98c6-1f649ae0fbda"), "GB", "United Kingdom" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b2d8d04b-cceb-4db1-9521-498ea0c52843"), "GE", "Georgia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b4a87689-544b-401c-af53-b7b37f6e5a43"), "MX", "Mexico" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b5504f18-7b07-4db3-8480-241b9ef011ee"), "MU", "Mauritius" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b7b20cb3-ec9a-463e-8148-4e32732cc6ac"), "JP", "Japan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bc39a6be-d181-4b09-9f75-6097c715c5cc"), "AD", "Andorra" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bc902e3d-ea6c-4897-b10d-a464765121ef"), "KW", "Kuwait" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bd55d064-2498-4a0c-9037-2e053e89f4a1"), "GA", "Gabon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bf4c42c1-5923-4dce-bbc2-5032d07632c4"), "NO", "Norway" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c005349f-54bf-4886-a12b-556a33e4c605"), "IE", "Ireland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c33c82cc-9a54-4315-82f5-fd5e47826b85"), "LT", "Lithuania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c349e046-8999-413b-bfba-51cab755282d"), "MN", "Mongolia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c4966c13-56d4-4fde-8f3b-59f92f7735e5"), "PA", "Panama" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c49a207d-7506-4cf1-9dd8-3f73f82a6f21"), "PW", "Palau" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c4b13d6f-dcfc-40ae-8f02-088a44b517ab"), "VE", "Venezuela" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c54cb112-0e41-43f7-b3fe-d77509ee17f3"), "TV", "Tuvalu" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c6118364-7a23-4a25-a4a1-0be24d4e9358"), "TJ", "Tajikistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c743bdf4-70f0-4dba-bfac-e0de97729f09"), "SV", "El Salvador" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c7a58439-5dbc-4376-a389-d37d1ea7947d"), "PL", "Poland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c840baa1-605a-4171-9bcb-0ec212ea2e09"), "NI", "Nicaragua" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c8ba33b6-b518-4455-9991-f3964271eccd"), "UY", "Uruguay" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c984db25-61d1-4a25-879c-3c2177c41b08"), "MM", "Myanmar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("caf91bc5-3adb-4e27-80dc-2dbe39472246"), "SN", "Senegal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cc6f2d37-6cdc-4e17-84ac-bac56cda3f91"), "TZ", "Tanzania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d2325685-79a0-4081-ac75-0d91bad9b091"), "CL", "Chile" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d293f09a-9635-423a-b9c5-de84623721cd"), "GQ", "Equatorial Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d5dc78e8-36dd-46d2-b21b-eb823f90f649"), "KR", "South Korea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d71d45e1-1ee7-4bcc-ba1f-af5ca41c90d5"), "ME", "Montenegro" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d75c46c9-5737-49ad-94ad-30e50064f520"), "GD", "Grenada" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d7dc4887-5908-42dc-b2e0-6595762a77ef"), "PE", "Peru" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d88c0cc0-690d-45ba-8581-e8fdf683d0e5"), "CN", "China" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d92f4370-956d-4a38-beed-066bebeb66b2"), "ET", "Ethiopia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dc4462eb-75e7-48f0-b03b-52842a8864ea"), "HU", "Hungary" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ddc5f1c7-d9a7-472e-a0b4-adc8f696fb9d"), "AM", "Armenia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e07c8d62-a928-440f-ba5f-9d23122d5edf"), "AU", "Australia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e20942cd-0db8-4832-a82b-57c13812a383"), "US", "United States" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e39391b6-c11b-4f62-947e-12111b125e7b"), "TL", "East Timor" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e9fdf640-ba60-4754-a13c-6d3569531f8c"), "BR", "Brazil" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ea41e8e4-5c9b-4c06-b763-821ae723f8f2"), "JM", "Jamaica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ec14259d-6fdc-4091-bfef-e82a4db05264"), "MR", "Mauritania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ecf6db97-c856-40a0-b7c8-93f59c0e552a"), "DE", "Germany" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ecf89f50-e5d3-4ddd-84d4-4cc642ee5879"), "VN", "Vietnam" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ee0e3c41-8c81-4870-8d01-874fbc5a7a11"), "HT", "Haiti" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ef6a4457-e7a7-4bfd-983a-423f7633ffea"), "FR", "France" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f433a313-a017-4fb8-8764-9634532e0e85"), "CA", "Canada" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f4673ce5-a992-46db-8b37-28d4f93f4497"), "LR", "Liberia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f4915ab8-a401-4734-87e7-721fb44e6117"), "CF", "Central African Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f4ca0b5c-cb9b-4fa5-82e9-5d416d7e3496"), "KH", "Cambodia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f520866b-dd6e-4c49-9107-5d69a4f798be"), "TR", "Turkey" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f681677a-9c34-4fdc-9051-244dd8f828af"), "ZA", "South Africa" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f7943a4c-3059-4b27-bfc4-96859a5be6d7"), "LV", "Latvia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f8414a69-de39-4a0c-9d7d-25ff20b2c193"), "BG", "Bulgaria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f8e609bb-6afe-4f89-8158-f10804717bca"), "EC", "Ecuador" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f8f87961-ae2a-4bba-976e-c61a1085d666"), "KZ", "Kazakhstan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fa9033bd-2367-4e0c-b486-c590b36e67dc"), "AO", "Angola" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fd460bc9-cee3-4540-ac53-901387d3b078"), "YE", "Yemen" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fd744a7e-9a68-4719-955e-525448ea5dd4"), "SG", "Singapore" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fdc00d6e-fb0d-4d52-bb22-51622dee121a"), "XK", "Kosovo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("feb7529a-ce1b-4837-a491-1df556ac5c14"), "GY", "Guyana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ff112fc2-6723-4798-a0ce-75424a95b3ed"), "BF", "Burkina Faso" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ff22037d-c835-4055-b39b-77c58ba50029"), "LS", "Lesotho" });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_User1Id",
                table: "Friendships",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_User2Id",
                table: "Friendships",
                column: "User2Id");

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
