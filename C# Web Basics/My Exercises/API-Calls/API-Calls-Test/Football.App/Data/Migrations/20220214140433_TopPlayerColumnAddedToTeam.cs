using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Football.App.Data.Migrations
{
    public partial class TopPlayerColumnAddedToTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopPlayerId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TopPlayerId",
                table: "Teams",
                column: "TopPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Players_TopPlayerId",
                table: "Teams",
                column: "TopPlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Players_TopPlayerId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TopPlayerId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TopPlayerId",
                table: "Teams");
        }
    }
}
