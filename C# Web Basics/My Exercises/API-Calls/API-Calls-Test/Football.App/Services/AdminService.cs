using Newtonsoft.Json;

using Football.App.APICalls;
using Football.App.ImportDto;
using Football.App.ImportDto.Event;
using Football.App.ImportDto.Teams;
using Football.App.ImportDto.Players;
using Football.App.Data;
using Football.App.ImportDto.Gameweeks;
using Football.App.ImportDto.Fixtures;
using Football.App.ImportDto.Lineups;

namespace Football.App.Services
{
    public class AdminService : IAdminService
    {
        //private const int leagueId = 172;
        //private const int season = 2021;


        private readonly IDictionary<string, ICollection<int>> roundsFixtures;
        private readonly ApplicationDbContext data;

        public AdminService(ApplicationDbContext data)
        {
            this.roundsFixtures = new Dictionary<string, ICollection<int>>();
            this.data = data;
        }

        public async Task<IEnumerable<TeamStadiumDto>> GetTeamsAndStadiumsJsonAsync(int leagueId, int season)
        {
            var json = await ApiWorker.GetAllTeamsAsync(leagueId, season);

            var teamsResponse = JsonConvert.DeserializeObject<ApiTeamsResponseDto>(json);


            if (teamsResponse.Results == 0)
            {
                throw new ArgumentException($"League {leagueId} in season {season} does not contain any teams.");
            }

            return teamsResponse.Response;
        }

        public async Task<TeamPlayersInfoDto> GetTeamSquadJsonAsync(int teamId)
        {
            var json = await ApiWorker.GetSquadAsync(teamId);

            var squadResponse = JsonConvert.DeserializeObject<ApiPlayersResponseDto>(json);

            if (squadResponse.Results == 0)
            {
                throw new ArgumentException($"Team {teamId} does not exist.");
            }

            return squadResponse.Response[0];
        }

        public async Task<string[]> GetAllRoundsAsync(int leagueId, int seasonId)
        {
            var roundsJson = await ApiWorker.GetRoundsJsonAsync(leagueId, seasonId);

            var roundsResponse = JsonConvert.DeserializeObject<ApiRoundsResponseDto>(roundsJson);

            return roundsResponse.Rounds;
        }

        public async Task<IEnumerable<FixtureInfoDto>> GetAllFixturesByGameweekAsync(int gameweek, int year = 2021)
        {
            var fixturesJson = await ApiWorker.GetFixturesByRoundAsync(gameweek, year);

            var fixturesResponse = JsonConvert.DeserializeObject<ApiFixturesResponseDto>(fixturesJson);

            return fixturesResponse.FixturesInfo;
        }

        public async Task<IEnumerable<TeamLineupDto>> GetLineupsAsync(int fixtureId)
        {
            var lineupsJson = await ApiWorker.GetLineupsJsonAsync(fixtureId);

            var lineups = JsonConvert.DeserializeObject<ApiFixtureLinupsDto>(lineupsJson);

            if (lineups.Results != 2)
            {
                throw new ArgumentException("Lineups have to be 2");
            }

            return lineups.Response;
        }

        public async Task<IEnumerable<EventResponseDto>> GetFixtureEventsAsync(int fixtureId)
        {
            var fixtureJson = await ApiWorker.GetFixtureEventsJsonAsync(fixtureId);

            var fixtureInfo = JsonConvert.DeserializeObject<ApiEventResponseDto>(fixtureJson);

            return fixtureInfo.Response;
        }

        public ICollection<int> GetFixturesIds(string roundName)
        {
            return this.roundsFixtures[roundName];
        }

        public async Task SetTeamsTopPlayers()
        {
            var topPlayersNumbers = new Dictionary<string, int>
            {
                { "Ludogorets", 11 },
                { "Botev Plovdiv", 8 },
                { "Levski Sofia", 7 },
                { "Cherno More Varna", 72 },
                { "CSKA Sofia", 2 },
                { "Slavia Sofia", 10 },
                { "Beroe", 30 },
                { "Lokomotiv Plovdiv", 14 },
                { "Botev Vratsa", 18 },
                { "Tsarsko Selo", 3 },
                { "Lokomotiv Sofia", 58 },
                { "CSKA 1948", 18 },
                { "Pirin Blagoevgrad", 29 },
                { "Arda Kardzhali", 17 }
            };

            var teams = this.data.Teams.ToList();
            var players = this.data.Players.ToList();

            foreach (var team in teams)
            {
                var player = this.data
                    .Players
                    .Where(p => p.TeamId == team.Id)
                    .FirstOrDefault(p => p.Number == topPlayersNumbers[team.Name]);

                team.TopPlayer = player;
            }

            await this.data.SaveChangesAsync();
        }
    }
}
