using Football.App.Common;
using RestSharp;

namespace Football.App.APICalls
{
    public static class Getter
    {
        private static RestClient client;

        public static async Task GetLineupsJson(int fixtureId)
        {
            var url = $"https://v3.football.api-sports.io/fixtures/lineups?fixture={fixtureId}";

            var response = await GetResponse(url);

            using (var sw = new StreamWriter($"lineups-{fixtureId}.json"))
            {
                await sw.WriteAsync(response.Content);
            }
        }

        public static async Task GetFixtureEventsJson(int fixtureId)
        {
            var url = $"https://v3.football.api-sports.io/fixtures/events?fixture={fixtureId}";

            var response = await GetResponse(url);

            using (var sw = new StreamWriter($"fixture-{fixtureId}.json"))
            {
                await sw.WriteAsync(response.Content);
            }
        }

        public static async Task GetRoundsJson(int league, int season)
        {
            var url = $"https://v3.football.api-sports.io/fixtures/rounds?season={season}&league={league}";

            var response = await GetResponse(url);

            using (var sw = new StreamWriter($"rounds-{season}.json"))
            {
                await sw.WriteAsync(response.Content);
            }
        }

        public static async Task GetLeaguesJson(string countryCode, int season)
        {
            var url = $"https://v3.football.api-sports.io/leagues?code={countryCode}&season={season}";            

            var response = await GetResponse(url);

            using (var sw = new StreamWriter("leagues.json"))
            {
                await sw.WriteAsync(response.Content);
            }
        }

        public static async Task GetFixturesByRound(string round, int season)
        {
            var url = $"https://v3.football.api-sports.io/fixtures?season={season}&round={round}&league=172";

            var response = await GetResponse(url);

            using (var sw = new StreamWriter($"{round}.json"))
            {
                await sw.WriteAsync(response.Content);
            }
        }

        private static async Task<RestResponse> GetResponse(string url)
        {
            client = new RestClient(url);
            var request = new RestRequest();

            var authHeader = new Header("x-apisports-key", Constants.Key);
            var headers = new List<Header>();
            headers.Add(authHeader);

            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            return await client.ExecuteGetAsync(request);
        }
    }
}
