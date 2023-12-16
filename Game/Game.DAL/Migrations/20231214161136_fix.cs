using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.DAL.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicTacToeMove_Moves_Id",
                table: "TicTacToeMove");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicTacToeMove",
                table: "TicTacToeMove");

            migrationBuilder.RenameTable(
                name: "TicTacToeMove",
                newName: "TicTacToeMoves");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicTacToeMoves",
                table: "TicTacToeMoves",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicTacToeMoves_Moves_Id",
                table: "TicTacToeMoves",
                column: "Id",
                principalTable: "Moves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicTacToeMoves_Moves_Id",
                table: "TicTacToeMoves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicTacToeMoves",
                table: "TicTacToeMoves");

            migrationBuilder.RenameTable(
                name: "TicTacToeMoves",
                newName: "TicTacToeMove");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicTacToeMove",
                table: "TicTacToeMove",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicTacToeMove_Moves_Id",
                table: "TicTacToeMove",
                column: "Id",
                principalTable: "Moves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
