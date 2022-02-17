using Football.App.Data;
using Football.App.Data.Models;
using Football.App.Services.Enums;
using Microsoft.EntityFrameworkCore;

namespace Football.App.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IAdminService adminService;
        private readonly ApplicationDbContext data;
        private readonly IDictionary<int, int> playersIds;

        public PlayerService(IAdminService adminService, ApplicationDbContext data)
        {
            this.adminService = adminService;
            this.data = data;

            this.playersIds = this.data
                .Players
                .Select(p => new
                {
                    p.Id,
                    p.ExternId
                })
                .ToDictionary(p => p.ExternId, p => p.Id);
        }

        public async Task ImportLineups(int gameweekNumber)
        {
            var fixturesInGameweek = this.data.Fixtures.Where(f => f.GameweekId == gameweekNumber).ToList();
            var gameweekId = this.data.Gameweeks.FirstOrDefault(gw => gw.Number == gameweekNumber).Id;

            var allPlayersInGameweekExternIds = new HashSet<int>();  

            foreach (var fixture in fixturesInGameweek)
            {
                var lineupsResult = (await this.adminService
                    .GetLineupsAsync(fixture.ExternId))
                    .ToList();

                var homeTeamLineupExternIds = lineupsResult[0].StartXI.Select(p => p.Player.PlayerId);
                var homeTeamSubstitutesExternIds = lineupsResult[0].Substitutes.Select(p => p.Player.PlayerId);

                var awayTeamLineupExternIds = lineupsResult[1].StartXI.Select(p => p.Player.PlayerId);
                var awayTeamSubstitutesExternIds = lineupsResult[1].Substitutes.Select(p => p.Player.PlayerId);

                var startedPlayers = homeTeamLineupExternIds.Union(awayTeamLineupExternIds);
                var reservePlayers = homeTeamSubstitutesExternIds.Union(awayTeamSubstitutesExternIds);
                var allPlayers = startedPlayers.Union(reservePlayers);

                var allPlayersInFixture = PlayersInitialAdding(allPlayers, startedPlayers, gameweekId, allPlayersInGameweekExternIds);
                await this.data.PlayersGameweeks.AddRangeAsync(allPlayersInFixture);
                await this.data.SaveChangesAsync();

                allPlayersInGameweekExternIds.UnionWith(allPlayers);
            }
        }

        public async Task ImportEvents(int gameweekNumber)
        {
            var fixturesInGameweek = this.data.Fixtures.Where(f => f.GameweekId == gameweekNumber).ToList();
            var gameweekId = this.data.Gameweeks.FirstOrDefault(gw => gw.Number == gameweekNumber).Id;

            foreach (var fixture in fixturesInGameweek)
            {
                var fixtureEvents = (await this.adminService
                    .GetFixtureEventsAsync(fixture.ExternId))
                    .ToList();

                foreach (var matchEvent in fixtureEvents)
                {
                    var eventTime = matchEvent.Time.Elapsed + (int)(matchEvent.Time.Extra != null ? matchEvent.Time.Extra : 0);

                    var isValidEvent = Enum.TryParse<EventType>(
                        matchEvent.Type, 
                        true, 
                        out EventType type);

                    if (!isValidEvent)
                    {
                        throw new InvalidOperationException($"Event type '{matchEvent.Type}' is not valid.");
                    }

                    var detail = matchEvent.Detail;

                    var playerExternId = matchEvent.Player.Id;

                    if (!this.playersIds.ContainsKey(playerExternId))
                    {
                        continue;
                    }

                    var player = this.data
                        .Players
                        .Include(p => p.PlayerGameweeks)
                        .FirstOrDefault(p => p.ExternId == playerExternId);

                    if (type == EventType.Goal)
                    {
                        if (detail == "Normal Goal" || detail == "Penalty")
                        {

                        }
                        else if (detail == "Own Goal")
                        {

                        }
                        else if (detail == "Missed Penalty")
                        {

                        }
                        else
                        {
                            throw new InvalidOperationException($"Event detail '{detail}' is not valid.");
                        }
                    }
                    else if (type == EventType.Card)
                    {
                        if (detail == "Yellow Card")
                        {

                        }
                        else if (detail == "Second Yellow card" || detail == "Red card")
                        {

                        }
                        else
                        {
                            throw new InvalidOperationException($"Event detail '{detail}' is not valid.");
                        }
                    }
                    else if (type == EventType.Subst)
                    {
                        var playerStartedMatch = player
                            .PlayerGameweeks
                            .Where(pg => pg.GameweekId == gameweekId)                            
                            .FirstOrDefault()
                            .InStartingLineup;

                        var minutesPlayed = 0;

                        if (playerStartedMatch)
                        {
                            minutesPlayed = eventTime;

                        }
                    }
                    else if (type == EventType.Var)
                    {

                    }

                    this.data.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<PlayerGameweek> PlayersInitialAdding(
            IEnumerable<int> playersExternIds, 
            IEnumerable<int> startedPlayers, 
            int gameweekId, 
            HashSet<int> allPlayersInGameweekExternIds)
        {
            var playersGameweek = new List<PlayerGameweek>();

            foreach (var playerExternId in playersExternIds)
            {
                if (!this.playersIds.ContainsKey(playerExternId) || allPlayersInGameweekExternIds.Contains(playerExternId))
                {
                    continue;
                }

                var player = new PlayerGameweek
                {
                    PlayerId = this.playersIds[playerExternId],
                    GameweekId = gameweekId,
                    InStartingLineup = startedPlayers.Contains(playerExternId),
                    IsSubstitute = !startedPlayers.Contains(playerExternId),
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

                playersGameweek.Add(player);
            }

            return playersGameweek;
        }

    }
}
