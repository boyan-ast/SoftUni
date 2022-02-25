using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Football.App.Data.Migrations
{
    public partial class AddedColumnTeamResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamResult",
                table: "PlayersGameweeks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamResult",
                table: "PlayersGameweeks");
        }
    }
}
