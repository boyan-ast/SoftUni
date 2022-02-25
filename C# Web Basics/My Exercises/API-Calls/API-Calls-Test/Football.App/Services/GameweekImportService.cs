using Football.App.Data;
using Football.App.Data.Models;
using Football.App.Data.Models.Enums;
using Football.App.Services.Enums;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Football.App.Services
{
    public class GameweekImportService : IGameweekImportService
    {
        private readonly IFootballDataService footballDataService;
        private readonly ApplicationDbContext data;
        private readonly IDictionary<int, int> playersIds;

        public GameweekImportService(
            IFootballDataService adminService,
            ApplicationDbContext data)
        {
            this.footballDataService = adminService;
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

        public async Task ImportFixtures(int gameweek, int season)
        {
            var fixturesInfo = await this.footballDataService.GetAllFixturesByGameweekAsync(gameweek, season);

            foreach (var fixtureDto in fixturesInfo)
            {
                var externId = fixtureDto.Fixture.Id;
                var fixtureGameweek = this.data.Gameweeks.FirstOrDefault(gw => gw.Number == gameweek);
                var fixtureDate = this.ParseFixtureDate(fixtureDto.Fixture.Date.Split("T")[0]);
                var homeTeamId = this.data.Teams.FirstOrDefault(t => t.ExternId == fixtureDto.Teams.HomeTeam.Id).Id;
                var awayTeamId = this.data.Teams.FirstOrDefault(t => t.ExternId == fixtureDto.Teams.AwayTeam.Id).Id;
                var status = fixtureDto.Fixture.Status.Status;
                var homeGoals = fixtureDto.Goals.HomeGoals;
                var awayGoals = fixtureDto.Goals.AwayGoals;

                var newFixture = new Fixture
                {
                    ExternId = externId,
                    Gameweek = fixtureGameweek,
                    Date = fixtureDate,
                    HomeTeamId = homeTeamId,
                    AwayTeamId = awayTeamId,
                    Status = status,
                    HomeGoals = homeGoals,
                    AwayGoals = awayGoals
                };

                await this.data.Fixtures.AddAsync(newFixture);
            }

            await this.data.SaveChangesAsync();
        }

        public async Task ImportLineups(int gameweekNumber)
        {
            var fixturesInGameweek = await this.data
                .Fixtures
                .Where(f => f.GameweekId == gameweekNumber)
                .ToListAsync();

            var gameweekId = (await this.data
                .Gameweeks
                .FirstOrDefaultAsync(gw => gw.Number == gameweekNumber))
                .Id;

            var allPlayersInGameweekExternIds = new HashSet<int>();

            foreach (var fixture in fixturesInGameweek)
            {
                var lineupsResult = (await this.footballDataService
                    .GetLineupsAsync(fixture.ExternId))
                    .ToList();

                var homeTeamLineupExternIds = lineupsResult[0]
                    .StartXI
                    .Select(p => p.Player.PlayerId);

                var homeTeamSubstitutesExternIds = lineupsResult[0]
                    .Substitutes
                    .Select(p => p.Player.PlayerId);

                var awayTeamLineupExternIds = lineupsResult[1]
                    .StartXI
                    .Select(p => p.Player.PlayerId);

                var awayTeamSubstitutesExternIds = lineupsResult[1]
                    .Substitutes
                    .Select(p => p.Player.PlayerId);

                var startedPlayers = homeTeamLineupExternIds.Union(awayTeamLineupExternIds);
                var reservePlayers = homeTeamSubstitutesExternIds.Union(awayTeamSubstitutesExternIds);
                var allPlayers = startedPlayers.Union(reservePlayers);

                var allPlayersInFixture =
                    PlayersInitialAdding(
                        allPlayers,
                        startedPlayers,
                        gameweekId,
                        allPlayersInGameweekExternIds);

                await this.data.PlayersGameweeks.AddRangeAsync(allPlayersInFixture);
                await this.data.SaveChangesAsync();

                allPlayersInGameweekExternIds.UnionWith(allPlayers);
            }
        }

        public async Task ImportEvents(int gameweekNumber)
        {
            var fixturesInGameweek = await this.data
                .Fixtures
                .Where(f => f.GameweekId == gameweekNumber)
                .ToListAsync();

            var gameweekId = (await this.data
                .Gameweeks
                .FirstOrDefaultAsync(gw => gw.Number == gameweekNumber))?
                .Id;

            var playersInGameweek = await this.data
                .PlayersGameweeks
                .Include(pg => pg.Player)
                .ThenInclude(p => p.Team)
                .Where(p => p.GameweekId == gameweekId)
                .ToListAsync();

            this.SetIsPlayingForAllPlayersInGameweek(playersInGameweek);

            foreach (var fixture in fixturesInGameweek)
            {
                var fixtureEvents = (await this.footballDataService
                    .GetFixtureEventsAsync(fixture.ExternId))
                    .ToList();

                var homeTeamExternId = fixture.HomeTeam.ExternId;
                var awayTeamExternId = fixture.AwayTeam.ExternId;

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

                    var oponentTeamExternId = matchEvent.Team.Id == homeTeamExternId ?
                        awayTeamExternId : homeTeamExternId;

                    var detail = matchEvent.Detail;

                    var playerExternId = matchEvent.Player.Id;


                    if (!this.playersIds.ContainsKey(playerExternId))
                    {
                        continue;
                    }

                    var player = playersInGameweek
                        .FirstOrDefault(p => p.PlayerId == playersIds[playerExternId]);

                    if (player == null)
                    {
                        continue;
                    }

                    if (type == EventType.Goal)
                    {
                        if (detail == "Normal Goal" || detail == "Penalty")
                        {
                            player.Goals += 1;

                            UpdateConcededGoalsOfPlayers(oponentTeamExternId, playersInGameweek);
                        }
                        else if (detail == "Own Goal")
                        {
                            player.OwnGoals += 1;

                            UpdateConcededGoalsOfPlayers(matchEvent.Team.Id, playersInGameweek);
                        }
                        else if (detail == "Missed Penalty")
                        {
                            player.MissedPenalties += 1;

                            var oponentGoalkeeper = playersInGameweek
                                .Where(p => p.Player.Team.ExternId == oponentTeamExternId)
                                .Where(p => p.Player.Position == Position.Goalkeeper)
                                .Where(p => p.IsPlaying)
                                .First();

                            oponentGoalkeeper.SavedPenalties += 1;
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
                            player.YellowCards += 1;
                        }
                        else if (detail == "Second Yellow card" || detail == "Red Card")
                        {
                            player.RedCards += 1;
                            player.IsPlaying = false;

                            var playerStartedMatch = player.InStartingLineup;

                            if (playerStartedMatch)
                            {
                                player.MinutesPlayed = eventTime;
                            }
                            else //If the player was a substitute player which was substituted again
                            {
                                int minutesPlayed = eventTime - (90 - player.MinutesPlayed);
                                player.MinutesPlayed = minutesPlayed > 0 ? minutesPlayed : 0;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException($"Event detail '{detail}' is not valid.");
                        }
                    }
                    else if (type == EventType.Subst)
                    {
                        var playerStartedMatch = player.InStartingLineup;
                        player.IsPlaying = false;

                        if (playerStartedMatch)
                        {
                            player.MinutesPlayed = eventTime > 90 ? 90 : eventTime;
                        }
                        else //If the player was a substitute player which was substituted again
                        {
                            int minutesPlayed = eventTime - (90 - player.MinutesPlayed);
                            player.MinutesPlayed = minutesPlayed > 0 ? minutesPlayed : 0;
                        }

                        var substitutePlayerExternId = matchEvent.Assist.Id ?? 0;

                        if (this.playersIds.ContainsKey(substitutePlayerExternId))
                        {
                            var substitutePlayerGameweek = playersInGameweek
                                .Where(pg => (pg.PlayerId == playersIds[substitutePlayerExternId] && pg.GameweekId == gameweekId))
                                .First();

                            var minutesPlayed = 90 - eventTime;
                            substitutePlayerGameweek.MinutesPlayed = minutesPlayed < 0 ?
                                0 : minutesPlayed;

                            substitutePlayerGameweek.IsPlaying = true;
                        }
                    }
                    else if (type == EventType.Var) //TODO: Implement Goal cancelled and Penalty confirmed
                    {
                        continue;
                    }
                }

                if (fixture.HomeGoals > 0)
                {
                    UpdateCleanSheetOfPlayers(awayTeamExternId, playersInGameweek);
                }

                if (fixture.AwayGoals > 0)
                {
                    UpdateCleanSheetOfPlayers(homeTeamExternId, playersInGameweek);
                }

                if (fixture.HomeGoals > fixture.AwayGoals)
                {
                    UpdatePlayersTeamResult(homeTeamExternId, awayTeamExternId, playersInGameweek);
                }
                else if (fixture.HomeGoals < fixture.AwayGoals)
                {
                    UpdatePlayersTeamResult(awayTeamExternId, homeTeamExternId, playersInGameweek);
                }
                else
                {
                    UpdatePlayersTeamResult(homeTeamExternId, awayTeamExternId, playersInGameweek, true);
                }

                await this.data.SaveChangesAsync();
            }
        }

        private void UpdatePlayersTeamResult(int winnerExternId, int opponentExternId, List<PlayerGameweek> playersInGameweek, bool isDraw = false)
        {
            if (!isDraw)
            {
                var winnerTeamPlayers = playersInGameweek
                    .Where(pg => pg.Player.Team.ExternId == winnerExternId);

                var opponentTeamPlayers = playersInGameweek
                    .Where(pg => pg.Player.Team.ExternId == opponentExternId);

                foreach (var player in winnerTeamPlayers)
                {
                    player.TeamResult = TeamResult.Won;
                }

                foreach (var player in opponentTeamPlayers)
                {
                    player.TeamResult = TeamResult.Lost;
                }
            }
            else
            {
                var playersInFixture = playersInGameweek
                    .Where(pg => pg.Player.Team.ExternId == winnerExternId
                        || pg.Player.Team.ExternId == opponentExternId);

                foreach (var player in playersInFixture)
                {
                    player.TeamResult = TeamResult.Draw;
                }
            }

        }

        private void UpdateCleanSheetOfPlayers(
            int teamExternId,
            List<PlayerGameweek> playersInGameweek)
        {
            var teamPlayers = playersInGameweek
                .Where(pg => pg.Player.Team.ExternId == teamExternId)
                .Where(p => p.MinutesPlayed > 0);

            foreach (var player in teamPlayers)
            {
                player.CleanSheet = false;
            }
        }

        private void UpdateConcededGoalsOfPlayers(int teamExternId, List<PlayerGameweek> playersInGameweek)
        {
            var teamPlayers = playersInGameweek
                .Where(pg => pg.Player.Team.ExternId == teamExternId)
                .Where(p => p.IsPlaying);

            foreach (var player in teamPlayers)
            {
                player.ConcededGoals++;
            }
        }

        private void SetIsPlayingForAllPlayersInGameweek(IEnumerable<PlayerGameweek> players)
        {
            foreach (var player in players)
            {
                if (player.InStartingLineup)
                {
                    player.IsPlaying = true;
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
                if (!this.playersIds.ContainsKey(playerExternId)
                    || allPlayersInGameweekExternIds.Contains(playerExternId))
                {
                    continue;
                }

                var player = new PlayerGameweek
                {
                    PlayerId = this.playersIds[playerExternId],
                    GameweekId = gameweekId,
                    InStartingLineup = startedPlayers.Contains(playerExternId),
                    IsSubstitute = !startedPlayers.Contains(playerExternId),
                    MinutesPlayed = startedPlayers.Contains(playerExternId) ? 90 : 0,
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

        private DateTime ParseFixtureDate(string dateString)
        {
            DateTime.TryParseExact(
                dateString,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime date);

            return date;
        }
    }
}
