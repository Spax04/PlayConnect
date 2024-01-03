using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.DAL.Migrations
{
    public partial class added_image_to_game_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "GameTypes",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "GameTypes");
        }
    }
}
