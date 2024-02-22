using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.DAL.Migrations
{
    public partial class fix6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "GameResults");

            migrationBuilder.AddColumn<Guid>(
                name: "GameTypeId",
                table: "GameResults",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OpponentId",
                table: "GameResults",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlayedAt",
                table: "GameResults",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "GameResults",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_GameTypeId",
                table: "GameResults",
                column: "GameTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_OpponentId",
                table: "GameResults",
                column: "OpponentId");

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_PlayerId",
                table: "GameResults",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_GameTypes_GameTypeId",
                table: "GameResults",
                column: "GameTypeId",
                principalTable: "GameTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_Players_OpponentId",
                table: "GameResults",
                column: "OpponentId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_Players_PlayerId",
                table: "GameResults",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_GameTypes_GameTypeId",
                table: "GameResults");

            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_Players_OpponentId",
                table: "GameResults");

            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_Players_PlayerId",
                table: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_GameTypeId",
                table: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_OpponentId",
                table: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_PlayerId",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "GameTypeId",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "OpponentId",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "PlayedAt",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "GameResults");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "GameResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
