using Football.App.APICalls;
using Football.App.ImportDto;
using Football.App.ImportDto.Event;
using Newtonsoft.Json;
using System.Text;

namespace Football.App.Services
{
    public class AdminServices : IAdminServices
    {
        public async Task<string[]> GetAllRounds(int league, int season)
        {
            if (!File.Exists($"rounds-{season}.json"))
            {
                await Getter.GetRoundsJson(league, season);
            }
            var roundsJson = await File.ReadAllTextAsync($"rounds-{season}.json");

            var roundsResponse = JsonConvert.DeserializeObject<ApiRoundsResponseDto>(roundsJson);

            return roundsResponse.Rounds;
        }

        public async Task<IEnumerable<FixtureInfoDto>> GetAllFixturesPerRound(string round, int year = 2021)
        {
            if (!File.Exists($"{round}.json"))
            {
                await Getter.GetFixturesByRound(round, year);
            }

            var fixturesJson = await File.ReadAllTextAsync($"{round}.json");

            var fixturesResponse = JsonConvert.DeserializeObject<ApiFixturesResponseDto>(fixturesJson);

            return fixturesResponse.FixturesInfo;
        }

        public async Task<IEnumerable<TeamLineupDto>> GetLineups(int fixtureId)
        {
            if (!File.Exists($"lineups-{fixtureId}.json"))
            {
                await Getter.GetLineupsJson(fixtureId);
            }

            var lineupsJson = await File.ReadAllTextAsync($"lineups-{fixtureId}.json");

            var lineups = JsonConvert.DeserializeObject<ApiFixtureLinupsDto>(lineupsJson);

            return lineups.Response.ToArray();
        }

        public async Task<IEnumerable<EventResponseDto>> GetFixtureEvents(int fixtureId)
        {
            if (!File.Exists($"fixture-{fixtureId}.json"))
            {
                await Getter.GetFixtureEventsJson(fixtureId);
            }

            var fixtureJson = await File.ReadAllTextAsync($"fixture-{fixtureId}.json");

            var fixtureInfo = JsonConvert.DeserializeObject<ApiEventResponseDto>(fixtureJson);

            return fixtureInfo.Response;
        }

        public async Task<IEnumerable<int>> GetFixturesIds(string round)
        {
            var ids = new List<int>();

            if (!File.Exists($"fixture-{round}.json"))
            {
                await Getter.GetFixturesByRound(round, 2021);
            }

            var fixturesJson = await File.ReadAllTextAsync($"fixture-{round}.json");

            var fixturesResponse = JsonConvert.DeserializeObject<ApiFixturesResponseDto>(fixturesJson);

            foreach (var fixtureInfo in fixturesResponse.FixturesInfo)
            {
                if (fixtureInfo.Fixture.Status.Status == "FT")
                {
                    ids.Add(fixtureInfo.Fixture.Id);
                }
            }

            return ids;
        }

    }
}
