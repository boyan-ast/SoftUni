using Football.App.Data;
using Football.App.Data.Models;

namespace Football.App.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IAdminService adminService;
        private readonly ApplicationDbContext data;

        public PlayerService(IAdminService adminService, ApplicationDbContext data)
        {
            this.adminService = adminService;
            this.data = data;
        }

        public async Task InitialImportPlayersGameweeks(int gameweek)
        {
            var fixturesInGameweek = this.data.Fixtures.Where(f => f.GameweekId == gameweek);
            var gameweekId = this.data.Gameweeks.FirstOrDefault(gw => gw.Number == gameweek).Id;

            foreach (var fixture in fixturesInGameweek)
            {
                var lineupsResult = (await this.adminService
                    .GetLineupsAsync(fixture.ExternId))
                    .ToList();

                //Extern ids of the players of home team in the fixture
                var homeTeamLineupExternIds = lineupsResult[0].StartXI.Select(p => p.Player.PlayerId);
                var homeTeamSubstitutesExternIds = lineupsResult[0].Substitutes.Select(p => p.Player.PlayerId);

                var awayTeamLineupExternIds = lineupsResult[0].StartXI.Select(p => p.Player.PlayerId);
                var awayTeamSubstitutesExternIds = lineupsResult[0].Substitutes.Select(p => p.Player.PlayerId);

                //Initial import of start players of home team
                await PlayersInitialAdding(homeTeamLineupExternIds, true, gameweekId);

                //Initial import of reserve players of home team
                await PlayersInitialAdding(homeTeamSubstitutesExternIds, false, gameweekId);

                //Initial import of start players of away team
                await PlayersInitialAdding(awayTeamLineupExternIds, true, gameweekId);

                //Initial import of reserve players of away team
                await PlayersInitialAdding(awayTeamSubstitutesExternIds, false, gameweekId);
            }
        }

        private async Task PlayersInitialAdding(IEnumerable<int> playersExternIds, bool started, int gameweekId)
        {
            var playersIds = this.data
                .Players
                .Select(p => new
                {
                    p.Id,
                    p.ExternId
                })
                .ToList();

            foreach (var playerId in playersExternIds)
            {
                var player = new PlayerGameweek
                {
                    PlayerId = playersIds.FirstOrDefault(p => p.ExternId == playerId).Id,
                    GameweekId = gameweekId,
                    InStartingLineup = started,
                    IsSubstitute = !started,
                    MinutesPlayed = 0,
                    Goals = 0,
                    CleanSheet = true,
                    YellowCards = 0,
                    RedCards = 0,
                    SavedPenalties = 0,
                    ConcededGoals = 0,
                    MissedPenalties = 0,
                    OwnGoals = 0,
                    BonusPoints = 0,
                    TotalPoints = 0
                };

                this.data.PlayersGameweeks.Add(player);
            }

            await this.data.SaveChangesAsync();
        }

    }
}
