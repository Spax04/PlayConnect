using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.DAL.Migrations
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

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("03a1cd41-7394-4c33-804b-50f3ae63afb9"), "JP", "Japan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("03a22155-7891-4101-b1cd-f11dcac1403d"), "IR", "Iran" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0449c296-83d3-4f42-912d-398fddfeac8f"), "KM", "Comoros" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("066216ff-069e-4975-bf70-822e49a33fab"), "AR", "Argentina" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("06ceac33-0109-41fc-8970-f4aaceb64925"), "TR", "Turkey" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("07fd548b-1e1f-4633-a8f0-87f920e10b4d"), "PG", "Papua New Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("09104a69-d7fb-4e9c-982a-9b6c87ea166e"), "AF", "Afghanistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0cf93641-c335-42ed-a5ce-7c5822844e48"), "BB", "Barbados" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0ddda937-f8cf-4d99-ae92-54d2429e7a1b"), "PY", "Paraguay" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0eda96bc-4f00-445a-a1b9-1eb61086bbfe"), "AM", "Armenia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0edccdc3-bed0-45a5-a886-192d7b0fa2b4"), "NI", "Nicaragua" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("11901cc4-93d7-42db-8a6a-a32b71a9e8c0"), "PT", "Portugal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("11c20290-b31d-48fb-8771-2ed8e5347a87"), "AT", "Austria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1216569d-999a-4e38-893e-5c7ed1e08c52"), "GD", "Grenada" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("124addbb-ba46-4919-99b6-819a50126bc6"), "ES", "Spain" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("12caee02-9668-4311-beed-0dd9ff88afc0"), "LI", "Liechtenstein" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("13160ca8-2a18-451b-bc7a-8431a3c8a286"), "KP", "North Korea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("148f37c2-c406-47ec-9e8d-05fa995c4f59"), "DE", "Germany" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("14920c52-eb6c-4ca2-933f-083bd2af5b0b"), "MY", "Malaysia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1500ee0f-ac6b-4c7c-9959-3b418207d55f"), "AE", "United Arab Emirates" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("16172ea5-f263-4876-b008-750fe5d09f2e"), "MX", "Mexico" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("161a77ef-892a-4aa7-9ee5-648748029283"), "MU", "Mauritius" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1973e9be-46c2-4146-8b09-256e4e45df62"), "MH", "Marshall Islands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("19cbae87-39fe-4523-b301-12bb57558f67"), "BZ", "Belize" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1a1a545d-179e-4c78-9f83-69664c4482ee"), "HR", "Croatia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1a3dffde-2285-48af-9013-6503ea68a71b"), "HU", "Hungary" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1bc8bc12-e20f-47c4-b3e3-7247d02effc9"), "DO", "Dominican Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1c6d3c57-2dc7-41cf-8ad4-7b682753dd27"), "SR", "Suriname" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1de59465-22f9-46e3-8489-99ab3e39dfb2"), "XK", "Kosovo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1f08153d-c040-4614-8928-d73cd8aadca0"), "SY", "Syria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2028e9ca-cfa7-4b10-9a89-f8b2b8b2dad8"), "TH", "Thailand" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("20793634-f22e-458b-aa33-949a41873ba9"), "BW", "Botswana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("20dbf05a-5a71-4800-81ab-c79004b19535"), "RO", "Romania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("215edeed-aea1-4f60-967b-c8b7f5375fa6"), "ID", "Indonesia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2554f087-dffc-4af6-bc01-4122f4630d52"), "JM", "Jamaica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("25b7d2f8-c3be-4116-b830-c368abb894d9"), "CD", "Democratic Republic of the Congo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("26480ef2-e2d8-479e-949c-04894d9f4d6e"), "LK", "Sri Lanka" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("26501661-98d3-477f-bc29-8a32e4c8b894"), "NR", "Nauru" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("28097201-622e-480b-a36c-d123b9685c14"), "FR", "France" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("28696725-ca38-44e8-8b2d-d6e10f4308e7"), "TJ", "Tajikistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2869e019-7e81-4257-93ac-2f168d301c00"), "HT", "Haiti" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("28cb6ef3-7bc5-44c0-940a-1a724c7be8cb"), "ZA", "South Africa" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("29fdc335-8f5d-4329-be00-29157fa17005"), "DK", "Denmark" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2c3aca89-97bd-444c-8489-71b0977eba73"), "GQ", "Equatorial Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2fd8ed6a-da57-433c-b40f-b5e68b7ae593"), "DM", "Dominica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3070ced3-cf6a-4684-abc1-9d6abc62f054"), "VC", "Saint Vincent and the Grenadines" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("315eb608-841f-4c93-8188-3fe7ee20e7e2"), "GR", "Greece" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("33c6b6cf-2c2e-4071-9d29-52037c995b6f"), "PA", "Panama" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("34170a48-6c5a-4b2b-ba47-8aa0514c0e8d"), "HN", "Honduras" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("35a4b155-6555-467f-ba48-21049ae52a4f"), "ER", "Eritrea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("38a3b836-276d-4feb-be11-fa69042edeed"), "TW", "Taiwan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3c65e946-ef88-4849-a8b5-cd92b851cfd5"), "LS", "Lesotho" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3f9241b5-8175-490e-a0a6-e9fefe342541"), "SV", "El Salvador" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("414113a6-2034-4ae2-8400-eac36e6a2372"), "SA", "Saudi Arabia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("42b9325e-b7e4-4215-9ff1-82511a3d8e0a"), "BR", "Brazil" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4320a8c7-d0bc-480f-9fc6-457e34dac7c0"), "MN", "Mongolia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4412fd9b-a902-4626-92f4-3d8882f141e2"), "UY", "Uruguay" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("444ea099-ee0d-4540-b8c3-0668f7b2218f"), "IQ", "Iraq" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("44a91fb0-326d-47e1-ba2b-843fbc77dac4"), "YE", "Yemen" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("45ecd397-9ff1-427e-a4bb-51dac9641d28"), "TO", "Tonga" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4bfeb007-0ccd-4592-9662-2c7666aa50ae"), "BH", "Bahrain" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4c7122e3-69ba-48e5-8786-72a776dbcf77"), "LV", "Latvia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4d0bed98-ab52-4b3b-bb29-e4cd563ec7a9"), "SO", "Somalia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4e9e1000-4f5f-4d23-9385-bca2ede7e3bd"), "RU", "Russia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4ecafc44-e56f-4be0-b29a-87405ab954e8"), "SM", "San Marino" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4faf6eb6-168c-4a80-89f6-18ee16d42d07"), "CL", "Chile" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("511bcef4-31ba-4c42-a3b5-bf20890768b5"), "NE", "Niger" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("528445a8-4456-49d7-bd7e-5ad5ac01d74f"), "TM", "Turkmenistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("53033a60-adab-4b0c-a83d-3809cb87efe1"), "KN", "Saint Kitts and Nevis" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("551c02fe-5b2f-42e1-abb2-3836620a9c39"), "TT", "Trinidad and Tobago" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("56c0dfa7-475d-427f-b2d8-19b0ac5fbd76"), "CN", "China" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("57f07c42-55d8-4feb-9048-35a46c419bab"), "CV", "Cabo Verde" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5c088d38-10cc-4c71-8a96-ddb9983fffdc"), "KZ", "Kazakhstan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5dc942be-f099-4c14-8036-c9498ada2e27"), "SC", "Seychelles" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5e07949c-a5df-4f90-b6cf-dfe1e9e96865"), "CH", "Switzerland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("60817fcd-6f47-47ea-95ab-5a3090fb0584"), "MC", "Monaco" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("64728739-2b4c-4405-8374-7de7f3053f1d"), "BD", "Bangladesh" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("64ceb7c8-145d-4fb5-b207-e83e4b9c1e79"), "TG", "Togo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("66395865-ad31-417c-a8e0-8e6cfc174ea3"), "IL", "Israel" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("669d7c97-01a2-402a-9a28-625144184a66"), "EE", "Estonia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("67b2970f-d7e7-4dee-bd52-085533b92523"), "SN", "Senegal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("695d5ded-dac3-4641-a738-b4792acf7939"), "AG", "Antigua and Barbuda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6a0c2257-5ddd-429b-bbf1-d3d5dfd386cf"), "TV", "Tuvalu" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6aaf437f-9322-4981-9ed8-7fa9c948987e"), "TN", "Tunisia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6ce95312-c86d-4321-aa80-39c056746bec"), "CO", "Colombia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6f4cc9c5-c28f-47db-a439-906289f59fe1"), "BO", "Bolivia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("707dfe08-71d0-41ff-8b4f-01b5e0775e4a"), "LA", "Laos" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("735b191d-ccd8-49c6-8f8d-d9b1535e8e18"), "PE", "Peru" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7372b0b6-dbec-456b-8f1f-9156009fb34c"), "DJ", "Djibouti" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("73ee67fa-f32c-4ce5-8daa-8e1dbaabd4b7"), "WS", "Samoa" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7673b4b7-9d33-43f0-8021-16ecfe22b3e5"), "SI", "Slovenia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("76ba8598-e5dc-4cec-8cf5-a2959f99e413"), "US", "United States" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("776e2c8d-baee-42e1-89f7-5433a10b2c5a"), "GW", "Guinea-Bissau" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("782b845e-9e47-4dc1-98ce-a30e3062a175"), "BA", "Bosnia and Herzegovina" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7a950fd3-688e-46c3-86de-c79aaffb58f0"), "BJ", "Benin" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7b28b2a4-7175-4b64-b415-4313f069400e"), "NP", "Nepal" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7b8075c3-78f0-491b-b4c5-94edf98e5a81"), "ML", "Mali" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7f6e538d-f446-424c-bb67-03f4ee6b4ea2"), "ME", "Montenegro" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("80a546ab-8c87-4a7a-ae46-db7742431705"), "ZM", "Zambia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("84bdd035-327e-4624-be06-cabe0003764c"), "MZ", "Mozambique" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("84e3b092-548a-40ba-94e4-0a0f7d329c76"), "PH", "Philippines" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8604d561-e8a5-4e8f-9bd8-6362675cdc97"), "PL", "Poland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("87aabdbd-fc5f-4715-bd58-c65446701798"), "SZ", "Swaziland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("890c54f6-a68c-4cb0-85fb-411c341b5229"), "QA", "Qatar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8989040f-67ea-418d-b523-a49265131556"), "SG", "Singapore" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8a275a58-a526-4f20-8e26-0a57c47759a0"), "NO", "Norway" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8ab2d1aa-7b33-4825-b2a6-e68070e7baf5"), "NG", "Nigeria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8e8ba41c-48c1-4f8a-8db1-d91c476d991b"), "KG", "Kyrgyzstan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8f11f361-d301-4468-bcfa-6d784674c1fb"), "FI", "Finland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8f3f64a3-cab4-4256-947e-45ee58c14bb4"), "AL", "Albania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8f58b1a8-24fb-4a37-9d1a-6bd6a119f26b"), "MK", "North Macedonia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("90bb2ec4-1040-43af-bfaa-2a013bf6630e"), "PW", "Palau" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("90fe886b-a33e-4cf5-bed0-aa1792b2eaca"), "MM", "Myanmar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9254c4b9-39bb-4ac4-82d7-36842449d655"), "PK", "Pakistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("94695042-728d-4929-a030-80138dc0dec4"), "LY", "Libya" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("96010ab5-58e4-4666-bea0-4a14b4c8fbac"), "BF", "Burkina Faso" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("96881418-7bcf-4f59-a050-e93e135a2455"), "EG", "Egypt" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9746ebe6-003d-40bb-a008-84b10c2d3cc1"), "TD", "Chad" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("97be6b47-805a-4eb5-8f86-8d1ca817328f"), "SB", "Solomon Islands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("98cca953-9d30-4dcf-bbfd-187b818bc82d"), "GB", "United Kingdom" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9997dac7-a2ee-495d-886e-f746a0942dc9"), "GN", "Guinea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9ab3c8e6-6dd5-498e-b592-660e5c5d3585"), "BN", "Brunei" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9adea670-6d7c-4e69-ba1e-245be2e9f4f9"), "LC", "Saint Lucia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9eb8a667-8019-4dfa-926d-8322a19d6c8d"), "ZW", "Zimbabwe" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9f86e555-5376-4439-a9be-4de7d5ad6d7e"), "RW", "Rwanda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a086b9a8-5ba8-4ac9-9c79-c3bfb68258dc"), "MA", "Morocco" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a21be421-9fa3-4fcc-a23e-4fdbf6c696e3"), "MR", "Mauritania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a42a08e0-9a5e-499c-8c98-974ef8923585"), "CG", "Congo" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a5f44319-c2f8-4c29-9c16-acfe13f7aeda"), "VU", "Vanuatu" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a6ad8c8e-f9aa-430a-9e11-a20ea48e81ec"), "SD", "Sudan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ac3469d4-24aa-4217-b4f1-6c9d1a3d0ee6"), "BI", "Burundi" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ad5c42e8-7497-44dc-995a-62fe0793d5e7"), "SK", "Slovakia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ae136ab0-682c-4314-8c39-4de288fba15c"), "CF", "Central African Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b016bb85-75b9-4dd1-b6ec-eae8bf370e20"), "BY", "Belarus" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b338ede4-f0a9-4b1a-90cf-c68232668ee8"), "SL", "Sierra Leone" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b50f1783-4a20-4d1a-9ad1-ca68421e41c3"), "FM", "Micronesia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b5ebb884-af5b-4ea9-a61c-bf824fb0d3e4"), "CR", "Costa Rica" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b6f6d48b-10a5-4fee-9e7b-963ddd7d8296"), "ET", "Ethiopia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b71512fc-53e2-42f1-a62c-4e7028128709"), "UZ", "Uzbekistan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b92d0e1c-9e19-41cd-83e2-5976b89a70fc"), "LR", "Liberia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b97000a6-900c-4e11-8601-1f27629653ed"), "SE", "Sweden" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ba062912-aa42-4bcc-96e7-30128dc0d172"), "KR", "South Korea" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bb76f743-29ce-4693-9b61-b648cb5d5d48"), "GH", "Ghana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bbce2a0b-6f87-4cbc-a71a-177b3969bc4f"), "CY", "Cyprus" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bc28c4be-d669-45eb-909c-cc08ebcc071d"), "TZ", "Tanzania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bdc582fc-5fea-483a-add5-86ff5e82530f"), "CM", "Cameroon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c00e3f3b-b6f0-4fbf-b658-7d1ac543d5ef"), "BS", "Bahamas" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c4b167f8-689b-4afa-b15d-1eebafeaa278"), "NA", "Namibia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c5fac1f0-9b3d-4165-b5a4-b7fa14b2876a"), "ST", "Sao Tome and Principe" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c8c0c072-95ac-4427-8139-9170b44760b7"), "OM", "Oman" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ca761c6c-07a2-4069-a437-1c87e33d677e"), "GY", "Guyana" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cbe3b0cf-069a-4b62-b679-3cf43d379914"), "NZ", "New Zealand" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ce8d1b47-b730-4d6b-b272-69cb28dd6d5a"), "UG", "Uganda" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cecd4386-e176-4d4e-a589-012ea3ecd5d3"), "IT", "Italy" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cf9dec91-8532-44b8-a225-7a1faa9fad3b"), "JO", "Jordan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cfd6d428-49be-40d2-874f-ac346ec13b0d"), "LU", "Luxembourg" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d0d90eff-ae52-4ef3-943e-486b037143a5"), "IN", "India" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d494a5a4-8fbb-4083-9d54-a9ea5282ffed"), "CA", "Canada" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d5569361-9881-4fcd-b9dd-80004bca4817"), "UA", "Ukraine" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d6a5d108-7ca8-43cf-a389-6d0e0154e4c5"), "MD", "Moldova" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("db368883-9d84-4f17-be50-953ad6a7dc47"), "SS", "South Sudan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dc3c1dd7-7a62-4941-ab08-7bde474b406b"), "RS", "Serbia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ddbd9dc5-32a4-455c-a598-268c351019a8"), "NL", "Netherlands" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ddfbda1a-a15f-4f33-96a9-aa4dcf9add56"), "CU", "Cuba" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("de5ee6ee-a20a-4cc2-bd64-27dd9c8d8f33"), "AD", "Andorra" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e14ab7c4-44c8-4bdc-8c3d-d6cd883c6ccd"), "GA", "Gabon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e5298e4c-d95c-417b-af11-0dca1da3827b"), "GT", "Guatemala" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e64db3d3-a1e8-4f23-aeb6-d70e19d727d2"), "AU", "Australia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e820e9a2-8617-481e-9600-fdcecb085f94"), "GM", "Gambia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e8c25baf-048e-42ad-ad0d-2cf3617b427b"), "KI", "Kiribati" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e9938f66-e8be-48f6-ab0c-ee39f714c331"), "MT", "Malta" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ea9e562c-96e5-4cb4-ae5f-374ef41e9da3"), "GE", "Georgia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("eb905af3-6d63-4cbd-a7cc-e8342f35d8c3"), "EC", "Ecuador" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ebda3f84-ab3c-48ed-8663-fba074dcce12"), "KW", "Kuwait" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ecbd97e7-1f75-4158-b81a-6f965cb0fea7"), "LB", "Lebanon" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ecdf39fa-a3b9-4d7f-9b37-bba97c4628b3"), "KH", "Cambodia" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ed2aeea3-336f-4ffb-ba86-5bab0077b1bf"), "VN", "Vietnam" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ee10902b-0369-4927-bd6f-3ee3af737cf5"), "KE", "Kenya" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("eecf38f3-a478-4c1d-a860-5daed6e65a49"), "TL", "East Timor" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("efccd6a3-d477-4470-9f5a-afbd371ebb70"), "BG", "Bulgaria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f0007d5c-8a94-4a18-879b-5531323e654f"), "CI", "Ivory Coast" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f0aebe7a-bf1e-4e44-8b98-d85c94e8edb2"), "BT", "Bhutan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f34ff7e9-ef09-432d-97b2-017659f85696"), "BE", "Belgium" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f38751ed-e649-4ceb-8ba3-91e4d2beecd1"), "AO", "Angola" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f41062ce-e35d-40c4-b8dd-c687ef465a07"), "DZ", "Algeria" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f47927fb-d93e-4904-92dd-1646a2439fc0"), "LT", "Lithuania" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f48a101d-30c0-4a00-afc8-a6737c4d0e02"), "FJ", "Fiji" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f778a4d2-f81f-40c5-a9a1-d451b8593414"), "CZ", "Czech Republic" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f822c6a8-d6da-434d-a1cb-318680e701b3"), "AZ", "Azerbaijan" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f85ee678-2376-4e9f-b239-63637b7ad645"), "IS", "Iceland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fa0408e3-9d39-48fc-b1c3-431e0a42a0a6"), "VA", "Vatican City" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fa1d0fa9-364b-4142-8181-0233a4970e82"), "IE", "Ireland" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fa91c2fc-4283-420f-ae17-5957656b5a9a"), "MV", "Maldives" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fb07e6a8-97c0-47ea-aba9-ea18da04c2cd"), "MG", "Madagascar" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fbb221bd-e096-458a-b85b-22d7cc4c19c6"), "VE", "Venezuela" });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ffcd3ff5-b716-4c56-9c44-27f43ceeb7b7"), "MW", "Malawi" });

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
