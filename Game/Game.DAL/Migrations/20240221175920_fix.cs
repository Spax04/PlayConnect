using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.DAL.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Column",
                table: "TicTacToeMoves");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "TicTacToeMoves");

            migrationBuilder.DropColumn(
                name: "MoveDetails",
                table: "Moves");

            migrationBuilder.AddColumn<string>(
                name: "MoveHistoryJson",
                table: "TicTacToeMoves",
                type: "json",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoveHistoryJson",
                table: "TicTacToeMoves");

            migrationBuilder.AddColumn<int>(
                name: "Column",
                table: "TicTacToeMoves",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "TicTacToeMoves",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MoveDetails",
                table: "Moves",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
