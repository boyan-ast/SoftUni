using Newtonsoft.Json;

using Football.App.APICalls;
using Football.App.ImportDto;
using Football.App.ImportDto.Event;
using Football.App.ImportDto.Teams;
using Football.App.ImportDto.Players;

namespace Football.App.Services
{
    public class AdminServices : IAdminServices
    {
        //private const int leagueId = 172;
        //private const int season = 2021;

        private readonly ICollection<int> leagues;
        private readonly ICollection<int> seasons;
        private readonly ICollection<string> rounds;
        private readonly IDictionary<string, ICollection<int>> roundsFixtures;
        private readonly ICollection<int> fixturesLineups;
        private readonly ICollection<int> fixturesEvents;

        public AdminServices()
        {
            this.leagues = new HashSet<int>();
            this.seasons = new HashSet<int>();
            this.rounds = new HashSet<string>();
            this.roundsFixtures = new Dictionary<string, ICollection<int>>();
            this.fixturesLineups = new HashSet<int>();
            this.fixturesEvents = new HashSet<int>();
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

            return squadResponse.Response;
        }

        public async Task<string[]> GetAllRoundsAsync(int leagueId, int seasonId)
        {

            if (this.leagues.Contains(leagueId) && this.seasons.Contains(seasonId))
            {
                throw new ArgumentException($"League {leagueId} for season {seasonId} already exists.");
            }

            var roundsJson = await ApiWorker.GetRoundsJsonAsync(leagueId, seasonId);

            this.leagues.Add(leagueId);
            this.seasons.Add(seasonId);

            var roundsResponse = JsonConvert.DeserializeObject<ApiRoundsResponseDto>(roundsJson);

            return roundsResponse.Rounds;
        }

        public async Task<IEnumerable<FixtureInfoDto>> GetAllFixturesByRoundAsync(string roundName, int year = 2021)
        {
            if (this.rounds.Contains(roundName))
            {
                throw new ArgumentException($"Round {roundName} already exists.");
            }

            var fixturesJson = await ApiWorker.GetFixturesByRoundAsync(roundName, year);

            var fixturesResponse = JsonConvert.DeserializeObject<ApiFixturesResponseDto>(fixturesJson);

            if (!roundsFixtures.ContainsKey(roundName))
            {
                roundsFixtures[roundName] = new HashSet<int>();
            }

            foreach (var fixtureInfo in fixturesResponse.FixturesInfo)
            {
                if (fixtureInfo.Fixture.Status.Status == "FT")
                {
                    roundsFixtures[roundName].Add(fixtureInfo.Fixture.Id);
                }
            }

            return fixturesResponse.FixturesInfo;
        }

        public async Task<IEnumerable<TeamLineupDto>> GetLineupsAsync(int fixtureId)
        {
            if (this.fixturesLineups.Contains(fixtureId))
            {
                throw new ArgumentException($"Lineups for fixture {fixtureId} already exist.");
            }

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
            if (this.fixturesEvents.Contains(fixtureId))
            {
                throw new ArgumentException($"Events for fixture {fixtureId} already exist.");
            }

            var fixtureJson = await ApiWorker.GetFixtureEventsJsonAsync(fixtureId);

            var fixtureInfo = JsonConvert.DeserializeObject<ApiEventResponseDto>(fixtureJson);

            return fixtureInfo.Response;
        }

        public ICollection<int> GetFixturesIds(string roundName)
        {
            return this.roundsFixtures[roundName];
        }
    }
}
