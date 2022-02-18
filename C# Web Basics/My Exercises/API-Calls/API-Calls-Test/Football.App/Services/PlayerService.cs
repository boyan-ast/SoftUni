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

        //TODO: Implement CleanSheet, ConcededGoals functionalities
        public async Task ImportEvents(int gameweekNumber)
        {
            var fixturesInGameweek = this.data
                .Fixtures
                .Where(f => f.GameweekId == gameweekNumber)
                .ToList();

            var gameweekId = this.data
                .Gameweeks
                .FirstOrDefault(gw => gw.Number == gameweekNumber)?
                .Id;

            foreach (var fixture in fixturesInGameweek)
            {
                var fixtureEvents = (await this.adminService
                    .GetFixtureEventsAsync(fixture.ExternId))
                    .ToList();

                foreach (var matchEvent in fixtureEvents)
                {
                    var eventTime = matchEvent.Time.Elapsed +
                        (int)(matchEvent.Time.Extra != null ? matchEvent.Time.Extra : 0);

                    var isValidEvent = Enum.TryParse(
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

                    var playerGameweek = this.data
                        .PlayersGameweeks
                        .Where(pg => (pg.PlayerId == playersIds[playerExternId] && pg.GameweekId == gameweekId))
                        .First();

                    if (type == EventType.Goal)
                    {
                        if (detail == "Normal Goal" || detail == "Penalty")
                        {
                            playerGameweek.Goals += 1;
                        }
                        else if (detail == "Own Goal")
                        {
                            playerGameweek.OwnGoals += 1;
                        }
                        else if (detail == "Missed Penalty")
                        {
                            playerGameweek.MissedPenalties += 1;

                            //TODO: find oponent goalkeeper and update savedpenalties++;
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
                            playerGameweek.YellowCards += 1;
                        }
                        else if (detail == "Second Yellow card" || detail == "Red Card")
                        {
                            playerGameweek.RedCards += 1;

                            var playerStartedMatch = playerGameweek.InStartingLineup;

                            if (playerStartedMatch)
                            {
                                playerGameweek.MinutesPlayed = eventTime;
                            }
                            else //If the player was a substitute player which was substituted again
                            {
                                int minutesPlayed = eventTime - (90 - playerGameweek.MinutesPlayed);
                                playerGameweek.MinutesPlayed = minutesPlayed > 0 ? minutesPlayed : 0;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException($"Event detail '{detail}' is not valid.");
                        }
                    }
                    else if (type == EventType.Subst)
                    {
                        var playerStartedMatch = playerGameweek.InStartingLineup;

                        if (playerStartedMatch)
                        {
                            playerGameweek.MinutesPlayed = eventTime;
                        }
                        else //If the player was a substitute player which was substituted again
                        {
                            int minutesPlayed = eventTime - (90 - playerGameweek.MinutesPlayed);
                            playerGameweek.MinutesPlayed = minutesPlayed > 0 ? minutesPlayed : 0;
                        }

                        var substitutePlayerExternId = matchEvent.Assist.Id ?? 0;

                        if (this.playersIds.ContainsKey(substitutePlayerExternId))
                        {
                            var substitutePlayerGameweek = this.data
                                .PlayersGameweeks
                                .Where(pg => (pg.PlayerId == playersIds[substitutePlayerExternId] && pg.GameweekId == gameweekId))
                                .First();

                            substitutePlayerGameweek.MinutesPlayed = 90 - eventTime;
                        }
                    }
                    else if (type == EventType.Var) //TODO: Implement Goal cancelled and Penalty confirmed
                    {
                        continue;
                    }

                    await this.data.SaveChangesAsync();
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

            //TODO: If player is in starting lineup make its minutesPlayed 90
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
