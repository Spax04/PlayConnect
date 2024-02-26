using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.DAL.Migrations
{
    public partial class fix8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GameTypeId",
                table: "GameSessions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_GameTypeId",
                table: "GameSessions",
                column: "GameTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessions_GameTypes_GameTypeId",
                table: "GameSessions",
                column: "GameTypeId",
                principalTable: "GameTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameSessions_GameTypes_GameTypeId",
                table: "GameSessions");

            migrationBuilder.DropIndex(
                name: "IX_GameSessions_GameTypeId",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "GameTypeId",
                table: "GameSessions");
        }
    }
}
