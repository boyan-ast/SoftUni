using Newtonsoft.Json;

using Football.App.APICalls;
using Football.App.ImportDto;
using Football.App.ImportDto.Event;

namespace Football.App.Services
{
    public class AdminServices : IAdminServices
    {
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

        public async Task<ICollection<int>> GetFixturesIdsAsync(string roundName)
        {            
            return this.roundsFixtures[roundName];
        }
    }
}
