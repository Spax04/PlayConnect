using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.DAL.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GameTypeId",
                table: "Moves",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Moves_GameTypeId",
                table: "Moves",
                column: "GameTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_GameTypes_GameTypeId",
                table: "Moves",
                column: "GameTypeId",
                principalTable: "GameTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_GameTypes_GameTypeId",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_GameTypeId",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "GameTypeId",
                table: "Moves");
        }
    }
}
