using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Football.App.Data.Migrations
{
    public partial class AddedGoalScoredToFixturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AwayGoals",
                table: "Fixtures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeGoals",
                table: "Fixtures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayGoals",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "HomeGoals",
                table: "Fixtures");
        }
    }
}
