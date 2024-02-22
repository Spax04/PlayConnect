using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.DAL.Migrations
{
    public partial class fix5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicTacToeMoves");

            migrationBuilder.AddColumn<string>(
                name: "MoveHistoryJson",
                table: "Moves",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoveHistoryJson",
                table: "Moves");

            migrationBuilder.CreateTable(
                name: "TicTacToeMoves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MoveHistoryJson = table.Column<string>(type: "json", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicTacToeMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicTacToeMoves_Moves_Id",
                        column: x => x.Id,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
