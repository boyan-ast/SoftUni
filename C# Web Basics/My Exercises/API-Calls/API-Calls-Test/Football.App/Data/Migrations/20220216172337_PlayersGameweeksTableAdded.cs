using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Football.App.Data.Migrations
{
    public partial class PlayersGameweeksTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayersGameweeks",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GameweekId = table.Column<int>(type: "int", nullable: false),
                    InStartingLineup = table.Column<bool>(type: "bit", nullable: false),
                    IsSubstitute = table.Column<bool>(type: "bit", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    CleanSheet = table.Column<bool>(type: "bit", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false),
                    SavedPenalties = table.Column<int>(type: "int", nullable: false),
                    ConcededGoals = table.Column<int>(type: "int", nullable: false),
                    MissedPenalties = table.Column<int>(type: "int", nullable: false),
                    OwnGoals = table.Column<int>(type: "int", nullable: false),
                    BonusPoints = table.Column<int>(type: "int", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersGameweeks", x => new { x.PlayerId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_PlayersGameweeks_Gameweeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "Gameweeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersGameweeks_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersGameweeks_GameweekId",
                table: "PlayersGameweeks",
                column: "GameweekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersGameweeks");
        }
    }
}
